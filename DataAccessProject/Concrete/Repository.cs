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
        private readonly PetProjContex _contex;

        public Repository(PetProjContex contex)
        {
            this._contex = contex;
        }
        
        public IEnumerable<T> GetItems()
        {
            return _contex.Set<T>().ToList();
        }

        public T GetItemById(int? id)
        {
            return _contex.Set<T>().Find(id);
        }

        public void AddItem(T item)
        {
            _contex.Set<T>().Add(item);
        }

        public void DeleteItem(int? id)
        {
            _contex.Set<T>().Remove(GetItemById(id));
        }

        public void UpdateItem(T item)
        {
            _contex.Entry(item).State = EntityState.Modified;
        }
    }
}
