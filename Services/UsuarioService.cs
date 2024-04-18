using Microsoft.EntityFrameworkCore;
using TacoslaEnredada_JRMJSC.Models;
namespace TacoslaEnredada_JRMJSC.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioDb _context;

        public UsuarioService(UsuarioDb context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuario = await _context.Usuario.Where(u => u.Correo == correo && u.Clave == clave).FirstOrDefaultAsync();
            return usuario;

        }

        public async Task<Usuario> SetUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
