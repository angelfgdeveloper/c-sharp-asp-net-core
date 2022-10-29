using System.ComponentModel.DataAnnotations;

namespace asp_net_core.Models;

public class Curso : ObjetoEscuelaBase
{
  [Required(ErrorMessage = "El nombre del curso es requerido")] // Requerido y mensaje personalizado
  [StringLength(5)]
  public override string Nombre { get; set; } // Sobrescribir
  
  public TiposJornada Jornada { get; set; }
  public List<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
  public List<Alumno> Alumnos { get; set; } = new List<Alumno>();

  [Display(Prompt = "Dirección de correspondencia", Name = "Address")] // Placeholder con prompt, y Address es como se tiene que mostrar
  [Required(ErrorMessage = "Se requiere incluir una dirección")]
  [MinLength(10, ErrorMessage = "La longitud minima de la direccion es 10")]
  public string Direccion { get; set; } = "";

  // Llave foranea hacia Escuela
  public string EscuelaId { get; set; }
  public Escuela Escuela { get; set; }

}
