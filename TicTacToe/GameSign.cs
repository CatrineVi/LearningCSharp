using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public static class GameSign
    {
        public const string Crosses = "X";
        public const string Noughts = "O";

        public static string GetOppositeSign(string sign)
        {
            return sign == Crosses ? Noughts : Crosses;
        }
    }
}
