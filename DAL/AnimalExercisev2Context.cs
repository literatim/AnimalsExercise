using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AnimalExercisev2.Models;

namespace AnimalExercisev2.DAL
{
    public class AnimalExercisev2Context : DbContext
    {
        
        public AnimalExercisev2Context() : base("AnimalExercisev2Context")
        {

        }
        
        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
