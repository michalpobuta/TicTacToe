using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Database.Model
{
    public class GameMove
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public int MoveNumber { get; set; }
        public int XPosition {  get; set; }
        public int YPosition { get; set; }
        public bool IsPlayerMove { get; set; }
    }
}
