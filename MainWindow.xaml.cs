using System;
using System.Collections.Generic;
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

namespace Assignment_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Object reference to tictactoe class.
        /// </summary>
        ticTacToeClass ticTac;

        /// <summary>
        /// Check if the game has started or not yet.
        /// </summary>
        private bool startGame;

        /// <summary>
        /// Set the player turn to be 1.
        /// </summary>
        private int player = 1;

        public MainWindow()
        {
            InitializeComponent();
            ///instantiate the object
            ticTac = new ticTacToeClass();
        }


        /// <summary>
        /// Click event button that will start the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            startGame = true;
            Board.IsEnabled = true;
            resetGame();
        }

        /// <summary>
        /// Click event for all labels in the game board.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_click(object sender, RoutedEventArgs e)
        {
            
            //buttons object
            var buttons = (Button)sender;

            if(startGame)
            {
                if(buttons.Content.ToString() == "")
                {
                    if(player == 1)
                    {
                        playerStatus.Content = "Player 1 Turn";
                        buttons.Content = "X";
                        LoadBoard();
                        if(ticTac.isWinningMove())
                        {
                            highlightWinningMove();
                            
                            ticTac.Player1Wins++;
                            player1Count.Content = "Player 1 Wins: " + ticTac.Player1Wins;
                            startGame = false;

                        }
                        player++;   
                    }
                    else
                    {
                        playerStatus.Content = "Player 2 Turn";
                        buttons.Content = "O";
                        LoadBoard();
                        if (ticTac.isWinningMove())
                        {
                            highlightWinningMove();
                            
                            ticTac.Player2Wins++;
                            player2Count.Content = "Player 2 Wins: " + ticTac.Player2Wins;
                            startGame = false;
                        }
                        player--;
                    }
                    if (ticTac.isTie())
                    {
                        ticTac.TotalTies++;
                        tiesCount.Content = "Ties: " + ticTac.TotalTies;
                        startGame = false;
                    }
                }
            } 
        }

        /// <summary>
        /// Load the board with values
        /// </summary>
        private void LoadBoard()
        {
            //first Col
            ticTac.Board[0,0] = button_0_0.Content.ToString();
            ticTac.Board[0,1] = button_0_1.Content.ToString();
            ticTac.Board[0,2] = button_0_2.Content.ToString();

            //second col
            ticTac.Board[1,0] = button_1_0.Content.ToString();
            ticTac.Board[1,1] = button_1_1.Content.ToString();
            ticTac.Board[1,2] = button_1_2.Content.ToString();

            //third col
            ticTac.Board[2,0] = button_2_0.Content.ToString();
            ticTac.Board[2,1] = button_2_1.Content.ToString();
            ticTac.Board[2,2] = button_2_2.Content.ToString();
        }
        
        /// <summary>
        /// Reset the board to its initial State.
        /// </summary>
        private void resetGame()
        {
            //make all the buttons empty 
            button_0_0.Content = string.Empty;
            button_1_0.Content = string.Empty;
            button_2_0.Content = string.Empty;
            button_0_1.Content = string.Empty;
            button_1_1.Content = string.Empty;
            button_2_1.Content = string.Empty;
            button_0_2.Content = string.Empty;
            button_1_2.Content = string.Empty;
            button_2_2.Content = string.Empty;

            //make the background white for every button
            button_0_0.Background = Brushes.White;
            button_1_0.Background = Brushes.White;
            button_2_0.Background = Brushes.White;
            button_0_1.Background = Brushes.White;
            button_1_1.Background = Brushes.White;
            button_2_1.Background = Brushes.White;
            button_0_2.Background = Brushes.White;
            button_1_2.Background = Brushes.White;
            button_2_2.Background = Brushes.White;

            //reset status label to player 1
            playerStatus.Content = "Player 1 Turn";
        }

        /// <summary>
        /// Highlight the selected buttons with the winning move.
        /// </summary>
        private void highlightWinningMove()
        {
            if (ticTac.GetWinningMoves == ticTacToeClass.WinningMoves.Row1)
            {
                button_0_0.Background = Brushes.LightGreen;
                button_0_1.Background = Brushes.LightGreen;
                button_0_2.Background = Brushes.LightGreen;
            }

            else if (ticTac.GetWinningMoves == ticTacToeClass.WinningMoves.Row2)
            {
                button_1_0.Background = Brushes.LightGreen;
                button_1_1.Background = Brushes.LightGreen;
                button_1_2.Background = Brushes.LightGreen;
            }

            else if (ticTac.GetWinningMoves == ticTacToeClass.WinningMoves.Row3)
            {
                button_2_0.Background = Brushes.LightGreen;
                button_2_1.Background = Brushes.LightGreen;
                button_2_2.Background = Brushes.LightGreen;
            }

            else if (ticTac.GetWinningMoves == ticTacToeClass.WinningMoves.Col1)
            {
                button_0_0.Background = Brushes.LightGreen;
                button_1_0.Background = Brushes.LightGreen;
                button_2_0.Background = Brushes.LightGreen;
            }

            else if (ticTac.GetWinningMoves == ticTacToeClass.WinningMoves.Col2)
            {
                button_0_1.Background = Brushes.LightGreen;
                button_1_1.Background = Brushes.LightGreen;
                button_2_1.Background = Brushes.LightGreen;
            }

            else if (ticTac.GetWinningMoves == ticTacToeClass.WinningMoves.Col3)
            {
                button_0_2.Background = Brushes.LightGreen;
                button_1_2.Background = Brushes.LightGreen;
                button_2_2.Background = Brushes.LightGreen;
            }

            else if (ticTac.GetWinningMoves == ticTacToeClass.WinningMoves.FirstDiagonal)
            {
                button_0_0.Background = Brushes.LightGreen;
                button_1_1.Background = Brushes.LightGreen;
                button_2_2.Background = Brushes.LightGreen;
            }

            else if (ticTac.GetWinningMoves == ticTacToeClass.WinningMoves.SecondDiagonal)
            {
                button_0_2.Background = Brushes.LightGreen;
                button_1_1.Background = Brushes.LightGreen;
                button_2_0.Background = Brushes.LightGreen;
            }
        }
    }
}
