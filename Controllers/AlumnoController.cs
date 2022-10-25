using Microsoft.AspNetCore.Mvc;
using asp_net_core.Models;

namespace asp_net_core.Controllers;

// https://localhost:7168/alumno
public class AlumnoController : Controller
{

  private EscuelaContext _context;

  public AlumnoController(EscuelaContext context)
  {
    this._context = context;

     // Crea DB
     context.Database.EnsureCreated();
  }

  // Vista Index que va a redireccion
  // https://localhost:7168/alumno/Index
  public IActionResult Index2()
  {
    // Crear modelo y enviarlo a la vistas
    Alumno alumno = new Alumno()
    {
      Id = Guid.NewGuid().ToString(),
      Nombre = "Pepe Perez"
    };

    ViewBag.cosaDinamica = "Hey!";
    ViewBag.Fecha = DateTime.Now;

    return View(_context.Alumnos.FirstOrDefault()); // Redireccionando a Index
  }

  [Route("Alumno/Index")]
  [Route("Alumno/Index/{alumnoId}")]
  public IActionResult Index(string alumnoId)
  {

    if (!string.IsNullOrWhiteSpace(alumnoId))
    {
      var alumno = from alum in _context.Alumnos
                              where alum.Id == alumnoId
                              select alum;
      return View(alumno.SingleOrDefault()); // Redireccionando y enviando un solo alumno
    }
    else
    {
      return View("MultiAlumno", _context.Alumnos); // Redireccionando a Index 
    }

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
    return View("MultiAlumno", _context.Alumnos); // Redireccionando a Index
  }

  private List<Alumno> GenerarAlumnosAlAzar()
  {
    string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
    string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
    string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

    var listaAlumnos = from n1 in nombre1
                       from n2 in nombre2
                       from a1 in apellido1
                       select new Alumno { Nombre = $"{n1} {n2} {a1}", Id = Guid.NewGuid().ToString() };

    return listaAlumnos.OrderBy((al) => al.Id).ToList();
  }

}