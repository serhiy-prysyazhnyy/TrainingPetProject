using System.ComponentModel.DataAnnotations;

namespace DataAccessProject.Models
{
    public class Kaban
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
