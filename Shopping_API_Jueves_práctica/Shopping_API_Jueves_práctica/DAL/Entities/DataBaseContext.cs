using Microsoft.EntityFrameworkCore;

namespace Shopping_API_Jueves_práctica.DAL.Entities
{
    public class DataBaseContext : DbContext
    {
        //Conecto a la BD por este constructor
        public DataBaseContext(DbContextOptions<DataBaseContext>options) : base(options) 
        {
            
        }

        //Este método que es porpio de EF CORE me sirve para configurar unos índices de cada campo de una tabla en BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique(); // Aquí creo un índice
                                                                             // del campo Name pra la tabla Countries
        }

        #region DbSets

        public DbSet<Country> Countries { get; set; }
        #endregion
    }
}
