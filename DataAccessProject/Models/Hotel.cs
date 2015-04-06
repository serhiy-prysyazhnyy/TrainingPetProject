using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPetProject.DataAccess.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        
        [Range(1,5)]
        [DataType(DataType.Currency)]
        public byte Stars { get; set; }
        
        public string HotelName { get; set; }
        
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

    }
}
