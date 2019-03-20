using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListEmployeeAPI.Model
{
    public class UsersBusinessModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string DateRegistered { get; set; }
        public string AdditionalRequest { get; set; }
        public string selectedDays { get; set; }
    }
}
