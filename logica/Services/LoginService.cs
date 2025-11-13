using System;
using System.Threading.Tasks;

namespace Logica.Services
{
    public class LoginService
    {
        public async Task<int> LoginUsuarioAsync(string username, string password)
        {
            // En este caso no hay operaciones asíncronas
            await Task.Yield();

            if (username == "admin" && password == "123")
            {
                return 1; // Login exitoso
            }
            else
            {
                return 0; // Credenciales incorrectas
            }
        }
    }
}
