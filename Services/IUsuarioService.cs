using TacoslaEnredada_JRMJSC.Models;

namespace TacoslaEnredada_JRMJSC.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string correo, string clave);
        Task<Usuario> SetUsuario (Usuario usuario);
    }
}
