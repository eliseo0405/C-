using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageBasic_2m3
{
    public partial class Form1 : Form
    {
        private bool isOperationAdded;
        private String operation;
        private double result = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            if (lblRes.Text.Equals("0") || isOperationAdded)
            {
                lblRes.Text = "";
            }

            isOperationAdded = false;

            Button btn = (Button)sender;
            if(btn.Text.Equals(".",StringComparison.CurrentCultureIgnoreCase)) //puede usarse en comparaciones de cadenas minus o mayus
            {
                if (lblRes.Text.Contains("."))
                {
                    return;
                }
            }
            lblRes.Text += btn.Text;
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (result == 0)
            {
                result = Double.Parse(lblRes.Text);
                lblOp.Text = lblRes.Text + " " + btn.Text;
                operation = btn.Text;
                isOperationAdded = true;

            }
            else
            {

                operation = btn.Text;
                isOperationAdded = true;
                PerformOperation(operation);
                lblOp.Text = lblRes.Text + " " + btn.Text;

            }
        }

        private void PerformOperation(String operation)
        {
            
            switch (operation)
            {
                case "+":
                    result = result + Double.Parse(lblRes.Text);
                    break;

                case "-":
                    result = result - Double.Parse(lblRes.Text);
                    break;

                case "x":
                    result = result * Double.Parse(lblRes.Text);
                    break;

                case "÷":
                    double temp = Double.Parse(lblRes.Text);

                    if (result == 0 && temp == 0)
                    {

                        lblRes.Text = "CONVERGE :)";

                    }else if(temp == 0){

                        lblRes.Text = "DIVERGE :)";

                    }
                    else{

                        result = result / temp;

                    }
                    break;

                default:
                    break;

            }
            lblRes.Text = result.ToString();
            operation = "";
        }
    }
}
