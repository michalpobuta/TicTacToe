using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Database.Model;

namespace TicTacToe.Common
{
    public class UserSession
    {
        public User CurrentUser { get; set; }
    }
}
