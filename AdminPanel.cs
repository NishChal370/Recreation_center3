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

            priceDayCmboBox.SelectedIndex = 0;
            Globals.readFileG("admin", Constants.WEEKDAYFILENAME);
            Globals.readFileG("admin", Constants.WEEKENDFILENAME);

            autoFillTextBox(Globals.weekDayPriceListG);
        }

        private void btnSaveTicket_Click(object sender, EventArgs e)
        {
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
        {
            clearTextBox(adminAgePricePanel);
            clearTextBox(adminGroupDiscountPanel);
        }

        private void daySelectionCmboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void savePrice(string selectedDay, List<Dictionary<string, float>> weekPriceList)
        { 
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
                        if (!isValidTextBox(c))
                        {
                            isTextBoxValid = false;
                            break;
                        }
                        else
                        {
                            priceList.Add(c.Name.Replace("TextBox", ""), float.Parse(c.Text));
                        }

                    }

                }

                if (!isTextBoxValid) { break; }
                // adding or saving priceList to global list
                if (priceList.Count() == 20 && panel.Name == "adminAgePricePanel" || priceList.Count() == 5 && panel.Name == "adminGroupDiscountPanel")
                {
                    if (panel.Name == "adminAgePricePanel") { weekPriceList.Clear(); } // clear list for new

                    weekPriceList.Add(priceList);

                    if (weekPriceList.Count() == 2)
                    {
                        string fileName = selectedDay + ".txt";
                        if (Globals.writeToTextFile(fileName, JsonConvert.SerializeObject(weekPriceList)))
                        {
                            MessageBox.Show("File Saved to " + fileName, " Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private bool isValidTextBox(Control c)
        {
            Regex ticketPriceRegex = new Regex(@"^[0-9]*\.?[0-9]*$");

            string txtBoxName = "";
            foreach (char chr in c.Name)
            {
                if (char.IsUpper(chr))
                {
                    txtBoxName += " " + chr;
                }
                else
                {
                    txtBoxName += chr;
                }
            }

            if (c.Text.ToString().Trim() == "")
            {
                c.BackColor = System.Drawing.Color.LightPink;
                MessageBox.Show(txtBoxName + " is Empty!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            else if (!ticketPriceRegex.IsMatch(c.Text.ToString()))
            {
                c.BackColor = System.Drawing.Color.LightPink;
                MessageBox.Show(txtBoxName + " have Invalid  price !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

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

        private void autoFillTextBox(List<Dictionary<string, float>> globalPriceList)
        {
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
            hourChildTextBox.BackColor = System.Drawing.Color.White;
        }

        private void twoHourChildTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            twoHourChildTextBox.BackColor = System.Drawing.Color.White;
        }

        private void threeHourChildTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            threeHourChildTextBox.BackColor = System.Drawing.Color.White;
        }

        private void fourHourChildTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            fourHourChildTextBox.BackColor = System.Drawing.Color.White;
        }

        private void wholeDayChildTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            wholeDayChildTextBox.BackColor = System.Drawing.Color.White;
        }

        private void hourTeenTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            hourTeenTextBox.BackColor = System.Drawing.Color.White;
        }

        private void twoHourTeenTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            twoHourTeenTextBox.BackColor = System.Drawing.Color.White;
        }

        private void threeHourTeenTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            threeHourTeenTextBox.BackColor = System.Drawing.Color.White;
        }

        private void fourHourTeenTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            fourHourTeenTextBox.BackColor = System.Drawing.Color.White;
        }

        private void wholeDayTeenTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            wholeDayTeenTextBox.BackColor = System.Drawing.Color.White;
        }

        private void hourAdultTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            hourAdultTextBox.BackColor = System.Drawing.Color.White;
        }

        private void twoHourAdultTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            twoHourAdultTextBox.BackColor = System.Drawing.Color.White;
        }

        private void threeHourAdultTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            threeHourAdultTextBox.BackColor = System.Drawing.Color.White;
        }

        private void fourHourAdultTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            fourHourAdultTextBox.BackColor = System.Drawing.Color.White;
        }

        private void wholeDayAdultTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            wholeDayAdultTextBox.BackColor = System.Drawing.Color.White;
        }

        private void hourOldTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            hourOldTextBox.BackColor = System.Drawing.Color.White;
        }

        private void twoHourOldTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            twoHourOldTextBox.BackColor = System.Drawing.Color.White;
        }

        private void threeHourOldTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            threeHourOldTextBox.BackColor = System.Drawing.Color.White;
        }

        private void fourHourOldTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            fourHourOldTextBox.BackColor = System.Drawing.Color.White;
        }

        private void wholeDayOldTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            wholeDayOldTextBox.BackColor = System.Drawing.Color.White;
        }

        private void hourDiscountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            hourDiscountTextBox.BackColor = System.Drawing.Color.White;
        }

        private void twoHourDiscountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            twoHourDiscountTextBox.BackColor = System.Drawing.Color.White;
        }

        private void threeHourDiscountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            threeHourDiscountTextBox.BackColor = System.Drawing.Color.White;
        }

        private void fourHourDiscountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            fourHourDiscountTextBox.BackColor = System.Drawing.Color.White;
        }

        private void wholeDayDiscountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            wholeDayDiscountTextBox.BackColor = System.Drawing.Color.White;
        }

    }
}