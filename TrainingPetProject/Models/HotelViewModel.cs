using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingPetProject.Web.Models
{
    public class HotelViewModel
    {
        public int Id { get; set; }
        public byte Stars { get; set; }
        public string HotelName { get; set; }

        public string LocationDisplayName { get; set; }
    }
}