using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GatoXAML.Logic
{
    public class Game
    {
        public List<Cell> Cells { get; set; }
        public int TurnCounter { get; set; }
        public int CurrentPlayer => TurnCounter % 2 == 0 ? 1 : 2;
        public int OWins { get; set; }
        public int XWins { get; set; }
        public int Ties { get; set; }
        private readonly string[] WinningCombinations = Constants.WINNING_COMBINATIONS;
        public void IncrementTies() => Ties++;

        public int GetOWins() => OWins;

        public int GetXWins() => XWins;

        public int GetTies() => Ties;
        public Game()
        {
            this.Cells = CreateNewListOfCells();
            this.TurnCounter = 0;
            this.OWins = 0;
            this.XWins = 0;
            this.Ties = 0;
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
                cell.SetIndex(cellIndex);
                Cells.Add(cell);
            }
            return Cells;
        }

        public bool CheckForWinner()
        {
            List<bool> matches = Enumerable.Range(0, 8).Select(_ => false).ToList();
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
            List<Cell> actualCells = new();
            foreach (var character in combination)
            {
                int value = int.Parse(character.ToString());
                actualCells.Add(GetCellByIndex(value));
            }
            return actualCells;
        }

        private Cell GetCellByIndex(int index)
        {
            var foundCell = this.Cells.Find(cell => cell.IndexNum == index);
            try
            {
                return foundCell;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine($"Cell with index {index} not found.");
                return null;
            }
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

        internal bool CheckForTie() => TurnCounter == 9;

        public void RegisterWin(string forPlayer)
        {
            if (forPlayer == Constants.PLAYER_SYMBOLS[1])
            {
                XWins++;
                return;
            }
            OWins++;
        }

        
    }
}
