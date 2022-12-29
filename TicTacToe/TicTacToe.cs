using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTacToe
    {
        private int[,] winningCombinations = new int[,]
        {
            {0, 1, 2},
            {3, 4, 5},
            {6, 7, 8},
            {0, 3, 6},
            {1, 4, 7},
            {2, 5, 8},
            {0, 4, 8},
            {2, 4, 6}
        };
        public void Start()
        {
            const string startSign = GameSign.Crosses;
            var currentSign = startSign;
            var startBoard = GameBoardManager.GetEmptyBoard();
            var board = startBoard;
            GameBoardManager.ShowBoard(board);
            while (true)
            {
                this.Move(currentSign, board);
                GameBoardManager.ShowBoard(board);

                var isWin = this.CheckWin(currentSign, board);
                if (isWin)
                {
                    System.Console.WriteLine($"{currentSign} is winner");
                    break;
                }

                var isDraw = this.ChceckDraw(board);
                if (isDraw)
                {
                    System.Console.WriteLine("It's draw");
                    break;
                }

                currentSign = GameSign.GetOppositeSign(currentSign);
            }
        }

        private void Move(string currentSign, string[] board)
        {
            var userInput = Console.ReadLine();
            while(!CheckInput(userInput, board))
            {
                Console.Write("Try again: ");
                userInput = Console.ReadLine();
            }
            board[int.Parse(userInput) - 1] = currentSign;
        }

        private bool ChceckDraw(string[] board)
        {
            bool isDraw = false; ;

            int flag = 0;

            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == GameSign.Crosses |
                    board[i] == GameSign.Noughts)
                    flag++;
            }
            if (flag == 9)
                isDraw = true;
            return isDraw;
        }

        private bool CheckWin(string currentSign, string[] board)
        {
            bool isWin = false;

            for (int i = 0; i < winningCombinations.GetLength(0); i++)
            {
                for (int j = 0; j < winningCombinations.GetLength(1); j++)
                {
                    var winningIndex = winningCombinations[i, j];
                    if (board[winningIndex] != currentSign)
                    {
                        isWin = false;
                        break;
                    }
                    else
                        isWin = true;
                }
                if (isWin)
                    break;
            }

            return isWin;
        }

        private static bool CheckInput(string a, string[] board)
        {
            var flag = int.TryParse(a, out int b);
            if ((flag) & (b >= 1) & (b <= 9))
            {
                if ((board[b - 1] != GameSign.Crosses) &
                    (board[b - 1] != GameSign.Noughts))
                    return true;
                else return false;
            }
            else return false;
        }
    }
}
