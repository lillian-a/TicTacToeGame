using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class MainScreen : Form
    {
        Calculations calculations;
        Button[,] buttonArray;
        int rows;
        int winner;

        public MainScreen()
        {
            InitializeComponent();
            calculations = new Calculations();
            calculations.StartUp();
            SetUpButtons();
            rows = calculations.NumRows;
            winner = 0;
            MessageLabel.Text = "";
        }

        /// UpdateWinLabel
        /// <summary>Updates message about winner</summary>
        /// <param name="player"></param>
        private void UpdateWinLabel()
        {
            MessageLabel.Text = "Player " + winner + " Wins!";
        }

        /// SetUpButtons
        /// <summary>Sets up buttonArray</summary>
        private void SetUpButtons()
        {
            rows = calculations.NumRows;
            buttonArray = new Button[rows, rows];
            buttonArray[0, 0] = button1;
            buttonArray[0, 1] = button2;
            buttonArray[0, 2] = button3;
            buttonArray[1, 0] = button4;
            buttonArray[1, 1] = button5;
            buttonArray[1, 2] = button6;
            buttonArray[2, 0] = button7;
            buttonArray[2, 1] = button8;
            buttonArray[2, 2] = button9;
            UpdateButtons();
        }

        /// UpdateButtons
        /// <summary>Updates buttons text and color</summary>
        private void UpdateButtons()
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < rows; j++)
                {
                    if (calculations.board[i, j] == 0)
                    {
                        buttonArray[i, j].Text = "_";
                        buttonArray[i, j].BackColor = Color.LightGray;
                    } else if((calculations.board[i, j] == 1))
                    {
                        buttonArray[i, j].Text = "X";
                        buttonArray[i, j].BackColor = Color.LightBlue;
                    } else
                    {
                        buttonArray[i, j].Text = "O";
                        buttonArray[i, j].BackColor = Color.LightGreen;
                    }
                }
            }
        }

        /// ShowMessage
        /// <summary>Uses MessageBox to show user a message</summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="btns"></param>
        /// <param name="icon"></param>
        private void ShowMessage(string message, string caption,
                                MessageBoxButtons btns = MessageBoxButtons.OK,
                                MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            DialogResult result;
            result = MessageBox.Show(message, caption, btns, icon);
        }
        
        /// RestartButton_Click
        /// <summary>Process the Restart Game procedure</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestartButton_Click(object sender, EventArgs e)
        {
            calculations.Restart();
            UpdateBoard();
            MessageLabel.Text = "";
        }

        /// QuitButton_Click
        /// <summary>Process Quit Game Procedure</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitButton_Click(object sender, EventArgs e)
        {
            const string msg = "Thanks for playing!\n" +
                    "Good-bye!";
            const string caption = "Exiting";
            ShowMessage(msg, caption);
            this.Close();
            Application.Exit();
        }

        /// UpdateBoard
        /// <summary>
        /// Updates buttons
        /// Checks for a win horizontally, vertically and diagonally
        /// if win exists, processes ProcessWinGame procedure
        /// if tie exists, processes ProcessTieGame procedure
        /// </summary>
        private void UpdateBoard()
        {
            UpdateButtons();
            //check for win
            if (calculations.CheckColumns(calculations.board))
            {
                ProcessWinGame();
            } else if (calculations.CheckRows(calculations.board))
            {
                ProcessWinGame();
            } else if (calculations.CheckDiagonals(calculations.board))
            {
                ProcessWinGame();
            } else
            {
                // check for scratch game
                if ((calculations.P1NumTurns + calculations.P2NumTurns) == 9)
                {
                    ProcessTieGame();
                }
            }
        }

        /// ProcessTieGame
        /// <summary>Processes tie game message</summary>
        private void ProcessTieGame()
        {
            const string msg = "GAME OVER\n" +
                    "No winner in this game.\n" +
                    "Click Restart to Play Again or\n" +
                    "Click Quit to Quit Application.";
            const string caption = "Game Over";
            ShowMessage(msg, caption);
        }

        /// ProcessWinGame
        /// <summary>Updates winner messages
        /// and Displays win message</summary>
        private void ProcessWinGame()
        {
            UpdateWinner();
            UpdateWinLabel();
            const string msg = "GAME OVER\n" +
                    "Congraulations Winner!\n" +
                    "Click Restart to Play Again or\n" +
                    "Click Quit to Quit Application.";
            const string caption = "Game Over";
            ShowMessage(msg, caption);
        }

        /// UpdateWinner
        /// <summary> updates winner int
        /// if P1 has higher number of turns then P2 then P1 is winner since they started</summary>
        private void UpdateWinner()
        {
            if (calculations.P1NumTurns > calculations.P2NumTurns)
            {
                winner = 1;
            } else
            {
                winner = 2;
            }
        }

        /// CheckButton
        /// <summary>
        /// takes in the row and column of button that was clicked
        /// checks whose turn it was and then updates the board
        /// gives error message if button was already taken
        /// </summary>
        /// <param name="r">row of button</param>
        /// <param name="c">column of button</param>
        private void CheckButton(int r, int c)
        {
            if (calculations.board[r, c] == 0)
            {
                if (calculations.P1NumTurns <= calculations.P2NumTurns)
                {
                    calculations.board[r, c] = 1;
                    calculations.P1NumTurns += 1;
                    UpdateBoard();
                }
                else
                {
                    calculations.board[r, c] = 2;
                    calculations.P2NumTurns += 1;
                    UpdateBoard();
                }
            }
            else
            {
                const string msg = "Space already taken.\n" +
                    "Choose another spot.";
                const string caption = "Error";
                ShowMessage(msg, caption);
            }
        }

        /// button1_Click
        /// <summary>Button click functioning for Button 1</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            CheckButton(0, 0);
        }

        /// button2_Click
        /// <summary>Button click functioning for Button 2</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            CheckButton(0, 1);
        }

        /// button3_Click
        /// <summary>Button click functioning for Button 3</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, EventArgs e)
        {
            CheckButton(0, 2);
        }

        /// button4_Click
        /// <summary>Button click functioning for Button 4</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4_Click(object sender, EventArgs e)
        {
            CheckButton(1, 0);
        }

        /// button5_Click
        /// <summary>Button click functioning for Button 5</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button5_Click(object sender, EventArgs e)
        {
            CheckButton(1, 1);
        }

        /// button6_Click
        /// <summary>Button click functioning for Button 6</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button6_Click(object sender, EventArgs e)
        {
            CheckButton(1, 2);
        }

        /// button7_Click
        /// <summary>Button click functioning for Button 7</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button7_Click(object sender, EventArgs e)
        {
            CheckButton(2, 0);
        }

        /// button8_Click
        /// <summary>Button click functioning for Button 8</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button8_Click(object sender, EventArgs e)
        {
            CheckButton(2, 1);
        }

        /// button9_Click
        /// <summary>Button click functioning for Button 9</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button9_Click(object sender, EventArgs e)
        {

            CheckButton(2, 2);
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
