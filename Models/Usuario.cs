using System.ComponentModel.DataAnnotations;
using TacoslaEnredada_JRMJSC.Models.CustomValidations;

namespace TacoslaEnredada_JRMJSC.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set;  }

        [Required (ErrorMessage = "El nombre es obligatorio")]
        public string? Nombre { get; set; }
        [EmailAddress (ErrorMessage = "El correo debe ser una direccion valida")]
        public string? Correo { get; set; }
        [CedulaEcuatoriana]
        public string? Cedula { get; set; }
        [Required (ErrorMessage = "Debe Ingresar una Clave")]
        public string? Clave {  get; set; } 

    }
}
