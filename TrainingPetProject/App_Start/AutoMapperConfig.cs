using AutoMapper;
using TrainingPetProject.DataAccess.Models;
using TrainingPetProject.Web.ViewModels;

namespace TrainingPetProject.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            KabanMapping();

            Mapper.AssertConfigurationIsValid();
        }
        
        private static void KabanMapping()
        {
            Mapper.CreateMap<Kaban, KabanViewModel>()
                .ReverseMap();
        }
    }
}