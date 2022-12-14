using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Emergency
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int StreetId { get; set; }
        public int House { get; set; }
        public int TypeId { get; set; }
    }
}
