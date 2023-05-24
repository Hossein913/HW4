using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersManegment.Models
{
    public class User
    {
        public User()
        {
        }
        public User(int id, string name, string phonenumber, DateTime birthdate, DateTime creationdate)
        {
            this.id =id;
            Name = name;
            PhoneNumber = phonenumber;
            BirthDate = birthdate;
            CreationDate = creationdate;
        }

        public int id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreationDate { get; set; }

        //it's just for test
        public override string ToString()
        {
            return $"{id} - {Name} - {PhoneNumber} - {BirthDate} - {CreationDate}";
        }
    }
}