using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IEmergencyRepository Emergencies { get; }
        IStreetRepository Streets { get; }
        IEmergencyTypeRepository Types { get; }
        void Save();
    }
}
