using System;

namespace asp_net_core.Models;

public class Evaluacion : ObjetoEscuelaBase
{
  public Alumno Alumno { get; set; }
  public Asignatura Asignatura { get; set; }

  public float Nota { get; set; }

  // Llaves foraneas
  public string AlumnoId { get; set; }
  public string AsignaturaId { get; set; }

  public override string ToString()
  {
    return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
  }
}
