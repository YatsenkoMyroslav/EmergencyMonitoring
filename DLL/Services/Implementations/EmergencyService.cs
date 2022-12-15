using AutoMapper;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork;
using BLL.DTO;
using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public class EmergencyService:IEmergencyService
    {
        private readonly IUnitOfWork _database;
        private int amountOnPage = 10;

        public EmergencyService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        public IEnumerable<EmergencyDTO> GetEmergencies(int emergencyTypeId, int page)
        {
            var emergenciesEntities = _database.Emergencies.Find(e => e.TypeId == emergencyTypeId, page, amountOnPage);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Emergency, EmergencyDTO>()).CreateMapper();
            var emeergencies = mapper.Map<IEnumerable<Emergency>, List<EmergencyDTO>>(emergenciesEntities);
            
            return emeergencies;
        }
    }
}
