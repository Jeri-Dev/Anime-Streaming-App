using Database.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class SerieViewModel
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? ImagePath { get; set; }
        [Required]
        public string? VideoPath { get; set; }
        [Required(ErrorMessage ="Debe de colocar una productora")]
        public int ProductoraId { get; set; }

        public Productora? Productora { get; set; }

        public string? ProductoraName { get; set; }
        [Required(ErrorMessage = "Debe de colocar un genero")]

        public int GeneroId { get; set; }
        public string? GeneroName { get; set; }


    }
}
