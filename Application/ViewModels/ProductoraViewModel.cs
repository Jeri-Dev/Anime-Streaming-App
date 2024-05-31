using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class ProductoraViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe de colocar un nombre de productora")]
        public string Name { get; set; }

        
    }
}