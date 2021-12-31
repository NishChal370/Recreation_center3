
namespace Recreation_center
{
    partial class viewTicketPanel
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ticketTable = new System.Windows.Forms.DataGridView();
            this.ticketId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelViewTicket = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ticketTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CalendarFont = new System.Drawing.Font("Modern No. 20", 12F);
            this.dateTimePicker.Font = new System.Drawing.Font("Modern No. 20", 12F);
            this.dateTimePicker.Location = new System.Drawing.Point(499, 59);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(240, 25);
            this.dateTimePicker.TabIndex = 0;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // ticketTable
            // 
            this.ticketTable.AllowUserToAddRows = false;
            this.ticketTable.AllowUserToDeleteRows = false;
            this.ticketTable.AllowUserToResizeColumns = false;
            this.ticketTable.AllowUserToResizeRows = false;
            this.ticketTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ticketTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ticketId,
            this.date,
            this.name,
            this.phone,
            this.address,
            this.age,
            this.inTime,
            this.outTime,
            this.price});
            this.ticketTable.Location = new System.Drawing.Point(13, 88);
            this.ticketTable.Name = "ticketTable";
            this.ticketTable.Size = new System.Drawing.Size(726, 396);
            this.ticketTable.TabIndex = 1;
            // 
            // ticketId
            // 
            this.ticketId.HeaderText = "Ticket ID";
            this.ticketId.Name = "ticketId";
            // 
            // date
            // 
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            // 
            // phone
            // 
            this.phone.HeaderText = "Phone";
            this.phone.Name = "phone";
            // 
            // address
            // 
            this.address.HeaderText = "Address";
            this.address.Name = "address";
            // 
            // age
            // 
            this.age.HeaderText = "Age";
            this.age.Name = "age";
            // 
            // inTime
            // 
            this.inTime.HeaderText = "InTime";
            this.inTime.Name = "inTime";
            // 
            // outTime
            // 
            this.outTime.HeaderText = "OutTime";
            this.outTime.Name = "outTime";
            // 
            // price
            // 
            this.price.HeaderText = "Price";
            this.price.Name = "price";
            // 
            // labelViewTicket
            // 
            this.labelViewTicket.AutoSize = true;
            this.labelViewTicket.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold);
            this.labelViewTicket.Location = new System.Drawing.Point(16, 59);
            this.labelViewTicket.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelViewTicket.Name = "labelViewTicket";
            this.labelViewTicket.Size = new System.Drawing.Size(137, 24);
            this.labelViewTicket.TabIndex = 3;
            this.labelViewTicket.Text = "View Tickets";
            // 
            // viewTicketPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.Controls.Add(this.labelViewTicket);
            this.Controls.Add(this.ticketTable);
            this.Controls.Add(this.dateTimePicker);
            this.Name = "viewTicketPanel";
            this.Size = new System.Drawing.Size(756, 501);
            ((System.ComponentModel.ISupportInitialize)(this.ticketTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.DataGridView ticketTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketId;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn age;
        private System.Windows.Forms.DataGridViewTextBoxColumn inTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn outTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.Label labelViewTicket;
    }
}
