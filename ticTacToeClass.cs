using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Assignment_4
{
    public class ticTacToeClass
    {

        #region Private Members With Their Properties

        /// <summary>
        /// Gameboard Representation 
        /// </summary>
        private string[,] board;

        /// <summary>
        /// Stats Tracker for player 1
        /// </summary>
        private int player1Wins;

        /// <summary>
        /// Stats Tracker for player 2
        /// </summary>
        private int player2Wins;

        /// <summary>
        /// Stat Tracker for all the ties
        /// </summary>
        private int totalTies;

        /// <summary>
        /// Winning Moves enum representation
        /// </summary>
        private WinningMoves eWinningMoves;

        #endregion

        #region Enum WinningMoves
        /// <summary>
        /// Enum identifying the different winning moves on the board.
        /// </summary>
        public enum WinningMoves
        {
            /// <summary>
            /// enum that refers to the win condition when the player marks the first row.
            /// </summary>
            Row1,

            /// <summary>
            /// enum that refers to the win condition when the player marks the second row.
            /// </summary>
            Row2,

            /// <summary>
            /// enum that refers to the win condition when the player marks the third row.
            /// </summary>
            Row3,

            /// <summary>
            /// enum that refers to the win condition when the player marks the first column.
            /// </summary>
            Col1,
            /// <summary>
            /// enum that refers to the win condition when the player marks the second column.
            /// </summary>
            Col2,
            /// <summary>
            /// enum that refers to the win condition when the player marks the third column.
            /// </summary>
            Col3,
            /// <summary>
            /// enum that refers to the win condition when the player marks the diagonal going from top left to bottom right.
            /// </summary>
            FirstDiagonal,
            /// <summary>
            /// enum that refers to the win condition when the player marks the diagonal going from top right to bottom left.
            /// </summary>
            SecondDiagonal
        }
        #endregion

        #region Properties

        public string[,] Board
        {
            get
            {
                return this.board;
            }
            set
            {
                this.board = value;
            }
        }

        public int Player1Wins
        {
            get
            {
                return this.player1Wins;
            }
            set
            {
                this.player1Wins = value;
            }
        }

        public int Player2Wins
        {
            get
            {
                return this.player2Wins;
            }
            set
            {
                this.player2Wins = value;
            }
        }

        public int TotalTies
        {
            get
            {
                return this.totalTies;
            }
            set
            {
                this.totalTies = value;
            }
        }

        public WinningMoves GetWinningMoves
        {
            get
            {
                return eWinningMoves; 
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// initialize all corresponding private values to 0 (CONSTRUCTOR)
        /// </summary>
        public ticTacToeClass()
        {
            this.board = new string[3, 3];
            this.player1Wins = 0;
            this.player2Wins = 0;
            this.totalTies = 0;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Will check for the different winning moves on the board.
        /// </summary>
        /// <returns> true or false </returns>
        public bool isWinningMove()
        {
            return isHoriWin() || isVerWin() || isDiagWin();
        }

        /// <summary>
        /// Checks for all the horizontal winning moves
        /// </summary>
        /// <returns> true or false </returns>
        private bool isHoriWin()
        {
            
            if (board[0,0] == board[0,1] && board[0,1] == board[0,2] && 
                board[0,0] != "" && board[0,1] != "" && board[0,2] != "")
            {
                eWinningMoves = WinningMoves.Row1;
                return true;
            }
            else if((board[1,0] == board[1,1] && board[1,1] == board[1,2] &&
                board[1,0] != "" && board[1,1] != "" && board[1,2] != ""))
            {
                eWinningMoves = WinningMoves.Row2;
                return true;
            }

            else if ((board[2,0] == board[2,1] && board[2,1] == board[2,2] &&
                board[2,0] != "" && board[2,1] != "" && board[2,2] != ""))
            {
                eWinningMoves = WinningMoves.Row3;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks for all the vertical winning moves
        /// </summary>
        /// <returns> true or false </returns>
        private bool isVerWin()
        {
            if (board[0,0] == board[1,0] && board[1,0] == board[2,0] &&
                board[0,0] != "" && board[1,0] != "" && board[2,0] != "")
            {
                eWinningMoves = WinningMoves.Col1;
                return true;
            }

            else if (board[0,1] == board[1,1] && board[1,1] == board[2,1] &&
                board[0,1] != "" && board[1,1] != "" && board[2,1] != "")
            {
                eWinningMoves = WinningMoves.Col2;
                return true;
            }

            else if (board[0,2] == board[1,2] && board[1,2] == board[2,2] &&
                board[0,2] != "" && board[1,2] != "" && board[2,2] != "")
            {
                eWinningMoves = WinningMoves.Col3;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks for all the diagonal winning moves
        /// </summary>
        /// <returns> true or false </returns>
        private bool isDiagWin()
        {

            if (board[0,0] == board[1,1] && board[1,1] == board[2,2] &&
                board[0,0] != "" && board[1,1] != "" && board[2,2] != "")
            {
                eWinningMoves = WinningMoves.FirstDiagonal;
                return true;
            }

            else if (board[0,2] == board[1,1] && board[1,1] == board[2,0] &&
                board[0,2] != "" && board[1,1] != "" && board[2,0] != "")
            {
                eWinningMoves = WinningMoves.SecondDiagonal;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if there are no moves left on the game board.
        /// If so, the match will end in a tie.
        /// </summary>
        /// <returns> true or false </returns>
        public bool isTie()
        {
            if (board[0, 0] != "" && board[0, 1] != "" && board[0, 2] != "" &&
                board[1, 0] != "" && board[1, 1] != "" && board[1, 2] != "" &&
                board[2, 0] != "" && board[2, 1] != "" && board[2, 2] != "")
            {
                return true;
            }
            return false;
        }
    }
}

#endregion
