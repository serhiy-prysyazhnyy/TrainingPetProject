using System.ComponentModel.DataAnnotations;

namespace TrainingPetProject.DataAccess.Models
{
    public class Kaban
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
