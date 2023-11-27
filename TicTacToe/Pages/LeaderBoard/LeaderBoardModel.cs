using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Pages.LeaderBoard
{
    public class LeaderBoardModel
    {
        public int Id { get; set; }
        public string ImageFullPath { get; set; }
        public string Name { get; set; }
        public int Score {  get; set; }
    }
}
