using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User(int id, string name, string phoneNumber, int age, string userName, string password) { 
            Id = id;
            Name = name;

            Regex validatePhoneNumberRegex = new Regex("^\\+?[1-9][0-9]{7,14}$");
            if(validatePhoneNumberRegex.IsMatch(phoneNumber))
                PhoneNumber= phoneNumber;

            if (Age > 16)
                Age = age;
            else
                age = 0;

            UserName = userName;
            Password = password;
        }
    }
}
