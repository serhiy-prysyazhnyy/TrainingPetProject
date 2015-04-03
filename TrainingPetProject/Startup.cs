using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrainingPetProject.Web.Startup))]
namespace TrainingPetProject.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
