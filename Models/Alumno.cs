namespace asp_net_core.Models;

public class Alumno : ObjetoEscuelaBase
{
  public List<Evaluacion> Evaluaciones { get; set; } //= new List<Evaluacion>();

  public string CursoId { get; set; }
  public Curso Curso { get; set; }
}
