using Microsoft.AspNetCore.Mvc;
using Logica.Services;
using logica.Model;
using System.Threading.Tasks;

namespace Logica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        // Inyectamos el servicio por constructor
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] Login request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Usuario o contraseña vacíos.");
            }

            var resultado = await _loginService.LoginUsuarioAsync(request.Username, request.Password);

            if (resultado == 1)
            {
                return Ok(new { mensaje = "Inicio de sesión exitoso." });
            }
            else
            {
                return Unauthorized(new { mensaje = "Credenciales incorrectas." });
            }
        }
    }
}
