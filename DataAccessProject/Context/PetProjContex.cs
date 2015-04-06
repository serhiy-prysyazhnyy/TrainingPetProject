using System.Data.Entity;
using TrainingPetProject.DataAccess.Models;

namespace TrainingPetProject.DataAccess.Context
{
    public class PetProjContex: DbContext
    {
        public DbSet<Kaban> Kabans { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Hotel> Hotels { get; set; } 
    }
}
