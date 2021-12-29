using System;
using System.Windows.Forms;

namespace Recreation_center
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            adminPanel1.Visible = false;
            ticketPanel1.Visible = true;
            weeklyReport2.Visible = false;
            viewTicketPanel1.Visible = false;
            totalVisitorReport1.Visible = false;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            adminPanel1.Visible = true;
            ticketPanel1.Visible = false;
            weeklyReport2.Visible = false;
            viewTicketPanel1.Visible = false;
            totalVisitorReport1.Visible = false;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            adminPanel1.Visible = false;
            ticketPanel1.Visible = false;
            weeklyReport2.Visible = false;
            viewTicketPanel1.Visible = false;
            totalVisitorReport1.Visible = true;
            
            totalVisitorReport1.loadVisitorsInChart();
        }

        private void btnWeekReport_Click(object sender, EventArgs e)
        {
            adminPanel1.Visible = false;
            ticketPanel1.Visible = false;
            weeklyReport2.Visible = true;
            viewTicketPanel1.Visible = false;
            totalVisitorReport1.Visible = false;
            
            weeklyReport2.loadReportToChart();
        }

        private void btnViewTicket_Click(object sender, EventArgs e)
        {
            adminPanel1.Visible = false;
            ticketPanel1.Visible = false;
            weeklyReport2.Visible = false;
            totalVisitorReport1.Visible = false;
            viewTicketPanel1.Visible = true;

            viewTicketPanel1.fillTicketTable();
        }
    }
}
