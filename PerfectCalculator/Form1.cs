using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerfectCalculator
{
    public partial class Form1 : Form
    {
        int timeSec = 0;
        int timeMinute = 0;
        int timeHour = 0;
        int errorTimer;
        int tickRedText = 0;
        int lastDigitChanged = -1;

        string errorMessage;
        string resultField = "";
        string[] operationSymbols = { "-", "+", "/", "*"};

        public Form1()
        {
            InitializeComponent();
        }

        private void workingTime_Tick(object sender, EventArgs e)
        {
            timeSec++;

            if (timeSec >= 59)
            {
                timeSec = 0;
                timeMinute++;
            }

            if (timeMinute >= 60)
            {
                timeMinute = 0;
                timeHour++;
            }

            labelTime.Text = "Время работы программы: " + timeHour + "ч " + timeMinute + "м " + timeSec + "с ";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (calcLabel.Text != resultField)
            {
                calcLabel.Text = ": " + resultField;
            }

            if (calcLabel.Text.Length > 5) { buttonCalculate.FlatAppearance.BorderColor = Color.LightGreen; } 
            else { buttonCalculate.FlatAppearance.BorderColor = Color.FromArgb(19, 23, 29); }

            if (calcLabel.Text.Length != lastDigitChanged)
            {
                calcLabel.ForeColor = Color.White;
                if (resultLabel.Text == "Упс, вы что-то сделали не так.") resultLabel.Text = "";
            }
        }

        // Ряд функций, отвечающий за event при нажатии кнопок
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                string resultOfCalculate = new DataTable().Compute(resultField, null).ToString();
                resultLabel.Text = "= " + resultOfCalculate;
            }
            catch (Exception a)
            {
                ErrorTimer.Enabled = true;
                errorMessage = a.ToString();

                resultLabel.Text = "Упс, вы что-то сделали не так.";
                lastDigitChanged = calcLabel.Text.Length;
                calcLabel.ForeColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e) // 1
        {
            resultField += "1";
        }

        private void button2_Click(object sender, EventArgs e) // 2
        {
            resultField += "2";
        }

        private void button3_Click(object sender, EventArgs e) // 3
        {
            resultField += "3";
        }

        private void button4_Click(object sender, EventArgs e) // 4
        {
            resultField += "4";
        }

        private void button5_Click(object sender, EventArgs e) // 5
        {
            resultField += "5";
        }

        private void button6_Click(object sender, EventArgs e) // 6
        {
            resultField += "6";
        }

        private void button7_Click(object sender, EventArgs e) // 7
        {
            resultField += "7";
        }

        private void button8_Click(object sender, EventArgs e) // 8
        {
            resultField += "8";
        }

        private void button9_Click(object sender, EventArgs e) // 9
        {
            resultField += "9";
        }

        private void button0_Click(object sender, EventArgs e) // 0
        {
            resultField += "0";
        }

        private void buttonDot_Click(object sender, EventArgs e) // .
        {
            resultField += ".";
        }

        private void buttonDel_Click(object sender, EventArgs e) // Delete
        {
            if (resultField.Length > 0) 
                resultField = resultField.Remove(resultField.Length - 1);
        }

        private void buttonMinus_Click(object sender, EventArgs e) // -
        {
            resultField += "-";
        }

        private void buttonPlus_Click(object sender, EventArgs e) // +
        {
            resultField += "+";
        }

        private void buttonMultiply_Click(object sender, EventArgs e) // *
        {
            resultField += "*";
        }

        private void buttonDivision_Click(object sender, EventArgs e) // /
        {
            resultField += "/";
        }

        private void buttonExp_Click(object sender, EventArgs e) // ^
        {
            resultField += "^";
        }

        private void buttonBracket_Click(object sender, EventArgs e) // (
        {
            resultField += "(";

        }

        private void buttonReverseBracker_Click(object sender, EventArgs e) // )
        {
            resultField += ")";
        }

        private void buttonClear_Click(object sender, EventArgs e) // clear
        {
            resultField = "";

        }

        // Действия при ошибке
        private void ErrorTimer_Tick(object sender, EventArgs e)
        {
            errorTimer++;
            errorButton.Visible = true;
            if (errorTimer >= 50)
            {
                errorTimer = 0;
                errorButton.Visible = false;
                ErrorTimer.Enabled = false;
            }
        }

        private void errorButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(errorMessage);
        }

        private void redText_Tick(object sender, EventArgs e)
        {
        }
        // 
    }
}