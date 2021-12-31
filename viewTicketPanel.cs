using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Recreation_center
{
    public partial class viewTicketPanel : UserControl
    {
        public viewTicketPanel()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fillTicketTable();
        }

        public void fillTicketTable()
        {
            string[] ageGroupList = {
                "5-12",
                "12-18",
                "18-60",
                "Above 60",
            };

            ticketTable.Rows.Clear();
            foreach (Ticket ticket in Globals.myTicket)
            {   // if user selected date and ticket date matches
                if (dateTimePicker.Value.Date == ticket.date.Date)
                {

                    string outTime = (ticket.outTime != null)
                                        ? ticket.outTime
                                        : "NaN";

                    ticketTable.Rows.Add(
                        ticket.ticketID, ticket.date.ToString("ddd, dd MMMM yyyy"),
                        ticket.name, ticket.phone, ticket.address, ageGroupList[ticket.age], ticket.inTime, outTime, ticket.price
                    );
                }

            }
        }

    }

}
