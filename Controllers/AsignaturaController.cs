using Microsoft.AspNetCore.Mvc;
using asp_net_core.Models;

namespace asp_net_core.Controllers;

// https://localhost:7168/asignatura
public class AsignaturaController : Controller
{

  // Vista Index que va a redireccion
  // https://localhost:7168/Asignatura/Index
  public IActionResult Index()
  {
    // Crear modelo y enviarlo a la vistas
    Asignatura asignatura = new Asignatura() {
      Id = Guid.NewGuid().ToString(),
      Nombre = "Programación"
    };

    ViewBag.cosaDinamica = "Hey!";
    ViewBag.Fecha = DateTime.Now;

    return View(asignatura); // Redireccionando a Index
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
    return View("MultiAsignatura", listaAsignaturas); // Redireccionando a Index
  }

}