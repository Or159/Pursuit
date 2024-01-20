using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pursuit
{
    public partial class LaunchForm : Form
    {
        public static int squareAmount; // Square Amount (x * x) //
        public static int distanceAmount; // Distance Amount Between Blue Player To Red Player //

        public LaunchForm()
        {
            InitializeComponent();

            // Places The Form In The Middle Of The Screen //
            StartPosition = FormStartPosition.CenterScreen;
        }

        public void picBox_Play_Click(object sender, EventArgs e)
        {
            lbl_Error.Visible = false;

            // Checks If The Variable Contains A Number //
            if (txtBox_SquareAmount.Text.All(char.IsDigit) == true && txtBox_SquareAmount.Text != "")
            {
                // Checks If The Variable Contains A Number //
                if (txtBox_DistanceAmount.Text.All(char.IsDigit) == true && txtBox_DistanceAmount.Text != "")
                {
                    // Convert String To Int //
                    squareAmount = Int32.Parse(txtBox_SquareAmount.Text);
                    distanceAmount = Int32.Parse(txtBox_DistanceAmount.Text);

                    // Makes GameForm Visible //
                    GameForm GameForm = new GameForm();
                    GameForm.Show();
                    Hide();
                }

                else
                    lbl_Error.Visible = true;
            }

            else
                lbl_Error.Visible = true;
        }
    }
}