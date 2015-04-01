using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrainingPetProject.Startup))]
namespace TrainingPetProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
