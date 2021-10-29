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

        // Objects for order data
        private struct Order
        {
            public int OrderNumber;
            public int TotalItems;
            public int TotalCost;
            public string OrderDate;
            public string CustomerName;
            public string CustomerPhone;
            public string CustomerEmail;
            public bool Paid;
            public bool Shipped;
            public bool Completed;
            public Order(int orderNumber, int totalItems, int totalCost, string orderDate, string customerName, 
                string customerPhone, string customerEmail, bool paid, bool shipped, bool completed)
            {
                OrderNumber = orderNumber;
                TotalItems = totalItems;
                TotalCost = totalCost;
                OrderDate = orderDate;
                CustomerName = customerName;
                CustomerPhone = customerPhone;
                CustomerEmail = customerEmail;
                Paid = paid;
                Shipped = shipped;
                Completed = completed;
            }
        }
        private struct Address
        {

        }
        private struct OrderDetails
        {

        }

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

        // Displaying the file
        private void button2_Click(object sender, EventArgs e)
        {
            // Clear out old output values
            richTextBox1.Clear();

            // Verify a valid filepath was selected
            if( filepath == "")
            {
                MessageBox.Show("No file was selected");
                return;
            }

            // Open connection to file
            StreamReader sr = new StreamReader(filepath);

            // Create out file processing loop
            while( !sr.EndOfStream)
            {
                // Read each line
                string line = sr.ReadLine();

                // Read lines between each category 100, 200, 300
                string res = line.Substring(0, 1);
                if(res == "1")
                {
                    richTextBox1.AppendText(line + "\n");
                }

                // richTextBox1.AppendText();
            }

            // Close connection to file
            sr.Close();

            // Report results
        }
    }
}
