using System.ComponentModel.DataAnnotations;

namespace Unit8Practice.Attributes
{  
    internal class Movie
    {
        [Required(AllowEmptyStrings = true)]
        public string Title { get; set; }

        [Range(2000, 2022)]
        public int Year { get; set; }

        [Required]
        [Range(0.0, 5000.0, ErrorMessage = "BoxOfficeMillions must be between $0 and $5000 million ($5 billion)")]
        public decimal? BoxOfficeMillions { get; set; }

        [Required]
        [Range(typeof(DateTime), minimum: "2000-01-01", maximum: "2050-01-01")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [RegularExpression("[A-Z]{3}[0-9]{3}", ErrorMessage = "Doesn't match pattern. Valid example: ABC123")]    
        public string Id { get; set; }

        [StringLength(13)]
        public string Director { get; set; }

    }
}
