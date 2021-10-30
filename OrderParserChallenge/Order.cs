using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderParserChallenge
{
    class Order
    {
        // Order headings
        public string OrderNumber { get; set; }
        public int TotalItems { get; set; }
        public float TotalCost { get; set; }
        public string OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public bool Paid { get; set; }
        public bool Shipped { get; set; }
        public bool Completed { get; set; }

        // Order Address
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string OrderState { get; set; }
        public string ZipCode { get; set; }

        // Order Details
        public class LineNumber
        {
            public int LineNum { get; set; }
            public int Quantity { get; set; }
            public float CostEach { get; set; }
            public float TotalItemCost { get; set; }
            public string Description { get; set; }
        }


        

        //// Valid Order
        public bool ValidOrder { get; set; }
        public string ErrorMessage { get; set; }
    }
}
