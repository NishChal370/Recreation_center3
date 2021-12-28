
namespace Recreation_center
{
    partial class TicketPanel
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
            this.panelTicketForm = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBoxTotalPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxDiscount = new System.Windows.Forms.TextBox();
            this.txtBoxGrandTotal = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.notGroupRadioBtn = new System.Windows.Forms.RadioButton();
            this.isGroupRadioBtn = new System.Windows.Forms.RadioButton();
            this.ticketTable = new System.Windows.Forms.DataGridView();
            this.TicketNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ticketDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ticketAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ticketAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ticketGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ticketInTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ticketOutTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ticketPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBoxOutTime = new System.Windows.Forms.TextBox();
            this.txtBoxInTime = new System.Windows.Forms.TextBox();
            this.txtBoxPrice = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelOutTime = new System.Windows.Forms.Label();
            this.labelGroup = new System.Windows.Forms.Label();
            this.labelInTime = new System.Windows.Forms.Label();
            this.cmboBoxAge = new System.Windows.Forms.ComboBox();
            this.txtBoxAddress = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelAge = new System.Windows.Forms.Label();
            this.txtBoxPhone = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelTicketNo = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtBoxTicketNo = new System.Windows.Forms.TextBox();
            this.btnSearchTicket = new System.Windows.Forms.Button();
            this.panelTicketForm.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ticketTable)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTicketForm
            // 
            this.panelTicketForm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTicketForm.Controls.Add(this.btnAdd);
            this.panelTicketForm.Controls.Add(this.panel1);
            this.panelTicketForm.Controls.Add(this.notGroupRadioBtn);
            this.panelTicketForm.Controls.Add(this.isGroupRadioBtn);
            this.panelTicketForm.Controls.Add(this.ticketTable);
            this.panelTicketForm.Controls.Add(this.txtBoxOutTime);
            this.panelTicketForm.Controls.Add(this.txtBoxInTime);
            this.panelTicketForm.Controls.Add(this.txtBoxPrice);
            this.panelTicketForm.Controls.Add(this.labelPrice);
            this.panelTicketForm.Controls.Add(this.labelOutTime);
            this.panelTicketForm.Controls.Add(this.labelGroup);
            this.panelTicketForm.Controls.Add(this.labelInTime);
            this.panelTicketForm.Controls.Add(this.cmboBoxAge);
            this.panelTicketForm.Controls.Add(this.txtBoxAddress);
            this.panelTicketForm.Controls.Add(this.labelAddress);
            this.panelTicketForm.Controls.Add(this.labelAge);
            this.panelTicketForm.Controls.Add(this.txtBoxPhone);
            this.panelTicketForm.Controls.Add(this.labelPhone);
            this.panelTicketForm.Controls.Add(this.txtBoxName);
            this.panelTicketForm.Controls.Add(this.labelName);
            this.panelTicketForm.Location = new System.Drawing.Point(13, 88);
            this.panelTicketForm.Margin = new System.Windows.Forms.Padding(2);
            this.panelTicketForm.Name = "panelTicketForm";
            this.panelTicketForm.Size = new System.Drawing.Size(680, 374);
            this.panelTicketForm.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Enabled = false;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(565, 141);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(103, 25);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtBoxTotalPrice);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtBoxDiscount);
            this.panel1.Controls.Add(this.txtBoxGrandTotal);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(358, 183);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 179);
            this.panel1.TabIndex = 27;
            // 
            // txtBoxTotalPrice
            // 
            this.txtBoxTotalPrice.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBoxTotalPrice.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxTotalPrice.Location = new System.Drawing.Point(151, 23);
            this.txtBoxTotalPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxTotalPrice.Name = "txtBoxTotalPrice";
            this.txtBoxTotalPrice.ReadOnly = true;
            this.txtBoxTotalPrice.Size = new System.Drawing.Size(159, 24);
            this.txtBoxTotalPrice.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 16.2F);
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Total Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 16.2F);
            this.label2.Location = new System.Drawing.Point(4, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Discount (%)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Grand Total";
            // 
            // txtBoxDiscount
            // 
            this.txtBoxDiscount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBoxDiscount.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDiscount.Location = new System.Drawing.Point(151, 51);
            this.txtBoxDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxDiscount.Name = "txtBoxDiscount";
            this.txtBoxDiscount.ReadOnly = true;
            this.txtBoxDiscount.Size = new System.Drawing.Size(159, 24);
            this.txtBoxDiscount.TabIndex = 6;
            // 
            // txtBoxGrandTotal
            // 
            this.txtBoxGrandTotal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBoxGrandTotal.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxGrandTotal.Location = new System.Drawing.Point(150, 79);
            this.txtBoxGrandTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxGrandTotal.Name = "txtBoxGrandTotal";
            this.txtBoxGrandTotal.ReadOnly = true;
            this.txtBoxGrandTotal.Size = new System.Drawing.Size(160, 24);
            this.txtBoxGrandTotal.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(2, 113);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(308, 30);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(2, 147);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(308, 30);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // notGroupRadioBtn
            // 
            this.notGroupRadioBtn.AutoSize = true;
            this.notGroupRadioBtn.Checked = true;
            this.notGroupRadioBtn.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.notGroupRadioBtn.Location = new System.Drawing.Point(510, 141);
            this.notGroupRadioBtn.Name = "notGroupRadioBtn";
            this.notGroupRadioBtn.Size = new System.Drawing.Size(50, 25);
            this.notGroupRadioBtn.TabIndex = 26;
            this.notGroupRadioBtn.TabStop = true;
            this.notGroupRadioBtn.Text = "No";
            this.notGroupRadioBtn.UseVisualStyleBackColor = true;
            this.notGroupRadioBtn.CheckedChanged += new System.EventHandler(this.notGroupRadioBtn_CheckedChanged);
            // 
            // isGroupRadioBtn
            // 
            this.isGroupRadioBtn.AutoSize = true;
            this.isGroupRadioBtn.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isGroupRadioBtn.Location = new System.Drawing.Point(446, 141);
            this.isGroupRadioBtn.Name = "isGroupRadioBtn";
            this.isGroupRadioBtn.Size = new System.Drawing.Size(57, 25);
            this.isGroupRadioBtn.TabIndex = 25;
            this.isGroupRadioBtn.Text = "Yes";
            this.isGroupRadioBtn.UseVisualStyleBackColor = true;
            this.isGroupRadioBtn.CheckedChanged += new System.EventHandler(this.isGroupRadioBtn_CheckedChanged);
            // 
            // ticketTable
            // 
            this.ticketTable.AllowUserToAddRows = false;
            this.ticketTable.AllowUserToDeleteRows = false;
            this.ticketTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ticketTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ticketTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TicketNo,
            this.ticketDate,
            this.CustomerName,
            this.Phone,
            this.ticketAddress,
            this.ticketAge,
            this.ticketGroup,
            this.ticketInTime,
            this.ticketOutTime,
            this.ticketPrice});
            this.ticketTable.Location = new System.Drawing.Point(3, 183);
            this.ticketTable.Name = "ticketTable";
            this.ticketTable.ReadOnly = true;
            this.ticketTable.Size = new System.Drawing.Size(311, 179);
            this.ticketTable.TabIndex = 24;
            // 
            // TicketNo
            // 
            this.TicketNo.HeaderText = "TicketNo";
            this.TicketNo.Name = "TicketNo";
            this.TicketNo.ReadOnly = true;
            this.TicketNo.Width = 60;
            // 
            // ticketDate
            // 
            this.ticketDate.HeaderText = "Date";
            this.ticketDate.Name = "ticketDate";
            this.ticketDate.ReadOnly = true;
            this.ticketDate.Width = 130;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // ticketAddress
            // 
            this.ticketAddress.HeaderText = "Address";
            this.ticketAddress.Name = "ticketAddress";
            this.ticketAddress.ReadOnly = true;
            // 
            // ticketAge
            // 
            this.ticketAge.HeaderText = "Age";
            this.ticketAge.Name = "ticketAge";
            this.ticketAge.ReadOnly = true;
            this.ticketAge.Width = 60;
            // 
            // ticketGroup
            // 
            this.ticketGroup.HeaderText = "Group";
            this.ticketGroup.Name = "ticketGroup";
            this.ticketGroup.ReadOnly = true;
            this.ticketGroup.Width = 60;
            // 
            // ticketInTime
            // 
            this.ticketInTime.HeaderText = "InTime";
            this.ticketInTime.Name = "ticketInTime";
            this.ticketInTime.ReadOnly = true;
            this.ticketInTime.Width = 60;
            // 
            // ticketOutTime
            // 
            this.ticketOutTime.HeaderText = "OutTime";
            this.ticketOutTime.Name = "ticketOutTime";
            this.ticketOutTime.ReadOnly = true;
            this.ticketOutTime.Width = 60;
            // 
            // ticketPrice
            // 
            this.ticketPrice.HeaderText = "Price";
            this.ticketPrice.Name = "ticketPrice";
            this.ticketPrice.ReadOnly = true;
            this.ticketPrice.Width = 60;
            // 
            // txtBoxOutTime
            // 
            this.txtBoxOutTime.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBoxOutTime.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxOutTime.Location = new System.Drawing.Point(448, 58);
            this.txtBoxOutTime.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxOutTime.Name = "txtBoxOutTime";
            this.txtBoxOutTime.ReadOnly = true;
            this.txtBoxOutTime.Size = new System.Drawing.Size(220, 24);
            this.txtBoxOutTime.TabIndex = 7;
            // 
            // txtBoxInTime
            // 
            this.txtBoxInTime.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBoxInTime.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxInTime.Location = new System.Drawing.Point(448, 21);
            this.txtBoxInTime.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxInTime.Name = "txtBoxInTime";
            this.txtBoxInTime.ReadOnly = true;
            this.txtBoxInTime.Size = new System.Drawing.Size(220, 24);
            this.txtBoxInTime.TabIndex = 6;
            // 
            // txtBoxPrice
            // 
            this.txtBoxPrice.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBoxPrice.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPrice.Location = new System.Drawing.Point(448, 99);
            this.txtBoxPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxPrice.Name = "txtBoxPrice";
            this.txtBoxPrice.ReadOnly = true;
            this.txtBoxPrice.Size = new System.Drawing.Size(220, 24);
            this.txtBoxPrice.TabIndex = 8;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Modern No. 20", 16.2F);
            this.labelPrice.Location = new System.Drawing.Point(354, 97);
            this.labelPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(58, 24);
            this.labelPrice.TabIndex = 19;
            this.labelPrice.Text = "Price";
            // 
            // labelOutTime
            // 
            this.labelOutTime.AutoSize = true;
            this.labelOutTime.Font = new System.Drawing.Font("Modern No. 20", 16.2F);
            this.labelOutTime.Location = new System.Drawing.Point(354, 58);
            this.labelOutTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOutTime.Name = "labelOutTime";
            this.labelOutTime.Size = new System.Drawing.Size(93, 24);
            this.labelOutTime.TabIndex = 13;
            this.labelOutTime.Text = "Out Time";
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Font = new System.Drawing.Font("Modern No. 20", 16.2F);
            this.labelGroup.Location = new System.Drawing.Point(354, 141);
            this.labelGroup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(66, 24);
            this.labelGroup.TabIndex = 9;
            this.labelGroup.Text = "Group";
            // 
            // labelInTime
            // 
            this.labelInTime.AutoSize = true;
            this.labelInTime.Font = new System.Drawing.Font("Modern No. 20", 16.2F);
            this.labelInTime.Location = new System.Drawing.Point(354, 19);
            this.labelInTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInTime.Name = "labelInTime";
            this.labelInTime.Size = new System.Drawing.Size(82, 24);
            this.labelInTime.TabIndex = 11;
            this.labelInTime.Text = "In Time";
            // 
            // cmboBoxAge
            // 
            this.cmboBoxAge.AutoCompleteCustomSource.AddRange(new string[] {
            "0-5",
            "5-20"});
            this.cmboBoxAge.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cmboBoxAge.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboBoxAge.FormattingEnabled = true;
            this.cmboBoxAge.Items.AddRange(new object[] {
            "5-12",
            "12-18",
            "18-60",
            "Above>60"});
            this.cmboBoxAge.Location = new System.Drawing.Point(94, 98);
            this.cmboBoxAge.Margin = new System.Windows.Forms.Padding(2);
            this.cmboBoxAge.Name = "cmboBoxAge";
            this.cmboBoxAge.Size = new System.Drawing.Size(220, 25);
            this.cmboBoxAge.TabIndex = 2;
            this.cmboBoxAge.Text = "Select age...";
            // 
            // txtBoxAddress
            // 
            this.txtBoxAddress.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBoxAddress.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxAddress.Location = new System.Drawing.Point(94, 139);
            this.txtBoxAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxAddress.Name = "txtBoxAddress";
            this.txtBoxAddress.Size = new System.Drawing.Size(220, 24);
            this.txtBoxAddress.TabIndex = 1;
            this.txtBoxAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxAddress_KeyPress);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Modern No. 20", 16.2F);
            this.labelAddress.Location = new System.Drawing.Point(1, 139);
            this.labelAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(81, 24);
            this.labelAddress.TabIndex = 6;
            this.labelAddress.Text = "Address";
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Font = new System.Drawing.Font("Modern No. 20", 16.2F);
            this.labelAge.Location = new System.Drawing.Point(2, 96);
            this.labelAge.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(44, 24);
            this.labelAge.TabIndex = 4;
            this.labelAge.Text = "Age";
            // 
            // txtBoxPhone
            // 
            this.txtBoxPhone.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBoxPhone.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPhone.Location = new System.Drawing.Point(94, 59);
            this.txtBoxPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxPhone.MaxLength = 10;
            this.txtBoxPhone.Name = "txtBoxPhone";
            this.txtBoxPhone.ShortcutsEnabled = false;
            this.txtBoxPhone.Size = new System.Drawing.Size(220, 24);
            this.txtBoxPhone.TabIndex = 3;
            this.txtBoxPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxPhone_KeyPress);
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Modern No. 20", 16.2F);
            this.labelPhone.Location = new System.Drawing.Point(2, 59);
            this.labelPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(67, 24);
            this.labelPhone.TabIndex = 2;
            this.labelPhone.Text = "Phone";
            // 
            // txtBoxName
            // 
            this.txtBoxName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBoxName.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxName.Location = new System.Drawing.Point(94, 19);
            this.txtBoxName.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(220, 24);
            this.txtBoxName.TabIndex = 4;
            this.txtBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxName_KeyPress);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Modern No. 20", 16.2F);
            this.labelName.Location = new System.Drawing.Point(2, 19);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(61, 24);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // labelTicketNo
            // 
            this.labelTicketNo.AutoSize = true;
            this.labelTicketNo.Font = new System.Drawing.Font("Modern No. 20", 16.2F);
            this.labelTicketNo.Location = new System.Drawing.Point(16, 59);
            this.labelTicketNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTicketNo.Name = "labelTicketNo";
            this.labelTicketNo.Size = new System.Drawing.Size(97, 24);
            this.labelTicketNo.TabIndex = 3;
            this.labelTicketNo.Text = "Ticket No";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.ControlLightLight;
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Modern No. 20", 12F);
            this.dateTimePicker1.Location = new System.Drawing.Point(464, 59);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(229, 25);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.Value = new System.DateTime(2021, 12, 20, 15, 16, 0, 0);
            // 
            // txtBoxTicketNo
            // 
            this.txtBoxTicketNo.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxTicketNo.Location = new System.Drawing.Point(109, 59);
            this.txtBoxTicketNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxTicketNo.MaxLength = 4;
            this.txtBoxTicketNo.Name = "txtBoxTicketNo";
            this.txtBoxTicketNo.ShortcutsEnabled = false;
            this.txtBoxTicketNo.Size = new System.Drawing.Size(145, 25);
            this.txtBoxTicketNo.TabIndex = 15;
            this.txtBoxTicketNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxTicketNo_KeyPress);
            // 
            // btnSearchTicket
            // 
            this.btnSearchTicket.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSearchTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchTicket.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchTicket.ForeColor = System.Drawing.Color.White;
            this.btnSearchTicket.Location = new System.Drawing.Point(258, 59);
            this.btnSearchTicket.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchTicket.Name = "btnSearchTicket";
            this.btnSearchTicket.Size = new System.Drawing.Size(71, 25);
            this.btnSearchTicket.TabIndex = 16;
            this.btnSearchTicket.Text = "Search";
            this.btnSearchTicket.UseVisualStyleBackColor = false;
            this.btnSearchTicket.Click += new System.EventHandler(this.btnSearchTicket_Click);
            // 
            // TicketPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.Controls.Add(this.btnSearchTicket);
            this.Controls.Add(this.txtBoxTicketNo);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.labelTicketNo);
            this.Controls.Add(this.panelTicketForm);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TicketPanel";
            this.Size = new System.Drawing.Size(706, 483);
            this.panelTicketForm.ResumeLayout(false);
            this.panelTicketForm.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ticketTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelTicketForm;
        private System.Windows.Forms.TextBox txtBoxAddress;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.TextBox txtBoxPhone;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelTicketNo;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelOutTime;
        private System.Windows.Forms.Label labelInTime;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.TextBox txtBoxTicketNo;
        private System.Windows.Forms.Button btnSearchTicket;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtBoxPrice;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox txtBoxOutTime;
        private System.Windows.Forms.TextBox txtBoxInTime;
        private System.Windows.Forms.DataGridView ticketTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketInTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketOutTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketPrice;
        private System.Windows.Forms.ComboBox cmboBoxAge;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.RadioButton notGroupRadioBtn;
        private System.Windows.Forms.RadioButton isGroupRadioBtn;
        private System.Windows.Forms.TextBox txtBoxGrandTotal;
        private System.Windows.Forms.TextBox txtBoxDiscount;
        private System.Windows.Forms.TextBox txtBoxTotalPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
    }
}
