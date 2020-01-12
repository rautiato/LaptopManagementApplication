using System;

namespace LaptopManagement
{
    public class Laptop
    {
        public string LaptopID { get; set; }
        public string LaptopName { get; set; }
        public string LaptopType { get; set; }
        public DateTime ProductDate { get; set; }
        public string Processor { get; set; }
        public string HDD { get; set; }
        public string RAM { get; set; }
        public int Price { get; set; }
        public string Avatar { get; set; }
        public Laptop()
        {
            LaptopID = "Not Assigned";
            LaptopName = "Not Assigned";
        }
    }
}
