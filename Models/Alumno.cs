namespace asp_net_core.Models;

public class Alumno : ObjetoEscuelaBase
{
  public List<Evaluación> Evaluaciones { get; set; } = new List<Evaluación>();
}
