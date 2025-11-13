using Microsoft.AspNetCore.Mvc.RazorPages;

namespace presentacion.Pages
{
    public class ResultadoModel : PageModel
    {
       public void OnGet()
{
    if (TempData["Mensaje"] == null)
    {
        Response.Redirect("/Index");
    }
}

    }
}
