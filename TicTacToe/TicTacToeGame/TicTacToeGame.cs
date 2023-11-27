using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.TicTacToeGame.Bot;

namespace TicTacToe.TicTacToeGame
{
    public class TicTacToeGame : ITicTacToeGame
    {
        private Array2D board = new Array2D(3, 3);
        private int player = 1;
        private Tuple<int, WinType> winInfo;

        public bool MakeMove(int row, int col)
        {
            if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == 0)
            {
                board[row, col] = player;
                return true;
            }
            return false;
        }
        public void ChangePlayer() 
        {
            player = (player == 1) ? 2 : 1;
        }
        public int CheckResult()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != 0 && board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2]) 
                {
                    winInfo = new(i, WinType.Row);
                    return board[i, 0];
                }
                if (board[0, i] != 0 && board[0, i] == board[1, i] && board[0, i] == board[2, i])
                {
                    winInfo = new(i, WinType.Column);
                    return board[0, i]; 
                } 
            }

            if (board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2])
            {
                winInfo = new(1, WinType.Diagonal);
                return board[0, 0]; 
            }
            if (board[0, 2] != 0 && board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0])
            {
                winInfo = new(0, WinType.Diagonal);
                return board[0, 2]; 
            }

            bool isboardFull = true;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == 0)
                    {
                        isboardFull = false;
                        break;
                    }
                }
            }

            if (isboardFull)
                return 0;
            return -1;
        }

        public int GetPiece(int row, int col)
        {
            return board[row, col];
        }
        public Tuple<int, WinType> GetWinInfo() 
        {
            return winInfo;
        }

        public void Reset()
        {
            board = new Array2D(3, 3);
            player = 1;
            winInfo = null;
        }
        public Point GetLastMove() => board.LastElement;

        public (int row, int col)? MakeMoveForBot(Bot.Bot bot)
        {
            var res = bot.MakeMove(board);
            return MakeMove(res.row,res.col) ? res : null;
        }
    }
}
