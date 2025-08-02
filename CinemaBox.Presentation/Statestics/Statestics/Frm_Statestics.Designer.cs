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
            Chart.Location = new Point(258, 38);
            Chart.Name = "Chart";
            Chart.Size = new Size(728, 518);
            Chart.TabIndex = 7;
            // 
            // Frm_Statestics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 556);
            Controls.Add(Chart);
            Controls.Add(Lst_Statestics);
            Name = "Frm_Statestics";
            Text = "Frm_Statestics";
            Load += Frm_Statestics_Load;
            Controls.SetChildIndex(Lst_Statestics, 0);
            Controls.SetChildIndex(Chart, 0);
            ResumeLayout(false);
        }

        #endregion

        private ListView Lst_Statestics;
        private ColumnHeader Col_Title;
        private ColumnHeader Col_Count;
        private Ces.WinForm.UI.CesChart.CesChart Chart;
    }
}