using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Pages.TicTacToe
{
    public class GameMoveModel
    {
        public string PlayerName {  get; set; }
        public int MoveX { get; set; }
        public int MoveY { get; set; }
        public int Player {  get; set; }
        public int MoveNumber { get; set; }
    }
}
