using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApplication
{
    //Generic delegate
    public delegate T Formula<T>(T arg1, T arg2);

    public partial class FrmCalculator : Form
    {
        private double num1, num2;
        CalculatorClass cal;
        public FrmCalculator()
        {
            InitializeComponent();
            cal = new CalculatorClass();
        }

        public class CalculatorClass
        {
            public Formula<double> formula;

            //2 Methods that return sum and difference
            public double GetSum(double num1, double num2)
            {
                return num1 + num2;
            }
            public double GetDifference(double num1, double num2)
            {
                return num1 - num2;
            }

            public double GetProduct(double num1, double num2)
            {
                return num1 * num2;
            }

            public double GetQuotient(double num1, double num2)
            {
                return num1 / num2;
            }

            //Add Event Accessor
            public event Formula<double> CalculateEvent;

            public void AddDelegate(Formula<double> del)
            {
                Console.WriteLine("Added the Delegate");
            }

            public void RemoveDelegate(Formula<double> del)
            {

                Console.WriteLine("Removed the Delegate");
            }
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {

            num1 = Double.Parse(txtBoxInput1.Text);
            num2 = Double.Parse(txtBoxInput2.Text);


            if (cbOperator.SelectedItem.ToString() == "+")
            {
                cal.CalculateEvent += new Formula<double>(cal.GetSum);
                lblDisplayTotal.Text = cal.GetSum(num1, num2).ToString();
                cal.CalculateEvent -= new Formula<double>(cal.GetSum);
            } 

            else if (cbOperator.SelectedItem.ToString() == "-")
            { 
                cal.CalculateEvent += new Formula<double>(cal.GetDifference);
                lblDisplayTotal.Text = cal.GetDifference(num1, num2).ToString();
                cal.CalculateEvent -= new Formula<double>(cal.GetDifference);
            }

            else if (cbOperator.SelectedItem.ToString() == "*")
            {
                cal.CalculateEvent += new Formula<double>(cal.GetProduct);
                lblDisplayTotal.Text = cal.GetProduct(num1, num2).ToString();
                cal.CalculateEvent -= new Formula<double>(cal.GetProduct);
            }

            else if (cbOperator.SelectedItem.ToString() == "/")
            {
                cal.CalculateEvent += new Formula<double>(cal.GetQuotient);
                lblDisplayTotal.Text = cal.GetQuotient(num1, num2).ToString();
                cal.CalculateEvent -= new Formula<double>(cal.GetQuotient);
            }
        
            else
            {
                MessageBox.Show("Please enter valid numbers in both input fields.");
            }
        }
    }
}