using Microsoft.AspNetCore.Mvc;
using asp_net_core.Models;

namespace asp_net_core.Controllers;

// https://localhost:7168/Escuela/Index
public class EscuelaController : Controller
{
  private EscuelaContext _context;

  public EscuelaController(EscuelaContext context)
  {
    this._context = context;

     // Crea DB
     context.Database.EnsureCreated();
  }

  // Vista Index que va a redireccion
  public IActionResult Index()
  {
    // Crear modelo y enviarlo a la vistas
    // Escuela escuela = new Escuela();
    // escuela.AnnioFundacion = 2005;
    // escuela.Id = Guid.NewGuid().ToString();
    // escuela.Nombre = "Platzi School";
    // escuela.Direccion = "Avd Siempre viva";
    // escuela.Ciudad = "Bogota";
    // escuela.Pais = "Colombia";
    // escuela.TipoEscuela = TiposEscuela.Secundaria;

    ViewBag.CosaDinamica = "Halloween";

    // Conecando con la DB
    Escuela escuela = this._context.Escuelas.FirstOrDefault();
    //System.Console.WriteLine(this._context.Escuelas.FirstOrDefault<Escuela>());

    return View(escuela); // Redireccionando a Index
  }

}