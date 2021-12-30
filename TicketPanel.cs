using System;
using System.IO;
using System.Data;
using System.Linq;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Recreation_center
{
    public partial class TicketPanel : UserControl
    {
        private List<Ticket> groupTicketList = new List<Ticket>();
        private List<Ticket> searchedTicketList = new List<Ticket>();
        public TicketPanel()
        {
            InitializeComponent();
            
            resetFields(""); // clear text field
            dateTimePicker1.Value = DateTime.Now;
            Globals.readFileG("ticket", Constants.TICKETFILENAME); // reading tickets file
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (btnSave.Text.ToString() == "Save")
             {
                 if (groupTicketList.Count <= 0)
                 {
                     if (isUserInputValid())
                     {
                         saveTicket();
                     }
                 }
                 else {
                     saveTicket();
                 }

             }
             else
             {
                 if (Globals.weekDayPriceListG.Count > 0 && Globals.weekEndPriceListG.Count > 0)
                 {
                     checkoutTicket();
                 }
                 else 
                 {
                     MessageBox.Show("Price is not set by admin!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }

             }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isUserInputValid())
            {
                addGroupTicket();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetFields("clear"); // clear textfield
            makeUserInputsReadOnly(false);
            groupTicketList.Clear();
            searchedTicketList.Clear();
            txtBoxTicketNo.ResetText();

        }

        private void btnSearchTicket_Click(object sender, EventArgs e)
        {
            resetFields("clear");
            searchTicket();
        }

        private void saveTicket()
        {
            int savedTicketNumber = 0;

            if (groupTicketList.Count > 0)  // if save for group ticket
            {
                savedTicketNumber = groupTicketList[0].ticketID;
                Globals.myTicket.AddRange(groupTicketList);
                groupTicketList.Clear();
            }
            else
            {
                Ticket newTicket = generateNewTicket();
                savedTicketNumber = newTicket.ticketID;

                Globals.myTicket.Add(newTicket);
            }

            Globals.writeToTextFile(Constants.TICKETFILENAME, JsonConvert.SerializeObject(Globals.myTicket));
            MessageBox.Show("Ticket: " + savedTicketNumber + " Saved !! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            resetFields("save");
            ticketTable.Rows.Clear();
        }

        private void addGroupTicket() {

            Ticket newTicket = generateNewTicket();
            groupTicketList.Add(newTicket);
            fillTicketTable(newTicket);

            resetFields("add");
            // allow user to add save group ticket only if group have more then 1 member
            if (groupTicketList.Count > 1)
            {
                btnSave.Enabled = true;
            }
            else 
            {
                btnSave.Enabled = false;
                isGroupRadioBtn.Enabled = false;
                notGroupRadioBtn.Enabled = false;
            }

            MessageBox.Show("Ticket: " + newTicket.ticketID + " Added !! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Ticket generateNewTicket() {
            txtBoxInTime.Text = DateTime.Now.ToShortTimeString();

            Ticket ticket = new Ticket();
            ticket.ticketID = generatedTicketId();
            ticket.name = txtBoxName.Text;
            ticket.phone = txtBoxPhone.Text;
            ticket.inTime = txtBoxInTime.Text;
            ticket.address = txtBoxAddress.Text;
            ticket.date = dateTimePicker1.Value;
            ticket.age = cmboBoxAge.SelectedIndex;
            ticket.isGroup = isGroupRadioBtn.Checked;

            return ticket;
        }

        private int generatedTicketId()
        {
            int ticketId = 0;
            if (Globals.myTicket.Count <= 0) // if no ticket avaiable
            {
                ticketId += 1;
            }
            else if (Globals.myTicket.Count != 0 && groupTicketList.Count <= 0) // not in group
            {
                ticketId = Globals.myTicket[Globals.myTicket.Count - 1].ticketID + 1;
            }
            else { // if in group
                ticketId = groupTicketList[0].ticketID;
            }

            return ticketId;
        }

        private void searchTicket() {
            ticketTable.Rows.Clear();
            searchedTicketList.Clear();
            makeUserInputsReadOnly(false);

            bool isSearchedTicketCheckedOut = false;
            Regex ticketNumberRegex = new Regex(@"^[0-9]*$");
            
            //search ticket
            if (txtBoxTicketNo.Text.ToString() != "")
            {
                //if ticket exist in file and in ticket list && user input ticket number > 0
                if (Globals.myTicket.Count > 0 && ticketNumberRegex.IsMatch(txtBoxTicketNo.Text.ToString()))
                {
                    int ticketNumber = int.Parse(txtBoxTicketNo.Text);
                    
                    if (Globals.myTicket[Globals.myTicket.Count - 1].ticketID >= ticketNumber)
                    {   
                        //search ticket
                        foreach (Ticket ticket in Globals.myTicket) 
                        {
                            if (ticket.ticketID == ticketNumber)
                            {
                                searchedTicketList.Add(ticket);
                                fillTicketTable(ticket);

                                btnSave.Text = "Check out";
                                makeUserInputsReadOnly(true);

                                // if outTime exist donot allow to checkout
                                isSearchedTicketCheckedOut = (ticket.outTime != null)
                                                                    ? true
                                                                    : false;
                            }
                            
                        }

                        calculateCheckedOutTicketPrice(isSearchedTicketCheckedOut);
                    }
                    else 
                    {
                        MessageBox.Show("No ticket found !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
 
                }
                else
                {
                    MessageBox.Show("No ticket found !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
            else 
            {
                MessageBox.Show("Please enter ticket Number !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
               
        private void fillTicketTable(Ticket ticket)
        {
            string[] ageGroupList = {
                "5-12",
                "12-18",
                "18-60",
                "Above 60",
            };

            ticketTable.Rows.Add(
                    ticket.ticketID, ticket.date.ToString("ddd, dd MMMM yyyy"),
                    ticket.name, ticket.phone, ticket.address, ageGroupList[ticket.age], ticket.isGroup, ticket.inTime, ticket.outTime, ticket.price
                );

        }

        private void calculateCheckedOutTicketPrice( bool isSearchedTicketCheckedOut) {

            if (isSearchedTicketCheckedOut)
            {
                btnSave.Enabled = false;
                float totalPrice = 0;
                btnSave.Enabled = false;
                searchedTicketList.ForEach(x =>
                {
                    totalPrice += x.price;
                });

                txtBoxTotalPrice.Text = totalPrice.ToString();
                txtBoxDiscount.Text = searchedTicketList[0].discountedPercent.ToString();
                txtBoxGrandTotal.Text = (totalPrice - (totalPrice * (searchedTicketList[0].discountedPercent / 100))).ToString();
            }

        }

        private void checkoutTicket()
        {
            float totalPrice = 0;
            float[] ticketPriceAndDiscount = null; 
            foreach (Ticket ticket in searchedTicketList) {
                // calculating total hrs stayed
                DateTime inTime = Convert.ToDateTime(ticket.inTime);
                DateTime outTime = DateTime.Now;

                int totalHrsCustomerStay = (int)(outTime - inTime).TotalHours + 1;

                int hourStayed = (totalHrsCustomerStay > 4 || totalHrsCustomerStay < 0 || ticket.date.Date.ToShortDateString() != DateTime.Now.Date.ToShortDateString())
                                    ? 4
                                    : totalHrsCustomerStay;
                // ticket price and discount
                ticketPriceAndDiscount = findIndividualTicketPrice(hourStayed, ticket.date, ticket.age, ticket.isGroup);

                totalPrice += ticketPriceAndDiscount[0];

                ticket.price = ticketPriceAndDiscount[0];
                ticket.outTime = outTime.ToShortTimeString();
                ticket.discountedPercent = ticketPriceAndDiscount[1];
            }

            txtBoxTotalPrice.Text = totalPrice.ToString();
            txtBoxDiscount.Text = ticketPriceAndDiscount[1].ToString();
            txtBoxGrandTotal.Text = (totalPrice - (totalPrice*(ticketPriceAndDiscount[1] /100))).ToString();

            //update file after checked out
            Globals.writeToTextFile(Constants.TICKETFILENAME, JsonConvert.SerializeObject(Globals.myTicket));

            btnSave.Enabled = false;
            ticketTable.Rows.Clear();

            // update table with updated data
            searchedTicketList.ForEach(ticket => {
                fillTicketTable(ticket);
            });

            MessageBox.Show("Ticket checked out !!!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void resetFields(string resetFor)
        {
            txtBoxName.ResetText();
            txtBoxPhone.ResetText();
            cmboBoxAge.SelectedIndex = -1;
            cmboBoxAge.Text = "Select age....";
            txtBoxTotalPrice.ResetText();
            txtBoxDiscount.ResetText();
            txtBoxAddress.ResetText();
            txtBoxGrandTotal.ResetText();
            txtBoxPrice.ResetText();
            txtBoxInTime.Text = DateTime.Now.ToShortTimeString();
            if (resetFor == "clear") {
                btnSave.Text = "Save";
                btnSave.Enabled = true;
            }

            if (resetFor == "save" || resetFor == "clear")
            {
                txtBoxOutTime.ResetText();
                ticketTable.Rows.Clear();
                isGroupRadioBtn.Enabled = true;
                notGroupRadioBtn.Enabled = true;
                isGroupRadioBtn.Checked = false;
                notGroupRadioBtn.Checked = true;
            }
            else if (resetFor == "add" ) {
                isGroupRadioBtn.Enabled = false;
                notGroupRadioBtn.Enabled = false;
            }
        }

        private float[] findIndividualTicketPrice(int hourStayed, DateTime ticketDate, int ticketAge, bool isGroup)
        {
            List<Dictionary<string, float>> prices;
            string[] agePrefix = { "Child", "Teen", "Adult", "Old" };
            string[] timePrefix = { "hour", "twoHour", "threeHour", "fourHour", "wholeDay" };

            prices = (isWeekDay(ticketDate))
                            ? Globals.weekDayPriceListG
                            : Globals.weekEndPriceListG;

            float ticketprice = prices[0][timePrefix[hourStayed] + agePrefix[ticketAge]];
            float discount = (isGroup) 
                                ? prices[1][timePrefix[hourStayed] + "Discount"] 
                                : 0;

            float[] totalPriceDiscountPercent = { ticketprice, discount };

            return totalPriceDiscountPercent;
        }

        private bool isWeekDay(DateTime ticketDate)
        {
            string todaysDay = ticketDate.ToString("ddd");

            return (todaysDay != "Sun" && todaysDay != "Sat");
        }

        private bool isUserInputValid()
        {
            string[] notValidatingList = {
                "txtBoxPrice",
                "txtBoxInTime", 
                "txtBoxOutTime",
            };

            foreach (Control control in panelTicketForm.Controls)
            {
                if (control is TextBox)
                {
                    if (!notValidatingList.Contains(control.Name))
                    {
                        if (string.IsNullOrEmpty(control.Text))
                        {
                            control.BackColor = System.Drawing.Color.LightPink;
                            MessageBox.Show(control.Name.Substring(6) + " is Empty.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return false;
                        }
                        else
                        {
                            Regex phoneRegex = new Regex(@"^[9][0-9]{9}$");
                            if (control.Name == "txtBoxPhone" && !phoneRegex.IsMatch(control.Text.ToString())) 
                            {
                                control.BackColor = System.Drawing.Color.LightPink;
                                MessageBox.Show("Invalid Phone number !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return false;
                            }
                            else if (control.Name != "txtBoxPhone" && !control.Text.ToString().All(i => char.IsLetter(i) || char.IsWhiteSpace(i))) 
                            {
                                control.BackColor = System.Drawing.Color.LightPink;
                                MessageBox.Show("Invalid " + control.Name.Substring(6) + " !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return false;
                            }
                        }

                    }

                }
            }

            // comboBox validation
            if (cmboBoxAge.SelectedIndex <= -1)
            {
                cmboBoxAge.BackColor = System.Drawing.Color.LightPink;
                MessageBox.Show("Age or Group should be selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
              
            return true;
        }

        private void makeUserInputsReadOnly(bool trueOrFalse) 
        {
            txtBoxName.ReadOnly = trueOrFalse;
            txtBoxPhone.ReadOnly = trueOrFalse;
            txtBoxAddress.ReadOnly = trueOrFalse;
            cmboBoxAge.Enabled = !trueOrFalse;
            dateTimePicker1.Enabled = !trueOrFalse;
            isGroupRadioBtn.Enabled = !trueOrFalse;
            notGroupRadioBtn.Enabled = !trueOrFalse;
        }

        private void ticketTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TextBox[] texBoxList = { txtBoxName, txtBoxPhone, txtBoxAddress, txtBoxInTime, txtBoxOutTime, txtBoxPrice };
            string[] tblColumnNameList = { "CustomerName", "Phone", "ticketAddress", "ticketIntime", "ticketOutTime", "ticketPrice" };

            if (e.RowIndex >= 0)
            {
                int count = 0;
                DataGridViewRow row = this.ticketTable.Rows[e.RowIndex];

                foreach (TextBox textBox in texBoxList)
                {
                    textBox.Text = (row.Cells[tblColumnNameList[count]].Value != null)
                                        ? row.Cells[tblColumnNameList[count]].Value.ToString()
                                        : "";
                    count++;
                }

                cmboBoxAge.SelectedItem = row.Cells["ticketAge"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["ticketDate"].Value);
            }
        }

        private void txtBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtBoxPhone.BackColor = System.Drawing.Color.White;
        }

        private void txtBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtBoxName.BackColor = System.Drawing.Color.White;
        }

        private void txtBoxAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtBoxAddress.BackColor = System.Drawing.Color.White;
        }

        private void txtBoxTicketNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtBoxTicketNo.BackColor = System.Drawing.Color.White;
        }

        private void isGroupRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
        }

        private void notGroupRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
        }

    }

}

//System.Diagnostics.Debug.WriteLine("Local " + JsonConvert.SerializeObject(groupTicketList));