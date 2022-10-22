using Microsoft.AspNetCore.Mvc;
using asp_net_core.Models;

namespace asp_net_core.Controllers;

// https://localhost:7168/alumno
public class AlumnoController : Controller
{

  // Vista Index que va a redireccion
  // https://localhost:7168/alumno/Index
  public IActionResult Index()
  {
    // Crear modelo y enviarlo a la vistas
    Alumno alumno = new Alumno()
    {
      UniqueId = Guid.NewGuid().ToString(),
      Nombre = "Pepe Perez"
    };

    ViewBag.cosaDinamica = "Hey!";
    ViewBag.Fecha = DateTime.Now;

    return View(alumno); // Redireccionando a Index
  }

  // https://localhost:7168/alumno/multialumno
  public IActionResult MultiAlumno()
  {
    // List<Alumno> listaAlumnos = new List<Alumno>() {
    //   new Alumno { Nombre = "Pepe Perez", UniqueId = Guid.NewGuid ().ToString () },
    //   new Alumno { Nombre = "Evelyn Soto", UniqueId = Guid.NewGuid ().ToString () },
    //   new Alumno { Nombre = "Cyndi bortex", UniqueId = Guid.NewGuid ().ToString () },
    //   new Alumno { Nombre = "Fernando Herrera", UniqueId = Guid.NewGuid ().ToString () },
    //   new Alumno { Nombre = "Salma Corral", UniqueId = Guid.NewGuid ().ToString () }
    // };

    var listaAlumnos = GenerarAlumnosAlAzar();

    ViewBag.cosaDinamica = "Hey!";
    ViewBag.Fecha = DateTime.Now;

    // Se especifica el nombre que renderizara del html "MultiAlumno",
    return View("MultiAlumno", listaAlumnos); // Redireccionando a Index
  }

  private List<Alumno> GenerarAlumnosAlAzar()
  {
    string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
    string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
    string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

    var listaAlumnos = from n1 in nombre1
                       from n2 in nombre2
                       from a1 in apellido1
                       select new Alumno { Nombre = $"{n1} {n2} {a1}", UniqueId = Guid.NewGuid().ToString() };

    return listaAlumnos.OrderBy((al) => al.UniqueId).ToList();
  }

}