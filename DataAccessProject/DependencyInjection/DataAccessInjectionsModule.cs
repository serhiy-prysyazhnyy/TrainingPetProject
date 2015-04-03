
using System.Data.Entity;
using Ninject.Modules;
using TrainingPetProject.DataAccess.Abstract;
using TrainingPetProject.DataAccess.Concrete;
using TrainingPetProject.DataAccess.Context;

namespace TrainingPetProject.DataAccess.DependencyInjection
{
    public class DataAccessInjectionsModule: NinjectModule 
    {
        public override void Load()
        {
            Bind(typeof (IRepository<>)).To(typeof(Repository<>));
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<DbContext>().To<PetProjContex>();
        }
    }
}
