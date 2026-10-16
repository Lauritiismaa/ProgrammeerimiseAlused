using System.Collections.Concurrent;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using Kodutoo2;

internal static class Program
{
    // Kodutöö juhendis soovitatud Eesti uudiste RSS-vood.
    private static readonly (string Publisher, string Address)[] Feeds =
    {
        ("Postimees", "https://www.postimees.ee/rss"),
        ("Lääne Elu", "https://online.le.ee/feed/"),
        ("Äripäev", "https://feeds.feedburner.com/aripaev-rss"),
        ("ERR", "https://www.err.ee/rss")
    };

    // Ühte HttpClienti saab kasutada kõigi päringute jaoks.
    private static readonly HttpClient Client = new()
    {
        Timeout = TimeSpan.FromSeconds(20)
    };

    private static readonly CultureInfo EstonianCulture = new("et-EE");

    private static async Task<int> Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; Kodutoo2/1.0)");

        bool compare = args.Contains("--vordle", StringComparer.OrdinalIgnoreCase);
        bool parallel = args.Contains("--paralleelselt", StringComparer.OrdinalIgnoreCase);

        Console.WriteLine("RSS-uudiste agregaator – Lauri Tiismaa");
        Console.WriteLine($"Uudisvooge: {Feeds.Length}. Väljund: 20 viimast uudist.\n");

        if (compare)
        {
            // Lisaharjutus: mõõdame järjestikuse ja paralleelse lahenduse kiirust.
            Console.WriteLine("1. Järjestikune RSS-voogude lugemine");
            Stopwatch sequentialTotal = Stopwatch.StartNew();
            Stopwatch sequentialRead = Stopwatch.StartNew();
            List<RssItem> sequentialItems = await ReadSequentiallyAsync();
            sequentialRead.Stop();
            int sequentialCount = await SaveTopNewsAsync(sequentialItems, "uudised_jarjest.html");
            sequentialTotal.Stop();

            Console.WriteLine("\n2. Paralleelne RSS-voogude lugemine");
            Stopwatch parallelTotal = Stopwatch.StartNew();
            Stopwatch parallelRead = Stopwatch.StartNew();
            List<RssItem> parallelItems = await ReadInParallelAsync();
            parallelRead.Stop();
            int parallelCount = await SaveTopNewsAsync(parallelItems, "uudised.html");
            parallelTotal.Stop();

            Console.WriteLine("\nKIIRUSE VÕRDLUS");
            Console.WriteLine($"Järjestikku – lugemine: {sequentialRead.Elapsed.TotalSeconds:F2} s; " +
                              $"kokku: {sequentialTotal.Elapsed.TotalSeconds:F2} s");
            Console.WriteLine($"Paralleelselt – lugemine: {parallelRead.Elapsed.TotalSeconds:F2} s; " +
                              $"kokku: {parallelTotal.Elapsed.TotalSeconds:F2} s");
            if (parallelRead.Elapsed.TotalMilliseconds > 0)
            {
                double speedup = sequentialRead.Elapsed.TotalMilliseconds / parallelRead.Elapsed.TotalMilliseconds;
                Console.WriteLine($"RSS-lugemise kiiruse suhe: {speedup:F2} korda " +
                                  "(suurem kui 1 tähendab, et paralleelne lugemine oli kiirem)");
            }
            Console.WriteLine("NB! Võrguühendus ja serverite koormus võivad mõõtmist mõjutada.");
            return sequentialCount > 0 || parallelCount > 0 ? 0 : 1;
        }

        Stopwatch total = Stopwatch.StartNew();
        Stopwatch reading = Stopwatch.StartNew();
        List<RssItem> items = parallel
            ? await ReadInParallelAsync()
            : await ReadSequentiallyAsync();
        reading.Stop();

        int savedCount = await SaveTopNewsAsync(items, "uudised.html");
        total.Stop();

        Console.WriteLine($"RSS-voogude lugemine: {reading.Elapsed.TotalSeconds:F2} s");
        Console.WriteLine($"Kogu programmi töö: {total.Elapsed.TotalSeconds:F2} s");
        return savedCount > 0 ? 0 : 1;
    }

    // Kohustuslik osa: loeme iga uudisvoo üksteise järel ja kasutame List<RssItem>.
    private static async Task<List<RssItem>> ReadSequentiallyAsync()
    {
        List<RssItem> items = new();

        foreach (var feed in Feeds)
        {
            List<RssItem> feedItems = await ReadFeedAsync(feed.Publisher, feed.Address);
            items.AddRange(feedItems);
        }

        return items;
    }

    // Valikuline lisaharjutus: Task.Run + Task.WhenAll + ConcurrentBag.
    // ConcurrentBag lubab mitmel ülesandel korraga uudiseid lisada.
    private static async Task<List<RssItem>> ReadInParallelAsync()
    {
        ConcurrentBag<RssItem> items = new();

        Task[] tasks = Feeds.Select(feed => Task.Run(async () =>
        {
            List<RssItem> feedItems = await ReadFeedAsync(feed.Publisher, feed.Address);
            foreach (RssItem item in feedItems)
            {
                items.Add(item);
            }
        })).ToArray();

        await Task.WhenAll(tasks);
        return items.ToList();
    }

    // Laeme ühe XML-põhise RSS- või Atom-uudisvoo internetist.
    private static async Task<List<RssItem>> ReadFeedAsync(string publisher, string url)
    {
        List<RssItem> items = new();
        try
        {
            using HttpResponseMessage response = await Client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            await using Stream stream = await response.Content.ReadAsStreamAsync();
            XmlReaderSettings settings = new()
            {
                DtdProcessing = DtdProcessing.Prohibit,
                XmlResolver = null,
                MaxCharactersInDocument = 10_000_000
            };

            using XmlReader reader = XmlReader.Create(stream, settings);
            XDocument document = XDocument.Load(reader);

            // RSS kasutab <item>, Atom <entry> elemente.
            IEnumerable<XElement> entries = document.Descendants()
                .Where(element => element.Name.LocalName is "item" or "entry");

            foreach (XElement entry in entries)
            {
                string title = ReadElement(entry, "title");
                string link = ReadLink(entry);
                string description = CleanDescription(ReadElement(entry, "description", "summary", "encoded", "content"));
                string rawDate = ReadElement(entry, "pubDate", "published", "updated", "date");

                if (string.IsNullOrWhiteSpace(title) || !IsValidHttpUrl(link))
                    continue;

                DateTimeOffset publishedAt = DateTimeOffset.TryParse(
                    rawDate, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces,
                    out DateTimeOffset parsedDate)
                    ? parsedDate
                    : DateTimeOffset.MinValue;

                items.Add(new RssItem
                {
                    Title = title,
                    Link = link,
                    Description = description,
                    Publisher = publisher,
                    PublishedAt = publishedAt
                });
            }

            Console.WriteLine($"{publisher}: loetud {items.Count} uudist.");
        }
        catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException or XmlException or IOException)
        {
            // Ühe väljaande tõrge ei katkesta ülejäänud RSS-voogude lugemist.
            Console.WriteLine($"HOIATUS: {publisher} RSS-voogu ei õnnestunud lugeda: {ex.Message}");
        }
        return items;
    }

    private static string ReadElement(XElement parent, params string[] names)
    {
        XElement? element = parent.Elements().FirstOrDefault(e =>
            names.Contains(e.Name.LocalName, StringComparer.OrdinalIgnoreCase));
        return element?.Value.Trim() ?? "";
    }

    private static string ReadLink(XElement entry)
    {
        // RSS: <link>https://...</link>
        // Atom: <link rel="alternate" href="https://..." />
        IEnumerable<XElement> links = entry.Elements()
            .Where(e => e.Name.LocalName == "link");

        foreach (XElement link in links)
        {
            string? relation = link.Attribute("rel")?.Value;
            if (relation is not null && relation != "alternate")
                continue;

            string address = (link.Attribute("href")?.Value ?? link.Value).Trim();
            if (IsValidHttpUrl(address))
                return address;
        }
        return "";
    }

    private static bool IsValidHttpUrl(string address)
    {
        return Uri.TryCreate(address, UriKind.Absolute, out Uri? uri)
               && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
    }

    private static string CleanDescription(string html)
    {
        // RSS-i kirjeldus võib sisaldada HTML-märgendeid.
        string decoded = WebUtility.HtmlDecode(html);
        string noTags = Regex.Replace(decoded, "<[^>]*>", " ");
        string cleaned = Regex.Replace(noTags, @"\s+", " ").Trim();
        return cleaned.Length <= 500 ? cleaned : cleaned[..500] + "…";
    }

    private static List<RssItem> LatestTwenty(List<RssItem> items)
    {
        // Eemaldame kattuvad uudised (sama link), järjestame aja järgi ja võtame 20.
        return items
            .GroupBy(item => item.Link, StringComparer.OrdinalIgnoreCase)
            .Select(group => group.First())
            .OrderByDescending(item => item.PublishedAt)
            .Take(20)
            .ToList();
    }

    private static async Task<int> SaveTopNewsAsync(List<RssItem> allNews, string fileName)
    {
        List<RssItem> news = LatestTwenty(allNews);
        if (news.Count == 0)
        {
            Console.WriteLine("Ühtegi uudist ei leitud. Kontrolli internetiühendust ja RSS-aadresse.");
            return 0;
        }

        string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);

        // FileStream, StreamWriter, using ja foreach vastavalt kodutöö vihjetele.
        await using FileStream file = new(path, FileMode.Create, FileAccess.Write, FileShare.None);
        await using StreamWriter writer = new(file, new UTF8Encoding(false));

        await writer.WriteLineAsync("""
            <!DOCTYPE html>
            <html lang="et">
            <head>
                <meta charset="utf-8">
                <meta name="viewport" content="width=device-width, initial-scale=1">
                <title>20 viimast uudist</title>
                <style>
                    :root { font-family: Arial, Helvetica, sans-serif; color: #1d2939; background: #f4f6fb; }
                    body { max-width: 900px; margin: 30px auto; padding: 0 18px; }
                    h1 { color: #172c54; }
                    .info { color: #667085; margin-bottom: 25px; }
                    ul { list-style: none; padding: 0; }
                    li { margin-bottom: 14px; padding: 18px 22px; border-radius: 10px;
                         background: white; box-shadow: 0 2px 12px #172c5414; }
                    li a { color: #1763aa; font-size: 1.15rem; font-weight: bold; text-decoration: none; }
                    li a:hover { text-decoration: underline; }
                    .meta { color: #667085; font-size: .9rem; margin: 9px 0; }
                    .description { margin: 0; line-height: 1.55; }
                </style>
            </head>
            <body>
                <h1>20 viimast uudist</h1>
                <p class="info">Uudised on kogutud mitmest Eesti RSS-voost ja järjestatud avaldamisaja järgi.</p>
                <ul>
            """);

        foreach (RssItem item in news)
        {
            string title = WebUtility.HtmlEncode(item.Title);
            string link = WebUtility.HtmlEncode(item.Link);
            string publisher = WebUtility.HtmlEncode(item.Publisher);
            string description = WebUtility.HtmlEncode(item.Description);
            string date = item.PublishedAt == DateTimeOffset.MinValue
                ? "Avaldamise aeg puudub"
                : item.PublishedAt.ToLocalTime().ToString("dd.MM.yyyy HH:mm", EstonianCulture);

            await writer.WriteLineAsync("<li>");
            await writer.WriteLineAsync($"  <a href=\"{link}\" target=\"_blank\" rel=\"noopener noreferrer\">{title}</a>");
            await writer.WriteLineAsync($"  <div class=\"meta\">{date} | {publisher}</div>");
            await writer.WriteLineAsync($"  <p class=\"description\">{description}</p>");
            await writer.WriteLineAsync("</li>");
        }

        await writer.WriteLineAsync("""
                </ul>
            </body>
            </html>
            """);
        Console.WriteLine($"Salvestatud {news.Count} uudist: {path}");
        return news.Count;
    }
}
