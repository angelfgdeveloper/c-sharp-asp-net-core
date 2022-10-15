using Microsoft.AspNetCore.Mvc;
using asp_net_core.Models;

namespace asp_net_core.Controllers;

// https://localhost:7168/Escuela/Index
public class EscuelaController : Controller
{

  // Vista Index que va a redireccion
  public IActionResult Index()
  {
    // Crear modelo y enviarlo a la vistas
    Escuela escuela = new Escuela() { EscuelaId = Guid.NewGuid().ToString(), Nombre = "Platzi School", AnnioFundacion = 2005 };
    return View(escuela); // Redireccionando a Index
  }

}