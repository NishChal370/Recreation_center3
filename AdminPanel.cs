using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Recreation_center
{
    public partial class AdminPanel : UserControl
    {
        public AdminPanel()
        {
            InitializeComponent();
            // this changed
            priceDayCmboBox.SelectedIndex = 0;
            readFile(Constants.WEEKDAYFILENAME);
            readFile(Constants.WEEKENDFILENAME);
            autoFillTextBox(Globals.weekDayPriceListG); 
        }

        private void btnSaveTicket_Click(object sender, EventArgs e)
        {
            // this changed
           if (priceDayCmboBox.SelectedIndex == 0)
            {   // save weekday price
                savePrice("weekDay", Globals.weekDayPriceListG);

            }
            else if (priceDayCmboBox.SelectedIndex == 1)
            {   // save weekEnd price
                savePrice("weekEnd", Globals.weekEndPriceListG);
            }
            else
            {
                MessageBox.Show("Not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClearTicket_Click_1(object sender, EventArgs e)
        {   // this changed
            clearTextBox(adminAgePricePanel);
            clearTextBox(adminGroupDiscountPanel);
        }

        private void daySelectionCmboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
               // this changed
            clearTextBox(adminAgePricePanel);
            clearTextBox(adminGroupDiscountPanel);

            if (priceDayCmboBox.SelectedIndex == 0) //weekday selected
            {
                autoFillTextBox(Globals.weekDayPriceListG);
            }
            else if (priceDayCmboBox.SelectedIndex == 1) //weekEnd selected
            {
                autoFillTextBox(Globals.weekEndPriceListG);
            }

        }

        private void savePrice( string selectedDay, List<Dictionary<string, float>> weekPriceList)
        {   // this changed
            bool isTextBoxValid = true;
            List<Panel> panels = new List<Panel>() { adminAgePricePanel, adminGroupDiscountPanel };
            
            foreach (Panel panel in panels)
            {
                Dictionary<string, float> priceList = new Dictionary<string, float>();
                // adding or saving pricelist to local list
                foreach (Control c in panel.Controls)
                {
                    if (c is TextBox)
                    {
                        if (!validateTextBox(c))
                        {
                            isTextBoxValid = false;
                            break;
                        }
                        else {
                            priceList.Add(c.Name.Replace("TextBox", ""), float.Parse(c.Text));
                        } //.Replace("TextBox", "")

                    }

                }

                if (!isTextBoxValid) { break; }
                // adding or saving priceList to global list
                if (priceList.Count() == 20 && panel.Name == "adminAgePricePanel" || priceList.Count() == 5 && panel.Name == "adminGroupDiscountPanel")
                {
                    if (panel.Name == "adminAgePricePanel") { weekPriceList.Clear(); } // to create new price list

                    weekPriceList.Add(priceList);
                    
                    if (weekPriceList.Count() == 2)
                    {
                        string fileName = selectedDay + ".txt";
                        if( Globals.writeToTextFile(fileName, JsonConvert.SerializeObject(weekPriceList)) )
                        {
                            MessageBox.Show("File Saved to " + fileName, " Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private bool validateTextBox(Control c)
        {
            Regex ticketPriceRegex = new Regex(@"^[0-9]*\.?[0-9]*$");
            // this changed
            /*string txtBoxName = "";
            foreach (char chr in c.Name) {
                if (char.IsUpper(chr))
                {
                    txtBoxName += " " + chr;
                }
                else {
                    txtBoxName += chr;
                }
            }

            if (c.Text.ToString().Trim() == "")
            {
                c.BackColor =System.Drawing.Color.LightPink;
                MessageBox.Show(txtBoxName + " is Empty!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                return false;
            }
            else if (!ticketPriceRegex.IsMatch(c.Text.ToString())) {
                c.BackColor = System.Drawing.Color.LightPink;
                MessageBox.Show(txtBoxName + " have Invalid  price !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return false;
            }
            */
            return true;
        }

        private void clearTextBox(Panel selectedPanel)
        {
            foreach (Control c in selectedPanel.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
        }

        private void readFile(string fileName)
        {   // this changed
            if (File.Exists(fileName))
            {
                using (StreamReader r = File.OpenText(fileName))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    { 
                        List<Dictionary<string, float>> weeklyPriceList = JsonConvert.DeserializeObject<List<Dictionary<string, float>>>(line);

                        if (fileName == Constants.WEEKDAYFILENAME)
                        {
                            Globals.weekDayPriceListG = weeklyPriceList;
                        }
                        else
                        {
                            Globals.weekEndPriceListG = weeklyPriceList;
                        }
                    }
                }
            } 
            
        }

        private void autoFillTextBox(List<Dictionary<string, float>> globalPriceList)
        {
            // this changed
            if (globalPriceList.Count != 0)
            { 
                Dictionary<string, float> agePriceList = globalPriceList[0];
                Dictionary<string, float> groupDiscountList = globalPriceList[1];

                List<Panel> panels = new List<Panel>() { adminAgePricePanel, adminGroupDiscountPanel };
                foreach (Panel panel in panels)
                {
                    Dictionary<string, float> list = (panel.Name == "adminAgePricePanel") 
                                                            ? agePriceList
                                                            : groupDiscountList;
                    foreach (Control control in panel.Controls)
                    {
                        if (control is TextBox)
                        {
                            control.Text = list[control.Name.Replace("TextBox", "")].ToString();
                        }
                    }
                }
               
            }

        }
        
        private void hourChildTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //hourChildTextBox.BackColor = System.Drawing.Color.White;
        }

        private void twoHourChildTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //twoHourChildTextBox.BackColor = System.Drawing.Color.White;
        }

        private void fourHourChildTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // fourHourChildTextBox.BackColor = System.Drawing.Color.White;
        }

        private void wholeDayChildTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           // wholeDayChildTextBox.BackColor = System.Drawing.Color.White;
        }

        private void hourAdultTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           // hourAdultTextBox.BackColor = System.Drawing.Color.White;
        }

        private void twoHourAdultTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //twoHourAdultTextBox.BackColor = System.Drawing.Color.White;
        }

        private void threeHourAdultTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           // threeHourAdultTextBox.BackColor = System.Drawing.Color.White;
        }

        private void fourHourAdultTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //fourHourAdultTextBox.BackColor = System.Drawing.Color.White;
        }

        private void wholeDayAdultTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //wholeDayAdultTextBox.BackColor = System.Drawing.Color.White;
        }

        private void hourSeniorTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //hourSeniorTextBox.BackColor = System.Drawing.Color.White;
        }

        private void twoHourSeniorTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //twoHourSeniorTextBox.BackColor = System.Drawing.Color.White;
        }

        private void threeHourSeniorTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //threeHourSeniorTextBox.BackColor = System.Drawing.Color.White;
        }

        private void fourHourSeniorTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //fourHourSeniorTextBox.BackColor = System.Drawing.Color.White;
        }

        private void wholeDaySeniorTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //wholeDaySeniorTextBox.BackColor = System.Drawing.Color.White;
        }

        private void hourFiveGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //hourFiveGrupTextBox.BackColor = System.Drawing.Color.White;
        }

        //FOR GROUP
        private void twoHourFiveGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //twoHourFiveGrupTextBox.BackColor = System.Drawing.Color.White;
        }

        private void threeHoursFiveGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //threeHoursFiveGrupTextBox.BackColor = System.Drawing.Color.White;
        }

        private void fourHoursFiveGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //fourHoursFiveGrupTextBox.BackColor = System.Drawing.Color.White;
        }

        private void wholeDayFiveGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //wholeDayFiveGrupTextBox.BackColor = System.Drawing.Color.White;
        }



    }
}



