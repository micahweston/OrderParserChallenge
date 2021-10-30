using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 


namespace OrderParserChallenge
{
    public partial class Form1 : Form
    {
        private string filepath;
        Order order0 = new Order();
        Order.LineNumber order0Line0 = new Order.LineNumber();
        Order.LineNumber order0Line1 = new Order.LineNumber();
        Order.LineNumber order0Line2 = new Order.LineNumber();

        Order order1 = new Order();
        Order.LineNumber order1Line0 = new Order.LineNumber();
        Order.LineNumber order1Line1 = new Order.LineNumber();
        Order.LineNumber order1Line2 = new Order.LineNumber();

        Order order2 = new Order();
        Order.LineNumber order2Line0 = new Order.LineNumber();
        Order.LineNumber order2Line1 = new Order.LineNumber();
        Order.LineNumber order2Line2 = new Order.LineNumber();

        public Form1()
        {
            InitializeComponent();

            filepath = "";
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        // use the openFileDialog
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();

            if( dr == DialogResult.OK)
            {
                filepath = openFileDialog1.FileName;
            }
            else
            {
                filepath = "";
            }
        }

        // Displaying all results
        private void button2_Click(object sender, EventArgs e)
        {
            // Clear out old output values
            richTextBox1.Clear();
            
            // richTextBox1.AppendText();

            // Report results
        }

        private void Order_Load(object sender, EventArgs e)
        {

        }

