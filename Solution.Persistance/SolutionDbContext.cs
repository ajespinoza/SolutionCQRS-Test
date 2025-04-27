using Microsoft.EntityFrameworkCore;
using Solution.Domain;

namespace Solution.Persistence
{
    public class SolutionDbContext : DbContext
    {
        public SolutionDbContext()
        {
            
        }
        public SolutionDbContext(DbContextOptions<SolutionDbContext> options): base(options) { }

        public DbSet<Curso> Cursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=DESKTOP-K394INF; Initial Catalog=SolutionCQRS; User Id=sa; Password=Notiene12345; MultipleActiveResultSets=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .Property(e => e.Precio)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Descripcion = "Curso de C# basico",
                    Titulo = "C# desde 0 hasta avanzado",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(1),
                    Precio = 56
                }
            );

            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Descripcion = "Curso de Javascript",
                    Titulo = "Javascript desde 0 hasta avanzado",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(1),
                    Precio = 30
                }
            );
        }
    }
}
