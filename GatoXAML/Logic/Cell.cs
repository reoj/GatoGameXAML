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
        public int IndexNum { get; set; }

        public void Mark(string player)
        {
            if (IsEmpty)
            {
                IsEmpty = false;
                Player = player;
            }
        }
        public void SetIndex(int index)
        {
            IndexNum = index;
        }
        public void Clear()
        {
            IsEmpty = true;
            Player = "";
        }
        public override string ToString()
        {
            return $"Cell {IndexNum} is {(IsEmpty ? "Empty" : Player)}";
        }

    }
}
