using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetPeople.Models
{
    public class PeopleViewModel
    {
        public Role? SelectedRole { get; set; }//nullabe para el all
        public IEnumerable<Person> People { get; set; }
    }
}