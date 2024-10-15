using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPageMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        //================================================================================
        
        [StringLength(60), MinLength(3)]
        [Required]
        public string? Title { get; set; }
        //================================================================================
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s]*$")]
        [RegularExpression(@"^[A-Z][a-zA-Z0-9'""\s]*$")]
        [StringLength(100)]
        public string? Description { get; set; }
        //================================================================================
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(60)]
        [Required]
        public string? Author { get; set; }  //El simbolo de interrogación es para que acepte valores nulos
        //================================================================================
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)] // aqui usamos la DataAnnotations
        [Required]
        public DateTime RelaseDate { get; set; } // usamos la etiqueta de arriba para decir que este valor es date time
        //================================================================================
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Genre { get; set; }
        //================================================================================
        [Range(1,100)]
        [DataType(DataType.Currency)]
        [Column(TypeName ="decimal(18,2)")]
        [Required]
        public decimal? Price { get; set; }
        //================================================================================
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s]*$")]
        [Required]
        [StringLength(5)]
        public string? Rating { get; set; }
    }
}
