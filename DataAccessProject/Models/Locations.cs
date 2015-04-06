using System.ComponentModel.DataAnnotations;

namespace TrainingPetProject.DataAccess.Models
{
    public class Locations
    {
        [Key]
        public int  Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string DisplayName { get; set; }
    }
}
