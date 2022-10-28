using System.ComponentModel.DataAnnotations;

namespace asp_net_core.Models;

public class Curso : ObjetoEscuelaBase
{
  [Required] // Requerido
  public override string Nombre { get; set; } // Sobrescribir
  
  public TiposJornada Jornada { get; set; }
  public List<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
  public List<Alumno> Alumnos { get; set; } = new List<Alumno>();
  public string Direccion { get; set; } = "";

  // Llave foranea hacia Escuela
  public string EscuelaId { get; set; }
  public Escuela Escuela { get; set; }

}
