using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.DTO
{
    public class EmergencyDTO
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int StreetId { get; set; }
        public int House { get; set; }
        public int TypeId { get; set; }
    }
}