/* private bool writeToText(string fileName, List<Dictionary<string, float>> weekPriceList)
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }

            StreamWriter outputFile = new StreamWriter(fileName);
            outputFile.WriteLine( JsonConvert.SerializeObject(weekPriceList) );
            outputFile.Close();

            return true;
        }*/

//wholeDayAboveGrupTextBox.BackColor = System.Drawing.Color.White;


/*
 * 
        private void hourTenGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //hourTenGrupTextBox.BackColor = System.Drawing.Color.White;
        }

        private void twoHourTenGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           // twoHourTenGrupTextBox.BackColor = System.Drawing.Color.White;
        }

        private void threeHoursTenGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           // threeHoursTenGrupTextBox.BackColor = System.Drawing.Color.White;
        }

        private void fourHoursTenGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           // fourHoursTenGrupTextBox.BackColor = System.Drawing.Color.White;
        }

        private void wholeDayTenGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           // wholeDayTenGrupTextBox.BackColor = System.Drawing.Color.White;
        }

        private void hourFifteenGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           // hourFifteenGrupTextBox.BackColor = System.Drawing.Color.White;
        }

        private void twoHourFifteenGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           // twoHourFifteenGrupTextBox.BackColor = System.Drawing.Color.White;
        }

        private void threeHoursFifteenGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           // threeHoursFifteenGrupTextBox.BackColor = System.Drawing.Color.White;
        }

        private void fourHoursFifteenGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           // fourHoursFifteenGrupTextBox.BackColor = System.Drawing.Color.White;
        }

        private void wholeDayFifteenGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //wholeDayFifteenGrupTextBox.BackColor = System.Drawing.Color.White;
        }

        private void hourAboveGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //hourAboveGrupTextBox.BackColor = System.Drawing.Color.White;
        }

        private void twoHourAboveGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //twoHourAboveGrupTextBox.BackColor = System.Drawing.Color.White;
        }

        private void threeHoursAboveGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //threeHoursAboveGrupTextBox.BackColor = System.Drawing.Color.White;
        }

        private void fourHoursAboveGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //fourHoursAboveGrupTextBox.BackColor = System.Drawing.Color.White;
        }

        private void wholeDayAboveGrupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //wholeDayAboveGrupTextBox.BackColor = System.Drawing.Color.White;
        }*/