namespace CinemaBox.UserController.Entertainment.CreditShow
{
    partial class ShowCrews
    { /// <summary> 
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
            Pic_People = new Ces.WinForm.UI.CesPictureBox();
            Txt_FullName = new Ces.WinForm.UI.CesLabel();
            Txt_CreditType = new Ces.WinForm.UI.CesLabel();
            Txt_RoleName = new Ces.WinForm.UI.CesLabel();
            Chk_IsLeadRole = new Ces.WinForm.UI.CesCheckBox();
            SuspendLayout();
            // 
            // Pic_People
            // 
            Pic_People.CesBorderColor = Color.DarkOrange;
            Pic_People.CesBorderThickness = 2;
            Pic_People.CesBorderType = System.Drawing.Drawing2D.DashStyle.Solid;
            Pic_People.CesImage = null;
            Pic_People.CesShowBorder = true;
            Pic_People.Location = new Point(0, 0);
            Pic_People.Name = "Pic_People";
            Pic_People.Size = new Size(217, 217);
            Pic_People.TabIndex = 0;
            Pic_People.Load += Pic_People_Load;
            // 
            // Txt_FullName
            // 
            Txt_FullName.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            Txt_FullName.CesShowUnderLine = false;
            Txt_FullName.CesUnderlineColor = Color.Black;
            Txt_FullName.CesUnderlineThickness = 1;
            Txt_FullName.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            Txt_FullName.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_FullName.Location = new Point(3, 223);
            Txt_FullName.Margin = new Padding(3);
            Txt_FullName.Name = "Txt_FullName";
            Txt_FullName.Size = new Size(214, 26);
            Txt_FullName.TabIndex = 1;
            Txt_FullName.Text = "cesLabel1";
            Txt_FullName.TextAlign = ContentAlignment.TopCenter;
            // 
            // Txt_CreditType
            // 
            Txt_CreditType.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            Txt_CreditType.CesShowUnderLine = false;
            Txt_CreditType.CesUnderlineColor = Color.Black;
            Txt_CreditType.CesUnderlineThickness = 1;
            Txt_CreditType.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            Txt_CreditType.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_CreditType.Location = new Point(0, 255);
            Txt_CreditType.Margin = new Padding(3);
            Txt_CreditType.Name = "Txt_CreditType";
            Txt_CreditType.Size = new Size(214, 26);
            Txt_CreditType.TabIndex = 2;
            Txt_CreditType.Text = "cesLabel1";
            Txt_CreditType.TextAlign = ContentAlignment.TopCenter;
            // 
            // Txt_RoleName
            // 
            Txt_RoleName.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            Txt_RoleName.CesShowUnderLine = false;
            Txt_RoleName.CesUnderlineColor = Color.Black;
            Txt_RoleName.CesUnderlineThickness = 1;
            Txt_RoleName.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            Txt_RoleName.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_RoleName.Location = new Point(0, 287);
            Txt_RoleName.Margin = new Padding(3);
            Txt_RoleName.Name = "Txt_RoleName";
            Txt_RoleName.Size = new Size(214, 26);
            Txt_RoleName.TabIndex = 3;
            Txt_RoleName.Text = "cesLabel1";
            Txt_RoleName.TextAlign = ContentAlignment.TopCenter;
            // 
            // Chk_IsLeadRole
            // 
            Chk_IsLeadRole.CesAllowNullValue = false;
            Chk_IsLeadRole.CesCheck = false;
            Chk_IsLeadRole.CesSize = Ces.WinForm.UI.CesCheckBoxSizeEnum.Small;
            Chk_IsLeadRole.CesText = "نقش اصلی";
            Chk_IsLeadRole.CesType = Ces.WinForm.UI.CesCheckBoxTypeEnum.TypeC;
            Chk_IsLeadRole.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Chk_IsLeadRole.Location = new Point(4, 322);
            Chk_IsLeadRole.Margin = new Padding(3, 4, 3, 4);
            Chk_IsLeadRole.Name = "Chk_IsLeadRole";
            Chk_IsLeadRole.RightToLeft = RightToLeft.Yes;
            Chk_IsLeadRole.Size = new Size(216, 26);
            Chk_IsLeadRole.TabIndex = 4;
            // 
            // ShowCrews
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(Chk_IsLeadRole);
            Controls.Add(Txt_RoleName);
            Controls.Add(Txt_CreditType);
            Controls.Add(Txt_FullName);
            Controls.Add(Pic_People);
            Name = "ShowCrews";
            Size = new Size(220, 352);
            ResumeLayout(false);
        }

        #endregion

        private Ces.WinForm.UI.CesPictureBox Pic_People;
        private Ces.WinForm.UI.CesLabel Txt_FullName;
        private Ces.WinForm.UI.CesLabel Txt_CreditType;
        private Ces.WinForm.UI.CesLabel Txt_RoleName;
        private Ces.WinForm.UI.CesCheckBox Chk_IsLeadRole;
    }
}