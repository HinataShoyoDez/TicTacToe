using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        private bool _isXTurn = true;
        private int[,] _board = new int[3, 3];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);

            if (_board[row, column] == 0)
            {
                _board[row, column] = _isXTurn ? 1 : 2;
                button.Content = _isXTurn ? "X" : "O";
                button.IsEnabled = false;

                if (CheckWin())
                {
                    MessageBox.Show(_isXTurn ? "X Kazandı!" : "O Kazandı!");
                    ResetBoard();
                }
                else if (IsBoardFull())
                {
                    MessageBox.Show("Beraberlik!");
                    ResetBoard();
                }
                else
                {
                    _isXTurn = !_isXTurn;
                }
            }
        }

        private bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
              
                if ((_board[i, 0] == _board[i, 1] && _board[i, 1] == _board[i, 2] && _board[i, 0] != 0) ||
                    (_board[0, i] == _board[1, i] && _board[1, i] == _board[2, i] && _board[0, i] != 0))
                {
                    return true;
                }
            }

           
            if ((_board[0, 0] == _board[1, 1] && _board[1, 1] == _board[2, 2] && _board[0, 0] != 0) ||
                (_board[0, 2] == _board[1, 1] && _board[1, 1] == _board[2, 0] && _board[0, 2] != 0))
            {
                return true;
            }

            return false;
        }

        private bool IsBoardFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_board[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void ResetBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _board[i, j] = 0;
                }
            }

            foreach (var child in this.grid.Children)
            {
                if (child is Button button)
                {
                    button.Content = "";
                    button.IsEnabled = true;
                }
            }

            _isXTurn = true;
        }
    }
}
