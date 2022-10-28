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

    // 1. Cargar cursos en la escuela
    List<Curso> cursos = CargarCursos(escuela);

    // 2. En cada curso cargar asignaturas
    List<Asignatura> asignaturas = CargarAsignaturas(cursos);

    // 3. En cada curso cargar alumnos
    List<Alumno> alumnos = CargarAlumnos(cursos);

    modelBuilder.Entity<Escuela>().HasData(escuela);
    modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
    modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
    modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());

    // Lista de datos en asignatura
    // List<Asignatura> listaAsignaturas = new List<Asignatura>() {
    //   new Asignatura { Nombre = "Matemáticas", Id = Guid.NewGuid ().ToString () },
    //   new Asignatura { Nombre = "Educación Física", Id = Guid.NewGuid ().ToString () },
    //   new Asignatura { Nombre = "Castellano", Id = Guid.NewGuid ().ToString () },
    //   new Asignatura { Nombre = "Ciencias Naturales", Id = Guid.NewGuid ().ToString () },
    //   new Asignatura { Nombre = "Programacion", Id = Guid.NewGuid ().ToString () }
    // };

    // modelBuilder.Entity<Asignatura>().HasData(listaAsignaturas.ToArray()); // Requiere que le amndes un ToArray(); (Lo convierte)

    // // Lista de Alumnos
    // List<Alumno> listaAlumnos = GenerarAlumnosAlAzar();
    // modelBuilder.Entity<Alumno>().HasData(listaAlumnos.ToArray()); // Requiere que le amndes un ToArray(); (Lo convierte)
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

  private static List<Curso> CargarCursos(Escuela escuela)
  {
    return new List<Curso>() {
      new Curso() {
          Id = Guid.NewGuid().ToString(),
          EscuelaId = escuela.Id,
          Nombre = "101",
          Jornada = TiposJornada.Mañana 
      },
      new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "201", Jornada = TiposJornada.Mañana},
      new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "301", Jornada = TiposJornada.Mañana},
      new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "401", Jornada = TiposJornada.Tarde},
      new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "501", Jornada = TiposJornada.Tarde},
    };
  }

  public List<Curso> AddCurso(Curso curso)
  {
    this.Cursos.Add(curso);
    return this.Cursos.ToList();
  }

  private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
  {
    List<Asignatura> listaCompleta = new List<Asignatura>();
    foreach (Curso curso in cursos)
    {
      List<Asignatura> tmpList = new List<Asignatura> {
        new Asignatura() {
            Id = Guid.NewGuid().ToString(),
            CursoId = curso.Id,
            Nombre="Matemáticas"
        },
        new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre = "Educación Física"},
        new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre = "Castellano"},
        new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre = "Ciencias Naturales"},
        new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre = "Programación"}
      };
      
      listaCompleta.AddRange(tmpList);
      //curso.Asignaturas = tmpList;
    }

    return listaCompleta;
  }

  private List<Alumno> GenerarAlumnosAlAzar(Curso curso, int cantidad)
  {
      string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
      string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
      string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

      var listaAlumnos = from n1 in nombre1
                         from n2 in nombre2
                         from a1 in apellido1
                         select new Alumno
                         {
                          CursoId = curso.Id,
                          Nombre = $"{n1} {n2} {a1}",
                          Id = Guid.NewGuid().ToString()
                         };

      return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
  }

  private List<Alumno> CargarAlumnos(List<Curso> cursos)
  {
    List<Alumno> listaAlumnos = new List<Alumno>();

    Random rnd = new Random();
    foreach (Curso curso in cursos)
    {
        int cantRandom = rnd.Next(5, 20); // Generar aleatorio entre 5 y 20
        var tmplist = GenerarAlumnosAlAzar(curso, cantRandom);
        listaAlumnos.AddRange(tmplist);
    }

    return listaAlumnos;
  }
    
}