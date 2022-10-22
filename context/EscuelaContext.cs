using Microsoft.EntityFrameworkCore;

namespace asp_net_core.Models;

public class EscuelaContext : DbContext
{
  public DbSet<Escuela> Escuelas { get; set; }
  public DbSet<Asignatura> Asignaturas { get; set; }
  public DbSet<Alumno> Alumnos { get; set; }
  public DbSet<Curso> Cursos { get; set; }
  public DbSet<Evaluacion> evaluaciones { get; set; }

  public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options) { }

  // Añadiendo datos iniciales a la DB
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    // Datos de escuela
    Escuela escuela = new Escuela();
    escuela.AnnioFundacion = 2005;
    escuela.Id = Guid.NewGuid().ToString();
    escuela.Nombre = "Platzi School";
    escuela.Direccion = "Avd Siempre viva";
    escuela.Ciudad = "Bogota";
    escuela.Pais = "Colombia";
    escuela.TipoEscuela = TiposEscuela.Secundaria;

    modelBuilder.Entity<Escuela>().HasData(escuela);

    // Lista de datos en asignatura
    List<Asignatura> listaAsignaturas = new List<Asignatura>() {
      new Asignatura { Nombre = "Matemáticas", Id = Guid.NewGuid ().ToString () },
      new Asignatura { Nombre = "Educación Física", Id = Guid.NewGuid ().ToString () },
      new Asignatura { Nombre = "Castellano", Id = Guid.NewGuid ().ToString () },
      new Asignatura { Nombre = "Ciencias Naturales", Id = Guid.NewGuid ().ToString () },
      new Asignatura { Nombre = "Programacion", Id = Guid.NewGuid ().ToString () }
    };

    modelBuilder.Entity<Asignatura>().HasData(listaAsignaturas.ToArray()); // Requiere que le amndes un ToArray(); (Lo convierte)

    // Lista de Alumnos
    List<Alumno> listaAlumnos = GenerarAlumnosAlAzar();
    modelBuilder.Entity<Alumno>().HasData(listaAlumnos.ToArray()); // Requiere que le amndes un ToArray(); (Lo convierte)

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