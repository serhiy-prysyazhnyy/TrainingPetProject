using AutoMapper;
using TrainingPetProject.DataAccess.Models;
using TrainingPetProject.Web.Models;

namespace TrainingPetProject.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            KabanMapping();
            LocationMapping();
            HotelMapping();
            HotelEditCreateMapping();

            Mapper.AssertConfigurationIsValid();
        }
        
        private static void KabanMapping()
        {
            Mapper.CreateMap<Kaban, KabanViewModel>()
                .ReverseMap();
        }
    
        private static void LocationMapping()
        {
            Mapper.CreateMap<Location, LocationViewModel>()
                .ReverseMap();
        }

        private static void HotelMapping()
        {
            Mapper.CreateMap<Hotel, HotelViewModel>()
                .ForMember(m => m.LocationDisplayName, opt => opt.Ignore())
                .ReverseMap();
        }

        private static void HotelEditCreateMapping()
        {
            Mapper.CreateMap<Hotel, HotelEditCreateViewModel>()
                .ForMember(m => m.LocationsList, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}