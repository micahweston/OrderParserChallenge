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
        //// Valid Order
        public bool ValidOrder { get; set; }
        public string ErrorMessage { get; set; }
        public Address OrderAddress { get; set; }
        
        public List<LineNumber> items = new List<LineNumber>();

        public Order(string line)
        {
            if (line.Length != 180)
            {
                ValidOrder = false;
                ErrorMessage = "Invalid line length";
                return;
            }
            try
            {
                OrderNumber = line.Substring(3, 10).Trim();
                TotalItems = Int16.Parse(line.Substring(13, 5).Trim());
                TotalCost = float.Parse(line.Substring(18, 10).Trim());
                OrderDate = line.Substring(28, 19).Trim();
                CustomerName = line.Substring(47, 50).Trim();
                CustomerPhone = line.Substring(97, 30).Trim();
                CustomerEmail = line.Substring(127, 50).Trim();
                Paid = line.Substring(177, 1).Equals("1") ? true : false;
                Shipped = line.Substring(178, 1).Equals("1") ? true : false;
                Completed = line.Substring(179, 1).Equals("1") ? true : false;
            }
            catch (Exception exc)
            {
                ValidOrder = false;
                ErrorMessage = $"Error: {exc}";
            }

        }
        // Order Address
        public class Address
        {
            public string AddressLineOne { get; set; }
            public string AddressLineTwo { get; set; }
            public string City { get; set; }
            public string OrderState { get; set; }
            public string ZipCode { get; set; }
            public string ErrorMessage { get; }

            public Address(string line)
            {
                if (line.Length != 180)
                {
                    ErrorMessage = "Invalid line length";
                    return;
                }
                try
                {
                    AddressLineOne = line.Substring(3, 50).Trim();
                    AddressLineTwo = (line.Substring(53, 50).Trim()).Equals("") ? null : line.Substring(53, 50);
                    City = line.Substring(103, 50).Trim();
                    OrderState = line.Substring(153, 2).Trim();
                    ZipCode = line.Substring(155, 5).Trim();
                }
                catch (Exception exc)
                {
                    ErrorMessage = $"Error: {exc}";
                }
            }
        }

        // Order Details
        public class LineNumber 
        {
            public int LineNum { get; set; }
            public int Quantity { get; set; }
            public float CostEach { get; set; }
            public float TotalItemCost { get; set; }
            public string Description { get; set; }
            public string ErrorMessage { get; }

            public LineNumber(string line)
            {
                if (line.Length != 180)
                {
                    ErrorMessage = "Invalid line length";
                    return;
                }
                try
                {
                    LineNum = Int16.Parse(line.Substring(3, 2).Trim());
                    Quantity = Int16.Parse(line.Substring(5, 5).Trim());
                    CostEach = float.Parse(line.Substring(10, 10).Trim());
                    TotalItemCost = float.Parse(line.Substring(20, 10).Trim());
                    Description = line.Substring(30, 50).Trim();
                }
                catch (Exception exc)
                {
                    ErrorMessage = $"Error: {exc}";
                }
            }
        }
    }
}
