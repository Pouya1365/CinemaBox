namespace CinemaBox.UserController.Entertainment.Movies
{
    partial class ShowMovieIcon
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Pic_Poster = new PictureBox();
            Lbl_Title = new Ces.WinForm.UI.CesLabel();
            Lbl_Year = new Ces.WinForm.UI.CesLabel();
            ((System.ComponentModel.ISupportInitialize)Pic_Poster).BeginInit();
            SuspendLayout();
            // 
            // Pic_Poster
            // 
            Pic_Poster.Location = new Point(0, 0);
            Pic_Poster.Name = "Pic_Poster";
            Pic_Poster.Size = new Size(153, 173);
            Pic_Poster.SizeMode = PictureBoxSizeMode.StretchImage;
            Pic_Poster.TabIndex = 0;
            Pic_Poster.TabStop = false;
            Pic_Poster.Click += new EventHandler(Pic_Poster_Click);
            // 
            // Lbl_Title
            // 
            Lbl_Title.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            Lbl_Title.CesShowUnderLine = false;
            Lbl_Title.CesUnderlineColor = Color.Black;
            Lbl_Title.CesUnderlineThickness = 1;
            Lbl_Title.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            Lbl_Title.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Title.Location = new Point(0, 179);
            Lbl_Title.Margin = new Padding(3);
            Lbl_Title.Name = "Lbl_Title";
            Lbl_Title.Size = new Size(153, 24);
            Lbl_Title.TabIndex = 1;
            Lbl_Title.Text = "-";
            Lbl_Title.TextAlign = ContentAlignment.TopCenter;
            // 
            // Lbl_Year
            // 
            Lbl_Year.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            Lbl_Year.CesShowUnderLine = false;
            Lbl_Year.CesUnderlineColor = Color.Black;
            Lbl_Year.CesUnderlineThickness = 1;
            Lbl_Year.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            Lbl_Year.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Year.Location = new Point(0, 220);
            Lbl_Year.Margin = new Padding(3);
            Lbl_Year.Name = "Lbl_Year";
            Lbl_Year.Size = new Size(153, 24);
            Lbl_Year.TabIndex = 2;
            Lbl_Year.Text = "-";
            Lbl_Year.TextAlign = ContentAlignment.TopCenter;
            // 
            // ShowMovieIcon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Lbl_Year);
            Controls.Add(Lbl_Title);
            Controls.Add(Pic_Poster);
            Name = "ShowMovieIcon";
            Size = new Size(154, 262);
            ((System.ComponentModel.ISupportInitialize)Pic_Poster).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox Pic_Poster;
        private Ces.WinForm.UI.CesLabel Lbl_Title;
        private Ces.WinForm.UI.CesLabel Lbl_Year;
    }
}