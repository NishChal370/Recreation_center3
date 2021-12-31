
using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Recreation_center
{
    public partial class WeeklyReport : UserControl
    {
        public WeeklyReport()
        {
            InitializeComponent();
			sortByEarningRatioBtn.Checked = true;
		}

		private void selectedWeeklyReportDate_ValueChanged(object sender, EventArgs e)
		{
			loadReportToChart();
		}

		private void sortByEarningRatioBtn_CheckedChanged(object sender, EventArgs e)
		{
			loadReportToChart();
		}

		private void sortByVisitorsRadioBtn_CheckedChanged(object sender, EventArgs e)
		{
			loadReportToChart();
		}

		public void loadReportToChart()
		{
			//@ weeklyReportList {"Date":[totalvisitors, totalEarning]}
			Dictionary<string, float[]> weeklyReportList = new Dictionary<string, float[]>();

			weeklyReportList = findEachDayEarningAndVisitor(weeklyReportList);

			calcTotalEarningAndVisitorsOfWeek(weeklyReportList);

			//load weekly report to chart and table
			weeklyReportTable.Rows.Clear();
			weeklyReportChart.Series["TotalVisitor"].Points.Clear();
			weeklyReportChart.Series["TotalEarning"].Points.Clear();
			
			foreach (KeyValuePair<string, float[]> item in sortReport(weeklyReportList))
			{	//graph
				weeklyReportChart.Series["TotalVisitor"].Points.AddXY(Convert.ToDateTime(item.Key).ToString("dddd"), item.Value[0]);
				weeklyReportChart.Series["TotalEarning"].Points.AddXY(Convert.ToDateTime(item.Key).ToString("dddd"), item.Value[1]);
				// table
				weeklyReportTable.Rows.Add(Convert.ToDateTime(item.Key).ToString("ddd, dd MMMM yyyy"), item.Value[0], item.Value[1]);
			}
		}

		//finding toal visitors a day in a week and total earning a day in a week.
		private Dictionary<string, float[]> findEachDayEarningAndVisitor(Dictionary<string, float[]> weeklyReportList)
		{									
			string ticketDate = "";
			float totalPrice = 0;
			float discountPercent = 0;
			bool isSelectedDate = false;
			//@ TicketGroupList :   [ [{G1}], [{G2}, {G2}, {G2}}] ,[{G3}] ]
			List<List<Ticket>> ticketGroupList = new List<List<Ticket>>();

			groupTicketByID(ticketGroupList);

			foreach (var ticketSubGroup in ticketGroupList)
			{
				// calculate total price of ticketGroup and discount %
				foreach (Ticket ticket in ticketSubGroup)
				{
					if (isBetweenStartAndEndDate(ticket.date, weklyDatePicker.Value))
					{
						discountPercent = ticket.discountedPercent;
						totalPrice += ticket.price;
						isSelectedDate = true;
						ticketDate = ticket.date.ToShortDateString();
					}

				}

				// isBetweenStartAndEndDate
				if (isSelectedDate) 
				{
					float discountedAmt = totalPrice - (totalPrice * (discountPercent / 100));
					totalPrice = 0;
					isSelectedDate = false;
					if (weeklyReportList.ContainsKey(ticketDate))
					{
						//@ weeklyReportList[ticketDaate][0]  total visitor of that week
						//@ weeklyReportList[ticketDaate][1] total earning of that week
						weeklyReportList[ticketDate][0] = weeklyReportList[ticketDate][0] + ticketSubGroup.Count();
						weeklyReportList[ticketDate][1] = weeklyReportList[ticketDate][1] + discountedAmt;
					}
					else
					{
						float[] totalVisitorsAndEarning = { ticketSubGroup.Count(), discountedAmt };
						weeklyReportList.Add(ticketDate, totalVisitorsAndEarning);
					}
				}

			}
			
			return weeklyReportList;
		}

		//Grouping or seperating ticket in subList accounting to their group i.e ticketID
		private void groupTicketByID(List<List<Ticket>> ticketGroupList) {

			int count = -1;
			List<Ticket> subGroupList = new List<Ticket>();
			
			foreach (Ticket tk in Globals.myTicket)
			{
				if (count < Globals.myTicket.Count - 1)
				{
					count++;
				}

				subGroupList.Add(tk);

				if (count  < Globals.myTicket.Count-1)
				{
					if (Globals.myTicket[count + 1].ticketID != tk.ticketID)
					{
						ticketGroupList.Add(subGroupList);
						subGroupList = new List<Ticket>();
					}
				}

				if (count + 1 == Globals.myTicket.Count) // for last ticket group
				{
					ticketGroupList.Add(subGroupList);
				}

			}

		}

		// it return true if the ticket date is between the user selected week.
		private bool isBetweenStartAndEndDate(DateTime ticketDate, DateTime selectedDate)
		{

			int year = selectedDate.Date.Year;
			//set the first day of the year
			DateTime firstDay = new DateTime(year, 1, 1);
			CultureInfo cul = CultureInfo.CurrentCulture;
			//get no of week for the date
			int weekNo = cul.Calendar.GetWeekOfYear(selectedDate, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
			//get no of day
			int days = (weekNo - 1) * 7;
			DateTime dt1 = firstDay.AddDays(days);
			DayOfWeek dayOfWeek = dt1.DayOfWeek;
			DateTime startDateOfWeek = dt1.AddDays(-(int)dayOfWeek);
			DateTime endDateOfWeek = startDateOfWeek.AddDays(7);

			return (startDateOfWeek <= ticketDate) & (endDateOfWeek >= ticketDate);
		}


		//converts dictionary into list and bubble sort according to sortBy param
		private Dictionary<string, float[]> sortReport(Dictionary<string, float[]> weeklyReportDict)
        {
			List<KeyValuePair<string, float[]>> weeklyReportList = weeklyReportDict.ToList(); // converting dictionary into list

			//@ 0 for sort by totalVisitors
			//@ 1 for sor by totalEarning
			int sortBy = 0;
			if (!sortByVisitorsRadioBtn.Checked) { sortBy = 1; }

			//bubble sort																					   
			for (int i = weeklyReportList.Count - 1; i > 0; i--)
			{
				for (int j = 0; j <= i - 1; j++)
				{
					if (weeklyReportList[j].Value[sortBy] > weeklyReportList[j+1].Value[sortBy])
					{
						KeyValuePair<string, float[]> temp = weeklyReportList[j];
						weeklyReportList[j] = weeklyReportList[j + 1];
						weeklyReportList[j + 1] = temp;
					}
				}
			}

			return weeklyReportList.ToDictionary(x => x.Key, x => x.Value); // converting list int dictionary
		}

		private void calcTotalEarningAndVisitorsOfWeek(Dictionary<string, float[]> weeklyReportList) {
			float totalEarningOfWeek = 0;
			float totalVisitorsOfWeek = 0;
			
			foreach (KeyValuePair<string, float[]> data in weeklyReportList) {
				totalEarningOfWeek += data.Value[1];
				totalVisitorsOfWeek += data.Value[0];
			}

			totalEarningResultLabel.Text = totalEarningOfWeek.ToString();
			totalVisitorsResultLabel.Text = totalVisitorsOfWeek.ToString();
		}
        
    }
}



/**
 else {
							if (beforeWasGroup) {
								beforeWasGroup = false;
								System.Diagnostics.Debug.WriteLine("-----------------Break-----------------------");
							}
							System.Diagnostics.Debug.WriteLine("Tickets->  " + JsonConvert.SerializeObject("ID: " + tk.ticketID + "Price: " + tk.price));
						}
*/

/*				if (Globals.myTicket[globalTicketIndex].ticketID != tk.ticketID)
				{
					list.Add(newList);
					newList.Clear();
					System.Diagnostics.Debug.WriteLine("--break--");
				}
				*/



//->>>>
/*				if (globalTicketIndex + 1 == Globals.myTicket.Count)
				{
					System.Diagnostics.Debug.WriteLine("END: ");
				}*/



// from cal
/*
 foreach (Ticket tk in Globals.myTicket)
			{

				if (isBetweenStartAndEndDate(tk.date, selectedWeeklyReportDate.Value))
				{
					string ticketDate = tk.date.ToString("MM/dd/yyyy");
					if (weeklyReportList.ContainsKey(ticketDate))
					{
						//@ 0 index for  total visitors.
						//@ 1 index for total earning.

						/*if (tk.isGroup)
						{
							beforeWasGroup = true;
							if (tk.ticketID != tik)
							{
								System.Diagnostics.Debug.WriteLine("-----------------NEW GROUP-----------------------");
								tik = tk.ticketID;
								isSameGroup = false;
							}
							else
							{
								isSameGroup = true;
							}
							totalPrice += tk.price;
							System.Diagnostics.Debug.WriteLine("Group->  " + JsonConvert.SerializeObject("ID: " + tk.ticketID + "Price: " + tk.price));
						}
						else {
							if (beforeWasGroup)
							{
								beforeWasGroup = false;
								System.Diagnostics.Debug.WriteLine("TOTAL: " + totalPrice);
								totalPrice = 0;
								System.Diagnostics.Debug.WriteLine("-----------------Break-----------------------");

							}
						}
						
						*/
						// this is
						/*weeklyReportList[ticketDate][0] = weeklyReportList[ticketDate][0] + 1;
						weeklyReportList[ticketDate][1] = weeklyReportList[ticketDate][1] + tk.price;*/
/*					}
					else
{// this is
	/*float[] totalVisitorsAndEarning = { 1, tk.price };
	weeklyReportList.Add(ticketDate, totalVisitorsAndEarning);*/
//}
//				}

//			};
//*/