        private void parseData_Click(object sender, EventArgs e)
        {
            // Verify a valid filepath was selected
            if (filepath == "")
            {
                MessageBox.Show("No file was selected");
                return;
            }

            // Store file into an Enumerable
            string[] lines = File.ReadAllLines(filepath);
            string previousLoop = "";
            int lineCount = 0;
            int count = 0;
            foreach (string line in lines)
            {
                if (line.Substring(0, 3) == "100")
                {
                    if(previousLoop == "300")
                    {
                        count++;
                    }
                    if (count == 0)
                    {
                        // Saving Order Info
                        order0.OrderNumber = line.Substring(3, 10).Trim();
                        order0.TotalItems = Int16.Parse(line.Substring(13, 5).Trim());
                        order0.TotalCost = float.Parse(line.Substring(18, 10).Trim());
                        order0.OrderDate = line.Substring(28, 19).Trim();
                        order0.CustomerName = line.Substring(47, 50).Trim();
                        order0.CustomerPhone = line.Substring(97, 30).Trim(); // Fix all phone numbers should be (97, 30) not (97, 50)
                        order0.CustomerEmail = line.Substring(127, 50).Trim();
                        order0.Paid = line.Substring(177, 1).Equals("1") ? true : false;
                        order0.Shipped = line.Substring(178, 1).Equals("1") ? true : false;
                        order0.Completed = line.Substring(179, 1).Equals("1") ? true : false;
                        lineCount = 0;
                    }
                    if (count == 1)
                    {
                        // Saving Order Info
                        order1.OrderNumber = line.Substring(3, 10).Trim();
                        order1.TotalItems = Int16.Parse(line.Substring(13, 5).Trim());
                        order1.TotalCost = float.Parse(line.Substring(18, 10).Trim());
                        order1.OrderDate = line.Substring(28, 19).Trim();
                        order1.CustomerName = line.Substring(47, 50).Trim();
                        order1.CustomerPhone = line.Substring(97, 30).Trim();
                        order1.CustomerEmail = line.Substring(127, 50).Trim();
                        order1.Paid = line.Substring(177, 1).Equals("1") ? true : false;
                        order1.Shipped = line.Substring(178, 1).Equals("1") ? true : false;
                        order1.Completed = line.Substring(179, 1).Equals("1") ? true : false;
                        lineCount = 0;
                    }
                    if (count == 2)
                    {
                        // Saving Order Info
                        order2.OrderNumber = line.Substring(3, 10).Trim();
                        order2.TotalItems = Int16.Parse(line.Substring(13, 5).Trim());
                        order2.TotalCost = float.Parse(line.Substring(18, 10).Trim());
                        order2.OrderDate = line.Substring(28, 19).Trim();
                        order2.CustomerName = line.Substring(47, 50).Trim();
                        order2.CustomerPhone = line.Substring(97, 30).Trim();
                        order2.CustomerEmail = line.Substring(127, 50).Trim();
                        order2.Paid = line.Substring(177, 1).Equals("1") ? true : false;
                        order2.Shipped = line.Substring(178, 1).Equals("1") ? true : false;
                        order2.Completed = line.Substring(179, 1).Equals("1") ? true : false;
                        lineCount = 0;
                    }

                }
                else if (line.Substring(0, 3) == "200")
                {
                    if (count == 0)
                    {
                        order0.AddressLineOne = line.Substring(3, 50).Trim();
                        order0.AddressLineTwo = (line.Substring(53, 50).Trim()).Equals("") ? null : line.Substring(53, 50);
                        order0.City = line.Substring(103, 50).Trim();
                        order0.OrderState = line.Substring(153, 2).Trim();
                        order0.ZipCode = line.Substring(155, 5).Trim();
                    }
                    else if (count == 1)
                    {
                        order1.AddressLineOne = line.Substring(3, 50).Trim();
                        order1.AddressLineTwo = (line.Substring(53, 50).Trim()).Equals("") ? null : line.Substring(53, 50);
                        order1.City = line.Substring(103, 50).Trim();
                        order1.OrderState = line.Substring(153, 2).Trim();
                        order1.ZipCode = line.Substring(155, 5).Trim();
                    }
                    else if (count == 2)
                    {
                        order2.AddressLineOne = line.Substring(3, 50).Trim();
                        order2.AddressLineTwo = (line.Substring(53, 50).Trim()).Equals("") ? null : line.Substring(53, 50);
                        order2.City = line.Substring(103, 50).Trim();
                        order2.OrderState = line.Substring(153, 2).Trim();
                        order2.ZipCode = line.Substring(155, 5).Trim();
                    }
                }
                else if (line.Substring(0, 3) == "300")
                {

                    if (count == 0)
                    {
                        if (lineCount == 0)
                        {
                            order0.ValidOrder = true;
                            order0Line0.LineNum = Int16.Parse(line.Substring(3, 2).Trim());
                            order0Line0.Quantity = Int16.Parse(line.Substring(5, 5).Trim());
                            order0Line0.CostEach = float.Parse(line.Substring(10, 10).Trim());
                            if (line.Substring(20, 10).Trim().Equals(typeof(float)))
                            {
                                order0Line0.TotalItemCost = float.Parse(line.Substring(20, 10).Trim());
                            }
                            else
                            {
                                if(order0.ValidOrder == false)
                                {
                                    continue;
                                }
                                else
                                {
                                    order0.ErrorMessage = "Not a valid Total Item Cost: Must be a numeric value.";
                                    order0.ValidOrder = false;
                                }
                            }
                            order0Line0.Description = line.Substring(30, 50).Trim();
                            lineCount += 1;
                        }
                        else if (lineCount == 1)
                        {
                            order0Line1.LineNum = Int16.Parse(line.Substring(3, 2).Trim());
                            order0Line1.Quantity = Int16.Parse(line.Substring(5, 5).Trim());
                            order0Line1.CostEach = float.Parse(line.Substring(10, 10).Trim());
                            if (line.Substring(20, 10).Trim().Equals(typeof(float)))
                            {
                                order0Line1.TotalItemCost = float.Parse(line.Substring(20, 10).Trim());
                                
                            }
                            else
                            {
                                if (order0.ValidOrder == false)
                                {
                                    continue;
                                }
                                else
                                {
                                    order0.ErrorMessage = "Not a valid Total Item Cost: Must be a numeric value.";
                                    order0.ValidOrder = false;
                                }
                            }
                            order0Line1.Description = line.Substring(30, 50).Trim();
                            lineCount += 1;
                        }
                        else if (lineCount == 2)
                        {
                            order0Line2.LineNum = Int16.Parse(line.Substring(3, 2).Trim());
                            order0Line2.Quantity = Int16.Parse(line.Substring(5, 5).Trim());
                            order0Line2.CostEach = float.Parse(line.Substring(10, 10).Trim());
                            if (line.Substring(20, 10).Trim().Equals(typeof(float)))
                            {
                                order0Line2.TotalItemCost = float.Parse(line.Substring(20, 10).Trim());
                                
                            }
                            else
                            {
                                if (order0.ValidOrder == false)
                                {
                                    continue;
                                }
                                else
                                {
                                    order0.ErrorMessage = "Not a valid Total Item Cost: Must be a numeric value.";
                                    order0.ValidOrder = false;
                                }
                            }
                            order0Line2.Description = line.Substring(30, 50).Trim();
                            lineCount += 1;
                        }
                    }
                    else if (count == 1)
                    {
                        if (lineCount == 0)
                        {
                            order1.ValidOrder = true;
                            order1Line0.LineNum = Int16.Parse(line.Substring(3, 2).Trim());
                            order1Line0.Quantity = Int16.Parse(line.Substring(5, 5).Trim());
                            order1Line0.CostEach = float.Parse(line.Substring(10, 10).Trim());
                            if (line.Substring(20, 10).Trim().Equals(typeof(float)))
                            {
                                order1Line0.TotalItemCost = float.Parse(line.Substring(20, 10).Trim());
                                
                            }
                            else
                            {
                                if (order1.ValidOrder == false)
                                {
                                    continue;
                                }
                                else
                                {
                                    order1.ErrorMessage = "Not a valid Total Item Cost: Must be a numeric value.";
                                    order1.ValidOrder = false;
                                }
                            }
                            order1Line0.Description = line.Substring(30, 50).Trim();
                            lineCount += 1;
                        }
                        else if (lineCount == 1)
                        {
                            order1Line1.LineNum = Int16.Parse(line.Substring(3, 2).Trim());
                            order1Line1.Quantity = Int16.Parse(line.Substring(5, 5).Trim());
                            order1Line1.CostEach = float.Parse(line.Substring(10, 10).Trim());
                            if (line.Substring(20, 10).Trim().Equals(typeof(float)))
                            {
                                order1Line1.TotalItemCost = float.Parse(line.Substring(20, 10).Trim());
                                
                            }
                            else
                            {
                                if (order1.ValidOrder == false)
                                {
                                    continue;
                                }
                                else
                                {
                                    order1.ErrorMessage = "Not a valid Total Item Cost: Must be a numeric value.";
                                    order1.ValidOrder = false;
                                }
                            }
                            order1Line1.Description = line.Substring(30, 50).Trim();
                            lineCount += 1;
                        }
                        else if (lineCount == 2)
                        {
                            order1Line2.LineNum = Int16.Parse(line.Substring(3, 2).Trim());
                            order1Line2.Quantity = Int16.Parse(line.Substring(5, 5).Trim());
                            order1Line2.CostEach = float.Parse(line.Substring(10, 10).Trim());
                            if (line.Substring(20, 10).Trim().Equals(typeof(float)))
                            {
                                order1Line2.TotalItemCost = float.Parse(line.Substring(20, 10).Trim());
                               
                            }
                            else
                            {
                                if (order1.ValidOrder == false)
                                {
                                    continue;
                                }
                                else
                                {
                                    order1.ErrorMessage = "Not a valid Total Item Cost: Must be a numeric value.";
                                    order1.ValidOrder = false;
                                }
                            }
                            order1Line2.Description = line.Substring(30, 50).Trim();
                            lineCount += 1;
                        }
                    }
                    else if (count == 2)
                    {
                        if (lineCount == 0)
                        {
                            order2.ValidOrder = true;
                            order2Line0.LineNum = Int16.Parse(line.Substring(3, 2).Trim());
                            order2Line0.Quantity = Int16.Parse(line.Substring(5, 5).Trim());
                            order2Line0.CostEach = float.Parse(line.Substring(10, 10).Trim());
                            if (line.Substring(20, 10).Trim().Equals(typeof(float)))
                            {
                                order2Line0.TotalItemCost = float.Parse(line.Substring(20, 10).Trim());
                                
                            }
                            else
                            {
                                if (order2.ValidOrder == false)
                                {
                                    continue;
                                }
                                else
                                {
                                    order2.ErrorMessage = "Not a valid Total Item Cost: Must be a numeric value.";
                                    order2.ValidOrder = false;
                                }
                            }
                            order2Line0.Description = line.Substring(30, 50).Trim();
                            lineCount += 1;
                        }
                        else if (lineCount == 1)
                        {
                            order2Line1.LineNum = Int16.Parse(line.Substring(3, 2).Trim());
                            order2Line1.Quantity = Int16.Parse(line.Substring(5, 5).Trim());
                            order2Line1.CostEach = float.Parse(line.Substring(10, 10).Trim());
                            if (line.Substring(20, 10).Trim().Equals(typeof(float)))
                            {
                                order2Line1.TotalItemCost = float.Parse(line.Substring(20, 10).Trim());
                                
                            }
                            else
                            {
                                if (order2.ValidOrder == false)
                                {
                                    continue;
                                }
                                else
                                {
                                    order2.ErrorMessage = "Not a valid Total Item Cost: Must be a numeric value.";
                                    order2.ValidOrder = false;
                                }
                            }
                            order2Line1.Description = line.Substring(30, 50).Trim();
                            lineCount += 1;
                        }
                        else if (lineCount == 2)
                        {
                            order2Line2.LineNum = Int16.Parse(line.Substring(3, 2).Trim());
                            order2Line2.Quantity = Int16.Parse(line.Substring(5, 5).Trim());
                            order2Line2.CostEach = float.Parse(line.Substring(10, 10).Trim());
                            if (line.Substring(20, 10).Trim().Equals(typeof(float)))
                            {
                                order2Line2.TotalItemCost = float.Parse(line.Substring(20, 10).Trim());
                                
                            }
                            else
                            {
                                if (order2.ValidOrder == false)
                                {
                                    continue;
                                }
                                else
                                {
                                    order2.ErrorMessage = "Not a valid Total Item Cost: Must be a numeric value.";
                                    order2.ValidOrder = false;
                                }
                            }
                            order2Line2.Description = line.Substring(30, 50).Trim();
                            lineCount += 1;
                        }
                    }
                }
                previousLoop = line.Substring(0, 3);
            }
        }

