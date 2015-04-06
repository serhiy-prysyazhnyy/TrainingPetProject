using System.Web.Mvc;

namespace TrainingPetProject.Web.Models
{
    public class HotelEditCreateViewModel
    {
        public int Id { get; set; }
        public byte Stars { get; set; }
        public string HotelName { get; set; }

        public SelectList LocationsList { get; set; }
    }
}