using System;
using System.Linq;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Collections.Generic;


namespace Recreation_center
{
    public partial class TotalVisitorReportPanel : UserControl
    {
        
        public TotalVisitorReportPanel()
        {
            InitializeComponent();
        }

        private void selectedReportDate_ValueChanged(object sender, EventArgs e)
        {
            loadVisitorsInChart();
        }
       
        public void loadVisitorsInChart()
        {
            /// <summary>
            /// aDayGroupVisitorList for <'ticketID', totalVisitorsOfThatGroup>
            /// aDayAgeVisitorList for <'age', totalVisitorsOfThatAge>
            /// aDayGroupCateogTotalList <'groupCategary', totalNumber>
            /// </summary>
            Dictionary<int, int> aDayGroupVisitorList = new Dictionary<int, int>();
            Dictionary<string, int> aDayAgeVisitorList = new Dictionary<string, int>();
            Dictionary<string, int> aDayGroupCateogTotalList = new Dictionary<string, int>();

            findTotalVisitorsByCategory(aDayAgeVisitorList, aDayGroupVisitorList);

            //load to Age in chart and table
            ageTable.Rows.Clear();
            ageChart.Series["Age"].Points.Clear();
            foreach ( KeyValuePair<string, int> item in sortTicketVisitorsReportList(aDayAgeVisitorList))
            {
                ageTable.Rows.Add(item.Key, item.Value);
                ageChart.Series["Age"].Points.AddXY(item.Key, item.Value);
            }

            // add group cateogary in aDayGroupCateogTotalListn dictonary
            string[] groupCateogary = { "2-5", "5-10", "10-15", "Above-15" };
            foreach (string group in groupCateogary)
            {
                aDayGroupCateogTotalList.Add(group, 0);
            }

            // calculated total visitors according to group cateogary
            foreach ( KeyValuePair<int, int> item in aDayGroupVisitorList )
            {
                if (item.Value < 5) //"2-5"
                {
                    aDayGroupCateogTotalList[groupCateogary[0]] = aDayGroupCateogTotalList[groupCateogary[0]] + item.Value;
                }
                else if (item.Value < 10) { //"5-10"
                    aDayGroupCateogTotalList[groupCateogary[1]] = aDayGroupCateogTotalList[groupCateogary[1]] + item.Value;
                }
                else if (item.Value < 15)//"10-15"
                {
                    aDayGroupCateogTotalList[groupCateogary[2]] = aDayGroupCateogTotalList[groupCateogary[2]] + item.Value;
                }
                else if (item.Value > 15) //"Above-15"
                {
                    aDayGroupCateogTotalList[groupCateogary[3]] = aDayGroupCateogTotalList[groupCateogary[3]] + item.Value;
                }
            }

            //load to Group in chart and table
            groupTable.Rows.Clear();
            groupChart.Series["Group"].Points.Clear();
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

            foreach (Ticket ticket in Globals.myTicket)
            {   //if ticket date and user selected date match
                if (selectedReportDate.Value.ToShortDateString() == ticket.date.ToShortDateString())
                {
                    // for group
                    if (ticket.isGroup) { // aDayGroupVisitorList : [ID, "totalNum"]
                        if (aDayGroupVisitorList.ContainsKey(ticket.ticketID))
                        {
                            aDayGroupVisitorList[ticket.ticketID] = aDayGroupVisitorList[ticket.ticketID] + 1;
                        }
                        else
                        {
                            aDayGroupVisitorList.Add(ticket.ticketID, 1);
                        }
                    }

                    //for all visitors
                    if (aDayAgeVisitorList.ContainsKey(ageGroupList[ticket.age]))
                    {
                        aDayAgeVisitorList[ageGroupList[ticket.age]] = aDayAgeVisitorList[ageGroupList[ticket.age]] + 1;
                    }
                    else
                    {
                        aDayAgeVisitorList.Add(ageGroupList[ticket.age], 1);
                    }
                }
            }
            
        }

        // convert dictionary into list, bubble sort the list and return list by converting into dictionary
        private Dictionary<string, int> sortTicketVisitorsReportList(Dictionary<string, int> aDayCategoryVisitorDict)
        {
            
            List<KeyValuePair<string, int>> aDayCategoryVisitorList = aDayCategoryVisitorDict.ToList();
            //bubble sort 
           for (int i = aDayCategoryVisitorList.Count - 1; i > 0; i--)
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
           }

            return aDayCategoryVisitorList.ToDictionary(x => x.Key, x => x.Value);
        }

    }
}