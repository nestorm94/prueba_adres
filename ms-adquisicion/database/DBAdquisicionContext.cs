
using Microsoft.EntityFrameworkCore;
using ms_adquisicion.model;



namespace ms_adquisicion.database
{
    /// <summary>
    /// Contexto de base de datos para el módulo de adquisiciones.
    /// </summary>
    public class DBAdquisicionContext : DbContext
    {
        public DBAdquisicionContext(DbContextOptions<DBAdquisicionContext> options) : base(options)
        {
        }

        /// <summary>
        /// Representa la tabla de adquisiciones en la base de datos.
        /// </summary>
        public DbSet<Adquisicion> Adquisiciones { get; set; }

        /// <summary>
        /// Configuración del modelo de entidad.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapea la entidad Adquisicion a la tabla "Adquisicion"
            modelBuilder.Entity<Adquisicion>().ToTable("Adquisicion");

        }
    }
}
