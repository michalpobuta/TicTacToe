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
            // Sprawdzenie wierszy i kolumn
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != 0 && board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2])
                    return board[i, 0];  // Zwycięstwo
                if (board[0, i] != 0 && board[0, i] == board[1, i] && board[0, i] == board[2, i])
                    return board[0, i];  // Zwycięstwo
            }

            // Sprawdzenie przekątnych
            if (board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2])
                return board[0, 0];  // Zwycięstwo
            if (board[0, 2] != 0 && board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0])
                return board[0, 2];  // Zwycięstwo

            // Sprawdzenie, czy wszystkie pola są zapełnione (remis)
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
                return 0;  // Remis

            return -1;  // Gra trwa
        }

        public int GetPiece(int row, int col)
        {
            return board[row, col];
        }

        public void Reset()
        {
            board = new Array2D(3, 3);
            player = 1;
        }
        public Point GetLastMove() => board.LastElement;

        public bool MakeMoveForBot(IBot bot)
        {
            var res = bot.MakeMove(board);
            return MakeMove(res.row,res.col);
        }
    }
}
