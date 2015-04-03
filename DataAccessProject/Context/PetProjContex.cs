using System.Data.Entity;
using TrainingPetProject.Web.DataAccess.Models;

namespace TrainingPetProject.Web.DataAccess.Context
{
    public class PetProjContex: DbContext
    {
        public DbSet<Kaban> Kabans { get; set; }
        public DbSet<KabanFemale> KabanFemales { get; set; } 
    }
}
