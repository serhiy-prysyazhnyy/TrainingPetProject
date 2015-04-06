using TrainingPetProject.DataAccess.Models;

namespace TrainingPetProject.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        void Save();
        IRepository<Kaban> KabanRepository { get; }
        IRepository<Location> LocationsRepository { get; }
        IRepository<Hotel> HotelRepository { get; } 
    }
}
