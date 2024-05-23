using GatoXAML.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GatoXAML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public Game GameLogic { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            InitializeComponent();
            this.GameLogic = new Game();
            this.DataContext = this;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            this.GameLogic = new Game();
            OnPropertyChanged(nameof(GameLogic.Cells));
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            this.GameLogic.Reset();
            OnPropertyChanged(nameof(GameLogic.Cells));
        }

        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int cellIndex = FindIndexFromName(button.Name);
            Cell cell = GameLogic.Cells[cellIndex];

            if (cell.IsEmpty)
            {
                MarkCell(button, cell);
            }
        }

        private void MarkCell(Button button, Cell cell)
        {
            cell.Player =
                GameLogic.TurnCounter % 2 == 0
                    ? Constants.PLAYER_SYMBOLS[1]
                    : Constants.PLAYER_SYMBOLS[2];
            button.Content = cell.Player;
            GameLogic.TurnCounter++;

            if (GameLogic.CheckForWinner())
            {
                AnounceWinner(cell);
                return;
            }
            if (GameLogic.CheckForTie())
            {
                AnnounceTie();
                return;
            }
        }

        private void AnnounceTie()
        {
            MessageBox.Show("It's a tie!");
            this.GameLogic.IncrementTies();
            OnPropertyChanged("GameLogic");
        }

        private void AnounceWinner(Cell cell)
        {
            MessageBox.Show($"{cell.Player} wins!");
            this.GameLogic.RegisterWin(cell.Player);
            OnPropertyChanged("GameLogic");
        }

        private int FindIndexFromName(string name) =>
            Constants.CELL_NAME_INDEX.ContainsKey(name) ? Constants.CELL_NAME_INDEX[name] : -1;
    }
}
