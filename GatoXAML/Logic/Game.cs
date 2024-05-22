using System;
using System.Collections.Generic;
using System.Text;

namespace GatoXAML.Logic
{
    public class Game
    {
        public List<Cell> Cells { get; set; }
        public int TurnCounter { get; set; }
        private static readonly string[] WinningCombinations = new string[]
        {
            "012",
            "345",
            "678",
            "036",
            "147",
            "258",
            "048",
            "246"
        };

        public Game()
        {
            this.Cells = CreateNewListOfCells();
        }

        public int GetCellCount()
        {
            return Cells.Count;
        }

        private List<Cell> CreateNewListOfCells()
        {
            List<Cell> Cells = new();
            for (int cellIndex = 0; cellIndex < 9; cellIndex++)
            {
                var cell = new Cell();
                cell.Index = cellIndex;
                Cells.Add(cell);
            }
            return Cells;
        }

        public bool CheckForWinner()
        {
            List<bool> matches = new();
            if (this.TurnCounter < 5)
            {
                return false;
            }
            foreach (var combination in WinningCombinations)
            {
                List<Cell> actualCells = GetActualCellsWithSameIndexAs(combination);
                bool allCellsAreNotEmpty = actualCells.TrueForAll(cell => !cell.IsEmpty);
                string potentialWinner = actualCells[0].Player;
                bool allCellsBelongToSamePlayer = actualCells.TrueForAll(
                    eachCell => eachCell.Player == potentialWinner
                );
                matches.Add(allCellsAreNotEmpty && allCellsBelongToSamePlayer);
            }
            return matches.Contains(true);
        }

        private List<Cell> GetActualCellsWithSameIndexAs(string combination)
        {
            return new List<Cell>
            {
                this.GetCellByIndex(combination[0]),
                this.GetCellByIndex(combination[1]),
                this.GetCellByIndex(combination[2])
            };
        }

        private Cell GetCellByIndex(int index)
        {
            this.Cells.Find(cell => cell.Index == index);
            return this.Cells[0];
        }
        public void Reset()
        {
            this.Cells = CreateNewListOfCells();
            this.TurnCounter = 0;
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (var cell in Cells)
            {
                sb.AppendLine(cell.ToString());
            }
            return sb.ToString();
        }
    }
}
