using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pursuit
{
    public partial class GameForm : Form
    {
        Random random = new Random();

        PictureBox[,] boardArr2D;

        string[,] question;

        bool gameActive = true; // Game Status //
        int turnWho = 0; // If Equals To 0 = Blue Player Turn, If Equals To 1 = Red Player Turn //
        int blueLocationX = 0, blueLocationY = 0; // Blue Player Location Variables //
        int redLocationX = 0, redLocationY = 0; // Red Player Location Variables //
        int presentsAmount = 5; // Amount Of Presents That Will Be In The Game //
        int randomQuestion; // Random Question //

        public GameForm()
        {
            InitializeComponent();

            // Places The Form In The Middle Of The Screen //
            StartPosition = FormStartPosition.CenterScreen;
        }
        
        private void GameForm_Load(object sender, EventArgs e)
        {
            CreateBoard();
        }

        #region Game Functions

        // Creates Game Board //
        public void CreateBoard()
        {
            // Variables //
            int x, y;
            int w, h;
            int dw;
            int dh;

            // Sets "boardArr2D" Size //
            boardArr2D = new PictureBox[LaunchForm.squareAmount, LaunchForm.squareAmount];

            x = 10;
            y = 10;

            // Sets Width & Height Of The Board By Form Height (Matrix) //
            w = ClientSize.Height / boardArr2D.GetLength(1);
            h = ClientSize.Height / boardArr2D.GetLength(0);

            dw = w / 10;
            dh = h / 10;

            h -= dh;
            w -= dw;

            // Creates "boardArr2D" & Makes It Visible //
            for (int i = 0; i < boardArr2D.GetLength(0); i++)
            {
                for (int j = 0; j < boardArr2D.GetLength(1); j++)
                {
                    boardArr2D[i, j] = new PictureBox();
                    this.Controls.Add(boardArr2D[i, j]);
                    
                    boardArr2D[i, j].Location = new Point(x, y);
                    boardArr2D[i, j].Size = new Size(w, h);

                    boardArr2D[i, j].BackgroundImage = Properties.Resources.Frame;
                    boardArr2D[i, j].BackgroundImageLayout = ImageLayout.Stretch;

                    boardArr2D[i, j].Tag = "none";

                    x += w + dw;
                }

                x = 10;
                y += h + dh;
            }

            // Sets "picBox_PlayerBlue" & "picBox_PlayerRed" Size By "boardArr2D Size" //
            picBox_PlayerBlue.Size = new Size(w, h);
            picBox_PlayerRed.Size = new Size(w, h);

            // Sets Visual Location Of Player Blue & Player Red //
            picBox_PlayerBlue.Location = new Point(10, 10);
            picBox_PlayerRed.Location = new Point(10, 10 + (h + dh) * LaunchForm.distanceAmount);

            // Blue Player Initial Values //
            blueLocationX = 0;
            blueLocationY = 0;

            // Red Player Initial Values //
            redLocationX = 0;
            redLocationY = LaunchForm.distanceAmount;

            // Adds Tags //
            boardArr2D[blueLocationY, blueLocationX].Tag = "blue start";
            boardArr2D[redLocationY, redLocationX].Tag = "red start";
            boardArr2D[LaunchForm.squareAmount - 1, LaunchForm.squareAmount - 1].Tag = "end";

            QuestionsStock();

            PresentSet(boardArr2D, random, presentsAmount);
        }

        // Movement Function //
        public void PlayerMovement(PictureBox[,] boardArr2D)
        {
            // Rolls Random Number Between 1 To 5 //
            int rolledNumber = random.Next(1, 6);

            // Updates "lbl_RolledNumber" Text To The Current Rolled Number //
            lbl_RolledNumber.Text = $"Rolled Number > {rolledNumber}";

            // Blue Turn //
            if (turnWho == 0)
            {
                lbl_RolledNumber.ForeColor = Color.FromArgb(50, 125, 200);

                // If blueLocationX + RolledNumber Will Go Out Of The Array //
                if (blueLocationX + rolledNumber >= boardArr2D.GetLength(1))
                {
                    // If End Then //
                    if (blueLocationX + rolledNumber >= boardArr2D.GetLength(1) && blueLocationY == LaunchForm.squareAmount - 1)
                    {
                        redLocationX = LaunchForm.squareAmount - 1;
                        redLocationY = LaunchForm.squareAmount - 1;
                    }

                    // If NOT End Then //
                    else
                    {
                        rolledNumber -= boardArr2D.GetLength(1) - blueLocationX;

                        blueLocationY += 1;
                        blueLocationX = rolledNumber;

                        if (blueLocationX >= boardArr2D.GetLength(1))
                            blueLocationX = LaunchForm.squareAmount - 1;

                        if (blueLocationY >= boardArr2D.GetLength(0))
                            blueLocationY = LaunchForm.squareAmount - 1;
                    }
                }

                // If blueLocationX + RolledNumber Will NOT Go Out Of The Array //
                else
                {
                    // If End Then //
                    if (blueLocationX + rolledNumber >= boardArr2D.GetLength(1) && blueLocationY == LaunchForm.squareAmount - 1)
                    {
                        redLocationX = LaunchForm.squareAmount - 1;
                        redLocationY = LaunchForm.squareAmount - 1;
                    }

                    // If NOT End Then //
                    else
                    {
                        blueLocationX += rolledNumber;

                        if (blueLocationX >= boardArr2D.GetLength(1))
                            blueLocationX = LaunchForm.squareAmount - 1;

                        if (blueLocationY >= boardArr2D.GetLength(0))
                            blueLocationY = LaunchForm.squareAmount - 1;
                    }
                }

                picBox_PlayerBlue.Location = boardArr2D[blueLocationY, blueLocationX].Location;

                turnWho = 1;
            }

            // Red Turn //
            else
            {
                lbl_RolledNumber.ForeColor = Color.FromArgb(175, 0, 0);

                // If redLocationX + RolledNumber Will Go Out Of The Array //
                if (redLocationX + rolledNumber >= boardArr2D.GetLength(1))
                {
                    // If End Then //
                    if (redLocationX + rolledNumber >= boardArr2D.GetLength(1) && redLocationY == LaunchForm.squareAmount - 1)
                    {
                        redLocationX = LaunchForm.squareAmount - 1;
                        redLocationY = LaunchForm.squareAmount - 1;
                    }

                    // If NOT End Then //
                    else
                    {
                        rolledNumber -= boardArr2D.GetLength(1) - redLocationX;

                        redLocationY += 1;
                        redLocationX = rolledNumber;

                        if (redLocationX >= boardArr2D.GetLength(1))
                            redLocationX = LaunchForm.squareAmount - 1;

                        if (redLocationY >= boardArr2D.GetLength(0))
                            redLocationY = LaunchForm.squareAmount - 1;
                    }
                }

                // If redLocationX + RolledNumber Will NOT Go Out Of The Array //
                else
                {
                    // If End Then //
                    if (redLocationX + rolledNumber >= boardArr2D.GetLength(1) && redLocationY == LaunchForm.squareAmount - 1)
                    {
                        redLocationX = LaunchForm.squareAmount - 1;
                        redLocationY = LaunchForm.squareAmount - 1;
                    }

                    // If NOT End Then //
                    else
                    {
                        redLocationX += rolledNumber;

                        if (redLocationX >= boardArr2D.GetLength(1))
                            redLocationX = LaunchForm.squareAmount - 1;

                        if (redLocationY >= boardArr2D.GetLength(0))
                            redLocationY = LaunchForm.squareAmount - 1;
                    }
                }

                picBox_PlayerRed.Location = boardArr2D[redLocationY, redLocationX].Location;

                turnWho = 0;
            }

            CheckCurrentBoard();
        }

        // Sets Presents //
        public void PresentSet(PictureBox[,] boardArr2D, Random random, int presentsAmount)
        {
            // Runs On "boardArr2D To Set Presents //
            while (presentsAmount > 0)
            {
                for (int i = 0; i < boardArr2D.GetLength(0); i++)
                {
                    // Stops After "x" Presents //
                    if (presentsAmount <= 0)
                        break;

                    for (int j = 0; j < boardArr2D.GetLength(1); j++)
                    {
                        // Stops After "x" Presents //
                        if (presentsAmount <= 0)
                            break;

                        // If Current Square Is Not An Start Point Or End Point //
                        if (boardArr2D[i, j].Tag.Equals("none"))
                        {
                            // If Random Number Between 1 To 25 Equals 1 //
                            if (random.Next(1, 26) == 1)
                            {
                                // Text For Developers //
                                Console.WriteLine($"Present Location [{i}, {j}].");
                                
                                // Sets Present Picture //
                                boardArr2D[i, j].BackgroundImage = Properties.Resources.Present_Icon;
                                boardArr2D[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                                
                                // Sets Present Tag //
                                boardArr2D[i, j].Tag = "present";
                                
                                presentsAmount--;
                            }
                        }
                    }
                }
            }

            // Text For Developers //
            Console.WriteLine();
        }

        // Checks If There Is Any Presents Active //
        public void PresentCheck()
        {
            // If Blue Or Red Current Location Is On Present //
            if (boardArr2D[blueLocationY, blueLocationX].Tag.Equals("present") || boardArr2D[redLocationY, redLocationX].Tag.Equals("present"))
                Question();
        }

        // Checks If There Is Any Winner //
        public void WinCheck()
        {
            // If Blue Won //
            if (blueLocationX >= redLocationX && blueLocationY >= redLocationY)
            {
                lbl_WinBlue.Visible = true;
                pnl_Finish.Visible = true;

                gameActive = false;
            }

            // If Red Won //
            if (redLocationX + 1 >= boardArr2D.GetLength(1) && redLocationY + 1 >= boardArr2D.GetLength(0))
            {
                pnl_Finish.Visible = true;
                lbl_WinRed.Visible = true;

                gameActive = false;
            }
        }

        // Checks Current Board //
        public void CheckCurrentBoard()
        {
            PresentCheck();
            WinCheck();

            // Text For Developers //
            Console.WriteLine($"Blue Location [{blueLocationY}, {blueLocationX}].");
            Console.WriteLine($"Red Location [{redLocationY}, {redLocationX}].\n");
        }

        // Questions Stock //
        public void QuestionsStock()
        {
            // "question" Size //
            question = new string[25, 3];

            // Questions                                        |   Right Answer   |                            Wrong Answer //
            question[0, 0] = "Average";                         question[0, 1] = "ממוצע";                       question[0, 2] = "גיבור";
            question[1, 0] = "Authority";                       question[1, 1] = "סמכות";                       question[1, 2] = "קוסם";
            question[2, 0] = "Contribution";                    question[2, 1] = "תרומה";                       question[2, 2] = "מצב";
            question[3, 0] = "Concern";                         question[3, 1] = "דאגה";                        question[3, 2] = "קונצרט";
            question[4, 0] = "Condition";                       question[4, 1] = "תנאי";                        question[4, 2] = "טעות";
            question[5, 0] = "Entertainment";                   question[5, 1] = "בידור";                       question[5, 2] = "פיל";
            question[6, 0] = "Equipment";                       question[6, 1] = "ציוד";                        question[6, 2] = "מגבת";
            question[7, 0] = "Expenses";                        question[7, 1] = "הוצאות";                      question[7, 2] = "מהיר";
            question[8, 0] = "Environment";                     question[8, 1] = "סביבה";                       question[8, 2] = "שקט";
            question[9, 0] = "Income";                          question[9, 1] = "הכנסה";                       question[9, 2] = "הוצאה";
            question[10, 0] = "Invention";                      question[10, 1] = "המצאה";                      question[10, 2] = "הזמנה";
            question[11, 0] = "Minority";                       question[11, 1] = "מיעוט";                      question[11, 2] = "רוב";
            question[12, 0] = "Majority";                       question[12, 1] = "רוב";                        question[12, 2] = "מיעוט";
            question[13, 0] = "Military";                       question[13, 1] = "צבאי";                       question[13, 2] = "משטרתי";
            question[14, 0] = "Method";                         question[14, 1] = "שיטה";                       question[14, 2] = "מכסה מנוע";
            question[15, 0] = "Operation";                      question[15, 1] = "ניתוח";                      question[15, 2] = "ציוד";
            question[16, 0] = "Outcome";                        question[16, 1] = "תוצאה";                      question[16, 2] = "הכנסה";
            question[17, 0] = "Requirement";                    question[17, 1] = "דרישה";                      question[17, 2] = "המלצה";
            question[18, 0] = "Recommendation";                 question[18, 1] = "המלצה";                      question[18, 2] = "דרישה";
            question[19, 0] = "Science";                        question[19, 1] = "מדע";                        question[19, 2] = "צריכה";
            question[20, 0] = "Source";                         question[20, 1] = "מקור";                       question[20, 2] = "מדע";
            question[21, 0] = "Space";                          question[21, 1] = "חלל";                        question[21, 2] = "מכונית";
            question[22, 0] = "Transport";                      question[22, 1] = "תחבורה";                     question[22, 2] = "כרטיס אשראי";
            question[23, 0] = "Welfare";                        question[23, 1] = "רווחה";                      question[23, 2] = "עכבר";
            question[24, 0] = "School";                         question[24, 1] = "בית הספר";                   question[24, 2] = "מחשב";
        }

        // Takes One Random Question //
        public int Question()
        {
            // Rolls Random Number Between 0 To 24 //
            randomQuestion = random.Next(0, 25);

            // If The Question Is Not Null //
            if (question[randomQuestion, 0] != "")
            {
                btn_Answer1.Checked = false;
                btn_Answer2.Checked = false;

                pnl_Question.Visible = true;

                lbl_Question.Text = $"Translate The Word > {question[randomQuestion, 0]}";

                // Shows Player The Answers By Random Order //
                if (random.Next(1, 3) == 1)
                {
                    btn_Answer1.Checked = false;
                    btn_Answer2.Checked = false;

                    btn_Answer1.Text = question[randomQuestion, 1];
                    btn_Answer2.Text = question[randomQuestion, 2];
                }

                // Shows Player The Answers By Random Order //
                else
                {
                    btn_Answer1.Text = question[randomQuestion, 2];
                    btn_Answer2.Text = question[randomQuestion, 1];
                }

                // Disables Question After Used //
                question[randomQuestion, 0] = "";

                // Disables Pictre Box //
                picBox_Roll.Enabled = false;

                return randomQuestion;
            }

            // If The Question Is Null //
            else
                Question();

            return -1;
        }

        // Checks If The Answer To The Question Was Correct //
        public void QuestionCheck(int randomQuestion)
        {
            // Random Bonus Number //
            int randomBonus = random.Next(LaunchForm.squareAmount / 2, LaunchForm.squareAmount + 1);

            // If Blue Turn //
            if (turnWho == 1)
            {
                // If "btn_Answer1" Is Checked //
                if (btn_Answer1.Checked)
                {
                    // If "btn_Answer1" Is Correct //
                    if (btn_Answer1.Text == question[randomQuestion, 1])
                    {
                        // If blueLocationX + RolledNumber Will Go Out Of The Array //
                        if (blueLocationX + randomBonus >= boardArr2D.GetLength(1))
                        {
                            // If End Then //
                            if (blueLocationX + randomBonus >= boardArr2D.GetLength(1) && blueLocationY == LaunchForm.squareAmount - 1)
                            {
                                redLocationX = LaunchForm.squareAmount - 1;
                                redLocationY = LaunchForm.squareAmount - 1;
                            }

                            // If NOT End Then //
                            else
                            {
                                randomBonus -= boardArr2D.GetLength(1) - blueLocationX;

                                blueLocationY += 1;
                                blueLocationX = randomBonus;

                                if (blueLocationX >= boardArr2D.GetLength(1))
                                    blueLocationX = LaunchForm.squareAmount - 1;

                                if (blueLocationY >= boardArr2D.GetLength(0))
                                    blueLocationY = LaunchForm.squareAmount - 1;
                            }
                        }

                        // If blueLocationX + RolledNumber Will NOT Go Out Of The Array //
                        else
                        {
                            // If End Then //
                            if (blueLocationX + randomBonus >= boardArr2D.GetLength(1) && blueLocationY == LaunchForm.squareAmount - 1)
                            {
                                redLocationX = LaunchForm.squareAmount - 1;
                                redLocationY = LaunchForm.squareAmount - 1;
                            }

                            // If NOT End Then //
                            else
                            {
                                blueLocationX += randomBonus;

                                if (blueLocationX >= boardArr2D.GetLength(1))
                                    blueLocationX = LaunchForm.squareAmount - 1;

                                if (blueLocationY >= boardArr2D.GetLength(0))
                                    blueLocationY = LaunchForm.squareAmount - 1;
                            }
                        }
                    }

                    // If "btn_Answer1" Is Uncorrect //
                    if (btn_Answer1.Text != question[randomQuestion, 1])
                    {
                        blueLocationX = 0;
                    }
                }

                // If "btn_Answer2" Is Checked //
                else
                {
                    // If "btn_Answer2" Is Correct //
                    if (btn_Answer2.Text == question[randomQuestion, 1])
                    {
                        // If blueLocationX + RolledNumber Will Go Out Of The Array //
                        if (blueLocationX + randomBonus >= boardArr2D.GetLength(1))
                        {
                            // If End Then //
                            if (blueLocationX + randomBonus >= boardArr2D.GetLength(1) && blueLocationY == LaunchForm.squareAmount - 1)
                            {
                                redLocationX = LaunchForm.squareAmount - 1;
                                redLocationY = LaunchForm.squareAmount - 1;
                            }

                            // If NOT End Then //
                            else
                            {
                                randomBonus -= boardArr2D.GetLength(1) - blueLocationX;

                                blueLocationY += 1;
                                blueLocationX = randomBonus;

                                if (blueLocationX >= boardArr2D.GetLength(1))
                                    blueLocationX = LaunchForm.squareAmount - 1;

                                if (blueLocationY >= boardArr2D.GetLength(0))
                                    blueLocationY = LaunchForm.squareAmount - 1;
                            }
                        }

                        // If blueLocationX + RolledNumber Will NOT Go Out Of The Array //
                        else
                        {
                            // If End Then //
                            if (blueLocationX + randomBonus >= boardArr2D.GetLength(1) && blueLocationY == LaunchForm.squareAmount - 1)
                            {
                                redLocationX = LaunchForm.squareAmount - 1;
                                redLocationY = LaunchForm.squareAmount - 1;
                            }

                            // If NOT End Then //
                            else
                            {
                                blueLocationX += randomBonus;

                                if (blueLocationX >= boardArr2D.GetLength(1))
                                    blueLocationX = LaunchForm.squareAmount - 1;

                                if (blueLocationY >= boardArr2D.GetLength(0))
                                    blueLocationY = LaunchForm.squareAmount - 1;
                            }
                        }
                    }

                    // If "btn_Answer2" Is Uncorrect //
                    if (btn_Answer2.Text != question[randomQuestion, 1])
                    {
                        blueLocationX = 0;
                    }
                }

                picBox_PlayerBlue.Location = boardArr2D[blueLocationY, blueLocationX].Location;
            }

            // If Red Turn //
            else
            {
                // If "btn_Answer1" Is Checked //
                if (btn_Answer1.Checked)
                {
                    // If "btn_Answer1" Is Correct //
                    if (btn_Answer1.Text == question[randomQuestion, 1])
                    {
                        // If redLocationX + RolledNumber Will Go Out Of The Array //
                        if (redLocationX + randomBonus >= boardArr2D.GetLength(1))
                        {
                            // If End Then //
                            if (redLocationX + randomBonus >= boardArr2D.GetLength(1) && redLocationY == LaunchForm.squareAmount - 1)
                            {
                                redLocationX = LaunchForm.squareAmount - 1;
                                redLocationY = LaunchForm.squareAmount - 1;
                            }

                            // If NOT End Then //
                            else
                            {
                                randomBonus -= boardArr2D.GetLength(1) - redLocationX;

                                redLocationY += 1;
                                redLocationX = randomBonus;

                                if (redLocationX >= boardArr2D.GetLength(1))
                                    redLocationX = LaunchForm.squareAmount - 1;

                                if (redLocationY >= boardArr2D.GetLength(0))
                                    redLocationY = LaunchForm.squareAmount - 1;
                            }
                        }

                        // If redLocationX + RolledNumber Will NOT Go Out Of The Array //
                        else
                        {
                            // If End Then //
                            if (redLocationX + randomBonus >= boardArr2D.GetLength(1) && redLocationY == LaunchForm.squareAmount - 1)
                            {
                                redLocationX = LaunchForm.squareAmount - 1;
                                redLocationY = LaunchForm.squareAmount - 1;
                            }

                            // If NOT End Then //
                            else
                            {
                                redLocationX += randomBonus;

                                if (redLocationX >= boardArr2D.GetLength(1))
                                    redLocationX = LaunchForm.squareAmount - 1;

                                if (redLocationY >= boardArr2D.GetLength(0))
                                    redLocationY = LaunchForm.squareAmount - 1;
                            }
                        }
                    }

                    // If "btn_Answer1" Is Uncorrect //
                    if (btn_Answer1.Text != question[randomQuestion, 1])
                    {
                        redLocationX = 0;
                    }
                }

                // If "btn_Answer2" Is Checked //
                else
                {
                    // If "btn_Answer2" Is Correct //
                    if (btn_Answer2.Text == question[randomQuestion, 1])
                    {
                        // If redLocationX + RolledNumber Will Go Out Of The Array //
                        if (redLocationX + randomBonus >= boardArr2D.GetLength(1))
                        {
                            // If End Then //
                            if (redLocationX + randomBonus >= boardArr2D.GetLength(1) && redLocationY == LaunchForm.squareAmount - 1)
                            {
                                redLocationX = LaunchForm.squareAmount - 1;
                                redLocationY = LaunchForm.squareAmount - 1;
                            }

                            // If NOT End Then //
                            else
                            {
                                randomBonus -= boardArr2D.GetLength(1) - redLocationX;

                                redLocationY += 1;
                                redLocationX = randomBonus;

                                if (redLocationX >= boardArr2D.GetLength(1))
                                    redLocationX = LaunchForm.squareAmount - 1;

                                if (redLocationY >= boardArr2D.GetLength(0))
                                    redLocationY = LaunchForm.squareAmount - 1;
                            }
                        }

                        // If redLocationX + RolledNumber Will NOT Go Out Of The Array //
                        else
                        {
                            // If End Then //
                            if (redLocationX + randomBonus >= boardArr2D.GetLength(1) && redLocationY == LaunchForm.squareAmount - 1)
                            {
                                redLocationX = LaunchForm.squareAmount - 1;
                                redLocationY = LaunchForm.squareAmount - 1;
                            }

                            // If NOT End Then //
                            else
                            {
                                redLocationX += randomBonus;

                                if (redLocationX >= boardArr2D.GetLength(1))
                                    redLocationX = LaunchForm.squareAmount - 1;

                                if (redLocationY >= boardArr2D.GetLength(0))
                                    redLocationY = LaunchForm.squareAmount - 1;
                            }
                        }
                    }

                    // If "btn_Answer2" Is Uncorrect //
                    if (btn_Answer2.Text != question[randomQuestion, 1])
                    {
                        redLocationX = 0;
                    }
                }

                picBox_PlayerRed.Location = boardArr2D[redLocationY, redLocationX].Location;
            }
        }

        // "Roll It" Button //
        public void picBox_Roll_Click(object sender, EventArgs e)
        {
            PlayerMovement(boardArr2D);
        }

        // "Confirm" Button //
        private void lbl_Confirm_Click(object sender, EventArgs e)
        {
            if (btn_Answer1.Checked == false && btn_Answer2.Checked == false)
                return;

            QuestionCheck(randomQuestion);
            CheckCurrentBoard();

            pnl_Question.Visible = false;

            picBox_Roll.Enabled = true;
        }

        #endregion

        #region Menu Functions

        private void picBox_GameMenu_Click(object sender, EventArgs e)
        {
            pnl_Menu.Visible = true;
        }

        private void picBox_FinishMenu_Click(object sender, EventArgs e)
        {
            picBox_GameMenu.Visible = false;
            pnl_Finish.Visible = false;

            pnl_Menu.Visible = true;

            if (gameActive == true)
                lbl_Resume.Text = "Resume Game";

            if (gameActive == false)
                lbl_Resume.Text = "View Board";
        }

        private void lbl_Resume_Click(object sender, EventArgs e)
        {
            pnl_Menu.Visible = false;
            pnl_Rules.Visible = false;
            picBox_GameMenu.Visible = true;

            if (gameActive == false)
            {
                picBox_Roll.Visible = false;
                lbl_RolledNumber.Visible = false;
                pnl_Question.Visible = false;
            }
        }

        private void lbl_Rules_Click(object sender, EventArgs e)
        {
            pnl_Menu.Visible = false;
            pnl_Rules.Visible = true;
        }

        private void lbl_Restart_Click(object sender, EventArgs e)
        {
            // Resets Variables //
            Controls.Clear();

            // Makes LaunchForm Visible //
            LaunchForm LaunchForm = new LaunchForm();
            LaunchForm.Show();
            Hide();
        }

        #endregion
    }
}