using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ej_session.Models;

namespace Ej_session.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Registrarse()
    {
        return View();
    }

    public IActionResult Ingreso(string NombreUsuario, string Contraseña)
    {
        HttpContext.Session.SetString("usuario", NombreUsuario);
        return View("Bienvenida");
    }

    public IActionResult Verificación(string NombreUsuario, string Contraseña, string Nombre, string Apellido, string Tipo)
    {
        Usuario usuario1 = new Usuario(NombreUsuario, Contraseña, Nombre, Apellido, Tipo);
        BD.AgregarUsuario(usuario1);
        return View();
    }

    public IActionResult Cierre(){
        HttpContext.Session.Clear();
        return View("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
