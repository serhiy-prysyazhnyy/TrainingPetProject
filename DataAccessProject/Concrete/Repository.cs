using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ninject;
using TrainingPetProject.DataAccess.Abstract;
using TrainingPetProject.DataAccess.Context;

namespace TrainingPetProject.DataAccess.Concrete
{
    public class Repository<T>: IRepository<T> where T : class
    {
        private readonly PetProjContex contex;

        public Repository(PetProjContex contex)
        {
            this.contex = contex;
        }
        
        public IEnumerable<T> GetItems()
        {
            return contex.Set<T>().ToList();
        }

        public T GetItemById(int? id)
        {
            return contex.Set<T>().Find(id);
        }

        public void AddItem(T item)
        {
            contex.Set<T>().Add(item);
        }

        public void DeleteItem(int? id)
        {
            contex.Set<T>().Remove(GetItemById(id));
        }

        public void UpdateItem(T item)
        {
            contex.Entry(item).State = EntityState.Modified;
        }
    }
}
