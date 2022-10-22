namespace asp_net_core.Models;

public class Escuela : ObjetoEscuelaBase
{
  public int AnnioFundacion { get; set; }

  public string Pais { get; set; }
  public string Ciudad { get; set; }

  public string Direccion { get; set; }

  public TiposEscuela TipoEscuela { get; set; }
  public List<Curso> Cursos { get; set; }

  public Escuela(string nombre, int annio) => (Nombre, AnnioFundacion) = (nombre, annio);

  public Escuela(string nombre, int annio,
                 TiposEscuela tipo,
                 string pais = "", string ciudad = "") : base()
  {
    (Nombre, AnnioFundacion) = (nombre, annio);
    Pais = pais;
    Ciudad = ciudad;
  }

  // Contructor vacio
  public Escuela()
  {
    
  }

  public override string ToString()
  {
    return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad:{Ciudad}";
  }

}