        private void account1_Click(object sender, EventArgs e)
        {
            string displayAccountOne = $"Order Number: {order0.OrderNumber}\n Total Items: {order0.TotalItems}\n Total Cost: {order0.TotalCost}\n" +
                   $"Order Date: {order0.OrderDate}\n Customer Name: {order0.CustomerName}\n Customer Phone #: {order0.CustomerPhone}\n" +
                   $"Customer Email: {order0.CustomerEmail}\n Paid: {order0.Paid}\n Shipped: {order0.Shipped}\n Order Completed: {order0.Completed}\n\n";
            string displayAccountAddressOne = $"Customer Address: {order0.AddressLineOne}{order0.AddressLineTwo}\n{order0.City}, {order0.OrderState} {order0.ZipCode}\n\n";
            string errorOne = $"This Account order has an error: {order0.ErrorMessage}\n\n";
            string displayOrderDetailsOne = "";
            // validate how many orders
            if (order0Line0 != null && order0Line1 != null && order0Line2 != null)
            {
                displayOrderDetailsOne = $"Order Number: {order0Line0.LineNum}: Quantity: {order0Line0.Quantity}, Cost per item: {order0Line0.CostEach}, " +
                    $"Total Cost: {order0Line0.TotalItemCost}, Description: {order0Line0.Description}\n\nOrder Number: {order0Line1.LineNum}: Quantity: {order0Line1.Quantity}, " +
                    $"Cost per item: {order0Line0.CostEach}, Total Cost: {order0Line1.TotalItemCost}, Description: {order0Line1.Description}\n\n" +
                    $"Order Number: {order0Line2.LineNum}: Quantity: {order0Line2.Quantity}, Cost per item: {order0Line2.CostEach}, Total Cost: {order0Line2.TotalItemCost}" +
                    $", Description: {order0Line2.Description}\n\n";
            }
            else if(order0Line0 != null && order0Line1 != null && order0Line2 == null)
            {
                displayOrderDetailsOne = $"Order Number: {order0Line0.LineNum}: Quantity: {order0Line0.Quantity}, Cost per item: {order0Line0.CostEach}, " +
                    $"Total Cost: {order0Line0.TotalItemCost}, Description: {order0Line0.Description}\n\nOrder Number: {order0Line1.LineNum}: Quantity: {order0Line1.Quantity}, " +
                    $"Cost per item: {order0Line0.CostEach}, Total Cost: {order0Line1.TotalItemCost}, Description: {order0Line1.Description}\n\n";
            }
            else if (order0Line0 != null && order0Line1 == null && order0Line2 == null)
            {
                displayOrderDetailsOne = $"Order Number: {order0Line0.LineNum}: Quantity: {order0Line0.Quantity}, Cost per item: {order0Line0.CostEach}, " +
                    $"Total Cost: {order0Line0.TotalItemCost}, Description: {order0Line0.Description}\n\n";
            }
            else
            {
                displayOrderDetailsOne = "No order details to be shown.\n\n";
            }
            richTextBox1.Clear();
            if (order0.ValidOrder == true)
            {   
                richTextBox1.AppendText(displayAccountOne + displayAccountAddressOne + displayOrderDetailsOne);
            }
            else if(order0.ValidOrder == false)
            {
                richTextBox1.AppendText(displayAccountOne + displayAccountAddressOne + displayOrderDetailsOne + errorOne);
            }

        }

