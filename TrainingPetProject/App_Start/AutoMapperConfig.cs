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
            LocationsMapping();

            Mapper.AssertConfigurationIsValid();
        }
        
        private static void KabanMapping()
        {
            Mapper.CreateMap<Kaban, KabanViewModel>()
                .ReverseMap();
        }

        private static void LocationsMapping()
        {
            Mapper.CreateMap<Locations, LocationsViewModel>()
                .ReverseMap();
        }
    }
}