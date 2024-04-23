using Microsoft.EntityFrameworkCore;
using TacoslaEnredada_JRMJSC.Models;
using System.Threading.Tasks;
using System.Linq;

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
            return await _context.Usuario
                .Where(u => u.Correo == correo && u.Clave == clave)
                .FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetUsuarioByEmailorCedula(string email, string cedula)
        {
            return await _context.Usuario
                .Where(u => u.Correo == email || u.Cedula == cedula)
                .FirstOrDefaultAsync();
        }

        public async Task<Usuario> SetUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
