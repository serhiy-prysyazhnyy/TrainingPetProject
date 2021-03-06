﻿using System.Data.Entity.Validation;
using System.Linq;
using TrainingPetProject.DataAccess.Abstract;
using TrainingPetProject.DataAccess.Context;
using TrainingPetProject.DataAccess.Models;

namespace TrainingPetProject.DataAccess.Concrete
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly PetProjContex _context;

        public IRepository<Kaban> KabanRepository { get; protected set; }
        public IRepository<Location> LocationsRepository { get; protected set; }
        public IRepository<Hotel> HotelRepository { get; protected set; } 

        public UnitOfWork(PetProjContex context)
        {
            _context = context;
            KabanRepository = new Repository<Kaban>(_context);
            LocationsRepository = new Repository<Location>(_context);
            HotelRepository = new Repository<Hotel>(context);
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
    }
}
