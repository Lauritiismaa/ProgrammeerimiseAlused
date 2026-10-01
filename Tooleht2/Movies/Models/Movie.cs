using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;

public class Movie
{
    public int Id { get; set; }

    [Required, StringLength(60, MinimumLength = 3)]
    [Display(Name = "Pealkiri")]
    public string Title { get; set; } = "";

    [DataType(DataType.Date), Display(Name = "Ilmumiskuupäev")]
    public DateTime ReleaseDate { get; set; }

    [Required, StringLength(30)]
    [RegularExpression(@"^[A-ZÕÄÖÜ][a-zA-ZõäöüÕÄÖÜ\s]*$")]
    [Display(Name = "Žanr")]
    public string Genre { get; set; } = "";

    [Range(1, 100), DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)"), Display(Name = "Hind")]
    public decimal Price { get; set; }

    [Required, StringLength(5)]
    [RegularExpression(@"^[A-Z][a-zA-Z0-9\s-]*$")]
    [Display(Name = "Vanusepiirang")]
    public string Rating { get; set; } = "";
}
