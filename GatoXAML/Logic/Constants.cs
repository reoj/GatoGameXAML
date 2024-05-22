using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatoXAML.Logic
{
    public class Constants
    {
        public const int BOARD_SIZE = 300;
        public const int CELL_SIZE = 100;
        public const int LINE_WIDTH = 5;
        public const int LINE_OFFSET = LINE_WIDTH / 2;
        public static readonly Dictionary<int, string> PLAYER_SYMBOLS = new Dictionary<int, string>
        {
            { 0, "" },
            { 1, "X" },
            { 2, "O" }
        };
        public readonly Dictionary<int, string> PLAYER_COLORS = new Dictionary<int, string>
        {
            { 0, "Transparent" },
            { 1, "Red" },
            { 2, "Blue" }
        };
        public static readonly Dictionary<string, int> CELL_NAME_INDEX = new Dictionary<string, int>()
        {
            { "A", 0 },
            { "B", 1 },
            { "C", 2 },
            { "D", 3 },
            { "E", 4 },
            { "F", 5 },
            { "G", 6 },
            { "H", 7 },
            { "I", 8 }
        };
    }
}
