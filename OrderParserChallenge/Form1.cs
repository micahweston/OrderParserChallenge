// Order parsing challenge. 
// Author: Micah Weston
// Date: 10/29/2021

// This program is designed to take a specific file, and parse through each line to extract information for account holder,
// and order details.

// TODO: Remove redundancy from file by creating future classes. Research on future data structures. How to store data in array,
// TODO CONT: then pass array values over to class to parse files. Each array will hold values depending on line item, and also which 
// TODO CONT: account is being passed. 
// TODO CONT: Limitations: Further research is needing to be done on C# syntax to make sure that redundancy is limited. And program can be more modular.

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
        // declaring variables needed for file.
        private string filepath;
        List<Order> orders = new List<Order>();

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
                MessageBox.Show("File Loaded.");
            }
            else
            {
                filepath = "";
            }
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

            // clear orders list
            orders.Clear();
            // Store file into an Enumerable
            string[] lines = File.ReadAllLines(filepath);
            Console.WriteLine(lines);
            Order lastOrder = null;
            foreach (string line in lines)
            {
                switch (line.Substring(0, 3)) {
                    case "100":
                        orders.Add(new Order(line));
                        break;
                    case "200":
                        lastOrder.OrderAddress = new Order.Address(line);
                        Console.WriteLine(lastOrder.OrderAddress);
                        break;
                    case "300":
                        lastOrder.items.Add(new Order.LineNumber(line));
                        Console.WriteLine(lastOrder.items);
                        break;
                    default:
                        MessageBox.Show("File Format incorrect");
                        break;
                }
                lastOrder = orders.Last();
            }
            MessageBox.Show("File parsing finished.");
        }

        // Display data for account one. Needs to be stored in own class, and remove redundancy. 
        private void account1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            foreach (var order in orders)
            {
                richTextBox1.AppendText($"Order Number: {order.OrderNumber}\nTotal Items: {order.TotalItems}\nTotal Cost: {order.TotalCost}\n" +
                $"Order Date: {order.OrderDate}\nCustomer Name: {order.CustomerName}\nCustomer Phone: {order.CustomerPhone}\nCustomer Email:" +
                $"{order.CustomerEmail}\n Customer Paid: {order.Paid}\nOrder Shipped: {order.Shipped}\nOrder Completed: {order.Completed}\n\n");    
            }

        }

        
    }
}
