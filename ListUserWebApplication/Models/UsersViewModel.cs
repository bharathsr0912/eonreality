using System;

namespace ListUserWebApplication.Model
{
    public class UsersViewModel
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
