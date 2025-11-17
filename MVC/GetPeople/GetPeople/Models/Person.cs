using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetPeople.Models
{
    public enum Role
    {
        Admin,
        User,
        Guest
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
    }
}