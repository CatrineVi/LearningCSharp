using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameBoardManager
    {
        public static void ShowBoard(string[] board)
        {
            string line = "-------------";
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine(line);
            Console.Write("|");
            for (int i = 0; i < 3; i++)
            {
                if (board[i] == GameSign.Crosses)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (board[i] == GameSign.Noughts)
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" {board[i]} ");
                Console.ResetColor();
                Console.Write("|");
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(line);
            Console.Write("|");
            for (int i = 3; i < 6; i++)
            {
                if (board[i] == GameSign.Crosses)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (board[i] == GameSign.Noughts)
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" {board[i]} ");
                Console.ResetColor();
                Console.Write("|");
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(line);
            Console.Write("|");
            for (int i = 6; i < 9; i++)
            {
                if (board[i] == GameSign.Crosses)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (board[i] == GameSign.Noughts)
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" {board[i]} ");
                Console.ResetColor();
                Console.Write("|");
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(line);
            Console.ResetColor();
        }

        public static string[] GetEmptyBoard()
        {
            return new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        }
    }
}
