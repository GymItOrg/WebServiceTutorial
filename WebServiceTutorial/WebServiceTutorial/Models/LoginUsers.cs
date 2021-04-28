using System;
using System.Collections.Generic;
using System.Text;

namespace WebServiceTutorial.Models
{
    public class LoginUsers
    {
        //[Required(ErrorMessage = "User name is required")]
        public string userName { get; set; }

        //[Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
