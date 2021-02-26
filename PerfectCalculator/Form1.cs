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
        public int timeSec = 0;
        public int timeMinute = 0;
        public int timeHour = 0;
        public int errorTimer;
        public int tickRedText = 0;
        public int lastDigitChanged = -1;

        public string errorMessage;
        public string resultField = "";
        public string[] operationSymbols = { "-", "+", "/", "*", "/", "(", ")", "^"};

        public bool haveSymbol = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void MainThread_Tick(object sender, EventArgs e)
        {
            if (calcLabel.Text != resultField)
            {
                calcLabel.Text = ": " + resultField;
            }
            
            if (calcLabel.Text.Length != lastDigitChanged)
            {
                calcLabel.ForeColor = Color.White;

                if (resultLabel.Text == "Упс, вы что-то сделали не так.")
                {
                    resultLabel.Text = "";
                }
            }

            DisplayResult();
        }

        private void DisplayResult()
        {
            char[] charArrayText = new char[resultField.Length];
            string[] arrayText = new string[resultField.Length];

            if (resultField.Length > 0)
            {
                // Преобразование char в string[]
                charArrayText = resultField.ToCharArray();

                for (int i = 0; i < charArrayText.Length; i++)
                {
                    arrayText[i] = charArrayText[i].ToString();
                }

                // Проверка на наличие в тексте знаков мат. операции
                foreach (var textSymbol in arrayText)
                {
                    foreach (var operationSymbol in operationSymbols)
                    {
                        if (textSymbol == operationSymbol) haveSymbol = true;
                    }
                }
            }
            
            // При условии, что в тексте есть символ математической операции выводится результат
            if (haveSymbol == true)
            {
                try
                {
                    string resultOfCalculate = new DataTable().Compute(resultField, null).ToString();
                    resultLabel.Text = "= " + resultOfCalculate;
                    haveSymbol = false;
                    buttonCalculate.FlatAppearance.BorderColor = Color.LightGreen;
                }
                catch (Exception a)
                {
                    buttonCalculate.FlatAppearance.BorderColor = Color.FromArgb(19, 23, 29);
                }

            }
            else
            {
                resultLabel.Text = "= ";
            }
        }

        // Попытка передачи строки в метод Compute при нажатии кнопки Calculate
        private void CalculatingString()
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
        // Левый столбец

        private void button1_Click(object sender, EventArgs e) { resultField += "1"; }

        private void button2_Click(object sender, EventArgs e) { resultField += "2"; }

        private void button3_Click(object sender, EventArgs e) { resultField += "3"; } 

        private void button4_Click(object sender, EventArgs e) { resultField += "4"; } 

        private void button5_Click(object sender, EventArgs e) { resultField += "5"; }

        private void button6_Click(object sender, EventArgs e) { resultField += "6"; } 

        private void button7_Click(object sender, EventArgs e) { resultField += "7"; } 

        private void button8_Click(object sender, EventArgs e) { resultField += "8"; } 

        private void button9_Click(object sender, EventArgs e) { resultField += "9"; } 

        private void button0_Click(object sender, EventArgs e) { resultField += "0"; }

        private void buttonDot_Click(object sender, EventArgs e) { resultField += "/"; }

        private void buttonDel_Click(object sender, EventArgs e)  // Delete
        {
            if (resultField.Length > 0) 
                resultField = resultField.Remove(resultField.Length - 1);
        }

        // Правый столбец
        private void buttonCalculate_Click(object sender, EventArgs e) { CalculatingString(); }

        private void buttonMinus_Click(object sender, EventArgs e) { resultField += "-"; }

        private void buttonPlus_Click(object sender, EventArgs e) { resultField += "+"; }

        private void buttonMultiply_Click(object sender, EventArgs e) { resultField += "*"; } 

        private void buttonDivision_Click(object sender, EventArgs e) { resultField += "/"; } 

        private void buttonExp_Click(object sender, EventArgs e) { resultField += "^"; } 

        private void buttonBracket_Click(object sender, EventArgs e) { resultField += "("; }

        private void buttonReverseBracker_Click(object sender, EventArgs e) { resultField += ")"; } 

        private void buttonClear_Click(object sender, EventArgs e) { resultField = ""; }


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

        // Отображение времени работы
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

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string pKey = e.KeyChar.ToString();
            if (pKey == "1" || pKey == "2")
            {
                calcLabel.Text += pKey;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}