using Microsoft.AspNetCore.Mvc;
using asp_net_core.Models;

namespace asp_net_core.Controllers;

// https://localhost:7168/asignatura
public class AsignaturaController : Controller
{

  private EscuelaContext _context;

  public AsignaturaController(EscuelaContext context)
  {
    this._context = context;

     // Crea DB
     context.Database.EnsureCreated();
  }

  // Vista Index que va a redireccion
  // https://localhost:7168/Asignatura/Index
  public IActionResult Index2()
  {
    // Crear modelo y enviarlo a la vistas
    // Asignatura asignatura = new Asignatura() {
    //   Id = Guid.NewGuid().ToString(),
    //   Nombre = "Programación"
    // };

    Asignatura asignatura = _context.Asignaturas.FirstOrDefault();

    ViewBag.cosaDinamica = "Hey!";
    ViewBag.Fecha = DateTime.Now;

    return View(asignatura); // Redireccionando a Index
  }

  // https://localhost:7168/asignatura/index/775059d7-06a3-4550-980e-5088a27cc0d2
  [Route("Asignatura/Index")]
  [Route("Asignatura/Index/{asignaturaId}")]
  public IActionResult Index(string asignaturaId)
  {

    if (!string.IsNullOrWhiteSpace(asignaturaId))
    {
      var asignatura = from asig in _context.Asignaturas
                              where asig.Id == asignaturaId
                              select asig;
      return View(asignatura.SingleOrDefault()); // Redireccionando y enviando una sola asignatura
    }
    else
    {
      return View("MultiAsignatura", _context.Asignaturas); // Redireccionando a Index 
    }

  }

  // https://localhost:7168/asignatura/multiasignatura
  public IActionResult MultiAsignatura()
  {
    List<Asignatura> listaAsignaturas = new List<Asignatura>() {
      new Asignatura { Nombre = "Matemáticas", Id = Guid.NewGuid ().ToString () },
      new Asignatura { Nombre = "Educación Física", Id = Guid.NewGuid ().ToString () },
      new Asignatura { Nombre = "Castellano", Id = Guid.NewGuid ().ToString () },
      new Asignatura { Nombre = "Ciencias Naturales", Id = Guid.NewGuid ().ToString () },
      new Asignatura { Nombre = "Programacion", Id = Guid.NewGuid ().ToString () }
    };

    ViewBag.cosaDinamica = "Hey!";
    ViewBag.Fecha = DateTime.Now;

    // Se especifica el nombre que renderizara del html "MultiAsignatura",
    return View("MultiAsignatura", _context.Asignaturas); // Redireccionando a Index
  }

}