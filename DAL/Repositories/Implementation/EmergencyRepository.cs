using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementation
{
    public class EmergencyRepository : BaseRepository<Emergency>, IEmergencyRepository
    {
        internal EmergencyRepository(EmergencyContext context) : base(context)
        {
        }
    }
}
