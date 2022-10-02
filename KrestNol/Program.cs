using System;

namespace KrestNol
{
    class Program
    {
        static void Main(string[] args)
        {
            KrestNol();
        }

        private static void Consol(string[] a)
        {
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine($"-------------");
            Console.Write($"|");
            for (int i = 0; i < 3; i++)
            {
                if (a[i] == "X")
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (a[i] == "O")
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" {a[i]} ");
                Console.ResetColor();
                Console.Write($"|");
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"-------------");
            Console.Write($"|");
            for (int i = 3; i < 6; i++)
            {
                if (a[i] == "X")
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (a[i] == "O")
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" {a[i]} ");
                Console.ResetColor();
                Console.Write($"|");
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"-------------"); 
            Console.Write($"|");
            for (int i = 6; i < 9; i++)
            {
                if (a[i] == "X")
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (a[i] == "O")
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" {a[i]} ");
                Console.ResetColor();
                Console.Write($"|");
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"-------------");
            Console.ResetColor();
        }

        private static bool CheckInput(string a, string[] array)
        {
            var flag = int.TryParse(a, out int b);
            if ((flag) & (b >= 1) & (b <= 9))
            {
                if ((array[b - 1] != "X") & (array[b - 1] != "O"))
                    return true;
                else return false;
            }
            else return false;
        }

        private static bool WinCobination(string player, string[] a)
        {
            if ((player == a[0]) & (player == a[1]) & (player == a[2]))
                return true;
            else if ((player == a[3]) & (player == a[4]) & (player == a[5]))
                return true;
            else if ((player == a[6]) & (player == a[7]) & (player == a[8]))
                return true;
            else if ((player == a[0]) & (player == a[4]) & (player == a[8]))
                return true;
            else if ((player == a[2]) & (player == a[4]) & (player == a[6]))
                return true;
            else if ((player == a[0]) & (player == a[3]) & (player == a[6]))
                return true;
            else if ((player == a[1]) & (player == a[4]) & (player == a[7]))
                return true;
            else if ((player == a[2]) & (player == a[5]) & (player == a[8]))
                return true;
            else return false;
        }

        private static bool Fullness(string[] a)
        {
            int flag = 0;

            for (int i = 0; i < 9; i++)
            {
                if ((a[i] == "X") | (a[i] == "O"))
                    flag++;
            }
            if (flag == 9)
                return true;
            else return false;
        }

        private static bool Draw(string[] a, string player1, string player2)
        {
            if ((Fullness(a)) & (!WinCobination(player1, a)) & (!WinCobination(player2, a)))
                return true;
            else return false;
        }

        private static void KrestNol()
        {
            string[] array = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            Consol(array);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Кто будет Х (1/2)?: ");
            var pl = Console.ReadLine();
            string player1;
            string player2;
            if (pl == "1")
            {
                player1 = "X";
                player2 = "O";
            }
            else
            {
                player2 = "X";
                player1 = "O";
            }
            Console.WriteLine("(ввод хода: координата на доске, число от 1 до 9)");
            Consol(array);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Игрок 1: ");
            var move1 = Console.ReadLine();
            while (!CheckInput(move1, array))
            {
                Console.Write("Некоректно введен ход, попробуйте еще раз: ");
                move1 = Console.ReadLine();
            }
            array[int.Parse(move1) - 1] = player1;
            Consol(array);

            while (!Fullness(array))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Игрок 2: ");
                var move2 = Console.ReadLine();
                while (!CheckInput(move2, array))
                {
                    Console.Write("Некоректно введен ход, попробуйте еще раз: ");
                    move2 = Console.ReadLine();
                }
                array[int.Parse(move2) - 1] = player2;
                Consol(array);
                if (WinCobination(player2, array))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Поздравляем! Игрок 2 победил!");
                    Console.ResetColor();
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Игрок 1: ");
                move1 = Console.ReadLine();
                while (!CheckInput(move1, array))
                {
                    Console.Write("Некоректно введен ход, попробуйте еще раз: ");
                    move1 = Console.ReadLine();
                }
                array[int.Parse(move1) - 1] = player1;

                Console.ForegroundColor = ConsoleColor.Green;
                Consol(array);
                if (WinCobination(player1, array))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Поздравляем! Игрок 1 победил!");
                    Console.ResetColor();
                    break;
                }
            }

            if (Draw(array, player1, player2))
                Console.WriteLine("Игра закончилась ничьей...");
        }
    }
}