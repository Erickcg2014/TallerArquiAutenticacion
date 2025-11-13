using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;

namespace presentacion.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string? Username { get; set; }

        [BindProperty]
        public string? Password { get; set; }

        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _httpClientFactory.CreateClient();

            // Construir el JSON a enviar
            var body = new
            {
                username = Username,
                password = Password
            };

            try
            {
                // Ejecución del POST
                var response = await client.PostAsJsonAsync(
                    "http://logica-service/api/login/autenticar",
                    body
                );


                if (!response.IsSuccessStatusCode)
                {
                    TempData["Mensaje"] = "Error: servidor devolvió estado inválido.";
                    TempData["EsError"] = true;
                    return RedirectToPage("/Resultado");
                }

                // Leer respuesta como JSON dinámico
                var resultado = await response.Content.ReadFromJsonAsync<RespuestaLogin>();

                if (resultado != null && resultado.mensaje != null)
                {
                    TempData["Mensaje"] = resultado.mensaje;
                    TempData["EsError"] = false;
                }
                else
                {
                    TempData["Mensaje"] = "Respuesta del servidor inválida.";
                    TempData["EsError"] = true;
                }
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = "Error al conectar con el servidor: " + ex.Message;
                TempData["EsError"] = true;
            }

            return RedirectToPage("/Resultado");
        }

        // Clase necesaria para mapear la respuesta JSON
        public class RespuestaLogin
        {
            public string? mensaje { get; set; }
        }
    }
}
