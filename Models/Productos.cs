using System.ComponentModel.DataAnnotations;

namespace TacoslaEnredada_JRMJSC.Models
{
    public class Productos
    {
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Range(0.01, 10.99)]
        public decimal Precio { get; set; }
        [Required]
        public string? Ingredientes { get; set; }
        [Display(Name = "Ruta de la imagen")]
        public string? RutaImagen { get; set; }
    }
}
