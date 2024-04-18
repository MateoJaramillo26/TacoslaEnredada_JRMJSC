using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TacoslaEnredada_JRMJSC.Models.CustomValidations
{
    public class CedulaEcuatorianaAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var cedula = value as string;
            if (string.IsNullOrEmpty(cedula))
            {
                ErrorMessage = "La cédula es requerida.";
                return false;
            }

            if (cedula.Length != 10 || !cedula.All(char.IsDigit))
            {
                ErrorMessage = "La cédula debe ser un número de 10 dígitos.";
                return false;
            }

            int provincia = int.Parse(cedula.Substring(0, 2));
            int tercerDigito = int.Parse(cedula[2].ToString());

            if (provincia < 1 || provincia > 24 || tercerDigito > 5)
            {
                ErrorMessage = "La cédula contiene un código de provincia inválido o un tercer dígito incorrecto.";
                return false;
            }

            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int suma = 0;

            for (int i = 0; i < coeficientes.Length; i++)
            {
                int valor = coeficientes[i] * int.Parse(cedula[i].ToString());
                suma += valor > 9 ? valor - 9 : valor;
            }

            int digitoVerificador = suma % 10 == 0 ? 0 : 10 - suma % 10;

            if (digitoVerificador != int.Parse(cedula[9].ToString()))
            {
                ErrorMessage = "El dígito verificador no es válido.";
                return false;
            }

            return true;
        }
    }
}