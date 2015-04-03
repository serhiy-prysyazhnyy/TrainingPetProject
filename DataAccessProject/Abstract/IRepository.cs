using System.Collections.Generic;

namespace TrainingPetProject.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetItems();
        T GetItemById(int? id);
        void AddItem(T taskVar);
        void DeleteItem(int? id);
        void UpdateItem(T taskVar);
    }
}
