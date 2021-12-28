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
        private List<Ticket> searchedTicketList = new List<Ticket>();
        public TicketPanel()
        {
            InitializeComponent();

            resetFields(""); // clear text field
            readTicketFile(); // reading tickets file
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
                /*if (isUserInputValid())
                {
                    Ticket newTicket = generateNewTicket();
                    savedTicketNumber = newTicket.ticketID;

                    Globals.myTicket.Add(newTicket);
                }*/
                Ticket newTicket = generateNewTicket();
                savedTicketNumber = newTicket.ticketID;

                Globals.myTicket.Add(newTicket);
            }
            //if (savedTicketNumber != 0) { // if ticket is saved i.e. savedTicketNumbersavedTicketNumber savedTicketNumber > 0
                Globals.writeToTextFile(Constants.TICKETFILENAME, JsonConvert.SerializeObject(Globals.myTicket));
                MessageBox.Show("Ticket: " + savedTicketNumber + " Saved !! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            

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
                        
                        //calculating ticket price for checked out ticket
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

        private void checkoutTicket()
        {
            float totalPrice = 0;
            float[] ticketPriceAndDiscount = null; 
            foreach (Ticket ticket in searchedTicketList) {
                // calculating total hrs stayed
                DateTime inTime = Convert.ToDateTime(ticket.inTime);
                DateTime outTime = DateTime.Now;

                int totalHrsCustomerStay = (int)(outTime - inTime).TotalHours + 1;

                System.Diagnostics.Debug.WriteLine("time11 -> " + JsonConvert.SerializeObject(totalHrsCustomerStay));
                System.Diagnostics.Debug.WriteLine("date12 -> " + JsonConvert.SerializeObject(ticket.date.Date.ToShortDateString()));
                System.Diagnostics.Debug.WriteLine("date13 -> " + JsonConvert.SerializeObject(DateTime.Now.Date.ToShortDateString()));
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
            string[] timePrefix = { "hour", "twoHour", "threeHours", "fourHour", "wholeDay" };

            prices = (isWeekDay(ticketDate))
                            ? Globals.weekDayPriceListG
                            : Globals.weekEndPriceListG;
            MessageBox.Show(timePrefix[hourStayed] + agePrefix[ticketAge]);
            System.Diagnostics.Debug.WriteLine("time1 -> " + JsonConvert.SerializeObject(hourStayed));
            System.Diagnostics.Debug.WriteLine("age2 -> " + JsonConvert.SerializeObject(ticketAge));
            System.Diagnostics.Debug.WriteLine("pricetime3 -> " + JsonConvert.SerializeObject(timePrefix[hourStayed] + agePrefix[ticketAge]));
            System.Diagnostics.Debug.WriteLine("price4 -> " + JsonConvert.SerializeObject(prices[0]));
            float ticketprice = prices[0][timePrefix[hourStayed] + agePrefix[ticketAge]];
            float discount = (isGroup) 
                                ? prices[1][timePrefix[hourStayed] + "Discount"] 
                                : 0;

            float[] totalPriceDiscountPercent = { ticketprice, discount };

            return totalPriceDiscountPercent;
        }

        private void readTicketFile()
        {
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
                "txtBoxAddress",
            };

            // this changed
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


//auto filll

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

/*
private void cmboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
{
    //this change
   if (cmboBoxGroup.SelectedIndex > -1) //if group selected
    {
        cmboBoxAge.SelectedIndex = -1;
        cmboBoxAge.Text = "Select age....";
        cmboBoxAge.BackColor = System.Drawing.Color.White;
        cmboBoxGroup.BackColor = System.Drawing.Color.White;
    }

}*/



/**
 * 
 * private float[] calculateTicketPrice(int hourStayed, DateTime ticketDate, int ticketAge)
        {

            //float calculatedPrice = 0;
            //this changed
            List<Dictionary<string, float>> prices;
            string[] agePrefix = { "Child", "Teen", "Adult", "Senior" };
            string[] timePrefix = { "hour", "twoHour", "threeHour", "fourHour", "wholeDay" };

            prices = (isWeekDay(ticketDate))
                            ? Globals.weekDayPriceListG
                            : Globals.weekEndPriceListG;


            System.Diagnostics.Debug.WriteLine("FROM lsir:  " + timePrefix[hourStayed] + agePrefix[ticketAge]);
            float calculatedPrice = prices[0][timePrefix[hourStayed] + agePrefix[ticketAge]];
            float discount = prices[1][timePrefix[hourStayed] + "Discount"];

            float[] totalPriceDiscountPercent = { calculatedPrice, discount };
            return totalPriceDiscountPercent;
return null;
        }
**/

/*
        private void  calculateTotalHrsStayed() {

            //update out time
            txtBoxOutTime.Text = DateTime.Now.ToShortTimeString();
            //Globals.myTicket[ticketNumber].outTime = txtBoxOutTime.Text;

            //update price
            //DateTime inTime = Convert.ToDateTime(Globals.myTicket[ticketNumber].inTime);
           // DateTime outTime = Convert.ToDateTime(Globals.myTicket[ticketNumber].outTime);

            //int totalHrsCustomerStay = (int)(outTime - inTime).TotalHours;

        }*/



//Reset
/* txtBoxTicketNo.ResetText();
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
             btnSave.Text = "Save";
             txtBoxTotalPrice.ResetText();
             txtBoxDiscount.ResetText();
             txtBoxGrandTotal.ResetText();
             if (resetTo == "save") {
                 groupTicketList.Clear();
                 ticketTable.Rows.Clear();

                 btnSave.Enabled = true;
                 isGroupRadioBtn.Enabled = true;
                 notGroupRadioBtn.Enabled = true;
                 notGroupRadioBtn.Checked = true;
             }
             */


/*        private float[] findPrice(Ticket ticket) {

            // find total hour stayed
            DateTime inTime = Convert.ToDateTime(ticket.inTime);
            DateTime outTime = DateTime.Now;
            int totalHrsCustomerStay = (int)(outTime - inTime).TotalHours + 1;
            int hourStayed = (totalHrsCustomerStay > 4 || totalHrsCustomerStay < 0)
                                    ? 4
                                    : totalHrsCustomerStay;

            MessageBox.Show("Total hrs stay "+ hourStayed);

            // find price and discount
            List<Dictionary<string, float>> prices;
            string[] agePrefix = { "Child", "Teen", "Adult", "Senior" };
            string[] timePrefix = { "hour", "twoHour", "threeHour", "fourHour", "wholeDay" };

            prices = (isWeekDay(ticket.date))
                            ? Globals.weekDayPriceListG
                            : Globals.weekEndPriceListG;


            System.Diagnostics.Debug.WriteLine("FROM lsir:  " + timePrefix[hourStayed] + agePrefix[ticket.age]);
            float calculatedPrice = prices[0][timePrefix[hourStayed] + agePrefix[ticket.age]];
            float discount = (ticket.isGroup)
                                   ? prices[1][timePrefix[hourStayed] + "Discount"]
                                   : 0;

            float[] priceAndDiscount = { calculatedPrice, discount };

            return priceAndDiscount;
            

        }*/