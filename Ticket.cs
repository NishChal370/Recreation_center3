
using System;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Recreation_center
{
    class Ticket
    {
        public int ticketID { get; set; }
        public DateTime date { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public int age { get; set; }
        public bool isGroup { get; set; }
        public string inTime { get; set; }
        public string outTime { get; set; }
        public float discountedPercent { get; set; }
        public float price { get; set; }

    }

}