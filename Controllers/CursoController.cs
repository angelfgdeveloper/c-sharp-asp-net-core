using Microsoft.AspNetCore.Mvc;
using asp_net_core.Models;

namespace asp_net_core.Controllers;

// https://localhost:7168/Curso
public class CursoController : Controller
{
  private EscuelaContext _context;

  public CursoController(EscuelaContext context)
  {
    this._context = context;

     // Crea DB
     context.Database.EnsureCreated();
  }


  [Route("Curso/Index")]
  [Route("Curso/Index/{CursoId}")]
  public IActionResult Index(string cursoId)
  {

    if (!string.IsNullOrWhiteSpace(cursoId))
    {
      var curso = from cur in _context.Cursos
                              where cur.Id == cursoId
                              select cur;
      return View(curso.SingleOrDefault()); // Redireccionando y enviando un solo Curso
    }
    else
    {
      return View("MultiCurso", _context.Cursos); // Redireccionando a Index 
    }

  }

  // https://localhost:7168/Curso/multiCurso
  public IActionResult MultiCurso()
  {
    ViewBag.cosaDinamica = "Hey!";
    ViewBag.Fecha = DateTime.Now;

    // Se especifica el nombre que renderizara del html "MultiCurso",
    return View("MultiCurso", _context.Cursos); // Redireccionando a Index
  }

  // https://localhost:7168/Curso/Create
  public IActionResult Create()
  {
    ViewBag.Fecha = DateTime.Now;

    return View(); // Redireccionando a Index
  }

  [HttpPost] // Metodo POST
  public IActionResult Create(Curso curso)
  {
    ViewBag.Fecha = DateTime.Now;
    // var errors = ModelState.Values.SelectMany(v => v.Errors).ToArray();
    Escuela escuela = this._context.Escuelas.FirstOrDefault();
    curso.Id = Guid.NewGuid().ToString();
    curso.Escuela = escuela;
    curso.EscuelaId = escuela.Id;
    this._context.AddCurso(curso);

    // if (ModelState.IsValid) // Si el modelo es valido
    var existCurso = this._context.Cursos.Find(curso.Id);
    if (existCurso.Nombre != null)
    {
      this._context.SaveChanges(); // Guardar cambios

      ViewBag.MensajeExtra = "Curso creado";
      return View("Index", curso); // Redirecciona a Index
    }
    else
    {
      return View(curso);
    }


  }

}