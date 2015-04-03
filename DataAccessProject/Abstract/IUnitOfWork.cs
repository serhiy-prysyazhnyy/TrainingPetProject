using System;
using System.Security.Cryptography.X509Certificates;
using TrainingPetProject.DataAccess.Models;

namespace TrainingPetProject.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        void Save();
        IRepository<Kaban> KabanRepository { get; }
    }
}
