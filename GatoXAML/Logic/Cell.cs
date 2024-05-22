using System.Numerics;

namespace GatoXAML.Logic
{
    public class Cell
    {
        public bool IsEmpty
        {
            get => string.IsNullOrEmpty(Player);
            set => IsEmpty = value;
        }
        public string Player { get; set; } = "";
        public int Index { get; set; }

        public void Mark(string player)
        {
            if (IsEmpty)
            {
                IsEmpty = false;
                Player = player;
            }
        }

        public void Clear()
        {
            IsEmpty = true;
            Player = "";
        }
        public override string ToString()
        {
            return $"Cell {Index} is {(IsEmpty ? "Empty" : Player)}";
        }

    }
}
