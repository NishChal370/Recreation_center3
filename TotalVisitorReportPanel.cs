using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recreation_center
{
    public partial class TotalVisitorReportPanel : UserControl
    {
        
        public TotalVisitorReportPanel()
        {
            InitializeComponent();
           // loadVisitorsInChart();

        }

        private void selectedReportDate_ValueChanged(object sender, EventArgs e)
        {
            loadVisitorsInChart();
        }

        public void loadVisitorsInChart()
        {
            MessageBox.Show("FRFOm dialy chart 1");
            System.Diagnostics.Debug.WriteLine("FRFOm dialy chart 2");
            //@ aDayAgeVisitorList for <'age', totalVisitorsOfThatAge>
            //@ aDayGroupVisitorList for <'group', totalVisitorsOfThatGroup>
            // this changed
            Dictionary<string, int> aDayAgeVisitorList = new Dictionary<string, int>();
            Dictionary<int, int> aDayGroupVisitorList = new Dictionary<int, int>();
            Dictionary<string, int> aDayGroupCateogTotalList = new Dictionary<string, int>();
            findTotalVisitorsByCategory(aDayAgeVisitorList, aDayGroupVisitorList);

            //load to Age in chart and table
            ageTable.Rows.Clear();
            ageChart.Series["Age"].Points.Clear(); //sortTicketVisitorsReportList() 
            foreach ( KeyValuePair<string, int> item in sortTicketVisitorsReportList(aDayAgeVisitorList))
            {
                ageTable.Rows.Add(item.Key, item.Value);
                ageChart.Series["Age"].Points.AddXY(item.Key, item.Value);
            }

            string[] groupCateogary = { "0-5", "5-10", "10-15", "Above-15" };
            foreach (string group in groupCateogary)
            {
                aDayGroupCateogTotalList.Add(group, 0);
            }

            //load to Group in chart and table
            groupTable.Rows.Clear();
            groupChart.Series["Group"].Points.Clear(); //sortTicketVisitorsReportList()
            foreach ( KeyValuePair<int, int> item in aDayGroupVisitorList )
            {
                if (item.Value < 5) 
                {
                    aDayGroupCateogTotalList["0-5"] = aDayGroupCateogTotalList["0-5"] + 1;
                }
                else if (item.Value < 10) {
                    aDayGroupCateogTotalList["5-10"] = aDayGroupCateogTotalList["5-10"] + 1;
                }
                else if (item.Value < 15)
                {
                    aDayGroupCateogTotalList["10-15"] = aDayGroupCateogTotalList["10-15"] + 1;
                }
                else if (item.Value > 15)
                {
                    aDayGroupCateogTotalList["Above-15"] = aDayGroupCateogTotalList["Above-15"] + 1;
                }
            }

            foreach (KeyValuePair<string, int> item in sortTicketVisitorsReportList(aDayGroupCateogTotalList)) {
                groupTable.Rows.Add(item.Key, item.Value);
                groupChart.Series["Group"].Points.AddXY(item.Key, item.Value);
            }
        }

        //  finding total visitors of different Category
        private void findTotalVisitorsByCategory(Dictionary<string, int> aDayAgeVisitorList, Dictionary<int, int> aDayGroupVisitorList) {

            string[] ageGroupList = {
                "5-12",
                "12-18",
                "18-60",
                "Above 60"
            };

            string[] groupList = {
                "2-5",
                "5-10",
                "10-15",
                "Above 15"
            };
            System.Diagnostics.Debug.WriteLine("FRFOm dialy chart 3");

            //List<List<Ticket>> g = Globals.myTicket.GroupBy(i => i.ticketID); //JsonConvert.SerializeObject(tempTicketList)
            /*Dictionary<int, int> groups =
             Globals.myTicket.GroupBy(x => x.ticketID)
                  .ToDictionary(x => x, x => x.Select(i => i.ticketID).ToList().Count);*/
           // System.Diagnostics.Debug.WriteLine("GROUP COUNT  " + JsonConvert.SerializeObject(groups));
            //foreach (List<Ticket> i  in g) {
            //    System.Diagnostics.Debug.WriteLine("GROUP  " + JsonConvert.SerializeObject(i));
            //}
            // this changed 
            foreach (Ticket ticket in Globals.myTicket)
            {   //if ticket date and user selected date match
                System.Diagnostics.Debug.WriteLine("FRFOm dialy chart 4 "+ selectedReportDate.Value.ToShortDateString() +" "+ ticket.date.ToShortDateString());
                if (selectedReportDate.Value.ToShortDateString() == ticket.date.ToShortDateString())
                {
                    System.Diagnostics.Debug.WriteLine("FRFOm dialy chart 5");
                    if (ticket.isGroup) {
                        System.Diagnostics.Debug.WriteLine("FRFOm dialy chart 6");
                        if (aDayGroupVisitorList.ContainsKey(ticket.ticketID))
                        {///groupList[ticket.age]
                            System.Diagnostics.Debug.WriteLine("FRFOm dialy chart 7.1");
                            //aDayGroupVisitorList[groupList[ticket.age]] = aDayGroupVisitorList[groupList[ticket.age]] + 1;
                            aDayGroupVisitorList[ticket.ticketID] = aDayGroupVisitorList[ticket.ticketID] + 1;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("FRFOm dialy chart 7.2");
                            //aDayGroupVisitorList.Add(groupList[ticket.age], 1);
                            aDayGroupVisitorList.Add(ticket.ticketID, 1);
                        }
                    }


                    if (aDayAgeVisitorList.ContainsKey(ageGroupList[ticket.age]))
                    {
                        aDayAgeVisitorList[ageGroupList[ticket.age]] = aDayAgeVisitorList[ageGroupList[ticket.age]] + 1;
                    }
                    else
                    {
                        aDayAgeVisitorList.Add(ageGroupList[ticket.age], 1);
                    }
                    //else// if ticket is not for group
                    //{
                        
                    //}
                }
            }

        }

        // convert dictionary into list, bubble sort the list and return list by converting into dictionary
        private Dictionary<string, int> sortTicketVisitorsReportList(Dictionary<string, int> aDayCategoryVisitorDict)
        {
            List<KeyValuePair<string, int>> aDayCategoryVisitorList = aDayCategoryVisitorDict.ToList();
            //bubble sort // this changed
           /* for (int i = aDayCategoryVisitorList.Count - 1; i > 0; i--)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    if (aDayCategoryVisitorList[j].Value > aDayCategoryVisitorList[j + 1].Value)
                    {
                        KeyValuePair<string, int> temp = aDayCategoryVisitorList[j];
                        aDayCategoryVisitorList[j] = aDayCategoryVisitorList[j + 1];
                        aDayCategoryVisitorList[j + 1] = temp;
                    }
                }
            }*/

            return aDayCategoryVisitorList.ToDictionary(x => x.Key, x => x.Value);
        }

    }
}