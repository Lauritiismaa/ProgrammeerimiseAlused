namespace Kodutoo2;

// Üks RSS-voost loetud uudis.
public class RssItem
{
    public string Title { get; set; } = "";
    public string Link { get; set; } = "";
    public string Description { get; set; } = "";
    public string Publisher { get; set; } = "";
    public DateTimeOffset PublishedAt { get; set; } = DateTimeOffset.MinValue;
}
