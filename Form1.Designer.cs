
namespace Recreation_center
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.topNavPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.sideNavPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnWeekReport = new System.Windows.Forms.Button();
            this.btnDayReport = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnTicket = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewTicket = new System.Windows.Forms.Button();
            this.ticketPanel1 = new Recreation_center.TicketPanel();
            this.adminPanel1 = new Recreation_center.AdminPanel();
            this.totalVisitorReport1 = new Recreation_center.TotalVisitorReportPanel();
            this.weeklyReport2 = new Recreation_center.WeeklyReport();
            this.viewTicketPanel1 = new Recreation_center.viewTicketPanel();
            this.weeklyReport1 = new Recreation_center.WeeklyReport();
            this.topNavPanel.SuspendLayout();
            this.sideNavPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // topNavPanel
            // 
            this.topNavPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.topNavPanel.Controls.Add(this.label1);
            this.topNavPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topNavPanel.Location = new System.Drawing.Point(0, 0);
            this.topNavPanel.Margin = new System.Windows.Forms.Padding(2);
            this.topNavPanel.Name = "topNavPanel";
            this.topNavPanel.Size = new System.Drawing.Size(884, 70);
            this.topNavPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Edwardian Script ITC", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(264, -6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 76);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recreation Center";
            // 
            // sideNavPanel
            // 
            this.sideNavPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sideNavPanel.Controls.Add(this.btnViewTicket);
            this.sideNavPanel.Controls.Add(this.pictureBox1);
            this.sideNavPanel.Controls.Add(this.btnWeekReport);
            this.sideNavPanel.Controls.Add(this.btnDayReport);
            this.sideNavPanel.Controls.Add(this.btnAdmin);
            this.sideNavPanel.Controls.Add(this.btnTicket);
            this.sideNavPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideNavPanel.Location = new System.Drawing.Point(0, 70);
            this.sideNavPanel.Margin = new System.Windows.Forms.Padding(2);
            this.sideNavPanel.Name = "sideNavPanel";
            this.sideNavPanel.Size = new System.Drawing.Size(127, 501);
            this.sideNavPanel.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnWeekReport
            // 
            this.btnWeekReport.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnWeekReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWeekReport.FlatAppearance.BorderSize = 0;
            this.btnWeekReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeekReport.Font = new System.Drawing.Font("Modern No. 20", 13.8F);
            this.btnWeekReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWeekReport.Location = new System.Drawing.Point(0, 247);
            this.btnWeekReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnWeekReport.Name = "btnWeekReport";
            this.btnWeekReport.Size = new System.Drawing.Size(127, 37);
            this.btnWeekReport.TabIndex = 4;
            this.btnWeekReport.Text = "Week Report";
            this.btnWeekReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWeekReport.UseVisualStyleBackColor = false;
            this.btnWeekReport.Click += new System.EventHandler(this.btnWeekReport_Click);
            // 
            // btnDayReport
            // 
            this.btnDayReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDayReport.FlatAppearance.BorderSize = 0;
            this.btnDayReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDayReport.Font = new System.Drawing.Font("Modern No. 20", 13.8F);
            this.btnDayReport.Location = new System.Drawing.Point(0, 204);
            this.btnDayReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnDayReport.Name = "btnDayReport";
            this.btnDayReport.Size = new System.Drawing.Size(127, 37);
            this.btnDayReport.TabIndex = 3;
            this.btnDayReport.Text = "Day Report";
            this.btnDayReport.UseVisualStyleBackColor = true;
            this.btnDayReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Font = new System.Drawing.Font("Modern No. 20", 13.8F);
            this.btnAdmin.Image = ((System.Drawing.Image)(resources.GetObject("btnAdmin.Image")));
            this.btnAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmin.Location = new System.Drawing.Point(0, 161);
            this.btnAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(127, 37);
            this.btnAdmin.TabIndex = 3;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnTicket
            // 
            this.btnTicket.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTicket.FlatAppearance.BorderSize = 0;
            this.btnTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTicket.Font = new System.Drawing.Font("Modern No. 20", 13.8F);
            this.btnTicket.ForeColor = System.Drawing.Color.Black;
            this.btnTicket.Image = ((System.Drawing.Image)(resources.GetObject("btnTicket.Image")));
            this.btnTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTicket.Location = new System.Drawing.Point(0, 118);
            this.btnTicket.Margin = new System.Windows.Forms.Padding(2);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Size = new System.Drawing.Size(127, 37);
            this.btnTicket.TabIndex = 3;
            this.btnTicket.Text = "Ticket";
            this.btnTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTicket.UseVisualStyleBackColor = false;
            this.btnTicket.Click += new System.EventHandler(this.btnTicket_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Snow;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(728, 554);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Developed by Nischal";
            // 
            // btnViewTicket
            // 
            this.btnViewTicket.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnViewTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewTicket.FlatAppearance.BorderSize = 0;
            this.btnViewTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewTicket.Font = new System.Drawing.Font("Modern No. 20", 13.8F);
            this.btnViewTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewTicket.Location = new System.Drawing.Point(0, 290);
            this.btnViewTicket.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewTicket.Name = "btnViewTicket";
            this.btnViewTicket.Size = new System.Drawing.Size(127, 37);
            this.btnViewTicket.TabIndex = 5;
            this.btnViewTicket.Text = "View Ticket";
            this.btnViewTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewTicket.UseVisualStyleBackColor = false;
            this.btnViewTicket.Click += new System.EventHandler(this.btnViewTicket_Click);
            // 
            // ticketPanel1
            // 
            this.ticketPanel1.BackColor = System.Drawing.Color.Snow;
            this.ticketPanel1.Location = new System.Drawing.Point(128, 70);
            this.ticketPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.ticketPanel1.Name = "ticketPanel1";
            this.ticketPanel1.Size = new System.Drawing.Size(756, 501);
            this.ticketPanel1.TabIndex = 6;
            // 
            // adminPanel1
            // 
            this.adminPanel1.BackColor = System.Drawing.Color.Snow;
            this.adminPanel1.Location = new System.Drawing.Point(127, 70);
            this.adminPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.adminPanel1.Name = "adminPanel1";
            this.adminPanel1.Size = new System.Drawing.Size(757, 501);
            this.adminPanel1.TabIndex = 3;
            // 
            // totalVisitorReport1
            // 
            this.totalVisitorReport1.BackColor = System.Drawing.Color.Snow;
            this.totalVisitorReport1.Location = new System.Drawing.Point(127, 70);
            this.totalVisitorReport1.Name = "totalVisitorReport1";
            this.totalVisitorReport1.Size = new System.Drawing.Size(757, 501);
            this.totalVisitorReport1.TabIndex = 4;
            // 
            // weeklyReport2
            // 
            this.weeklyReport2.BackColor = System.Drawing.Color.Snow;
            this.weeklyReport2.Location = new System.Drawing.Point(128, 69);
            this.weeklyReport2.Name = "weeklyReport2";
            this.weeklyReport2.Size = new System.Drawing.Size(756, 502);
            this.weeklyReport2.TabIndex = 5;
            // 
            // viewTicketPanel1
            // 
            this.viewTicketPanel1.Location = new System.Drawing.Point(127, 70);
            this.viewTicketPanel1.Name = "viewTicketPanel1";
            this.viewTicketPanel1.Size = new System.Drawing.Size(756, 501);
            this.viewTicketPanel1.TabIndex = 7;
            // 
            // weeklyReport1
            // 
            this.weeklyReport1.BackColor = System.Drawing.Color.Snow;
            this.weeklyReport1.Location = new System.Drawing.Point(128, 69);
            this.weeklyReport1.Name = "weeklyReport1";
            this.weeklyReport1.Size = new System.Drawing.Size(706, 483);
            this.weeklyReport1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 571);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ticketPanel1);
            this.Controls.Add(this.adminPanel1);
            this.Controls.Add(this.sideNavPanel);
            this.Controls.Add(this.topNavPanel);
            this.Controls.Add(this.totalVisitorReport1);
            this.Controls.Add(this.weeklyReport2);
            this.Controls.Add(this.viewTicketPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recreation Center Ticketing System";
            this.topNavPanel.ResumeLayout(false);
            this.topNavPanel.PerformLayout();
            this.sideNavPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topNavPanel;
        private System.Windows.Forms.Panel sideNavPanel;
        private System.Windows.Forms.Button btnTicket;
        private System.Windows.Forms.Button btnDayReport;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnWeekReport;
        private WeeklyReport weeklyReport1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private WeeklyReport weeklyReport2;
        private TotalVisitorReportPanel totalVisitorReport1;
        private AdminPanel adminPanel1;
        private TicketPanel ticketPanel1;
        private viewTicketPanel viewTicketPanel1;
        private System.Windows.Forms.Button btnViewTicket;
    }
}

