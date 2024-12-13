using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foraneoAppMaui.Models
{

    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserCedula { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserProvince { get; set; }
        public string UserProgram { get; set; }
        public DateOnly UserBirthDate { get; set; }
    }

}
