﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPageMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        [Display(Name = "Realese Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Genre { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        
        public decimal Price { get; set; }
        [Required]
        public string? Rating { get; set; }
    }
}