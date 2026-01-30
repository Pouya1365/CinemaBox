namespace CinemaBox.Presentation.Person.Peoples
{
    partial class Frm_EditPeople
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_EditPeople));
            Tb_Main = new TabControl();
            Tb_MainDetails = new TabPage();
            Txt_NickName = new Ces.WinForm.UI.CesTextBox();
            Txt_ShamsiDeadDate = new Ces.WinForm.UI.CesTextBox();
            Txt_Height = new Ces.WinForm.UI.CesTextBox();
            Txt_BirthName = new Ces.WinForm.UI.CesTextBox();
            Txt_DeadPlace = new Ces.WinForm.UI.CesTextBox();
            Txt_FaMiniBioGraphy = new Ces.WinForm.UI.CesTextBox();
            Txt_EnMiniBioGraphy = new Ces.WinForm.UI.CesTextBox();
            Cmb_DeathCuase = new Ces.WinForm.UI.CesComboBox.CesComboBox();
            Txt_BornPlace = new Ces.WinForm.UI.CesTextBox();
            Txt_BirthDateShamsiYear = new Ces.WinForm.UI.CesTextBox();
            Txt_DeathDate = new Ces.WinForm.UI.CesTextBox();
            Txt_BirthDate = new Ces.WinForm.UI.CesTextBox();
            Txt_Imdb = new Ces.WinForm.UI.CesTextBox();
            Txt_FaFullName = new Ces.WinForm.UI.CesTextBox();
            Txt_EnFullName = new Ces.WinForm.UI.CesTextBox();
            Pic_Crew = new PictureBox();
            Tb_Movies = new TabPage();
            Flw_Movie = new FlowLayoutPanel();
            Btn_Update = new Ces.WinForm.UI.CesButton.CesButton();
            Tb_Main.SuspendLayout();
            Tb_MainDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Pic_Crew).BeginInit();
            Tb_Movies.SuspendLayout();
            SuspendLayout();
            // 
            // btnOptions
            // 
            btnOptions.FlatAppearance.BorderColor = Color.DarkGreen;
            btnOptions.FlatAppearance.BorderSize = 0;
            btnOptions.FlatAppearance.MouseDownBackColor = Color.MediumSeaGreen;
            btnOptions.FlatAppearance.MouseOverBackColor = Color.DarkSeaGreen;
            // 
            // Tb_Main
            // 
            Tb_Main.Controls.Add(Tb_MainDetails);
            Tb_Main.Controls.Add(Tb_Movies);
            Tb_Main.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Main.Location = new Point(5, 35);
            Tb_Main.Name = "Tb_Main";
            Tb_Main.RightToLeft = RightToLeft.Yes;
            Tb_Main.RightToLeftLayout = true;
            Tb_Main.SelectedIndex = 0;
            Tb_Main.Size = new Size(1037, 600);
            Tb_Main.TabIndex = 9;
            // 
            // Tb_MainDetails
            // 
            Tb_MainDetails.Controls.Add(Txt_NickName);
            Tb_MainDetails.Controls.Add(Txt_ShamsiDeadDate);
            Tb_MainDetails.Controls.Add(Txt_Height);
            Tb_MainDetails.Controls.Add(Txt_BirthName);
            Tb_MainDetails.Controls.Add(Txt_DeadPlace);
            Tb_MainDetails.Controls.Add(Txt_FaMiniBioGraphy);
            Tb_MainDetails.Controls.Add(Txt_EnMiniBioGraphy);
            Tb_MainDetails.Controls.Add(Cmb_DeathCuase);
            Tb_MainDetails.Controls.Add(Txt_BornPlace);
            Tb_MainDetails.Controls.Add(Txt_BirthDateShamsiYear);
            Tb_MainDetails.Controls.Add(Txt_DeathDate);
            Tb_MainDetails.Controls.Add(Txt_BirthDate);
            Tb_MainDetails.Controls.Add(Txt_Imdb);
            Tb_MainDetails.Controls.Add(Txt_FaFullName);
            Tb_MainDetails.Controls.Add(Txt_EnFullName);
            Tb_MainDetails.Controls.Add(Pic_Crew);
            Tb_MainDetails.Location = new Point(4, 28);
            Tb_MainDetails.Name = "Tb_MainDetails";
            Tb_MainDetails.Padding = new Padding(3);
            Tb_MainDetails.RightToLeft = RightToLeft.No;
            Tb_MainDetails.Size = new Size(1029, 568);
            Tb_MainDetails.TabIndex = 0;
            Tb_MainDetails.Text = "جزئیات";
            Tb_MainDetails.UseVisualStyleBackColor = true;
            // 
            // Txt_NickName
            // 
            Txt_NickName._initialControlHeight = 0;
            Txt_NickName.BackColor = Color.White;
            Txt_NickName.CesAutoHeight = true;
            Txt_NickName.CesBackColor = Color.White;
            Txt_NickName.CesBorderColor = Color.DeepSkyBlue;
            Txt_NickName.CesBorderRadius = 0;
            Txt_NickName.CesBorderThickness = 1;
            Txt_NickName.CesCharacterCasing = CharacterCasing.Normal;
            Txt_NickName.CesFocusColor = Color.White;
            Txt_NickName.CesHasFocus = false;
            Txt_NickName.CesHasNotification = false;
            Txt_NickName.CesIcon = null;
            Txt_NickName.CesInputType = Ces.WinForm.UI.CesInputTypeEnum.Any;
            Txt_NickName.CesMaxLength = 0;
            Txt_NickName.CesMultiLine = false;
            Txt_NickName.CesNotificationColor = Color.Red;
            Txt_NickName.CesPadding = new Padding(5);
            Txt_NickName.CesPasswordChar = '\0';
            Txt_NickName.CesPlaceHolderText = null;
            Txt_NickName.CesReadOnly = false;
            Txt_NickName.CesRightToLeft = RightToLeft.Yes;
            Txt_NickName.CesScrollBar = ScrollBars.None;
            Txt_NickName.CesShowClearButton = false;
            Txt_NickName.CesShowCopyButton = false;
            Txt_NickName.CesShowIcon = false;
            Txt_NickName.CesShowPasteButton = true;
            Txt_NickName.CesShowTitle = true;
            Txt_NickName.CesText = "";
            Txt_NickName.CesTextAlignment = HorizontalAlignment.Center;
            Txt_NickName.CesTheme = Ces.WinForm.UI.Infrastructure.ThemeEnum.White;
            Txt_NickName.CesTitleAutoHeight = false;
            Txt_NickName.CesTitleAutoWidth = true;
            Txt_NickName.CesTitleBackground = true;
            Txt_NickName.CesTitleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_NickName.CesTitleHeight = 25;
            Txt_NickName.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right;
            Txt_NickName.CesTitleText = "لقب";
            Txt_NickName.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            Txt_NickName.CesTitleTextColor = Color.White;
            Txt_NickName.CesTitleWidth = 80;
            Txt_NickName.CesWordWrap = false;
            Txt_NickName.Location = new Point(504, 95);
            Txt_NickName.Margin = new Padding(3, 52, 3, 52);
            Txt_NickName.Name = "Txt_NickName";
            Txt_NickName.Padding = new Padding(3, 52, 3, 52);
            Txt_NickName.Size = new Size(258, 35);
            Txt_NickName.TabIndex = 34;
            // 
            // Txt_ShamsiDeadDate
            // 
            Txt_ShamsiDeadDate._initialControlHeight = 0;
            Txt_ShamsiDeadDate.BackColor = Color.White;
            Txt_ShamsiDeadDate.CesAutoHeight = true;
            Txt_ShamsiDeadDate.CesBackColor = Color.White;
            Txt_ShamsiDeadDate.CesBorderColor = Color.DeepSkyBlue;
            Txt_ShamsiDeadDate.CesBorderRadius = 0;
            Txt_ShamsiDeadDate.CesBorderThickness = 1;
            Txt_ShamsiDeadDate.CesCharacterCasing = CharacterCasing.Normal;
            Txt_ShamsiDeadDate.CesFocusColor = Color.White;
            Txt_ShamsiDeadDate.CesHasFocus = false;
            Txt_ShamsiDeadDate.CesHasNotification = false;
            Txt_ShamsiDeadDate.CesIcon = null;
            Txt_ShamsiDeadDate.CesInputType = Ces.WinForm.UI.CesInputTypeEnum.Any;
            Txt_ShamsiDeadDate.CesMaxLength = 0;
            Txt_ShamsiDeadDate.CesMultiLine = false;
            Txt_ShamsiDeadDate.CesNotificationColor = Color.Red;
            Txt_ShamsiDeadDate.CesPadding = new Padding(5);
            Txt_ShamsiDeadDate.CesPasswordChar = '\0';
            Txt_ShamsiDeadDate.CesPlaceHolderText = null;
            Txt_ShamsiDeadDate.CesReadOnly = true;
            Txt_ShamsiDeadDate.CesRightToLeft = RightToLeft.Yes;
            Txt_ShamsiDeadDate.CesScrollBar = ScrollBars.None;
            Txt_ShamsiDeadDate.CesShowClearButton = false;
            Txt_ShamsiDeadDate.CesShowCopyButton = false;
            Txt_ShamsiDeadDate.CesShowIcon = false;
            Txt_ShamsiDeadDate.CesShowPasteButton = false;
            Txt_ShamsiDeadDate.CesShowTitle = true;
            Txt_ShamsiDeadDate.CesText = "";
            Txt_ShamsiDeadDate.CesTextAlignment = HorizontalAlignment.Center;
            Txt_ShamsiDeadDate.CesTheme = Ces.WinForm.UI.Infrastructure.ThemeEnum.White;
            Txt_ShamsiDeadDate.CesTitleAutoHeight = false;
            Txt_ShamsiDeadDate.CesTitleAutoWidth = true;
            Txt_ShamsiDeadDate.CesTitleBackground = true;
            Txt_ShamsiDeadDate.CesTitleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_ShamsiDeadDate.CesTitleHeight = 25;
            Txt_ShamsiDeadDate.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right;
            Txt_ShamsiDeadDate.CesTitleText = " تاریخ فوت شمسی";
            Txt_ShamsiDeadDate.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            Txt_ShamsiDeadDate.CesTitleTextColor = Color.White;
            Txt_ShamsiDeadDate.CesTitleWidth = 120;
            Txt_ShamsiDeadDate.CesWordWrap = false;
            Txt_ShamsiDeadDate.Location = new Point(504, 134);
            Txt_ShamsiDeadDate.Margin = new Padding(3, 13, 3, 13);
            Txt_ShamsiDeadDate.Name = "Txt_ShamsiDeadDate";
            Txt_ShamsiDeadDate.Padding = new Padding(3, 13, 3, 13);
            Txt_ShamsiDeadDate.Size = new Size(258, 35);
            Txt_ShamsiDeadDate.TabIndex = 33;
            // 
            // Txt_Height
            // 
            Txt_Height._initialControlHeight = 0;
            Txt_Height.BackColor = Color.White;
            Txt_Height.CesAutoHeight = true;
            Txt_Height.CesBackColor = Color.White;
            Txt_Height.CesBorderColor = Color.DeepSkyBlue;
            Txt_Height.CesBorderRadius = 0;
            Txt_Height.CesBorderThickness = 1;
            Txt_Height.CesCharacterCasing = CharacterCasing.Normal;
            Txt_Height.CesFocusColor = Color.White;
            Txt_Height.CesHasFocus = false;
            Txt_Height.CesHasNotification = false;
            Txt_Height.CesIcon = null;
            Txt_Height.CesInputType = Ces.WinForm.UI.CesInputTypeEnum.Number;
            Txt_Height.CesMaxLength = 0;
            Txt_Height.CesMultiLine = false;
            Txt_Height.CesNotificationColor = Color.Red;
            Txt_Height.CesPadding = new Padding(5);
            Txt_Height.CesPasswordChar = '\0';
            Txt_Height.CesPlaceHolderText = null;
            Txt_Height.CesReadOnly = false;
            Txt_Height.CesRightToLeft = RightToLeft.Yes;
            Txt_Height.CesScrollBar = ScrollBars.None;
            Txt_Height.CesShowClearButton = false;
            Txt_Height.CesShowCopyButton = false;
            Txt_Height.CesShowIcon = false;
            Txt_Height.CesShowPasteButton = true;
            Txt_Height.CesShowTitle = true;
            Txt_Height.CesText = "";
            Txt_Height.CesTextAlignment = HorizontalAlignment.Center;
            Txt_Height.CesTheme = Ces.WinForm.UI.Infrastructure.ThemeEnum.White;
            Txt_Height.CesTitleAutoHeight = false;
            Txt_Height.CesTitleAutoWidth = true;
            Txt_Height.CesTitleBackground = true;
            Txt_Height.CesTitleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_Height.CesTitleHeight = 25;
            Txt_Height.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right;
            Txt_Height.CesTitleText = "قد";
            Txt_Height.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            Txt_Height.CesTitleTextColor = Color.White;
            Txt_Height.CesTitleWidth = 80;
            Txt_Height.CesWordWrap = false;
            Txt_Height.Location = new Point(742, 255);
            Txt_Height.Margin = new Padding(3, 41, 3, 41);
            Txt_Height.Name = "Txt_Height";
            Txt_Height.Padding = new Padding(3, 41, 3, 41);
            Txt_Height.Size = new Size(285, 35);
            Txt_Height.TabIndex = 31;
            // 
            // Txt_BirthName
            // 
            Txt_BirthName._initialControlHeight = 0;
            Txt_BirthName.BackColor = Color.White;
            Txt_BirthName.CesAutoHeight = true;
            Txt_BirthName.CesBackColor = Color.White;
            Txt_BirthName.CesBorderColor = Color.DeepSkyBlue;
            Txt_BirthName.CesBorderRadius = 0;
            Txt_BirthName.CesBorderThickness = 1;
            Txt_BirthName.CesCharacterCasing = CharacterCasing.Normal;
            Txt_BirthName.CesFocusColor = Color.White;
            Txt_BirthName.CesHasFocus = false;
            Txt_BirthName.CesHasNotification = false;
            Txt_BirthName.CesIcon = null;
            Txt_BirthName.CesInputType = Ces.WinForm.UI.CesInputTypeEnum.Any;
            Txt_BirthName.CesMaxLength = 0;
            Txt_BirthName.CesMultiLine = false;
            Txt_BirthName.CesNotificationColor = Color.Red;
            Txt_BirthName.CesPadding = new Padding(5);
            Txt_BirthName.CesPasswordChar = '\0';
            Txt_BirthName.CesPlaceHolderText = null;
            Txt_BirthName.CesReadOnly = false;
            Txt_BirthName.CesRightToLeft = RightToLeft.Yes;
            Txt_BirthName.CesScrollBar = ScrollBars.None;
            Txt_BirthName.CesShowClearButton = false;
            Txt_BirthName.CesShowCopyButton = false;
            Txt_BirthName.CesShowIcon = false;
            Txt_BirthName.CesShowPasteButton = true;
            Txt_BirthName.CesShowTitle = true;
            Txt_BirthName.CesText = "";
            Txt_BirthName.CesTextAlignment = HorizontalAlignment.Center;
            Txt_BirthName.CesTheme = Ces.WinForm.UI.Infrastructure.ThemeEnum.White;
            Txt_BirthName.CesTitleAutoHeight = false;
            Txt_BirthName.CesTitleAutoWidth = true;
            Txt_BirthName.CesTitleBackground = true;
            Txt_BirthName.CesTitleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_BirthName.CesTitleHeight = 25;
            Txt_BirthName.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right;
            Txt_BirthName.CesTitleText = "اسم تولد";
            Txt_BirthName.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            Txt_BirthName.CesTitleTextColor = Color.White;
            Txt_BirthName.CesTitleWidth = 80;
            Txt_BirthName.CesWordWrap = false;
            Txt_BirthName.Location = new Point(768, 95);
            Txt_BirthName.Margin = new Padding(3, 41, 3, 41);
            Txt_BirthName.Name = "Txt_BirthName";
            Txt_BirthName.Padding = new Padding(3, 41, 3, 41);
            Txt_BirthName.Size = new Size(260, 35);
            Txt_BirthName.TabIndex = 30;
            // 
            // Txt_DeadPlace
            // 
            Txt_DeadPlace._initialControlHeight = 0;
            Txt_DeadPlace.BackColor = Color.White;
            Txt_DeadPlace.CesAutoHeight = true;
            Txt_DeadPlace.CesBackColor = Color.White;
            Txt_DeadPlace.CesBorderColor = Color.DeepSkyBlue;
            Txt_DeadPlace.CesBorderRadius = 0;
            Txt_DeadPlace.CesBorderThickness = 1;
            Txt_DeadPlace.CesCharacterCasing = CharacterCasing.Normal;
            Txt_DeadPlace.CesFocusColor = Color.White;
            Txt_DeadPlace.CesHasFocus = false;
            Txt_DeadPlace.CesHasNotification = false;
            Txt_DeadPlace.CesIcon = null;
            Txt_DeadPlace.CesInputType = Ces.WinForm.UI.CesInputTypeEnum.Any;
            Txt_DeadPlace.CesMaxLength = 0;
            Txt_DeadPlace.CesMultiLine = false;
            Txt_DeadPlace.CesNotificationColor = Color.Red;
            Txt_DeadPlace.CesPadding = new Padding(5);
            Txt_DeadPlace.CesPasswordChar = '\0';
            Txt_DeadPlace.CesPlaceHolderText = null;
            Txt_DeadPlace.CesReadOnly = false;
            Txt_DeadPlace.CesRightToLeft = RightToLeft.Yes;
            Txt_DeadPlace.CesScrollBar = ScrollBars.None;
            Txt_DeadPlace.CesShowClearButton = false;
            Txt_DeadPlace.CesShowCopyButton = false;
            Txt_DeadPlace.CesShowIcon = false;
            Txt_DeadPlace.CesShowPasteButton = true;
            Txt_DeadPlace.CesShowTitle = true;
            Txt_DeadPlace.CesText = "";
            Txt_DeadPlace.CesTextAlignment = HorizontalAlignment.Center;
            Txt_DeadPlace.CesTheme = Ces.WinForm.UI.Infrastructure.ThemeEnum.White;
            Txt_DeadPlace.CesTitleAutoHeight = false;
            Txt_DeadPlace.CesTitleAutoWidth = true;
            Txt_DeadPlace.CesTitleBackground = true;
            Txt_DeadPlace.CesTitleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_DeadPlace.CesTitleHeight = 25;
            Txt_DeadPlace.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right;
            Txt_DeadPlace.CesTitleText = "محل فوت";
            Txt_DeadPlace.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            Txt_DeadPlace.CesTitleTextColor = Color.White;
            Txt_DeadPlace.CesTitleWidth = 80;
            Txt_DeadPlace.CesWordWrap = false;
            Txt_DeadPlace.Location = new Point(240, 215);
            Txt_DeadPlace.Margin = new Padding(3, 32, 3, 32);
            Txt_DeadPlace.Name = "Txt_DeadPlace";
            Txt_DeadPlace.Padding = new Padding(3, 32, 3, 32);
            Txt_DeadPlace.Size = new Size(788, 35);
            Txt_DeadPlace.TabIndex = 28;
            // 
            // Txt_FaMiniBioGraphy
            // 
            Txt_FaMiniBioGraphy._initialControlHeight = 0;
            Txt_FaMiniBioGraphy.BackColor = Color.White;
            Txt_FaMiniBioGraphy.CesAutoHeight = true;
            Txt_FaMiniBioGraphy.CesBackColor = Color.White;
            Txt_FaMiniBioGraphy.CesBorderColor = Color.DeepSkyBlue;
            Txt_FaMiniBioGraphy.CesBorderRadius = 0;
            Txt_FaMiniBioGraphy.CesBorderThickness = 1;
            Txt_FaMiniBioGraphy.CesCharacterCasing = CharacterCasing.Normal;
            Txt_FaMiniBioGraphy.CesFocusColor = Color.White;
            Txt_FaMiniBioGraphy.CesHasFocus = false;
            Txt_FaMiniBioGraphy.CesHasNotification = false;
            Txt_FaMiniBioGraphy.CesIcon = null;
            Txt_FaMiniBioGraphy.CesInputType = Ces.WinForm.UI.CesInputTypeEnum.Number;
            Txt_FaMiniBioGraphy.CesMaxLength = 0;
            Txt_FaMiniBioGraphy.CesMultiLine = false;
            Txt_FaMiniBioGraphy.CesNotificationColor = Color.Red;
            Txt_FaMiniBioGraphy.CesPadding = new Padding(5);
            Txt_FaMiniBioGraphy.CesPasswordChar = '\0';
            Txt_FaMiniBioGraphy.CesPlaceHolderText = null;
            Txt_FaMiniBioGraphy.CesReadOnly = false;
            Txt_FaMiniBioGraphy.CesRightToLeft = RightToLeft.Yes;
            Txt_FaMiniBioGraphy.CesScrollBar = ScrollBars.None;
            Txt_FaMiniBioGraphy.CesShowClearButton = false;
            Txt_FaMiniBioGraphy.CesShowCopyButton = false;
            Txt_FaMiniBioGraphy.CesShowIcon = false;
            Txt_FaMiniBioGraphy.CesShowPasteButton = true;
            Txt_FaMiniBioGraphy.CesShowTitle = true;
            Txt_FaMiniBioGraphy.CesText = "";
            Txt_FaMiniBioGraphy.CesTextAlignment = HorizontalAlignment.Center;
            Txt_FaMiniBioGraphy.CesTheme = Ces.WinForm.UI.Infrastructure.ThemeEnum.White;
            Txt_FaMiniBioGraphy.CesTitleAutoHeight = false;
            Txt_FaMiniBioGraphy.CesTitleAutoWidth = false;
            Txt_FaMiniBioGraphy.CesTitleBackground = true;
            Txt_FaMiniBioGraphy.CesTitleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_FaMiniBioGraphy.CesTitleHeight = 50;
            Txt_FaMiniBioGraphy.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right;
            Txt_FaMiniBioGraphy.CesTitleText = "خلاصه زندگینامه فارسی";
            Txt_FaMiniBioGraphy.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            Txt_FaMiniBioGraphy.CesTitleTextColor = Color.White;
            Txt_FaMiniBioGraphy.CesTitleWidth = 130;
            Txt_FaMiniBioGraphy.CesWordWrap = false;
            Txt_FaMiniBioGraphy.Location = new Point(240, 431);
            Txt_FaMiniBioGraphy.Margin = new Padding(3, 16, 3, 16);
            Txt_FaMiniBioGraphy.Name = "Txt_FaMiniBioGraphy";
            Txt_FaMiniBioGraphy.Padding = new Padding(3, 16, 3, 16);
            Txt_FaMiniBioGraphy.Size = new Size(785, 125);
            Txt_FaMiniBioGraphy.TabIndex = 20;
            // 
            // Txt_EnMiniBioGraphy
            // 
            Txt_EnMiniBioGraphy._initialControlHeight = 0;
            Txt_EnMiniBioGraphy.BackColor = Color.White;
            Txt_EnMiniBioGraphy.CesAutoHeight = true;
            Txt_EnMiniBioGraphy.CesBackColor = Color.White;
            Txt_EnMiniBioGraphy.CesBorderColor = Color.DeepSkyBlue;
            Txt_EnMiniBioGraphy.CesBorderRadius = 0;
            Txt_EnMiniBioGraphy.CesBorderThickness = 1;
            Txt_EnMiniBioGraphy.CesCharacterCasing = CharacterCasing.Normal;
            Txt_EnMiniBioGraphy.CesFocusColor = Color.White;
            Txt_EnMiniBioGraphy.CesHasFocus = false;
            Txt_EnMiniBioGraphy.CesHasNotification = false;
            Txt_EnMiniBioGraphy.CesIcon = null;
            Txt_EnMiniBioGraphy.CesInputType = Ces.WinForm.UI.CesInputTypeEnum.Number;
            Txt_EnMiniBioGraphy.CesMaxLength = 0;
            Txt_EnMiniBioGraphy.CesMultiLine = true;
            Txt_EnMiniBioGraphy.CesNotificationColor = Color.Red;
            Txt_EnMiniBioGraphy.CesPadding = new Padding(5);
            Txt_EnMiniBioGraphy.CesPasswordChar = '\0';
            Txt_EnMiniBioGraphy.CesPlaceHolderText = null;
            Txt_EnMiniBioGraphy.CesReadOnly = false;
            Txt_EnMiniBioGraphy.CesRightToLeft = RightToLeft.No;
            Txt_EnMiniBioGraphy.CesScrollBar = ScrollBars.None;
            Txt_EnMiniBioGraphy.CesShowClearButton = false;
            Txt_EnMiniBioGraphy.CesShowCopyButton = false;
            Txt_EnMiniBioGraphy.CesShowIcon = false;
            Txt_EnMiniBioGraphy.CesShowPasteButton = true;
            Txt_EnMiniBioGraphy.CesShowTitle = true;
            Txt_EnMiniBioGraphy.CesText = "";
            Txt_EnMiniBioGraphy.CesTextAlignment = HorizontalAlignment.Left;
            Txt_EnMiniBioGraphy.CesTheme = Ces.WinForm.UI.Infrastructure.ThemeEnum.White;
            Txt_EnMiniBioGraphy.CesTitleAutoHeight = false;
            Txt_EnMiniBioGraphy.CesTitleAutoWidth = true;
            Txt_EnMiniBioGraphy.CesTitleBackground = true;
            Txt_EnMiniBioGraphy.CesTitleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_EnMiniBioGraphy.CesTitleHeight = 25;
            Txt_EnMiniBioGraphy.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right;
            Txt_EnMiniBioGraphy.CesTitleText = "خلاصه زندگینامه انگلیسی";
            Txt_EnMiniBioGraphy.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            Txt_EnMiniBioGraphy.CesTitleTextColor = Color.White;
            Txt_EnMiniBioGraphy.CesTitleWidth = 130;
            Txt_EnMiniBioGraphy.CesWordWrap = true;
            Txt_EnMiniBioGraphy.Location = new Point(240, 298);
            Txt_EnMiniBioGraphy.Margin = new Padding(3, 16, 3, 16);
            Txt_EnMiniBioGraphy.Name = "Txt_EnMiniBioGraphy";
            Txt_EnMiniBioGraphy.Padding = new Padding(3, 16, 3, 16);
            Txt_EnMiniBioGraphy.Size = new Size(785, 125);
            Txt_EnMiniBioGraphy.TabIndex = 19;
            // 
            // Cmb_DeathCuase
            // 
            Cmb_DeathCuase._initialControlHeight = 0;
            Cmb_DeathCuase.BackColor = Color.White;
            Cmb_DeathCuase.CesAdjustPopupToParentWidth = true;
            Cmb_DeathCuase.CesAlignToRight = false;
            Cmb_DeathCuase.CesAutoHeight = true;
            Cmb_DeathCuase.CesBackColor = Color.White;
            Cmb_DeathCuase.CesBorderColor = Color.DeepSkyBlue;
            Cmb_DeathCuase.CesBorderRadius = 0;
            Cmb_DeathCuase.CesBorderThickness = 1;
            Cmb_DeathCuase.CesDataSource = null;
            Cmb_DeathCuase.CesDisplayMember = null;
            Cmb_DeathCuase.CesDropDownOnFocus = false;
            Cmb_DeathCuase.CesFocusColor = Color.White;
            Cmb_DeathCuase.CesHasFocus = false;
            Cmb_DeathCuase.CesHasNotification = false;
            Cmb_DeathCuase.CesIcon = null;
            Cmb_DeathCuase.CesImageMember = null;
            Cmb_DeathCuase.CesImageWidth = 24;
            Cmb_DeathCuase.CesItemHeight = 30;
            Cmb_DeathCuase.CesKeepPreviousSelection = false;
            Cmb_DeathCuase.CesLoadingMode = false;
            Cmb_DeathCuase.CesNotificationColor = Color.Red;
            Cmb_DeathCuase.CesPadding = new Padding(5);
            Cmb_DeathCuase.CesPopupSize = new Size(350, 400);
            Cmb_DeathCuase.CesSelectedItem = null;
            Cmb_DeathCuase.CesSelectedValue = null;
            Cmb_DeathCuase.CesSelectFirstItem = false;
            Cmb_DeathCuase.CesSelectFirstItemIfPreviousWasNull = true;
            Cmb_DeathCuase.CesShowAddItemButton = false;
            Cmb_DeathCuase.CesShowClearButton = false;
            Cmb_DeathCuase.CesShowEditItemButton = false;
            Cmb_DeathCuase.CesShowIcon = false;
            Cmb_DeathCuase.CesShowImage = true;
            Cmb_DeathCuase.CesShowIndicator = false;
            Cmb_DeathCuase.CesShowLoadButton = false;
            Cmb_DeathCuase.CesShowSearchBox = true;
            Cmb_DeathCuase.CesShowStatusBar = true;
            Cmb_DeathCuase.CesShowTitle = true;
            Cmb_DeathCuase.CesStopSelectedItemChangedEvent = false;
            Cmb_DeathCuase.CesTheme = Ces.WinForm.UI.Infrastructure.ThemeEnum.White;
            Cmb_DeathCuase.CesTitleAutoHeight = false;
            Cmb_DeathCuase.CesTitleAutoWidth = false;
            Cmb_DeathCuase.CesTitleBackground = true;
            Cmb_DeathCuase.CesTitleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Cmb_DeathCuase.CesTitleHeight = 25;
            Cmb_DeathCuase.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right;
            Cmb_DeathCuase.CesTitleText = "دلیل فوت";
            Cmb_DeathCuase.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            Cmb_DeathCuase.CesTitleTextColor = Color.White;
            Cmb_DeathCuase.CesTitleWidth = 80;
            Cmb_DeathCuase.CesValueMember = null;
            Cmb_DeathCuase.Location = new Point(240, 255);
            Cmb_DeathCuase.Margin = new Padding(3, 4, 3, 4);
            Cmb_DeathCuase.Name = "Cmb_DeathCuase";
            Cmb_DeathCuase.Padding = new Padding(3, 4, 3, 4);
            Cmb_DeathCuase.Size = new Size(496, 35);
            Cmb_DeathCuase.TabIndex = 14;
            // 
            // Txt_BornPlace
            // 
            Txt_BornPlace._initialControlHeight = 0;
            Txt_BornPlace.BackColor = Color.White;
            Txt_BornPlace.CesAutoHeight = true;
            Txt_BornPlace.CesBackColor = Color.White;
            Txt_BornPlace.CesBorderColor = Color.DeepSkyBlue;
            Txt_BornPlace.CesBorderRadius = 0;
            Txt_BornPlace.CesBorderThickness = 1;
            Txt_BornPlace.CesCharacterCasing = CharacterCasing.Normal;
            Txt_BornPlace.CesFocusColor = Color.White;
            Txt_BornPlace.CesHasFocus = false;
            Txt_BornPlace.CesHasNotification = false;
            Txt_BornPlace.CesIcon = null;
            Txt_BornPlace.CesInputType = Ces.WinForm.UI.CesInputTypeEnum.Any;
            Txt_BornPlace.CesMaxLength = 0;
            Txt_BornPlace.CesMultiLine = false;
            Txt_BornPlace.CesNotificationColor = Color.Red;
            Txt_BornPlace.CesPadding = new Padding(5);
            Txt_BornPlace.CesPasswordChar = '\0';
            Txt_BornPlace.CesPlaceHolderText = null;
            Txt_BornPlace.CesReadOnly = false;
            Txt_BornPlace.CesRightToLeft = RightToLeft.Yes;
            Txt_BornPlace.CesScrollBar = ScrollBars.None;
            Txt_BornPlace.CesShowClearButton = false;
            Txt_BornPlace.CesShowCopyButton = false;
            Txt_BornPlace.CesShowIcon = false;
            Txt_BornPlace.CesShowPasteButton = true;
            Txt_BornPlace.CesShowTitle = true;
            Txt_BornPlace.CesText = "";
            Txt_BornPlace.CesTextAlignment = HorizontalAlignment.Center;
            Txt_BornPlace.CesTheme = Ces.WinForm.UI.Infrastructure.ThemeEnum.White;
            Txt_BornPlace.CesTitleAutoHeight = false;
            Txt_BornPlace.CesTitleAutoWidth = true;
            Txt_BornPlace.CesTitleBackground = true;
            Txt_BornPlace.CesTitleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_BornPlace.CesTitleHeight = 25;
            Txt_BornPlace.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right;
            Txt_BornPlace.CesTitleText = "محل تولد";
            Txt_BornPlace.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            Txt_BornPlace.CesTitleTextColor = Color.White;
            Txt_BornPlace.CesTitleWidth = 80;
            Txt_BornPlace.CesWordWrap = false;
            Txt_BornPlace.Location = new Point(240, 175);
            Txt_BornPlace.Margin = new Padding(3, 13, 3, 13);
            Txt_BornPlace.Name = "Txt_BornPlace";
            Txt_BornPlace.Padding = new Padding(3, 13, 3, 13);
            Txt_BornPlace.Size = new Size(788, 35);
            Txt_BornPlace.TabIndex = 11;
            // 
            // Txt_BirthDateShamsiYear
            // 
            Txt_BirthDateShamsiYear._initialControlHeight = 0;
            Txt_BirthDateShamsiYear.BackColor = Color.White;
            Txt_BirthDateShamsiYear.CesAutoHeight = true;
            Txt_BirthDateShamsiYear.CesBackColor = Color.White;
            Txt_BirthDateShamsiYear.CesBorderColor = Color.DeepSkyBlue;
            Txt_BirthDateShamsiYear.CesBorderRadius = 0;
            Txt_BirthDateShamsiYear.CesBorderThickness = 1;
            Txt_BirthDateShamsiYear.CesCharacterCasing = CharacterCasing.Normal;
            Txt_BirthDateShamsiYear.CesFocusColor = Color.White;
            Txt_BirthDateShamsiYear.CesHasFocus = false;
            Txt_BirthDateShamsiYear.CesHasNotification = false;
            Txt_BirthDateShamsiYear.CesIcon = null;
            Txt_BirthDateShamsiYear.CesInputType = Ces.WinForm.UI.CesInputTypeEnum.Any;
            Txt_BirthDateShamsiYear.CesMaxLength = 0;
            Txt_BirthDateShamsiYear.CesMultiLine = false;
            Txt_BirthDateShamsiYear.CesNotificationColor = Color.Red;
            Txt_BirthDateShamsiYear.CesPadding = new Padding(5);
            Txt_BirthDateShamsiYear.CesPasswordChar = '\0';
            Txt_BirthDateShamsiYear.CesPlaceHolderText = null;
            Txt_BirthDateShamsiYear.CesReadOnly = true;
            Txt_BirthDateShamsiYear.CesRightToLeft = RightToLeft.Yes;
            Txt_BirthDateShamsiYear.CesScrollBar = ScrollBars.None;
            Txt_BirthDateShamsiYear.CesShowClearButton = false;
            Txt_BirthDateShamsiYear.CesShowCopyButton = false;
            Txt_BirthDateShamsiYear.CesShowIcon = false;
            Txt_BirthDateShamsiYear.CesShowPasteButton = false;
            Txt_BirthDateShamsiYear.CesShowTitle = true;
            Txt_BirthDateShamsiYear.CesText = "";
            Txt_BirthDateShamsiYear.CesTextAlignment = HorizontalAlignment.Center;
            Txt_BirthDateShamsiYear.CesTheme = Ces.WinForm.UI.Infrastructure.ThemeEnum.White;
            Txt_BirthDateShamsiYear.CesTitleAutoHeight = false;
            Txt_BirthDateShamsiYear.CesTitleAutoWidth = true;
            Txt_BirthDateShamsiYear.CesTitleBackground = true;
            Txt_BirthDateShamsiYear.CesTitleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_BirthDateShamsiYear.CesTitleHeight = 25;
            Txt_BirthDateShamsiYear.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right;
            Txt_BirthDateShamsiYear.CesTitleText = " تاریخ تولد شمسی";
            Txt_BirthDateShamsiYear.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            Txt_BirthDateShamsiYear.CesTitleTextColor = Color.White;
            Txt_BirthDateShamsiYear.CesTitleWidth = 120;
            Txt_BirthDateShamsiYear.CesWordWrap = false;
            Txt_BirthDateShamsiYear.Location = new Point(240, 49);
            Txt_BirthDateShamsiYear.Margin = new Padding(3, 10, 3, 10);
            Txt_BirthDateShamsiYear.Name = "Txt_BirthDateShamsiYear";
            Txt_BirthDateShamsiYear.Padding = new Padding(3, 10, 3, 10);
            Txt_BirthDateShamsiYear.Size = new Size(258, 35);
            Txt_BirthDateShamsiYear.TabIndex = 6;
            // 
            // Txt_DeathDate
            // 
            Txt_DeathDate._initialControlHeight = 0;
            Txt_DeathDate.BackColor = Color.White;
            Txt_DeathDate.CesAutoHeight = true;
            Txt_DeathDate.CesBackColor = Color.White;
            Txt_DeathDate.CesBorderColor = Color.DeepSkyBlue;
            Txt_DeathDate.CesBorderRadius = 0;
            Txt_DeathDate.CesBorderThickness = 1;
            Txt_DeathDate.CesCharacterCasing = CharacterCasing.Normal;
            Txt_DeathDate.CesFocusColor = Color.White;
            Txt_DeathDate.CesHasFocus = false;
            Txt_DeathDate.CesHasNotification = false;
            Txt_DeathDate.CesIcon = null;
            Txt_DeathDate.CesInputType = Ces.WinForm.UI.CesInputTypeEnum.Any;
            Txt_DeathDate.CesMaxLength = 0;
            Txt_DeathDate.CesMultiLine = false;
            Txt_DeathDate.CesNotificationColor = Color.Red;
            Txt_DeathDate.CesPadding = new Padding(5);
            Txt_DeathDate.CesPasswordChar = '\0';
            Txt_DeathDate.CesPlaceHolderText = null;
            Txt_DeathDate.CesReadOnly = false;
            Txt_DeathDate.CesRightToLeft = RightToLeft.Yes;
            Txt_DeathDate.CesScrollBar = ScrollBars.None;
            Txt_DeathDate.CesShowClearButton = false;
            Txt_DeathDate.CesShowCopyButton = false;
            Txt_DeathDate.CesShowIcon = false;
            Txt_DeathDate.CesShowPasteButton = true;
            Txt_DeathDate.CesShowTitle = true;
            Txt_DeathDate.CesText = "";
            Txt_DeathDate.CesTextAlignment = HorizontalAlignment.Center;
            Txt_DeathDate.CesTheme = Ces.WinForm.UI.Infrastructure.ThemeEnum.White;
            Txt_DeathDate.CesTitleAutoHeight = false;
            Txt_DeathDate.CesTitleAutoWidth = true;
            Txt_DeathDate.CesTitleBackground = true;
            Txt_DeathDate.CesTitleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_DeathDate.CesTitleHeight = 25;
            Txt_DeathDate.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right;
            Txt_DeathDate.CesTitleText = "تاریخ فوت";
            Txt_DeathDate.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            Txt_DeathDate.CesTitleTextColor = Color.White;
            Txt_DeathDate.CesTitleWidth = 80;
            Txt_DeathDate.CesWordWrap = false;
            Txt_DeathDate.Location = new Point(768, 136);
            Txt_DeathDate.Margin = new Padding(3, 8, 3, 8);
            Txt_DeathDate.Name = "Txt_DeathDate";
            Txt_DeathDate.Padding = new Padding(3, 8, 3, 8);
            Txt_DeathDate.Size = new Size(258, 35);
            Txt_DeathDate.TabIndex = 5;
            // 
            // Txt_BirthDate
            // 
            Txt_BirthDate._initialControlHeight = 0;
            Txt_BirthDate.BackColor = Color.White;
            Txt_BirthDate.CesAutoHeight = true;
            Txt_BirthDate.CesBackColor = Color.White;
            Txt_BirthDate.CesBorderColor = Color.DeepSkyBlue;
            Txt_BirthDate.CesBorderRadius = 0;
            Txt_BirthDate.CesBorderThickness = 1;
            Txt_BirthDate.CesCharacterCasing = CharacterCasing.Normal;
            Txt_BirthDate.CesFocusColor = Color.White;
            Txt_BirthDate.CesHasFocus = false;
            Txt_BirthDate.CesHasNotification = false;
            Txt_BirthDate.CesIcon = null;
            Txt_BirthDate.CesInputType = Ces.WinForm.UI.CesInputTypeEnum.Any;
            Txt_BirthDate.CesMaxLength = 0;
            Txt_BirthDate.CesMultiLine = false;
            Txt_BirthDate.CesNotificationColor = Color.Red;
            Txt_BirthDate.CesPadding = new Padding(5);
            Txt_BirthDate.CesPasswordChar = '\0';
            Txt_BirthDate.CesPlaceHolderText = null;
            Txt_BirthDate.CesReadOnly = false;
            Txt_BirthDate.CesRightToLeft = RightToLeft.Yes;
            Txt_BirthDate.CesScrollBar = ScrollBars.None;
            Txt_BirthDate.CesShowClearButton = false;
            Txt_BirthDate.CesShowCopyButton = false;
            Txt_BirthDate.CesShowIcon = false;
            Txt_BirthDate.CesShowPasteButton = true;
            Txt_BirthDate.CesShowTitle = true;
            Txt_BirthDate.CesText = "";
            Txt_BirthDate.CesTextAlignment = HorizontalAlignment.Center;
            Txt_BirthDate.CesTheme = Ces.WinForm.UI.Infrastructure.ThemeEnum.White;
            Txt_BirthDate.CesTitleAutoHeight = false;
            Txt_BirthDate.CesTitleAutoWidth = true;
            Txt_BirthDate.CesTitleBackground = true;
            Txt_BirthDate.CesTitleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_BirthDate.CesTitleHeight = 25;
            Txt_BirthDate.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right;
            Txt_BirthDate.CesTitleText = "تاریخ تولد";
            Txt_BirthDate.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            Txt_BirthDate.CesTitleTextColor = Color.White;
            Txt_BirthDate.CesTitleWidth = 80;
            Txt_BirthDate.CesWordWrap = false;
            Txt_BirthDate.Location = new Point(504, 49);
            Txt_BirthDate.Margin = new Padding(3, 6, 3, 6);
            Txt_BirthDate.Name = "Txt_BirthDate";
            Txt_BirthDate.Padding = new Padding(3, 6, 3, 6);
            Txt_BirthDate.Size = new Size(258, 35);
            Txt_BirthDate.TabIndex = 4;
            // 
            // Txt_Imdb
            // 
            Txt_Imdb._initialControlHeight = 0;
            Txt_Imdb.BackColor = Color.White;
            Txt_Imdb.CesAutoHeight = true;
            Txt_Imdb.CesBackColor = Color.White;
            Txt_Imdb.CesBorderColor = Color.DeepSkyBlue;
            Txt_Imdb.CesBorderRadius = 0;
            Txt_Imdb.CesBorderThickness = 1;
            Txt_Imdb.CesCharacterCasing = CharacterCasing.Normal;
            Txt_Imdb.CesFocusColor = Color.White;
            Txt_Imdb.CesHasFocus = false;
            Txt_Imdb.CesHasNotification = false;
            Txt_Imdb.CesIcon = null;
            Txt_Imdb.CesInputType = Ces.WinForm.UI.CesInputTypeEnum.Any;
            Txt_Imdb.CesMaxLength = 0;
            Txt_Imdb.CesMultiLine = false;
            Txt_Imdb.CesNotificationColor = Color.Red;
            Txt_Imdb.CesPadding = new Padding(5);
            Txt_Imdb.CesPasswordChar = '\0';
            Txt_Imdb.CesPlaceHolderText = null;
            Txt_Imdb.CesReadOnly = false;
            Txt_Imdb.CesRightToLeft = RightToLeft.Yes;
            Txt_Imdb.CesScrollBar = ScrollBars.None;
            Txt_Imdb.CesShowClearButton = false;
            Txt_Imdb.CesShowCopyButton = false;
            Txt_Imdb.CesShowIcon = false;
            Txt_Imdb.CesShowPasteButton = true;
            Txt_Imdb.CesShowTitle = true;
            Txt_Imdb.CesText = "";
            Txt_Imdb.CesTextAlignment = HorizontalAlignment.Center;
            Txt_Imdb.CesTheme = Ces.WinForm.UI.Infrastructure.ThemeEnum.White;
            Txt_Imdb.CesTitleAutoHeight = false;
            Txt_Imdb.CesTitleAutoWidth = true;
            Txt_Imdb.CesTitleBackground = true;
            Txt_Imdb.CesTitleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_Imdb.CesTitleHeight = 25;
            Txt_Imdb.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right;
            Txt_Imdb.CesTitleText = "شناسه";
            Txt_Imdb.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            Txt_Imdb.CesTitleTextColor = Color.White;
            Txt_Imdb.CesTitleWidth = 80;
            Txt_Imdb.CesWordWrap = false;
            Txt_Imdb.Location = new Point(504, 3);
            Txt_Imdb.Margin = new Padding(3, 5, 3, 5);
            Txt_Imdb.Name = "Txt_Imdb";
            Txt_Imdb.Padding = new Padding(3, 5, 3, 5);
            Txt_Imdb.Size = new Size(258, 35);
            Txt_Imdb.TabIndex = 3;
            // 
            // Txt_FaFullName
            // 
            Txt_FaFullName._initialControlHeight = 0;
            Txt_FaFullName.BackColor = Color.White;
            Txt_FaFullName.CesAutoHeight = true;
            Txt_FaFullName.CesBackColor = Color.White;
            Txt_FaFullName.CesBorderColor = Color.DeepSkyBlue;
            Txt_FaFullName.CesBorderRadius = 0;
            Txt_FaFullName.CesBorderThickness = 1;
            Txt_FaFullName.CesCharacterCasing = CharacterCasing.Normal;
            Txt_FaFullName.CesFocusColor = Color.White;
            Txt_FaFullName.CesHasFocus = false;
            Txt_FaFullName.CesHasNotification = false;
            Txt_FaFullName.CesIcon = null;
            Txt_FaFullName.CesInputType = Ces.WinForm.UI.CesInputTypeEnum.Any;
            Txt_FaFullName.CesMaxLength = 0;
            Txt_FaFullName.CesMultiLine = false;
            Txt_FaFullName.CesNotificationColor = Color.Red;
            Txt_FaFullName.CesPadding = new Padding(5);
            Txt_FaFullName.CesPasswordChar = '\0';
            Txt_FaFullName.CesPlaceHolderText = null;
            Txt_FaFullName.CesReadOnly = false;
            Txt_FaFullName.CesRightToLeft = RightToLeft.Yes;
            Txt_FaFullName.CesScrollBar = ScrollBars.None;
            Txt_FaFullName.CesShowClearButton = false;
            Txt_FaFullName.CesShowCopyButton = false;
            Txt_FaFullName.CesShowIcon = false;
            Txt_FaFullName.CesShowPasteButton = true;
            Txt_FaFullName.CesShowTitle = true;
            Txt_FaFullName.CesText = "";
            Txt_FaFullName.CesTextAlignment = HorizontalAlignment.Center;
            Txt_FaFullName.CesTheme = Ces.WinForm.UI.Infrastructure.ThemeEnum.White;
            Txt_FaFullName.CesTitleAutoHeight = false;
            Txt_FaFullName.CesTitleAutoWidth = true;
            Txt_FaFullName.CesTitleBackground = true;
            Txt_FaFullName.CesTitleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_FaFullName.CesTitleHeight = 25;
            Txt_FaFullName.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right;
            Txt_FaFullName.CesTitleText = "نام فارسی";
            Txt_FaFullName.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            Txt_FaFullName.CesTitleTextColor = Color.White;
            Txt_FaFullName.CesTitleWidth = 80;
            Txt_FaFullName.CesWordWrap = false;
            Txt_FaFullName.Location = new Point(768, 49);
            Txt_FaFullName.Margin = new Padding(3, 5, 3, 5);
            Txt_FaFullName.Name = "Txt_FaFullName";
            Txt_FaFullName.Padding = new Padding(3, 5, 3, 5);
            Txt_FaFullName.Size = new Size(258, 35);
            Txt_FaFullName.TabIndex = 1;
            // 
            // Txt_EnFullName
            // 
            Txt_EnFullName._initialControlHeight = 0;
            Txt_EnFullName.BackColor = Color.White;
            Txt_EnFullName.CesAutoHeight = true;
            Txt_EnFullName.CesBackColor = Color.White;
            Txt_EnFullName.CesBorderColor = Color.DeepSkyBlue;
            Txt_EnFullName.CesBorderRadius = 0;
            Txt_EnFullName.CesBorderThickness = 1;
            Txt_EnFullName.CesCharacterCasing = CharacterCasing.Normal;
            Txt_EnFullName.CesFocusColor = Color.White;
            Txt_EnFullName.CesHasFocus = false;
            Txt_EnFullName.CesHasNotification = false;
            Txt_EnFullName.CesIcon = null;
            Txt_EnFullName.CesInputType = Ces.WinForm.UI.CesInputTypeEnum.Any;
            Txt_EnFullName.CesMaxLength = 0;
            Txt_EnFullName.CesMultiLine = false;
            Txt_EnFullName.CesNotificationColor = Color.Red;
            Txt_EnFullName.CesPadding = new Padding(5);
            Txt_EnFullName.CesPasswordChar = '\0';
            Txt_EnFullName.CesPlaceHolderText = null;
            Txt_EnFullName.CesReadOnly = false;
            Txt_EnFullName.CesRightToLeft = RightToLeft.Yes;
            Txt_EnFullName.CesScrollBar = ScrollBars.None;
            Txt_EnFullName.CesShowClearButton = false;
            Txt_EnFullName.CesShowCopyButton = false;
            Txt_EnFullName.CesShowIcon = false;
            Txt_EnFullName.CesShowPasteButton = true;
            Txt_EnFullName.CesShowTitle = true;
            Txt_EnFullName.CesText = "";
            Txt_EnFullName.CesTextAlignment = HorizontalAlignment.Center;
            Txt_EnFullName.CesTheme = Ces.WinForm.UI.Infrastructure.ThemeEnum.White;
            Txt_EnFullName.CesTitleAutoHeight = false;
            Txt_EnFullName.CesTitleAutoWidth = true;
            Txt_EnFullName.CesTitleBackground = true;
            Txt_EnFullName.CesTitleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_EnFullName.CesTitleHeight = 25;
            Txt_EnFullName.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right;
            Txt_EnFullName.CesTitleText = "نام انگلیسی";
            Txt_EnFullName.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            Txt_EnFullName.CesTitleTextColor = Color.White;
            Txt_EnFullName.CesTitleWidth = 80;
            Txt_EnFullName.CesWordWrap = false;
            Txt_EnFullName.Location = new Point(768, 5);
            Txt_EnFullName.Margin = new Padding(3, 4, 3, 4);
            Txt_EnFullName.Name = "Txt_EnFullName";
            Txt_EnFullName.Padding = new Padding(3, 4, 3, 4);
            Txt_EnFullName.Size = new Size(258, 35);
            Txt_EnFullName.TabIndex = 0;
            // 
            // Pic_Crew
            // 
            Pic_Crew.Location = new Point(6, 7);
            Pic_Crew.Name = "Pic_Crew";
            Pic_Crew.Size = new Size(228, 261);
            Pic_Crew.SizeMode = PictureBoxSizeMode.StretchImage;
            Pic_Crew.TabIndex = 17;
            Pic_Crew.TabStop = false;
            // 
            // Tb_Movies
            // 
            Tb_Movies.Controls.Add(Flw_Movie);
            Tb_Movies.Location = new Point(4, 28);
            Tb_Movies.Name = "Tb_Movies";
            Tb_Movies.Padding = new Padding(3);
            Tb_Movies.Size = new Size(1029, 568);
            Tb_Movies.TabIndex = 1;
            Tb_Movies.Text = "فیلم ها";
            Tb_Movies.UseVisualStyleBackColor = true;
            // 
            // Flw_Movie
            // 
            Flw_Movie.BackColor = Color.White;
            Flw_Movie.Location = new Point(6, 6);
            Flw_Movie.Name = "Flw_Movie";
            Flw_Movie.Size = new Size(1023, 556);
            Flw_Movie.TabIndex = 0;
            // 
            // Btn_Update
            // 
            Btn_Update.BackColor = Color.LightGray;
            Btn_Update.CesBorderThickness = 1;
            Btn_Update.CesBorderVisible = false;
            Btn_Update.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Silver;
            Btn_Update.CesEnableToolTip = false;
            Btn_Update.CesToolTipText = null;
            Btn_Update.FlatAppearance.BorderColor = Color.Gray;
            Btn_Update.FlatAppearance.BorderSize = 0;
            Btn_Update.FlatAppearance.MouseDownBackColor = Color.LightGray;
            Btn_Update.FlatAppearance.MouseOverBackColor = Color.Silver;
            Btn_Update.FlatStyle = FlatStyle.Flat;
            Btn_Update.ForeColor = Color.Black;
            Btn_Update.Location = new Point(205, 637);
            Btn_Update.Name = "Btn_Update";
            Btn_Update.Size = new Size(90, 35);
            Btn_Update.TabIndex = 10;
            Btn_Update.Text = "بروز رسانی";
            Btn_Update.UseVisualStyleBackColor = false;
            Btn_Update.Click += Btn_Update_Click;
            // 
            // Frm_EditPeople
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1047, 679);
            Controls.Add(Btn_Update);
            Controls.Add(Tb_Main);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Frm_EditPeople";
            Text = "Frm_EditPeople";
            Controls.SetChildIndex(Tb_Main, 0);
            Controls.SetChildIndex(Btn_Update, 0);
            Tb_Main.ResumeLayout(false);
            Tb_MainDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Pic_Crew).EndInit();
            Tb_Movies.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Ces.WinForm.UI.CesTextBox Txt_Currency;
        private Ces.WinForm.UI.CesTextBox Txt_Nominate;
        private Ces.WinForm.UI.CesTextBox Txt_Wins;
        private Ces.WinForm.UI.CesTextBox Txt_OscarWins;
        private Ces.WinForm.UI.CesTextBox Txt_OscarNominate;
        private Ces.WinForm.UI.CesTextBox Txt_EnStoryline;
        private Ces.WinForm.UI.CesTextBox Txt_FaStoryline;
        private Ces.WinForm.UI.CesComboBox.CesComboBox Cmb_Certificate;
        private Ces.WinForm.UI.CesToggleButton cesToggleButton1;
        private Ces.WinForm.UI.CesTextBox Txt_HourTime;
        private Ces.WinForm.UI.CesTextBox Txt_RunTime;
        private Ces.WinForm.UI.CesTextBox Txt_TopRanking;
        private Ces.WinForm.UI.CesTextBox cesTextBox2;
        private Ces.WinForm.UI.CesTextBox Txt_FaTitle;
        private TabControl Tb_Main;
        private TabPage Tb_MainDetails;
        private Ces.WinForm.UI.CesTextBox Txt_NickName;
        private Ces.WinForm.UI.CesTextBox Txt_ShamsiDeadDate;
        private Ces.WinForm.UI.CesTextBox Txt_Height;
        private Ces.WinForm.UI.CesTextBox Txt_BirthName;
        private Ces.WinForm.UI.CesTextBox Txt_DeadPlace;
        private Ces.WinForm.UI.CesTextBox Txt_FaMiniBioGraphy;
        private Ces.WinForm.UI.CesTextBox Txt_EnMiniBioGraphy;
        private Ces.WinForm.UI.CesComboBox.CesComboBox Cmb_DeathCuase;
        private Ces.WinForm.UI.CesTextBox Txt_BornPlace;
        private Ces.WinForm.UI.CesTextBox Txt_BirthDateShamsiYear;
        private Ces.WinForm.UI.CesTextBox Txt_DeathDate;
        private Ces.WinForm.UI.CesTextBox Txt_BirthDate;
        private Ces.WinForm.UI.CesTextBox Txt_Imdb;
        private Ces.WinForm.UI.CesTextBox Txt_FaFullName;
        private Ces.WinForm.UI.CesTextBox Txt_EnFullName;
        private PictureBox Pic_Crew;
        private TabPage Tb_Movies;
        private FlowLayoutPanel Flw_Movie;
        private Ces.WinForm.UI.CesButton.CesButton Btn_Update;
    }
}