using System.Data.Entity;
using TrainingPetProject.DataAccessProject.Models;
using TrainingPetProject.DataAccess.Models;

namespace TrainingPetProject.DataAccess.Context
{
    public class PetProjContex: DbContext
    {
        public DbSet<Kaban> Kabans { get; set; }
        public DbSet<Locations> Locationses { get; set; } 
    }
}
