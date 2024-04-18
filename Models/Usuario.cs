using System.ComponentModel.DataAnnotations;
using TacoslaEnredada_JRMJSC.Models.CustomValidations;

namespace TacoslaEnredada_JRMJSC.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set;  }

        [Required (ErrorMessage = "El nombre es obligatorio")]
        public string? nombre { get; set; }
        [EmailAddress (ErrorMessage = "El correo debe ser una direccion valida")]
        public string? correo { get; set; }
        [CedulaEcuatoriana]
        public string? cedula { get; set; }

    }
}
