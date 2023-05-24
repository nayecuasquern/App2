using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage : ContentPage
    {

        private string currentOperator;
        private double firstNumber;
        private double secondNumber;

        public MainPage()
        {
            InitializeComponent();
            numberEntry.Focused += (sender, e) => numberEntry.Unfocus();
        }

        // Método para eliminar un número al tocar el botón "C"
        private void OnClearClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(numberEntry.Text))
            {
                numberEntry.Text = numberEntry.Text.Substring(0, numberEntry.Text.Length - 1);
            }
        }

        // Método para eliminar todo al tocar el botón "AC"
        private void OnAllClearClicked(object sender, EventArgs e)
        {
            numberEntry.Text = string.Empty;
            resultLabel.Text = string.Empty;
        }

        private double CalculateResult()
        {
            double result = 0;

            switch (currentOperator)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "x":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
            }

            return result;
        }


        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;

            if (buttonText == "+" || buttonText == "-" || buttonText == "x" || buttonText == "/")
            {
                currentOperator = buttonText;
                firstNumber = double.Parse(numberEntry.Text);
                numberEntry.Text = string.Empty;
            }
            else if (buttonText == "=")
            {
                secondNumber = double.Parse(numberEntry.Text);
                double result = CalculateResult();
                resultLabel.Text = result.ToString();
                numberEntry.Text = result.ToString();
            }
            else
            {
                numberEntry.Text += buttonText;
            }
        }


    }
}
