using System;
using System.Collections.Generic;
using System.Text;

namespace WebServiceTutorial.Models
{
    public class RegisterUsers
    {
        //[Required(ErrorMessage = "User name is required")]
        public string userName { get; set; }

        //[Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
