namespace CinemaBox.Presentation.TvMaz
{
    partial class Frm_TvMaz
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            Dgv_TvMaz = new Ces.WinForm.UI.CesGridView.CesGridViewPro();
            SuspendLayout();
            // 
            // btnOptions
            // 
            btnOptions.FlatAppearance.BorderColor = Color.DarkGreen;
            btnOptions.FlatAppearance.BorderSize = 0;
            btnOptions.FlatAppearance.MouseDownBackColor = Color.MediumSeaGreen;
            btnOptions.FlatAppearance.MouseOverBackColor = Color.DarkSeaGreen;
            // 
            // Dgv_TvMaz
            // 
            Dgv_TvMaz.AllowUserToAddRows = false;
            Dgv_TvMaz.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle5.ForeColor = Color.Black;
            Dgv_TvMaz.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            Dgv_TvMaz.BackColor = Color.White;
            Dgv_TvMaz.BorderStyle = BorderStyle.FixedSingle;
            Dgv_TvMaz.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            Dgv_TvMaz.CesDataSource = null;
            Dgv_TvMaz.CesEnableFilteringRow = true;
            Dgv_TvMaz.CesEnableOptions = false;
            Dgv_TvMaz.CesHeaderFont = null;
            Dgv_TvMaz.CesHeaderHeight = 60;
            Dgv_TvMaz.CesHeaderTextAlignment = ContentAlignment.MiddleCenter;
            Dgv_TvMaz.CesHeaderTextColor = Color.Empty;
            Dgv_TvMaz.CesRowSizeMode = Ces.WinForm.UI.CesGridView.CesGridViewRowSizeModeEnum.Normal;
            Dgv_TvMaz.CesStopCerrentCellChangedEventInCurrentRow = false;
            Dgv_TvMaz.CesTheme = Ces.WinForm.UI.Infrastructure.ThemeEnum.White;
            Dgv_TvMaz.CesTitle = "Title";
            Dgv_TvMaz.CesTitleColor = Color.DimGray;
            Dgv_TvMaz.CesTitleTextAlignment = ContentAlignment.MiddleCenter;
            Dgv_TvMaz.CesTitleVisible = false;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.Khaki;
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            Dgv_TvMaz.DefaultCellStyle = dataGridViewCellStyle6;
            Dgv_TvMaz.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Dgv_TvMaz.ForeColor = Color.DimGray;
            Dgv_TvMaz.GridColor = Color.FromArgb(224, 224, 224);
            Dgv_TvMaz.Location = new Point(5, 35);
            Dgv_TvMaz.Name = "Dgv_TvMaz";
            Dgv_TvMaz.ReadOnly = true;
            Dgv_TvMaz.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            Dgv_TvMaz.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            Dgv_TvMaz.RowHeadersWidth = 29;
            Dgv_TvMaz.RowsDefaultCellStyle = dataGridViewCellStyle8;
            Dgv_TvMaz.RowTemplate.Height = 30;
            Dgv_TvMaz.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_TvMaz.Size = new Size(790, 410);
            Dgv_TvMaz.TabIndex = 7;
            // 
            // Frm_TvMaz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Dgv_TvMaz);
            Name = "Frm_TvMaz";
            Text = "Frm_TvMaz";
            Controls.SetChildIndex(Dgv_TvMaz, 0);
            ResumeLayout(false);
        }

        #endregion

        private Ces.WinForm.UI.CesGridView.CesGridViewPro Dgv_TvMaz;
    }
}