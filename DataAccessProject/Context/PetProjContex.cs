using System.Data.Entity;
using DataAccessProject.Models;

namespace DataAccessProject.Context
{
    public class PetProjContex: DbContext
    {
        public DbSet<Kaban> Kabans { get; set; }
        public DbSet<KabanFemale> KabanFemales { get; set; } 
    }
}
