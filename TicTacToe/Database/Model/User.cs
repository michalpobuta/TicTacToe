using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Database.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long CreationDate { get; set; }
        public long LastLogin {  get; set; }
        public ICollection<Game> UserGames { get; set; }
    }
}
