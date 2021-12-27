
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

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
    }
}
