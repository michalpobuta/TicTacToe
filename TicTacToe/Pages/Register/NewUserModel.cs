using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Pages.Register
{
    public class NewUserModel
    {
        public string Email {  get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }

        public bool IsUserValid() 
        {
            return !String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Password) && Password.Equals(Password2);
        }
    }
}
