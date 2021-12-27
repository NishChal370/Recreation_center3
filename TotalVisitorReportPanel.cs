using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Recreation_center
{
    public partial class TotalVisitorReportPanel : UserControl
    {
        
        public TotalVisitorReportPanel()
        {
            InitializeComponent();
            loadVisitorsInChart();
        }

        private void selectedReportDate_ValueChanged(object sender, EventArgs e)
        {
            loadVisitorsInChart();
        }

        public void loadVisitorsInChart()
        {
            //@ aDayAgeVisitorList for <'age', totalVisitorsOfThatAge>
            //@ aDayGroupVisitorList for <'group', totalVisitorsOfThatGroup>
            // this changed
          /*  Dictionary<string, int> aDayAgeVisitorList = new Dictionary<string, int>();
            Dictionary<string, int> aDayGroupVisitorList = new Dictionary<string, int>();

            findTotalVisitorsByCategory(aDayAgeVisitorList, aDayGroupVisitorList);

            //load to Age in chart and table
            ageTable.Rows.Clear();
            ageChart.Series["Age"].Points.Clear();
            foreach( KeyValuePair<string, int> item in sortTicketVisitorsReportList(aDayAgeVisitorList) )
            {
                ageTable.Rows.Add(item.Key, item.Value);
                ageChart.Series["Age"].Points.AddXY(item.Key, item.Value);
            }

            //load to Group in chart and table
            groupTable.Rows.Clear();
            groupChart.Series["Group"].Points.Clear();
            foreach ( KeyValuePair<string, int> item in sortTicketVisitorsReportList(aDayGroupVisitorList) )
            {
                groupTable.Rows.Add(item.Key, item.Value);
                groupChart.Series["Group"].Points.AddXY(item.Key, item.Value);
            }*/
        }

        //  finding total visitors of different Category
        private void findTotalVisitorsByCategory(Dictionary<string, int> aDayAgeVisitorList, Dictionary<string, int> aDayGroupVisitorList) {

            string[] ageGroupList = {
                "5-12",
                "12-30",
                "Above 30"
            };

            string[] groupList = {
                "2-5",
                "5-10",
                "10-15",
                "Above 15"
            };
            // this changed 
           /* foreach (Ticket ticket in Globals.myTicket)
            {   //if ticket date and user selected date match
                if (selectedReportDate.Value.ToShortDateString() == ticket.date.ToShortDateString())
                {
                    if (ticket.age != -1) // if ticket is for age
                    {
                        if (aDayAgeVisitorList.ContainsKey(ageGroupList[ticket.age]))
                        {
                            aDayAgeVisitorList[ageGroupList[ticket.age]] = aDayAgeVisitorList[ageGroupList[ticket.age]] + 1;
                        }
                        else
                        {
                            aDayAgeVisitorList.Add(ageGroupList[ticket.age], 1);
                        }
                    }
                    else if(ticket.group != -1) // if ticket is for group
                    {
                        if (aDayGroupVisitorList.ContainsKey(groupList[ticket.group]))
                        {
                            aDayGroupVisitorList[groupList[ticket.group]] = aDayGroupVisitorList[groupList[ticket.group]] + 1;
                        }
                        else
                        {
                            aDayGroupVisitorList.Add(groupList[ticket.group], 1);
                        }
                    }
                }
            }*/

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