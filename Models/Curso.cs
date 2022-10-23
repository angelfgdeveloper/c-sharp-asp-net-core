namespace asp_net_core.Models;

public class Curso : ObjetoEscuelaBase
{
  public TiposJornada Jornada { get; set; }
  public List<Asignatura> Asignaturas { get; set; }
  public List<Alumno> Alumnos { get; set; }
  public string Direccion { get; set; } = "";

  // Llave foranea hacia Escuela
  public string EscuelaId { get; set; }
  public Escuela Escuela { get; set; }

}
