namespace Pursuit
{
    partial class LaunchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Pursuit = new System.Windows.Forms.Label();
            this.lbl_SquareAmount = new System.Windows.Forms.Label();
            this.lbl_DistanceAmount = new System.Windows.Forms.Label();
            this.txtBox_SquareAmount = new System.Windows.Forms.TextBox();
            this.txtBox_DistanceAmount = new System.Windows.Forms.TextBox();
            this.lbl_Credit = new System.Windows.Forms.Label();
            this.lbl_Error = new System.Windows.Forms.Label();
            this.picBox_Play = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Play)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Pursuit
            // 
            this.lbl_Pursuit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Pursuit.AutoSize = true;
            this.lbl_Pursuit.Font = new System.Drawing.Font("Calibri", 34.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_Pursuit.Location = new System.Drawing.Point(435, 10);
            this.lbl_Pursuit.Name = "lbl_Pursuit";
            this.lbl_Pursuit.Size = new System.Drawing.Size(200, 71);
            this.lbl_Pursuit.TabIndex = 0;
            this.lbl_Pursuit.Text = "Pursuit";
            this.lbl_Pursuit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_SquareAmount
            // 
            this.lbl_SquareAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_SquareAmount.AutoSize = true;
            this.lbl_SquareAmount.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold);
            this.lbl_SquareAmount.Location = new System.Drawing.Point(50, 150);
            this.lbl_SquareAmount.Name = "lbl_SquareAmount";
            this.lbl_SquareAmount.Size = new System.Drawing.Size(442, 51);
            this.lbl_SquareAmount.TabIndex = 1;
            this.lbl_SquareAmount.Text = "Enter Square Amount > ";
            this.lbl_SquareAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_DistanceAmount
            // 
            this.lbl_DistanceAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_DistanceAmount.AutoSize = true;
            this.lbl_DistanceAmount.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold);
            this.lbl_DistanceAmount.Location = new System.Drawing.Point(50, 250);
            this.lbl_DistanceAmount.Name = "lbl_DistanceAmount";
            this.lbl_DistanceAmount.Size = new System.Drawing.Size(470, 51);
            this.lbl_DistanceAmount.TabIndex = 2;
            this.lbl_DistanceAmount.Text = "Enter Distance Amount > ";
            this.lbl_DistanceAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBox_SquareAmount
            // 
            this.txtBox_SquareAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox_SquareAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(125)))));
            this.txtBox_SquareAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBox_SquareAmount.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold);
            this.txtBox_SquareAmount.ForeColor = System.Drawing.Color.White;
            this.txtBox_SquareAmount.Location = new System.Drawing.Point(525, 150);
            this.txtBox_SquareAmount.Multiline = true;
            this.txtBox_SquareAmount.Name = "txtBox_SquareAmount";
            this.txtBox_SquareAmount.Size = new System.Drawing.Size(150, 51);
            this.txtBox_SquareAmount.TabIndex = 3;
            this.txtBox_SquareAmount.Text = "x";
            // 
            // txtBox_DistanceAmount
            // 
            this.txtBox_DistanceAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox_DistanceAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(125)))));
            this.txtBox_DistanceAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBox_DistanceAmount.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold);
            this.txtBox_DistanceAmount.ForeColor = System.Drawing.Color.White;
            this.txtBox_DistanceAmount.Location = new System.Drawing.Point(525, 250);
            this.txtBox_DistanceAmount.Multiline = true;
            this.txtBox_DistanceAmount.Name = "txtBox_DistanceAmount";
            this.txtBox_DistanceAmount.Size = new System.Drawing.Size(150, 51);
            this.txtBox_DistanceAmount.TabIndex = 4;
            this.txtBox_DistanceAmount.Text = "x";
            // 
            // lbl_Credit
            // 
            this.lbl_Credit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Credit.AutoSize = true;
            this.lbl_Credit.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Credit.ForeColor = System.Drawing.Color.White;
            this.lbl_Credit.Location = new System.Drawing.Point(12, 516);
            this.lbl_Credit.Name = "lbl_Credit";
            this.lbl_Credit.Size = new System.Drawing.Size(232, 25);
            this.lbl_Credit.TabIndex = 6;
            this.lbl_Credit.Text = "Developed By Or Avrahami";
            this.lbl_Credit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Error
            // 
            this.lbl_Error.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Error.AutoSize = true;
            this.lbl_Error.Font = new System.Drawing.Font("Calibri", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_Error.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(25)))), ((int)(((byte)(0)))));
            this.lbl_Error.Location = new System.Drawing.Point(465, 380);
            this.lbl_Error.Name = "lbl_Error";
            this.lbl_Error.Size = new System.Drawing.Size(123, 51);
            this.lbl_Error.TabIndex = 7;
            this.lbl_Error.Text = "Error!";
            this.lbl_Error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Error.Visible = false;
            // 
            // picBox_Play
            // 
            this.picBox_Play.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBox_Play.Image = global::Pursuit.Properties.Resources.Play_Button;
            this.picBox_Play.Location = new System.Drawing.Point(400, 450);
            this.picBox_Play.Name = "picBox_Play";
            this.picBox_Play.Size = new System.Drawing.Size(225, 75);
            this.picBox_Play.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_Play.TabIndex = 5;
            this.picBox_Play.TabStop = false;
            this.picBox_Play.Click += new System.EventHandler(this.picBox_Play_Click);
            // 
            // LaunchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 40F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.lbl_Error);
            this.Controls.Add(this.lbl_Credit);
            this.Controls.Add(this.picBox_Play);
            this.Controls.Add(this.txtBox_DistanceAmount);
            this.Controls.Add(this.txtBox_SquareAmount);
            this.Controls.Add(this.lbl_DistanceAmount);
            this.Controls.Add(this.lbl_SquareAmount);
            this.Controls.Add(this.lbl_Pursuit);
            this.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "LaunchForm";
            this.Text = "Pursuit";
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Play)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Pursuit;
        private System.Windows.Forms.Label lbl_SquareAmount;
        private System.Windows.Forms.Label lbl_DistanceAmount;
        private System.Windows.Forms.TextBox txtBox_SquareAmount;
        private System.Windows.Forms.TextBox txtBox_DistanceAmount;
        private System.Windows.Forms.PictureBox picBox_Play;
        private System.Windows.Forms.Label lbl_Credit;
        private System.Windows.Forms.Label lbl_Error;
    }
}

