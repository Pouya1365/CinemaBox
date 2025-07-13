namespace CinemaBox.UserController.People.People
{
    partial class ShowPeoples
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
            Txt_FullName = new Ces.WinForm.UI.CesLabel();
            Pic_People = new Ces.WinForm.UI.CesPictureBox();
            SuspendLayout();
            // 
            // Txt_FullName
            // 
            Txt_FullName.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            Txt_FullName.CesShowUnderLine = false;
            Txt_FullName.CesUnderlineColor = Color.Black;
            Txt_FullName.CesUnderlineThickness = 1;
            Txt_FullName.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            Txt_FullName.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_FullName.Location = new Point(3, 240);
            Txt_FullName.Margin = new Padding(3);
            Txt_FullName.Name = "Txt_FullName";
            Txt_FullName.Size = new Size(222, 56);
            Txt_FullName.TabIndex = 6;
            Txt_FullName.Text = "cesLabel1";
            Txt_FullName.TextAlign = ContentAlignment.TopCenter;
            // 
            // Pic_People
            // 
            Pic_People.CesBorderColor = Color.DarkOrange;
            Pic_People.CesBorderThickness = 2;
            Pic_People.CesBorderType = System.Drawing.Drawing2D.DashStyle.Solid;
            Pic_People.CesImage = null;
            Pic_People.CesShowBorder = true;
            Pic_People.Location = new Point(5, -3);
            Pic_People.Name = "Pic_People";
            Pic_People.Size = new Size(217, 217);
            Pic_People.TabIndex = 5;
            // 
            // ShowPeoples
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Txt_FullName);
            Controls.Add(Pic_People);
            Name = "ShowPeoples";
            Size = new Size(225, 311);
            ResumeLayout(false);
        }

        #endregion
        private Ces.WinForm.UI.CesLabel Txt_FullName;
        private Ces.WinForm.UI.CesPictureBox Pic_People;
    }
}
