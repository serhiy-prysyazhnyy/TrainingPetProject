using System;
using System.Data.Entity.Validation;
using System.Linq;
using TrainingPetProject.DataAccess.Abstract;
using TrainingPetProject.DataAccess.Context;
using TrainingPetProject.DataAccess.Models;

namespace TrainingPetProject.DataAccess.Concrete
{
    public class UnitOfWork: IUnitOfWork
    {
        private PetProjContex _context;

        public IRepository<Kaban> KabanRepository { get; protected set; }

        public UnitOfWork(PetProjContex context)
        {
            _context = context;
            KabanRepository = new Repository<Kaban>(_context);
        }
        
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (context != null)
        //        {
        //            context.Dispose();
        //        }
        //    }
        //}
    }
}
