using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IEmergencyService
    {
        IEnumerable<EmergencyDTO> GetEmergencies(int emergencyTypeId, int page);
    }
}
