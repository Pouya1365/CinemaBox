namespace CinemaBox.Presentation
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Pnl_Search = new Ces.WinForm.UI.CesPanel();
            Btn_GetInfo = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            Btn_Search = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            Txt_Search = new Ces.WinForm.UI.CesTextBox();
            cesPanel2 = new Ces.WinForm.UI.CesPanel();
            Pnl_Search.SuspendLayout();
            SuspendLayout();
            // 
            // btnOptions
            // 
            btnOptions.FlatAppearance.BorderColor = Color.DarkGreen;
            btnOptions.FlatAppearance.BorderSize = 0;
            btnOptions.FlatAppearance.MouseDownBackColor = Color.MediumSeaGreen;
            btnOptions.FlatAppearance.MouseOverBackColor = Color.DarkSeaGreen;
            // 
            // Pnl_Search
            // 
            Pnl_Search.CesBorderColor = Color.Black;
            Pnl_Search.CesBorderThickness = 1F;
            Pnl_Search.CesBorderVisible = true;
            Pnl_Search.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            Pnl_Search.CesVisibleBottomBorder = true;
            Pnl_Search.CesVisibleLeftBorder = true;
            Pnl_Search.CesVisibleRightBorder = true;
            Pnl_Search.CesVisibleTopBorder = true;
            Pnl_Search.Controls.Add(Btn_GetInfo);
            Pnl_Search.Controls.Add(Btn_Search);
            Pnl_Search.Controls.Add(Txt_Search);
            Pnl_Search.Dock = DockStyle.Top;
            Pnl_Search.Location = new Point(2, 32);
            Pnl_Search.Name = "Pnl_Search";
            Pnl_Search.Size = new Size(1147, 100);
            Pnl_Search.TabIndex = 7;
            // 
            // Btn_GetInfo
            // 
            Btn_GetInfo.BackColor = SystemColors.Control;
            Btn_GetInfo.CesBackColor = Color.Gray;
            Btn_GetInfo.CesBorderColor = Color.FromArgb(64, 64, 64);
            Btn_GetInfo.CesBorderRadius = 15;
            Btn_GetInfo.CesBorderThickness = 1;
            Btn_GetInfo.CesBorderVisible = false;
            Btn_GetInfo.CesCircular = false;
            Btn_GetInfo.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Gray;
            Btn_GetInfo.CesFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_GetInfo.CesForeColor = Color.Black;
            Btn_GetInfo.CesIcon = null;
            Btn_GetInfo.CesIconAlignment = ContentAlignment.MiddleCenter;
            Btn_GetInfo.CesMouseDownColor = Color.Gray;
            Btn_GetInfo.CesMouseOverColor = Color.DarkGray;
            Btn_GetInfo.CesShowIcon = false;
            Btn_GetInfo.CesShowText = true;
            Btn_GetInfo.CesText = "دریافت اطلاعات";
            Btn_GetInfo.CesTextAlignment = ContentAlignment.MiddleCenter;
            Btn_GetInfo.Location = new Point(69, 39);
            Btn_GetInfo.Name = "Btn_GetInfo";
            Btn_GetInfo.Size = new Size(134, 44);
            Btn_GetInfo.TabIndex = 2;
            Btn_GetInfo.Click += Btn_GetInfo_Click;
            // 
            // Btn_Search
            // 
            Btn_Search.BackColor = SystemColors.Control;
            Btn_Search.CesBackColor = Color.FromArgb(0, 192, 0);
            Btn_Search.CesBorderColor = Color.FromArgb(64, 64, 64);
            Btn_Search.CesBorderRadius = 15;
            Btn_Search.CesBorderThickness = 1;
            Btn_Search.CesBorderVisible = false;
            Btn_Search.CesCircular = false;
            Btn_Search.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Gray;
            Btn_Search.CesFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Search.CesForeColor = Color.Black;
            Btn_Search.CesIcon = null;
            Btn_Search.CesIconAlignment = ContentAlignment.MiddleCenter;
            Btn_Search.CesMouseDownColor = Color.FromArgb(0, 192, 0);
            Btn_Search.CesMouseOverColor = Color.DarkGray;
            Btn_Search.CesShowIcon = false;
            Btn_Search.CesShowText = true;
            Btn_Search.CesText = "جستجو";
            Btn_Search.CesTextAlignment = ContentAlignment.MiddleCenter;
            Btn_Search.Location = new Point(209, 39);
            Btn_Search.Name = "Btn_Search";
            Btn_Search.Size = new Size(134, 44);
            Btn_Search.TabIndex = 1;
            // 
            // Txt_Search
            // 
            Txt_Search._initialControlHeight = 0;
            Txt_Search.BackColor = Color.White;
            Txt_Search.CesAutoHeight = true;
            Txt_Search.CesBackColor = Color.White;
            Txt_Search.CesBorderColor = Color.DeepSkyBlue;
            Txt_Search.CesBorderRadius = 0;
            Txt_Search.CesBorderThickness = 1;
            Txt_Search.CesCharacterCasing = CharacterCasing.Normal;
            Txt_Search.CesFocusColor = Color.White;
            Txt_Search.CesHasFocus = false;
            Txt_Search.CesHasNotification = false;
            Txt_Search.CesIcon = null;
            Txt_Search.CesInputType = Ces.WinForm.UI.CesInputTypeEnum.Any;
            Txt_Search.CesMaxLength = 0;
            Txt_Search.CesMultiLine = false;
            Txt_Search.CesNotificationColor = Color.Red;
            Txt_Search.CesPadding = new Padding(5);
            Txt_Search.CesPasswordChar = '\0';
            Txt_Search.CesPlaceHolderText = null;
            Txt_Search.CesReadOnly = false;
            Txt_Search.CesRightToLeft = RightToLeft.No;
            Txt_Search.CesScrollBar = ScrollBars.None;
            Txt_Search.CesShowClearButton = false;
            Txt_Search.CesShowCopyButton = false;
            Txt_Search.CesShowIcon = false;
            Txt_Search.CesShowPasteButton = false;
            Txt_Search.CesShowTitle = true;
            Txt_Search.CesText = null;
            Txt_Search.CesTextAlignment = HorizontalAlignment.Left;
            Txt_Search.CesTheme = Ces.WinForm.UI.Infrastructure.ThemeEnum.White;
            Txt_Search.CesTitleAutoHeight = false;
            Txt_Search.CesTitleAutoWidth = false;
            Txt_Search.CesTitleBackground = true;
            Txt_Search.CesTitleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_Search.CesTitleHeight = 25;
            Txt_Search.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right;
            Txt_Search.CesTitleText = "جستجو";
            Txt_Search.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            Txt_Search.CesTitleTextColor = Color.White;
            Txt_Search.CesTitleWidth = 80;
            Txt_Search.CesWordWrap = false;
            Txt_Search.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_Search.Location = new Point(349, 39);
            Txt_Search.Margin = new Padding(3, 4, 3, 4);
            Txt_Search.Name = "Txt_Search";
            Txt_Search.Padding = new Padding(3, 4, 3, 4);
            Txt_Search.Size = new Size(723, 44);
            Txt_Search.TabIndex = 0;
            // 
            // cesPanel2
            // 
            cesPanel2.CesBorderColor = Color.Black;
            cesPanel2.CesBorderThickness = 1F;
            cesPanel2.CesBorderVisible = true;
            cesPanel2.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            cesPanel2.CesVisibleBottomBorder = true;
            cesPanel2.CesVisibleLeftBorder = true;
            cesPanel2.CesVisibleRightBorder = true;
            cesPanel2.CesVisibleTopBorder = true;
            cesPanel2.Dock = DockStyle.Bottom;
            cesPanel2.Location = new Point(2, 138);
            cesPanel2.Name = "cesPanel2";
            cesPanel2.Size = new Size(1147, 493);
            cesPanel2.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1151, 633);
            Controls.Add(cesPanel2);
            Controls.Add(Pnl_Search);
            Name = "Form1";
            Text = "Form1";
            Controls.SetChildIndex(Pnl_Search, 0);
            Controls.SetChildIndex(cesPanel2, 0);
            Pnl_Search.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Ces.WinForm.UI.CesPanel Pnl_Search;
        private Ces.WinForm.UI.CesPanel cesPanel2;
        private Ces.WinForm.UI.CesTextBox Txt_Search;
        private Ces.WinForm.UI.CesButton.CesRoundedButton Btn_Search;
        private Ces.WinForm.UI.CesButton.CesRoundedButton Btn_GetInfo;
    }
}
