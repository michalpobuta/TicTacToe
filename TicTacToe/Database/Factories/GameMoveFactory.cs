using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Database.Model;

namespace TicTacToe.Database.Factories
{
    public class GameMoveFactory
    {
        public static GameMove CreateGameMove(Game game,bool isPlayerMove,int moveNumber,int x,int y) 
        {
            return new GameMove() { Game = game,Id=0, IsPlayerMove = isPlayerMove,MoveNumber= moveNumber,XPosition=x,YPosition=y };
        }
    }
}