        private void account2_Click(object sender, EventArgs e)
        {
            string displayAccountTwo = $"Order Number: {order1.OrderNumber}\n Total Items: {order1.TotalItems}\n Total Cost: {order1.TotalCost}\n" +
                    $"Order Date: {order1.OrderDate}\n Customer Name: {order1.CustomerName}\n Customer Phone #: {order1.CustomerPhone}\n" +
                    $"Customer Email: {order1.CustomerEmail}\n Paid: {order1.Paid}\n Shipped: {order1.Shipped}\n Order Completed: {order1.Completed}\n\n";
            string displayAccountAddressTwo = $"Customer Address: {order1.AddressLineOne}{order1.AddressLineTwo}\n{order1.City}, {order1.OrderState} {order1.ZipCode}\n\n";
            string errorTwo = $"This Account order has an error: {order1.ErrorMessage}";
            string displayOrderDetailsTwo = "";
            // validate how many orders
            if (order1Line0 != null && order1Line1 != null && order1Line2 != null)
            {
                displayOrderDetailsTwo = $"Order Number: {order1Line0.LineNum}: Quantity: {order1Line0.Quantity}, Cost per item: {order1Line0.CostEach}, " +
                    $"Total Cost: {order1Line0.TotalItemCost}, Description: {order1Line0.Description}\n\nOrder Number: {order1Line1.LineNum}: Quantity: {order1Line1.Quantity}, " +
                    $"Cost per item: {order1Line0.CostEach}, Total Cost: {order1Line1.TotalItemCost}, Description: {order1Line1.Description}\n\n" +
                    $"Order Number: {order1Line2.LineNum}: Quantity: {order1Line2.Quantity}, Cost per item: {order1Line2.CostEach}, Total Cost: {order1Line2.TotalItemCost}" +
                    $", Description: {order1Line2.Description}\n\n";
            }
            else if (order1Line0 != null && order1Line1 != null && order1Line2 == null)
            {
                displayOrderDetailsTwo = $"Order Number: {order1Line0.LineNum}: Quantity: {order1Line0.Quantity}, Cost per item: {order1Line0.CostEach}, " +
                    $"Total Cost: {order1Line0.TotalItemCost}, Description: {order1Line0.Description}\n\nOrder Number: {order1Line1.LineNum}: Quantity: {order1Line1.Quantity}, " +
                    $"Cost per item: {order1Line0.CostEach}, Total Cost: {order1Line1.TotalItemCost}, Description: {order1Line1.Description}\n\n";
            }
            else if (order1Line0 != null && order1Line1 == null && order1Line2 == null)
            {
                displayOrderDetailsTwo = $"Order Number: {order1Line0.LineNum}: Quantity: {order1Line0.Quantity}, Cost per item: {order1Line0.CostEach}, " +
                    $"Total Cost: {order1Line0.TotalItemCost}, Description: {order1Line0.Description}\n\n";
            }
            else
            {
                displayOrderDetailsTwo = "No order details to be shown.\n\n";
            }
            richTextBox1.Clear();
            if (order1.ValidOrder)
            {
                
                richTextBox1.AppendText(displayAccountTwo + displayAccountAddressTwo + displayOrderDetailsTwo);
            }
            else
            {
                
                richTextBox1.AppendText(displayAccountTwo + displayAccountAddressTwo + displayOrderDetailsTwo  + errorTwo);
            }
        }

