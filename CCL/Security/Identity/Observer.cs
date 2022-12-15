using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class Observer:User
    {
        public int FabletId { get; set; }

        public Observer(int id, string name, string phoneNumber, int age, string userName, string password, int fabletId) : base(id, name, phoneNumber, age, userName, password) {
            if (fabletId > 0)
                FabletId = fabletId;
        }
    }
}
