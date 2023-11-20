using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Database.Model;

namespace TicTacToe.Database.Factories
{
    public class UserFactory
    {
        public static User CreateUser(string name,string email,string password) 
        {
            return new User() { Id = 0, CreationDate = DateTime.Now.Ticks, LastLogin = DateTime.Now.Ticks, UserGames = new List<Game>(), Email =email, Name=name, Password=password };   
        }
    }
}
