
namespace Recreation_center
{
    partial class WeeklyReport
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelWeeklyReportTitle = new System.Windows.Forms.Label();
            this.weeklyReportChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.weklyDatePicker = new System.Windows.Forms.DateTimePicker();
            this.weeklyReportTable = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalVisitors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalEarning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortByVisitorsRadioBtn = new System.Windows.Forms.RadioButton();
            this.sortByEarningRatioBtn = new System.Windows.Forms.RadioButton();
            this.totalVisitorsLabel = new System.Windows.Forms.Label();
            this.totalEarningLabel = new System.Windows.Forms.Label();
            this.totalVisitorsResultLabel = new System.Windows.Forms.Label();
            this.totalEarningResultLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.weeklyReportChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weeklyReportTable)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWeeklyReportTitle
            // 
            this.labelWeeklyReportTitle.AutoSize = true;
            this.labelWeeklyReportTitle.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold);
            this.labelWeeklyReportTitle.Location = new System.Drawing.Point(244, 25);
            this.labelWeeklyReportTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWeeklyReportTitle.Name = "labelWeeklyReportTitle";
            this.labelWeeklyReportTitle.Size = new System.Drawing.Size(157, 24);
            this.labelWeeklyReportTitle.TabIndex = 3;
            this.labelWeeklyReportTitle.Text = "Weekly Report";
            // 
            // weeklyReportChart
            // 
            chartArea1.Name = "ChartArea1";
            this.weeklyReportChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.weeklyReportChart.Legends.Add(legend1);
            this.weeklyReportChart.Location = new System.Drawing.Point(21, 125);
            this.weeklyReportChart.Name = "weeklyReportChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "TotalVisitor";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "TotalEarning";
            this.weeklyReportChart.Series.Add(series1);
            this.weeklyReportChart.Series.Add(series2);
            this.weeklyReportChart.Size = new System.Drawing.Size(330, 323);
            this.weeklyReportChart.TabIndex = 4;
            this.weeklyReportChart.Text = "chart1";
            // 
            // weklyDatePicker
            // 
            this.weklyDatePicker.Font = new System.Drawing.Font("Modern No. 20", 12F);
            this.weklyDatePicker.Location = new System.Drawing.Point(447, 71);
            this.weklyDatePicker.Name = "weklyDatePicker";
            this.weklyDatePicker.Size = new System.Drawing.Size(240, 25);
            this.weklyDatePicker.TabIndex = 5;
            this.weklyDatePicker.ValueChanged += new System.EventHandler(this.selectedWeeklyReportDate_ValueChanged);
            // 
            // weeklyReportTable
            // 
            this.weeklyReportTable.AllowUserToAddRows = false;
            this.weeklyReportTable.AllowUserToDeleteRows = false;
            this.weeklyReportTable.AllowUserToResizeColumns = false;
            this.weeklyReportTable.AllowUserToResizeRows = false;
            this.weeklyReportTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.weeklyReportTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.weeklyReportTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.TotalVisitors,
            this.TotalEarning});
            this.weeklyReportTable.Location = new System.Drawing.Point(366, 125);
            this.weeklyReportTable.Name = "weeklyReportTable";
            this.weeklyReportTable.Size = new System.Drawing.Size(321, 323);
            this.weeklyReportTable.TabIndex = 6;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Width = 138;
            // 
            // TotalVisitors
            // 
            this.TotalVisitors.HeaderText = "TotalVisitors";
            this.TotalVisitors.Name = "TotalVisitors";
            this.TotalVisitors.Width = 70;
            // 
            // TotalEarning
            // 
            this.TotalEarning.HeaderText = "TotalEarning";
            this.TotalEarning.Name = "TotalEarning";
            this.TotalEarning.Width = 70;
            // 
            // sortByVisitorsRadioBtn
            // 
            this.sortByVisitorsRadioBtn.AutoSize = true;
            this.sortByVisitorsRadioBtn.Location = new System.Drawing.Point(496, 102);
            this.sortByVisitorsRadioBtn.Name = "sortByVisitorsRadioBtn";
            this.sortByVisitorsRadioBtn.Size = new System.Drawing.Size(91, 17);
            this.sortByVisitorsRadioBtn.TabIndex = 7;
            this.sortByVisitorsRadioBtn.TabStop = true;
            this.sortByVisitorsRadioBtn.Text = "sort by visitors";
            this.sortByVisitorsRadioBtn.UseVisualStyleBackColor = true;
            this.sortByVisitorsRadioBtn.CheckedChanged += new System.EventHandler(this.sortByVisitorsRadioBtn_CheckedChanged);
            // 
            // sortByEarningRatioBtn
            // 
            this.sortByEarningRatioBtn.AutoSize = true;
            this.sortByEarningRatioBtn.Location = new System.Drawing.Point(593, 102);
            this.sortByEarningRatioBtn.Name = "sortByEarningRatioBtn";
            this.sortByEarningRatioBtn.Size = new System.Drawing.Size(94, 17);
            this.sortByEarningRatioBtn.TabIndex = 8;
            this.sortByEarningRatioBtn.TabStop = true;
            this.sortByEarningRatioBtn.Text = "sort by earning";
            this.sortByEarningRatioBtn.UseVisualStyleBackColor = true;
            this.sortByEarningRatioBtn.CheckedChanged += new System.EventHandler(this.sortByEarningRatioBtn_CheckedChanged);
            // 
            // totalVisitorsLabel
            // 
            this.totalVisitorsLabel.AutoSize = true;
            this.totalVisitorsLabel.BackColor = System.Drawing.Color.White;
            this.totalVisitorsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalVisitorsLabel.Location = new System.Drawing.Point(230, 400);
            this.totalVisitorsLabel.Name = "totalVisitorsLabel";
            this.totalVisitorsLabel.Size = new System.Drawing.Size(79, 15);
            this.totalVisitorsLabel.TabIndex = 9;
            this.totalVisitorsLabel.Text = "Total Visitors:";
            // 
            // totalEarningLabel
            // 
            this.totalEarningLabel.AutoSize = true;
            this.totalEarningLabel.BackColor = System.Drawing.Color.White;
            this.totalEarningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalEarningLabel.Location = new System.Drawing.Point(230, 425);
            this.totalEarningLabel.Name = "totalEarningLabel";
            this.totalEarningLabel.Size = new System.Drawing.Size(83, 15);
            this.totalEarningLabel.TabIndex = 10;
            this.totalEarningLabel.Text = "Total Earning:";
            // 
            // totalVisitorsResultLabel
            // 
            this.totalVisitorsResultLabel.AutoSize = true;
            this.totalVisitorsResultLabel.BackColor = System.Drawing.Color.White;
            this.totalVisitorsResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalVisitorsResultLabel.Location = new System.Drawing.Point(312, 400);
            this.totalVisitorsResultLabel.Name = "totalVisitorsResultLabel";
            this.totalVisitorsResultLabel.Size = new System.Drawing.Size(14, 15);
            this.totalVisitorsResultLabel.TabIndex = 11;
            this.totalVisitorsResultLabel.Text = "0";
            // 
            // totalEarningResultLabel
            // 
            this.totalEarningResultLabel.AutoSize = true;
            this.totalEarningResultLabel.BackColor = System.Drawing.Color.White;
            this.totalEarningResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalEarningResultLabel.Location = new System.Drawing.Point(312, 425);
            this.totalEarningResultLabel.Name = "totalEarningResultLabel";
            this.totalEarningResultLabel.Size = new System.Drawing.Size(14, 15);
            this.totalEarningResultLabel.TabIndex = 12;
            this.totalEarningResultLabel.Text = "0";
            // 
            // WeeklyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.Controls.Add(this.totalEarningResultLabel);
            this.Controls.Add(this.totalVisitorsResultLabel);
            this.Controls.Add(this.totalEarningLabel);
            this.Controls.Add(this.totalVisitorsLabel);
            this.Controls.Add(this.sortByEarningRatioBtn);
            this.Controls.Add(this.sortByVisitorsRadioBtn);
            this.Controls.Add(this.weeklyReportTable);
            this.Controls.Add(this.weklyDatePicker);
            this.Controls.Add(this.weeklyReportChart);
            this.Controls.Add(this.labelWeeklyReportTitle);
            this.Name = "WeeklyReport";
            this.Size = new System.Drawing.Size(706, 483);
            ((System.ComponentModel.ISupportInitialize)(this.weeklyReportChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weeklyReportTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWeeklyReportTitle;
        private System.Windows.Forms.DataVisualization.Charting.Chart weeklyReportChart;
        private System.Windows.Forms.DateTimePicker weklyDatePicker;
        private System.Windows.Forms.DataGridView weeklyReportTable;
        private System.Windows.Forms.RadioButton sortByVisitorsRadioBtn;
        private System.Windows.Forms.RadioButton sortByEarningRatioBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalVisitors;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalEarning;
        private System.Windows.Forms.Label totalVisitorsLabel;
        private System.Windows.Forms.Label totalEarningLabel;
        private System.Windows.Forms.Label totalVisitorsResultLabel;
        private System.Windows.Forms.Label totalEarningResultLabel;
    }
}
