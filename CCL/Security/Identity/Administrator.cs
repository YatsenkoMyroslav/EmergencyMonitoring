using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class Administrator:User
    {
        public int LapTopId { get; set; }
        public int WorkPlaceId { get; set; }

        public Administrator(int id, string name, string phoneNumber, int age, string userName, string password, int lapTopId, int workplaceId) : base(id, name, phoneNumber, age, userName, password)
        {
            if (lapTopId > 0)
                LapTopId = lapTopId;

            if(workplaceId>0)
                WorkPlaceId = workplaceId;
        }
    }
}
