using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Claims;
using TacoslaEnredada_JRMJSC.Models;
using TacoslaEnredada_JRMJSC.Services;

namespace TacoslaEnredada_JRMJSC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(Usuario usuario)
        {
            // Encrypt the password first
            usuario.Clave = Utilidades.EncriptarClave(usuario.Clave);

            // Try to find an existing user by email or cedula
            Usuario usuarioExistente = await _usuarioService.GetUsuario(usuario.Correo, usuario.Cedula);

            // Check if the user already exists by email
            if (usuarioExistente != null && usuarioExistente.Correo == usuario.Correo)
            {
                ViewData["Mensaje"] = "Ya existe un usuario con el mismo correo electrónico.";
                return View(usuario); // Return the same view with an error message
            }

            // Check if the user already exists by cedula
            else if (usuarioExistente != null && usuarioExistente.Cedula == usuario.Cedula)
            {
                ViewData["Mensaje"] = "Ya existe un usuario con la misma cédula.";
                return View(usuario); // Return the same view with an error message
            }

            // If no user exists with the same email or cedula, create a new user
            Usuario usuarioCreado = await _usuarioService.SetUsuario(usuario);
            if (usuarioCreado != null && usuarioCreado.UsuarioID > 0)
            {
                return RedirectToAction("IniciarSesion", "Login");
            }

            // If user creation fails, show a generic error message
            ViewData["Mensaje"] = "No se pudo crear el usuario. Intente nuevamente.";
            return View(usuario);
        }



        [HttpGet]
        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string clave)
        {
            Usuario usuarioEncontrado = await _usuarioService.GetUsuario(correo, Utilidades.EncriptarClave(clave));

            if (usuarioEncontrado == null)
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }

            List<Claim> claims = new List<Claim>()
    {
        new Claim(ClaimTypes.Name, usuarioEncontrado.Nombre)
    };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
            );

            return RedirectToAction("Index", "Home");
        }



    }
}
