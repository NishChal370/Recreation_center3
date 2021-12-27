using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data;

namespace Recreation_center
{
    public partial class TicketPanel : UserControl
    {
        private List<Ticket> groupTicketList = new List<Ticket>();
        public TicketPanel()
        {
            InitializeComponent();
            resetFields("save"); // clear text field
            readTicketFile(); // reading tickets file
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text.ToString() == "Save")
            {
                if (isUserInputValid())
                {
                    saveTicket();
                }
            }
            else
            {
                if (Globals.weekDayPriceListG.Count > 0 && Globals.weekEndPriceListG.Count > 0)
                {
                    updateTicket();
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
                addTicket();
            }
        }

        private void addTicket() {

            Ticket newTicket = generateNewTicket();

            groupTicketList.Add(newTicket);
            fillTicketTable(newTicket);

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

            resetFields("add");
            MessageBox.Show("Ticket: " + generateNewTicket().ticketID + " Added !! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveTicket()
        {
            int savedTicketNumber;

            if (groupTicketList.Count > 0)  // if save for group ticket
            {
                savedTicketNumber = groupTicketList[0].ticketID;
                Globals.myTicket.AddRange(groupTicketList);

                resetFields("save");
                groupTicketList.Clear();
                ticketTable.Rows.Clear();
            }
            else {
                Ticket newTicket = generateNewTicket();
                savedTicketNumber = newTicket.ticketID;
                Globals.myTicket.Add(newTicket);
                resetFields("save");
            }

            Globals.writeToTextFile(Constants.TICKETFILENAME, JsonConvert.SerializeObject(Globals.myTicket));
            MessageBox.Show("Ticket: " + savedTicketNumber + " Saved !! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
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


        private void btnClear_Click(object sender, EventArgs e)
        {
            resetFields("add"); // clear textfield
        }

        private void btnSearchTicket_Click(object sender, EventArgs e)
        {
            searchTicket();
        }

        // change Table according to Calendar
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //fillTicketTable();
        }

        private void searchTicket() {
            Regex ticketNumberRegex = new Regex(@"^[0-9]*$");

            //search ticket // this changed
            if (txtBoxTicketNo.Text.ToString() != "")
            {
                //if ticket exist in file and in ticket list && user input ticket number > 0
                if (Globals.myTicket.Count > 0 && ticketNumberRegex.IsMatch(txtBoxTicketNo.Text.ToString()))
                {   
                    try
                    {
                        //clearing price & outTime txtField
                        txtBoxPrice.ResetText();
                        txtBoxOutTime.ResetText();

                        // not allow user to edit the saved ticket when searching for ticket
                        makeUserInputsReadOnly(true);

                        btnSave.Text = "Check out";
                        int ticketNumber = int.Parse(txtBoxTicketNo.Text) - 1;
                        autoFillTextBox(ticketNumber);
                    }
                    catch
                    {
                        MessageBox.Show("No ticket found !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No ticket found !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else { MessageBox.Show("Please enter ticket Number !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }*/
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

        private void updateTicket()
        {
            // this changed
            /*btnSave.Enabled = false;
            int ticketNumber = int.Parse(txtBoxTicketNo.Text) - 1;
            //update out time
            txtBoxOutTime.Text = DateTime.Now.ToShortTimeString();
            Globals.myTicket[ticketNumber].outTime = txtBoxOutTime.Text;

            //update price
            DateTime inTime = Convert.ToDateTime(Globals.myTicket[ticketNumber].inTime);
            DateTime outTime = Convert.ToDateTime(Globals.myTicket[ticketNumber].outTime);

            int totalHrsCustomerStay = (int)(outTime - inTime).TotalHours;

            txtBoxPrice.Text = calculateTicketPrice(totalHrsCustomerStay).ToString();
            Globals.myTicket[ticketNumber].price = calculateTicketPrice(totalHrsCustomerStay);

            Globals.writeToTextFile(Constants.TICKETFILENAME, JsonConvert.SerializeObject(Globals.myTicket));
            MessageBox.Show("Ticket: " + (ticketNumber + 1) + " Checked out !!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
        }

        private void autoFillTextBox(int ticketNumber)
        {
            // this changed
           /* btnSave.Enabled = true;
            txtBoxName.Text = Globals.myTicket[ticketNumber].name;
            txtBoxAddress.Text = Globals.myTicket[ticketNumber].address;
            dateTimePicker1.Value = Globals.myTicket[ticketNumber].date;
            cmboBoxAge.SelectedIndex = Globals.myTicket[ticketNumber].age;
            //-> cmboBoxGroup.SelectedIndex = Globals.myTicket[ticketNumber].group;
            txtBoxPhone.Text = Globals.myTicket[ticketNumber].phone.ToString();
            txtBoxPrice.Text = Globals.myTicket[ticketNumber].price.ToString();
            txtBoxInTime.Text = Globals.myTicket[ticketNumber].inTime.ToString();

            if (Globals.myTicket[ticketNumber].outTime != null)
            {
                btnSave.Enabled = false;
                txtBoxPrice.Text = Globals.myTicket[ticketNumber].price.ToString();
                txtBoxOutTime.Text = Globals.myTicket[ticketNumber].outTime.ToString();
            }*/
        }

        
        private void resetFields(string resetTo)
        {
            txtBoxTicketNo.ResetText();
            txtBoxName.ResetText();
            txtBoxPhone.ResetText();
            txtBoxPrice.ResetText();
            txtBoxOutTime.Text = "";
            txtBoxOutTime.ResetText();
            txtBoxInTime.ResetText();
            txtBoxAddress.ResetText();
            dateTimePicker1.ResetText();
            cmboBoxAge.SelectedIndex = -1;
            cmboBoxAge.Text = "Select age....";
            txtBoxInTime.Text = DateTime.Now.ToShortTimeString();

            if (resetTo == "save") {
                btnSave.Text = "Save";
                btnSave.Enabled = true;
                isGroupRadioBtn.Enabled = true;
                notGroupRadioBtn.Enabled = true;
                notGroupRadioBtn.Checked = true;
            }
            

        }

        private float calculateTicketPrice(int totalHourStayed)
        {
            float calculatedPrice = 0;
            //this changed
            /*Dictionary<string, float> prices;
            string[] agePrefix = { "ChildTextBox", "AdultTextBox", "SeniorTextBox" };
            string[] timePrefix = {"hour", "twoHour", "threeHour", "fourHour", "wholeDay" };
            string[] groupPrefix = { "FiveGrupTextBox", "TenGrupTextBox", "FifteenGrupTextBox", "AboveGrupTextBox" };

            int hourStayed = (totalHourStayed > 4 || totalHourStayed < 0)
                                    ? 4
                                    : totalHourStayed;

            if (cmboBoxAge.SelectedIndex != -1) //if age is selected
            {
                prices = (isWeekDay()) 
                            ? Globals.weekDayPriceListG[0] 
                            : Globals.weekEndPriceListG[0];

                calculatedPrice = prices[timePrefix[hourStayed] + agePrefix[cmboBoxAge.SelectedIndex]];
            }
            else if (cmboBoxGroup.SelectedIndex != -1)// if group is selected
            {
                prices = (isWeekDay()) 
                            ? Globals.weekDayPriceListG[1] 
                            : Globals.weekEndPriceListG[1];
                                        // FORMAT :  hourChildTextBox
                calculatedPrice = prices[timePrefix[hourStayed] + groupPrefix[cmboBoxGroup.SelectedIndex]];
            }*/

            return calculatedPrice;
        }

        private void readTicketFile()
        {
            // this changed
           string fileName = Constants.TICKETFILENAME;
            if (File.Exists(fileName))
            {
                using (StreamReader r = File.OpenText(fileName))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        Globals.myTicket = JsonConvert.DeserializeObject<List<Ticket>>(line);
                    }
                }
            }
        }

        private bool isWeekDay()
        {
            string todaysDay = dateTimePicker1.Value.ToString("ddd");

            return (todaysDay != "Sun" && todaysDay != "Sat");
        }

        

        private bool isUserInputValid()
        {
            string[] notValidatingList = {
                "txtBoxPrice",
                "txtBoxInTime", 
                "txtBoxOutTime"    
            };
            // this changed
          /*  foreach (Control control in panelTicketForm.Controls)
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
                            Regex phoneRegex = new Regex(@"^[0-9]{10}$");
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
            if (cmboBoxAge.SelectedIndex <= -1 && cmboBoxGroup.SelectedIndex <= -1)
            {
                cmboBoxAge.BackColor = System.Drawing.Color.LightPink;
                cmboBoxGroup.BackColor = System.Drawing.Color.LightPink;
                MessageBox.Show("Age or Group should be selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            */
            return true;
        }

        private void makeUserInputsReadOnly(bool trueOrFalse) 
        {
            //this changed
            /*txtBoxName.ReadOnly = trueOrFalse;
            txtBoxPhone.ReadOnly = trueOrFalse;
            txtBoxAddress.ReadOnly = trueOrFalse;
            cmboBoxAge.Enabled = !trueOrFalse;
            //-> cmboBoxGroup.Enabled = !trueOrFalse;
            dateTimePicker1.Enabled = !trueOrFalse;*/
        }

        private void cmboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this change
            /*if (cmboBoxGroup.SelectedIndex > -1) //if group selected
            {
                cmboBoxAge.SelectedIndex = -1;
                cmboBoxAge.Text = "Select age....";
                cmboBoxAge.BackColor = System.Drawing.Color.White;
                cmboBoxGroup.BackColor = System.Drawing.Color.White;
            }*/

        }

        private void cmboBoxAge_SelectedIndexChanged(object sender, EventArgs e)
        {
            // this change
            /*if (cmboBoxAge.SelectedIndex > -1) //if age selected
            {
                cmboBoxGroup.SelectedIndex = -1;
                cmboBoxGroup.Text = "Select group....";
                cmboBoxAge.BackColor = System.Drawing.Color.White;
                cmboBoxGroup.BackColor = System.Drawing.Color.White;
            }*/

        }

        private void txtBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //txtBoxPhone.BackColor = System.Drawing.Color.White;
        }

        private void txtBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //txtBoxName.BackColor = System.Drawing.Color.White;
        }

        private void txtBoxAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            //txtBoxAddress.BackColor = System.Drawing.Color.White;
        }

        private void txtBoxTicketNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //txtBoxTicketNo.BackColor = System.Drawing.Color.White;
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



/*//@data: ticket global JSON List
        private void WriteTicketToText(string data)
        {
            string fileName = Constants.TICKETFILENAME;
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }

            StreamWriter outputFile = new StreamWriter(fileName);
            outputFile.WriteLine(data);
            outputFile.Close();
        }
*/

//txtBoxTicketNo.BackColor = System.Drawing.Color.White;





/*            /*if (Globals.myTicket.Count <= 0)
            {
                ticketId += 1;
            }
            else if (isGroupRadioBtn.Checked && Globals.myTicket[Globals.myTicket.Count - 1].isGroup)
            {

                ticketId = Globals.myTicket[Globals.myTicket.Count - 1].ticketID;
            }
            else
           {
                ticketTable.Rows.Clear();
                ticketId = Globals.myTicket[Globals.myTicket.Count - 1].ticketID + 1;
           }*/

//System.Diagnostics.Debug.WriteLine("TicketsLocal " + JsonConvert.SerializeObject(tempTicketList));



//Globals.writeToTextFile(Constants.TICKETFILENAME, JsonConvert.SerializeObject(Globals.myTicket));
//MessageBox.Show("Ticket: " + generateNewTicket().ticketID + " Saved !! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
/*if (tempTicketList.Count <= 0) {
    addTicket(false);
}

System.Diagnostics.Debug.WriteLine("TicketsGlobal " + JsonConvert.SerializeObject(Globals.myTicket));
System.Diagnostics.Debug.WriteLine("Size " + JsonConvert.SerializeObject(Globals.myTicket.Count));
Globals.myTicket.AddRange(tempTicketList);
tempTicketList.Clear();
System.Diagnostics.Debug.WriteLine("Size " + JsonConvert.SerializeObject(Globals.myTicket.Count));
System.Diagnostics.Debug.WriteLine("TicketsGlobal " + JsonConvert.SerializeObject(Globals.myTicket));*/
//this changed
//try
// {
/*txtBoxInTime.Text = DateTime.Now.ToShortTimeString();

Ticket newTicket = new Ticket();
newTicket.ticketID = generatedTicketId();
newTicket.name = txtBoxName.Text;
newTicket.phone = txtBoxPhone.Text;
newTicket.inTime = txtBoxInTime.Text;
newTicket.address = txtBoxAddress.Text;
newTicket.date = dateTimePicker1.Value;
newTicket.age = cmboBoxAge.SelectedIndex;
newTicket.isGroup = isGroupRadioBtn.Checked;*/

//Globals.myTicket.Add(newTicket);
//fillTicketTable(newTicket);
//Globals.writeToTextFile(Constants.TICKETFILENAME, JsonConvert.SerializeObject(Globals.myTicket));
//MessageBox.Show("Ticket: " + newTicket.ticketID + "Saved !! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
/*}
catch
{JsonConvert.SerializeObject(weekPriceList)
    MessageBox.Show("TextField is Invalid!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
}*/

/*foreach (DataGridViewRow item in ticketTable.Rows) {
    System.Diagnostics.Debug.WriteLine("Table row "+ JsonConvert.SerializeObject(item.Cells[2].Value));
}*/


//private void fillTicketTable()
//{
/*string[] ageGroupList = {
    "5-12",
    "12-18",
    "18-60",
    "Above 60",
};*/

/*string[] groupList = {
    "2-5",
    "5-10",
    "10-15",
    "Above 15"
};*/

// this changed
/*ticketTable.Rows.Clear();
foreach (Ticket ticket in Globals.myTicket)
{   // if user selected date and ticket date matches
    if (dateTimePicker1.Value.Date == ticket.date.Date) {

        string outTime = (ticket.outTime != null) 
                            ? ticket.outTime 
                            : "NaN";

        string age = (ticket.age != -1) 
                        ? ageGroupList[ticket.age] 
                        : "NaN";

        string group = (ticket.group != -1) 
                            ? groupList[ticket.group] 
                            : "NaN";

        ticketTable.Rows.Add(
            ticket.ticketID, ticket.date.ToString("ddd, dd MMMM yyyy"), 
            ticket.name, ticket.phone, ticket.address, age, group, ticket.inTime, outTime, ticket.price
        );
    }

}*/
//}


/*
             System.Diagnostics.Debug.WriteLine("-************************************************************* ");
            System.Diagnostics.Debug.WriteLine("Local " + JsonConvert.SerializeObject(groupTicketList));
            System.Diagnostics.Debug.WriteLine("Size " + JsonConvert.SerializeObject(groupTicketList.Count));
            System.Diagnostics.Debug.WriteLine("TicketsGlobal " + JsonConvert.SerializeObject(Globals.myTicket));
            System.Diagnostics.Debug.WriteLine("Size " + JsonConvert.SerializeObject(Globals.myTicket.Count));
            //Globals.writeToTextFile(Constants.TICKETFILENAME, JsonConvert.SerializeObject(Globals.myTicket));*/


/*
 
            System.Diagnostics.Debug.WriteLine("-***********************FROM  SAVE************************************** ");
            System.Diagnostics.Debug.WriteLine("Local " + JsonConvert.SerializeObject(groupTicketList));
            System.Diagnostics.Debug.WriteLine("Size " + JsonConvert.SerializeObject(groupTicketList.Count));
            System.Diagnostics.Debug.WriteLine("TicketsGlobal " + JsonConvert.SerializeObject(Globals.myTicket));
            System.Diagnostics.Debug.WriteLine("Size " + JsonConvert.SerializeObject(Globals.myTicket.Count));
 */