namespace CinemaBox.Presentation.Statestics.Statestics
{
    partial class Frm_Statestics
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
            Lst_Statestics = new ListView();
            Col_Title = new ColumnHeader();
            Col_Count = new ColumnHeader();
            Chart = new Ces.WinForm.UI.CesChart.CesChart();
            Cmb_LoadChart = new Ces.WinForm.UI.CesComboBox.CesComboBox();
            SuspendLayout();
            // 
            // btnOptions
            // 
            btnOptions.FlatAppearance.BorderColor = Color.DarkGreen;
            btnOptions.FlatAppearance.BorderSize = 0;
            btnOptions.FlatAppearance.MouseDownBackColor = Color.MediumSeaGreen;
            btnOptions.FlatAppearance.MouseOverBackColor = Color.DarkSeaGreen;
            // 
            // Lst_Statestics
            // 
            Lst_Statestics.Columns.AddRange(new ColumnHeader[] { Col_Title, Col_Count });
            Lst_Statestics.Dock = DockStyle.Left;
            Lst_Statestics.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lst_Statestics.FullRowSelect = true;
            Lst_Statestics.Location = new Point(2, 32);
            Lst_Statestics.MultiSelect = false;
            Lst_Statestics.Name = "Lst_Statestics";
            Lst_Statestics.RightToLeft = RightToLeft.Yes;
            Lst_Statestics.RightToLeftLayout = true;
            Lst_Statestics.Size = new Size(250, 522);
            Lst_Statestics.TabIndex = 0;
            Lst_Statestics.UseCompatibleStateImageBehavior = false;
            Lst_Statestics.View = View.Details;
            // 
            // Col_Title
            // 
            Col_Title.Text = "";
            Col_Title.TextAlign = HorizontalAlignment.Right;
            Col_Title.Width = 150;
            // 
            // Col_Count
            // 
            Col_Count.Text = "";
            Col_Count.Width = 175;
            // 
            // Chart
            // 
            Chart.BackColor = Color.White;
            Chart.CesCategoryFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Chart.CesCategoryGridLineVisible = false;
            Chart.CesCategoryHeight = 50F;
            Chart.CesCategoryVisible = true;
            Chart.CesChartTitle = "Chart title";
            Chart.CesChartTitleVisible = true;
            Chart.CesColumnWidth = 5F;
            Chart.CesData = null;
            Chart.CesErrorFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Chart.CesLegend = null;
            Chart.CesLegendFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Chart.CesLegendVisible = true;
            Chart.CesLegendWidth = 100F;
            Chart.CesScale = 10;
            Chart.CesScaleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Chart.CesScaleIndicatorWidth = 5F;
            Chart.CesScaleTitle = null;
            Chart.CesScaleVisible = true;
            Chart.CesScaleWidth = 50F;
            Chart.CesSeries = null;
            Chart.CesTitleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Chart.CesTitleHeight = 50F;
            Chart.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Chart.Location = new Point(258, 73);
            Chart.Name = "Chart";
            Chart.Size = new Size(728, 483);
            Chart.TabIndex = 7;
            // 
            // Cmb_LoadChart
            // 
            Cmb_LoadChart._initialControlHeight = 0;
            Cmb_LoadChart.BackColor = Color.White;
            Cmb_LoadChart.CesAdjustPopupToParentWidth = true;
            Cmb_LoadChart.CesAlignToRight = false;
            Cmb_LoadChart.CesAutoHeight = true;
            Cmb_LoadChart.CesBackColor = Color.White;
            Cmb_LoadChart.CesBorderColor = Color.DeepSkyBlue;
            Cmb_LoadChart.CesBorderRadius = 0;
            Cmb_LoadChart.CesBorderThickness = 1;
            Cmb_LoadChart.CesDataSource = null;
            Cmb_LoadChart.CesDisplayMember = null;
            Cmb_LoadChart.CesDropDownOnFocus = false;
            Cmb_LoadChart.CesFocusColor = Color.White;
            Cmb_LoadChart.CesHasFocus = false;
            Cmb_LoadChart.CesHasNotification = false;
            Cmb_LoadChart.CesIcon = null;
            Cmb_LoadChart.CesImageMember = null;
            Cmb_LoadChart.CesImageWidth = 24;
            Cmb_LoadChart.CesItemHeight = 30;
            Cmb_LoadChart.CesKeepPreviousSelection = true;
            Cmb_LoadChart.CesLoadingMode = false;
            Cmb_LoadChart.CesNotificationColor = Color.Red;
            Cmb_LoadChart.CesPadding = new Padding(5);
            Cmb_LoadChart.CesPopupSize = new Size(350, 400);
            Cmb_LoadChart.CesSelectedItem = null;
            Cmb_LoadChart.CesSelectedValue = null;
            Cmb_LoadChart.CesSelectFirstItem = false;
            Cmb_LoadChart.CesSelectFirstItemIfPreviousWasNull = true;
            Cmb_LoadChart.CesShowAddItemButton = false;
            Cmb_LoadChart.CesShowClearButton = false;
            Cmb_LoadChart.CesShowEditItemButton = false;
            Cmb_LoadChart.CesShowIcon = false;
            Cmb_LoadChart.CesShowImage = false;
            Cmb_LoadChart.CesShowIndicator = false;
            Cmb_LoadChart.CesShowLoadButton = false;
            Cmb_LoadChart.CesShowSearchBox = true;
            Cmb_LoadChart.CesShowStatusBar = true;
            Cmb_LoadChart.CesShowTitle = false;
            Cmb_LoadChart.CesStopSelectedItemChangedEvent = false;
            Cmb_LoadChart.CesTheme = Ces.WinForm.UI.Infrastructure.ThemeEnum.White;
            Cmb_LoadChart.CesTitleAutoHeight = false;
            Cmb_LoadChart.CesTitleAutoWidth = false;
            Cmb_LoadChart.CesTitleBackground = true;
            Cmb_LoadChart.CesTitleFont = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Cmb_LoadChart.CesTitleHeight = 25;
            Cmb_LoadChart.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Left;
            Cmb_LoadChart.CesTitleText = "Enter Value";
            Cmb_LoadChart.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            Cmb_LoadChart.CesTitleTextColor = Color.White;
            Cmb_LoadChart.CesTitleWidth = 80;
            Cmb_LoadChart.CesValueMember = null;
            Cmb_LoadChart.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Cmb_LoadChart.Location = new Point(258, 32);
            Cmb_LoadChart.Margin = new Padding(3, 4, 3, 4);
            Cmb_LoadChart.Name = "Cmb_LoadChart";
            Cmb_LoadChart.Padding = new Padding(3, 4, 3, 4);
            Cmb_LoadChart.RightToLeft = RightToLeft.Yes;
            Cmb_LoadChart.Size = new Size(450, 34);
            Cmb_LoadChart.TabIndex = 8;
            Cmb_LoadChart.CesSelectedItemChanged += Cmb_LoadChart_CesSelectedItemChanged;
            // 
            // Frm_Statestics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 556);
            Controls.Add(Cmb_LoadChart);
            Controls.Add(Chart);
            Controls.Add(Lst_Statestics);
            Name = "Frm_Statestics";
            Text = "Frm_Statestics";
            Load += Frm_Statestics_Load;
            Controls.SetChildIndex(Lst_Statestics, 0);
            Controls.SetChildIndex(Chart, 0);
            Controls.SetChildIndex(Cmb_LoadChart, 0);
            ResumeLayout(false);
        }

        #endregion

        private ListView Lst_Statestics;
        private ColumnHeader Col_Title;
        private ColumnHeader Col_Count;
        private Ces.WinForm.UI.CesChart.CesChart Chart;
        private Ces.WinForm.UI.CesComboBox.CesComboBox Cmb_LoadChart;
    }
}