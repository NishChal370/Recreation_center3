
namespace Recreation_center
{
    partial class TotalVisitorReportPanel
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelTotalVisitorReportTitle = new System.Windows.Forms.Label();
            this.ageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.selectedReportDate = new System.Windows.Forms.DateTimePicker();
            this.groupChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ageTable = new System.Windows.Forms.DataGridView();
            this.visitorsAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalVisitors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupTable = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ageChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ageTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTable)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTotalVisitorReportTitle
            // 
            this.labelTotalVisitorReportTitle.AutoSize = true;
            this.labelTotalVisitorReportTitle.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold);
            this.labelTotalVisitorReportTitle.Location = new System.Drawing.Point(245, 24);
            this.labelTotalVisitorReportTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTotalVisitorReportTitle.Name = "labelTotalVisitorReportTitle";
            this.labelTotalVisitorReportTitle.Size = new System.Drawing.Size(268, 24);
            this.labelTotalVisitorReportTitle.TabIndex = 2;
            this.labelTotalVisitorReportTitle.Text = "Total Visitor Report a day";
            // 
            // ageChart
            // 
            chartArea1.Name = "ChartArea1";
            this.ageChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ageChart.Legends.Add(legend1);
            this.ageChart.Location = new System.Drawing.Point(21, 104);
            this.ageChart.Name = "ageChart";
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Modern No. 20", 16.2F);
            series1.Legend = "Legend1";
            series1.Name = "Age";
            this.ageChart.Series.Add(series1);
            this.ageChart.Size = new System.Drawing.Size(330, 202);
            this.ageChart.TabIndex = 3;
            this.ageChart.Text = "visitoryByAgeChart";
            // 
            // selectedReportDate
            // 
            this.selectedReportDate.Font = new System.Drawing.Font("Modern No. 20", 12F);
            this.selectedReportDate.Location = new System.Drawing.Point(492, 73);
            this.selectedReportDate.Name = "selectedReportDate";
            this.selectedReportDate.Size = new System.Drawing.Size(240, 25);
            this.selectedReportDate.TabIndex = 4;
            this.selectedReportDate.ValueChanged += new System.EventHandler(this.selectedReportDate_ValueChanged);
            // 
            // groupChart
            // 
            chartArea2.Name = "ChartArea1";
            this.groupChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.groupChart.Legends.Add(legend2);
            this.groupChart.Location = new System.Drawing.Point(402, 104);
            this.groupChart.Name = "groupChart";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series2.Font = new System.Drawing.Font("Modern No. 20", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.Name = "Group";
            this.groupChart.Series.Add(series2);
            this.groupChart.Size = new System.Drawing.Size(330, 202);
            this.groupChart.TabIndex = 5;
            this.groupChart.Text = "visitoryByGroupChart";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 17.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 309);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Visitors By Age";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 17.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(470, 309);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Visitors By Group";
            // 
            // ageTable
            // 
            this.ageTable.AllowDrop = true;
            this.ageTable.AllowUserToAddRows = false;
            this.ageTable.AllowUserToDeleteRows = false;
            this.ageTable.AllowUserToOrderColumns = true;
            this.ageTable.AllowUserToResizeColumns = false;
            this.ageTable.AllowUserToResizeRows = false;
            this.ageTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ageTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ageTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.visitorsAge,
            this.totalVisitors});
            this.ageTable.Location = new System.Drawing.Point(21, 350);
            this.ageTable.Name = "ageTable";
            this.ageTable.ReadOnly = true;
            this.ageTable.Size = new System.Drawing.Size(330, 111);
            this.ageTable.TabIndex = 9;
            // 
            // visitorsAge
            // 
            this.visitorsAge.HeaderText = "Visitors Age";
            this.visitorsAge.MaxInputLength = 327675654;
            this.visitorsAge.Name = "visitorsAge";
            this.visitorsAge.ReadOnly = true;
            this.visitorsAge.Width = 186;
            // 
            // totalVisitors
            // 
            this.totalVisitors.HeaderText = "Total Visitors";
            this.totalVisitors.Name = "totalVisitors";
            this.totalVisitors.ReadOnly = true;
            this.totalVisitors.Width = 101;
            // 
            // groupTable
            // 
            this.groupTable.AllowUserToAddRows = false;
            this.groupTable.AllowUserToDeleteRows = false;
            this.groupTable.AllowUserToResizeColumns = false;
            this.groupTable.AllowUserToResizeRows = false;
            this.groupTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.groupTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.groupTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.groupTable.Location = new System.Drawing.Point(402, 350);
            this.groupTable.Name = "groupTable";
            this.groupTable.ReadOnly = true;
            this.groupTable.Size = new System.Drawing.Size(330, 111);
            this.groupTable.TabIndex = 10;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Visitors Group";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 327675654;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 186;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Total Visitors";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 101;
            // 
            // TotalVisitorReportPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.Controls.Add(this.groupTable);
            this.Controls.Add(this.ageTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupChart);
            this.Controls.Add(this.selectedReportDate);
            this.Controls.Add(this.ageChart);
            this.Controls.Add(this.labelTotalVisitorReportTitle);
            this.Name = "TotalVisitorReportPanel";
            this.Size = new System.Drawing.Size(756, 501);
            ((System.ComponentModel.ISupportInitialize)(this.ageChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ageTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTotalVisitorReportTitle;
        private System.Windows.Forms.DataVisualization.Charting.Chart ageChart;
        private System.Windows.Forms.DateTimePicker selectedReportDate;
        private System.Windows.Forms.DataVisualization.Charting.Chart groupChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView ageTable;
        private System.Windows.Forms.DataGridView groupTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitorsAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalVisitors;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
