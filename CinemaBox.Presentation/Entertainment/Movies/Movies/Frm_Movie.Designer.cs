namespace CinemaBox.Presentation
{
    partial class Frm_Movie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Movie));
            Pnl_Search = new Ces.WinForm.UI.CesPanel();
            Btn_Backup = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            Btn_ShowTvSchedule = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            Btn_Statestics = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            Btn_People = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            Btn_GetInfo = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            Btn_Search = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            Txt_Search = new Ces.WinForm.UI.CesTextBox();
            cesPanel2 = new Ces.WinForm.UI.CesPanel();
            Flw_ShowMovie = new FlowLayoutPanel();
            Btn_AddMovieFromHDD = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            Pnl_Search.SuspendLayout();
            cesPanel2.SuspendLayout();
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
            Pnl_Search.BackColor = Color.Transparent;
            Pnl_Search.CesBorderColor = Color.Black;
            Pnl_Search.CesBorderThickness = 1F;
            Pnl_Search.CesBorderVisible = true;
            Pnl_Search.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            Pnl_Search.CesVisibleBottomBorder = true;
            Pnl_Search.CesVisibleLeftBorder = true;
            Pnl_Search.CesVisibleRightBorder = true;
            Pnl_Search.CesVisibleTopBorder = true;
            Pnl_Search.Controls.Add(Btn_AddMovieFromHDD);
            Pnl_Search.Controls.Add(Btn_Backup);
            Pnl_Search.Controls.Add(Btn_ShowTvSchedule);
            Pnl_Search.Controls.Add(Btn_Statestics);
            Pnl_Search.Controls.Add(Btn_People);
            Pnl_Search.Controls.Add(Btn_GetInfo);
            Pnl_Search.Controls.Add(Btn_Search);
            Pnl_Search.Controls.Add(Txt_Search);
            Pnl_Search.Dock = DockStyle.Top;
            Pnl_Search.Location = new Point(2, 32);
            Pnl_Search.Name = "Pnl_Search";
            Pnl_Search.Size = new Size(1147, 100);
            Pnl_Search.TabIndex = 7;
            // 
            // Btn_Backup
            // 
            Btn_Backup.BackColor = Color.Olive;
            Btn_Backup.CesBackColor = Color.FromArgb(120, 209, 160);
            Btn_Backup.CesBorderColor = Color.MediumSeaGreen;
            Btn_Backup.CesBorderRadius = 15;
            Btn_Backup.CesBorderThickness = 1;
            Btn_Backup.CesBorderVisible = false;
            Btn_Backup.CesCircular = false;
            Btn_Backup.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.LightGreen;
            Btn_Backup.CesFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Backup.CesForeColor = Color.Black;
            Btn_Backup.CesIcon = null;
            Btn_Backup.CesIconAlignment = ContentAlignment.MiddleCenter;
            Btn_Backup.CesMouseDownColor = Color.FromArgb(120, 209, 160);
            Btn_Backup.CesMouseOverColor = Color.MediumSeaGreen;
            Btn_Backup.CesShowIcon = false;
            Btn_Backup.CesShowText = true;
            Btn_Backup.CesText = "بک آپ";
            Btn_Backup.CesTextAlignment = ContentAlignment.MiddleCenter;
            Btn_Backup.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Backup.Location = new Point(680, 4);
            Btn_Backup.Margin = new Padding(3, 4, 3, 4);
            Btn_Backup.Name = "Btn_Backup";
            Btn_Backup.Size = new Size(134, 27);
            Btn_Backup.TabIndex = 5;
            Btn_Backup.Click += Btn_Backup_ClickAsync;
            // 
            // Btn_ShowTvSchedule
            // 
            Btn_ShowTvSchedule.BackColor = Color.Olive;
            Btn_ShowTvSchedule.CesBackColor = Color.FromArgb(120, 209, 160);
            Btn_ShowTvSchedule.CesBorderColor = Color.MediumSeaGreen;
            Btn_ShowTvSchedule.CesBorderRadius = 15;
            Btn_ShowTvSchedule.CesBorderThickness = 1;
            Btn_ShowTvSchedule.CesBorderVisible = false;
            Btn_ShowTvSchedule.CesCircular = false;
            Btn_ShowTvSchedule.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.LightGreen;
            Btn_ShowTvSchedule.CesFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_ShowTvSchedule.CesForeColor = Color.Black;
            Btn_ShowTvSchedule.CesIcon = null;
            Btn_ShowTvSchedule.CesIconAlignment = ContentAlignment.MiddleCenter;
            Btn_ShowTvSchedule.CesMouseDownColor = Color.FromArgb(120, 209, 160);
            Btn_ShowTvSchedule.CesMouseOverColor = Color.MediumSeaGreen;
            Btn_ShowTvSchedule.CesShowIcon = false;
            Btn_ShowTvSchedule.CesShowText = true;
            Btn_ShowTvSchedule.CesText = "برنامه سریال";
            Btn_ShowTvSchedule.CesTextAlignment = ContentAlignment.MiddleCenter;
            Btn_ShowTvSchedule.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_ShowTvSchedule.Location = new Point(834, 4);
            Btn_ShowTvSchedule.Margin = new Padding(3, 4, 3, 4);
            Btn_ShowTvSchedule.Name = "Btn_ShowTvSchedule";
            Btn_ShowTvSchedule.Size = new Size(134, 27);
            Btn_ShowTvSchedule.TabIndex = 5;
            Btn_ShowTvSchedule.Click += Btn_ShowTvSchedule_Click;
            // 
            // Btn_Statestics
            // 
            Btn_Statestics.BackColor = Color.Olive;
            Btn_Statestics.CesBackColor = Color.FromArgb(120, 209, 160);
            Btn_Statestics.CesBorderColor = Color.MediumSeaGreen;
            Btn_Statestics.CesBorderRadius = 15;
            Btn_Statestics.CesBorderThickness = 1;
            Btn_Statestics.CesBorderVisible = false;
            Btn_Statestics.CesCircular = false;
            Btn_Statestics.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.LightGreen;
            Btn_Statestics.CesFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Statestics.CesForeColor = Color.Black;
            Btn_Statestics.CesIcon = null;
            Btn_Statestics.CesIconAlignment = ContentAlignment.MiddleCenter;
            Btn_Statestics.CesMouseDownColor = Color.FromArgb(120, 209, 160);
            Btn_Statestics.CesMouseOverColor = Color.MediumSeaGreen;
            Btn_Statestics.CesShowIcon = false;
            Btn_Statestics.CesShowText = true;
            Btn_Statestics.CesText = "آمار";
            Btn_Statestics.CesTextAlignment = ContentAlignment.MiddleCenter;
            Btn_Statestics.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Statestics.Location = new Point(1002, 3);
            Btn_Statestics.Margin = new Padding(3, 4, 3, 4);
            Btn_Statestics.Name = "Btn_Statestics";
            Btn_Statestics.Size = new Size(134, 44);
            Btn_Statestics.TabIndex = 4;
            Btn_Statestics.Click += Btn_Statestics_Click;
            // 
            // Btn_People
            // 
            Btn_People.BackColor = Color.Olive;
            Btn_People.CesBackColor = Color.FromArgb(120, 209, 160);
            Btn_People.CesBorderColor = Color.MediumSeaGreen;
            Btn_People.CesBorderRadius = 15;
            Btn_People.CesBorderThickness = 1;
            Btn_People.CesBorderVisible = false;
            Btn_People.CesCircular = false;
            Btn_People.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.LightGreen;
            Btn_People.CesFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_People.CesForeColor = Color.Black;
            Btn_People.CesIcon = null;
            Btn_People.CesIconAlignment = ContentAlignment.MiddleCenter;
            Btn_People.CesMouseDownColor = Color.FromArgb(120, 209, 160);
            Btn_People.CesMouseOverColor = Color.MediumSeaGreen;
            Btn_People.CesShowIcon = false;
            Btn_People.CesShowText = true;
            Btn_People.CesText = "افراد";
            Btn_People.CesTextAlignment = ContentAlignment.MiddleCenter;
            Btn_People.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_People.Location = new Point(1002, 50);
            Btn_People.Margin = new Padding(3, 4, 3, 4);
            Btn_People.Name = "Btn_People";
            Btn_People.Size = new Size(134, 44);
            Btn_People.TabIndex = 3;
            Btn_People.Click += Btn_People_Click;
            // 
            // Btn_GetInfo
            // 
            Btn_GetInfo.BackColor = SystemColors.Control;
            Btn_GetInfo.CesBackColor = Color.FromArgb(255, 113, 113);
            Btn_GetInfo.CesBorderColor = Color.Tomato;
            Btn_GetInfo.CesBorderRadius = 15;
            Btn_GetInfo.CesBorderThickness = 1;
            Btn_GetInfo.CesBorderVisible = false;
            Btn_GetInfo.CesCircular = false;
            Btn_GetInfo.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.LightRed;
            Btn_GetInfo.CesFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_GetInfo.CesForeColor = Color.Black;
            Btn_GetInfo.CesIcon = null;
            Btn_GetInfo.CesIconAlignment = ContentAlignment.MiddleCenter;
            Btn_GetInfo.CesMouseDownColor = Color.FromArgb(255, 113, 113);
            Btn_GetInfo.CesMouseOverColor = Color.FromArgb(255, 150, 150);
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
            Btn_Search.BackColor = Color.Lime;
            Btn_Search.CesBackColor = Color.FromArgb(120, 209, 160);
            Btn_Search.CesBorderColor = Color.MediumSeaGreen;
            Btn_Search.CesBorderRadius = 15;
            Btn_Search.CesBorderThickness = 1;
            Btn_Search.CesBorderVisible = false;
            Btn_Search.CesCircular = false;
            Btn_Search.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.LightGreen;
            Btn_Search.CesFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Search.CesForeColor = Color.Black;
            Btn_Search.CesIcon = null;
            Btn_Search.CesIconAlignment = ContentAlignment.MiddleCenter;
            Btn_Search.CesMouseDownColor = Color.FromArgb(120, 209, 160);
            Btn_Search.CesMouseOverColor = Color.MediumSeaGreen;
            Btn_Search.CesShowIcon = false;
            Btn_Search.CesShowText = true;
            Btn_Search.CesText = "جستجو";
            Btn_Search.CesTextAlignment = ContentAlignment.MiddleCenter;
            Btn_Search.Location = new Point(209, 39);
            Btn_Search.Name = "Btn_Search";
            Btn_Search.Size = new Size(134, 44);
            Btn_Search.TabIndex = 1;
            Btn_Search.Click += Btn_Search_Click;
            // 
            // Txt_Search
            // 
            Txt_Search._initialControlHeight = 0;
            Txt_Search.BackColor = Color.White;
            Txt_Search.CesAutoHeight = true;
            Txt_Search.CesBackColor = Color.White;
            Txt_Search.CesBorderColor = SystemColors.ActiveCaption;
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
            Txt_Search.Size = new Size(533, 44);
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
            cesPanel2.Controls.Add(Flw_ShowMovie);
            cesPanel2.Dock = DockStyle.Bottom;
            cesPanel2.Location = new Point(2, 138);
            cesPanel2.Name = "cesPanel2";
            cesPanel2.Size = new Size(1147, 493);
            cesPanel2.TabIndex = 8;
            // 
            // Flw_ShowMovie
            // 
            Flw_ShowMovie.AutoScroll = true;
            Flw_ShowMovie.Location = new Point(9, 3);
            Flw_ShowMovie.Name = "Flw_ShowMovie";
            Flw_ShowMovie.Size = new Size(1133, 485);
            Flw_ShowMovie.TabIndex = 0;
            // 
            // Btn_AddMovieFromHDD
            // 
            Btn_AddMovieFromHDD.BackColor = Color.Olive;
            Btn_AddMovieFromHDD.CesBackColor = Color.FromArgb(120, 209, 160);
            Btn_AddMovieFromHDD.CesBorderColor = Color.MediumSeaGreen;
            Btn_AddMovieFromHDD.CesBorderRadius = 15;
            Btn_AddMovieFromHDD.CesBorderThickness = 1;
            Btn_AddMovieFromHDD.CesBorderVisible = false;
            Btn_AddMovieFromHDD.CesCircular = false;
            Btn_AddMovieFromHDD.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.LightGreen;
            Btn_AddMovieFromHDD.CesFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_AddMovieFromHDD.CesForeColor = Color.Black;
            Btn_AddMovieFromHDD.CesIcon = null;
            Btn_AddMovieFromHDD.CesIconAlignment = ContentAlignment.MiddleCenter;
            Btn_AddMovieFromHDD.CesMouseDownColor = Color.FromArgb(120, 209, 160);
            Btn_AddMovieFromHDD.CesMouseOverColor = Color.MediumSeaGreen;
            Btn_AddMovieFromHDD.CesShowIcon = false;
            Btn_AddMovieFromHDD.CesShowText = true;
            Btn_AddMovieFromHDD.CesText = "اضافه کردن فیلم از روی هارد";
            Btn_AddMovieFromHDD.CesTextAlignment = ContentAlignment.MiddleCenter;
            Btn_AddMovieFromHDD.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_AddMovieFromHDD.Location = new Point(83, 5);
            Btn_AddMovieFromHDD.Margin = new Padding(3, 4, 3, 4);
            Btn_AddMovieFromHDD.Name = "Btn_AddMovieFromHDD";
            Btn_AddMovieFromHDD.Size = new Size(260, 27);
            Btn_AddMovieFromHDD.TabIndex = 6;
            Btn_AddMovieFromHDD.Click += Btn_AddMovieFromHDD_Click;
            // 
            // Frm_Movie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1151, 633);
            Controls.Add(cesPanel2);
            Controls.Add(Pnl_Search);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Frm_Movie";
            Text = "Form1";
            Load += Frm_Movie_Load;
            Controls.SetChildIndex(Pnl_Search, 0);
            Controls.SetChildIndex(cesPanel2, 0);
            Pnl_Search.ResumeLayout(false);
            cesPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Ces.WinForm.UI.CesPanel Pnl_Search;
        private Ces.WinForm.UI.CesPanel cesPanel2;
        private Ces.WinForm.UI.CesTextBox Txt_Search;
        private Ces.WinForm.UI.CesButton.CesRoundedButton Btn_Search;
        private Ces.WinForm.UI.CesButton.CesRoundedButton Btn_GetInfo;
        private FlowLayoutPanel Flw_ShowMovie;
        private Ces.WinForm.UI.CesButton.CesRoundedButton Btn_People;
        private Ces.WinForm.UI.CesButton.CesRoundedButton Btn_Statestics;
        private Ces.WinForm.UI.CesButton.CesRoundedButton Btn_ShowTvSchedule;
        private Ces.WinForm.UI.CesButton.CesRoundedButton Btn_Backup;
        private Ces.WinForm.UI.CesButton.CesRoundedButton Btn_AddMovieFromHDD;
    }
}
