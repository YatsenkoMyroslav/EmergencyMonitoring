using DAL.Repositories.Implementation;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class UnitOfWorkEF
        : IUnitOfWork
    {
        private EmergencyContext db;
        private EmergencyRepository emergencyRepository;
        private StreetRepository streetRepository;
        private EmergencyTypeRepository typeRepository;

        public UnitOfWorkEF(EmergencyContext context)
        {
            db = context;
        }
        public IEmergencyRepository Emergencies
        {
            get
            {
                if (emergencyRepository == null)
                    emergencyRepository = new EmergencyRepository(db);
                return emergencyRepository;
            }
        }

        public IStreetRepository Streets
        {
            get
            {
                if (streetRepository == null)
                    streetRepository = new StreetRepository(db);
                return streetRepository;
            }
        }

        public IEmergencyTypeRepository Types
        {
            get 
            { 
                if(typeRepository == null)
                    typeRepository= new EmergencyTypeRepository(db);
                return typeRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