        private void Account3_Click(object sender, EventArgs e)
        {
            string displayAccountThree = $"Order Number: {order2.OrderNumber}\n Total Items: {order2.TotalItems}\n Total Cost: {order2.TotalCost}\n" +
                    $"Order Date: {order2.OrderDate}\n Customer Name: {order2.CustomerName}\n Customer Phone #: {order2.CustomerPhone}\n" +
                    $"Customer Email: {order2.CustomerEmail}\n Paid: {order2.Paid}\n Shipped: {order2.Shipped}\n Order Completed: {order2.Completed}\n\n";
            string displayAccountAddressThree = $"Customer Address: {order2.AddressLineOne}{order2.AddressLineTwo}\n{order2.City}, {order2.OrderState} {order2.ZipCode}\n\n";
            string errorThree = $"This Account order has an error: {order2.ErrorMessage}";
            string displayOrderDetailsThree = "";
            // validate how many orders
            if (order2Line0 != null && order2Line1 != null && order2Line2 != null)
            {
                displayOrderDetailsThree = $"Order Number: {order2Line0.LineNum}: Quantity: {order2Line0.Quantity}, Cost per item: {order2Line0.CostEach}, " +
                    $"Total Cost: {order2Line0.TotalItemCost}, Description: {order2Line0.Description}\n\nOrder Number: {order2Line1.LineNum}: Quantity: {order2Line1.Quantity}, " +
                    $"Cost per item: {order2Line0.CostEach}, Total Cost: {order2Line1.TotalItemCost}, Description: {order2Line1.Description}\n\n" +
                    $"Order Number: {order2Line2.LineNum}: Quantity: {order2Line2.Quantity}, Cost per item: {order2Line2.CostEach}, Total Cost: {order2Line2.TotalItemCost}" +
                    $", Description: {order2Line2.Description}\n\n";
            }
            else if (order2Line0 != null && order2Line1 != null && order2Line2 == null)
            {
                displayOrderDetailsThree = $"Order Number: {order2Line0.LineNum}: Quantity: {order2Line0.Quantity}, Cost per item: {order2Line0.CostEach}, " +
                    $"Total Cost: {order2Line0.TotalItemCost}, Description: {order2Line0.Description}\n\nOrder Number: {order2Line1.LineNum}: Quantity: {order2Line1.Quantity}, " +
                    $"Cost per item: {order2Line0.CostEach}, Total Cost: {order2Line1.TotalItemCost}, Description: {order2Line1.Description}\n\n";
            }
            else if (order2Line0 != null && order2Line1 == null && order2Line2 == null)
            {
                displayOrderDetailsThree = $"Order Number: {order2Line0.LineNum}: Quantity: {order2Line0.Quantity}, Cost per item: {order2Line0.CostEach}, " +
                    $"Total Cost: {order2Line0.TotalItemCost}, Description: {order2Line0.Description}\n\n";
            }
            else
            {
                displayOrderDetailsThree = "No order details to be shown.\n\n";
            }
            richTextBox1.Clear();
            if (order2.ValidOrder)
            {
                
                richTextBox1.AppendText(displayAccountThree + displayAccountAddressThree + displayOrderDetailsThree);
            }
            else
            {
                
                richTextBox1.AppendText(displayAccountThree + displayAccountAddressThree + displayOrderDetailsThree + errorThree);
            }
        }
    }
}
