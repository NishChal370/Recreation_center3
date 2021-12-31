
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Recreation_center
{
    class Globals
    {
        public static List<Ticket> myTicket = new List<Ticket>(); 
        public static List<Dictionary<string, float>> weekDayPriceListG = new List<Dictionary<string, float>>();
        public static List<Dictionary<string, float>> weekEndPriceListG = new List<Dictionary<string, float>>();

        public static bool writeToTextFile(string fileName, string data) {
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }
            StreamWriter outputFile = new StreamWriter(fileName);
            outputFile.WriteLine(data);
            outputFile.Close();
            
            return true;
        }

        public static void readFile(string readFileFor, string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader r = File.OpenText(fileName))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        if (readFileFor == "admin") {
                            List<Dictionary<string, float>> weeklyPriceList = JsonConvert.DeserializeObject<List<Dictionary<string, float>>>(line);

                            if (fileName == Constants.WEEKDAYFILENAME)
                            {
                                weekDayPriceListG = weeklyPriceList;
                            }
                            else // for weekend
                            {
                               weekEndPriceListG = weeklyPriceList;
                            }

                        }
                        else // for ticket
                        {
                            myTicket = JsonConvert.DeserializeObject<List<Ticket>>(line);
                        }
                       
                    }
                }
            }

        }



    }
}
