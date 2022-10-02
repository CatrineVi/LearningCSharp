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
            Console.WriteLine($"-------------");
            Console.WriteLine($"| {a[0]} | {a[1]} | {a[2]} |");
            Console.WriteLine($"-------------");
            Console.WriteLine($"| {a[3]} | {a[4]} | {a[5]} |");
            Console.WriteLine($"-------------");
            Console.WriteLine($"| {a[6]} | {a[7]} | {a[8]} |");
            Console.WriteLine($"-------------");
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
                    Console.WriteLine("Поздравляем! Игрок 2 победил!");
                    break;
                }

                Console.Write("Игрок 1: ");
                move1 = Console.ReadLine();
                while (!CheckInput(move1, array))
                {
                    Console.Write("Некоректно введен ход, попробуйте еще раз: ");
                    move1 = Console.ReadLine();
                }
                array[int.Parse(move1) - 1] = player1;
                Consol(array);
                if (WinCobination(player1, array))
                {
                    Console.WriteLine("Поздравляем! Игрок 1 победил!");
                    break;
                }
            }

            if (Draw(array, player1, player2))
                Console.WriteLine("Игра закончилась ничьей...");
        }
    }
}