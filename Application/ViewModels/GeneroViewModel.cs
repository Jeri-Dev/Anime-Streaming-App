using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class GeneroViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe de agreagar un nombre")]
        public string Name { get; set; }
    }
}