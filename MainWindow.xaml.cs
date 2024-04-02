using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SVPP_CS_Lab1_task1_calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double num1 = 0;
        private string? op = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Обработчик кнопки изменения оформления.
        /// </summary>
        private void ButtonLight_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            string buttonContent = (string)button.Content;
            // Темные тона оформления
            if (buttonContent == "night")
            {
                button.Content = "day";
                button.ToolTip = "Включить светлый режим";
                GridMain.Background = new SolidColorBrush(Colors.Black);

                foreach (var element in GridMain.Children)
                {
                    if (element is Button)
                    {
                        Button butt = (Button)element;
                        butt.Background = new SolidColorBrush(Colors.DarkBlue);
                        butt.Foreground = new SolidColorBrush(Colors.White);
                    }
                    if (element is TextBox)
                    {
                        TextBox tb = (TextBox)element;
                        tb.Background = new SolidColorBrush(Colors.Black);
                        tb.Foreground = new SolidColorBrush(Colors.White);
                    }
                }
            }
            // Светлые тона оформления
            if (buttonContent == "day")
            {
                button.Content = "night";
                button.ToolTip = "Включить темный режим";
                GridMain.Background = new SolidColorBrush(Colors.Gray);

                foreach (var element in GridMain.Children)
                {
                    if (element is Button)
                    {
                        Button butt = (Button)element;
                        butt.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                        butt.Foreground = new SolidColorBrush(Colors.Black);
                    }
                    if (element is TextBox)
                    {
                        TextBox tb = (TextBox)element;
                        tb.Background = new SolidColorBrush(Colors.White);
                        tb.Foreground = new SolidColorBrush(Colors.Black);
                    }
                }
            }

        }

        /// <summary>
        /// Обработчик кнопки сброса С.
        /// </summary>
        private void ButtonС_Click(object sender, RoutedEventArgs e)
        {
            num1 = 0;
            op = null;
            TextBox_Numbers.Text = "0";
        }

        /// <summary>
        ///  Обработчик нажатия цифровых кнопок
        /// </summary>
        private void ButtonNum_Click(object sender, RoutedEventArgs e)
        {
            string number = (string)((Button)sender).Content;
            if (TextBox_Numbers.Text.Length < 12)
            {
                if (TextBox_Numbers.Text == "0") TextBox_Numbers.Text = number;
                else
                    TextBox_Numbers.Text += number;
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки операции.
        /// </summary>
        private void ButtonOperation_Click(object sender, RoutedEventArgs e)
        {
            string TempOp = (string)((Button)sender).Content;

            // Обработка нажатия кнопки "-" для ввода отрицательного числа.
            if ((TempOp == "-" && TextBox_Numbers.Text == "0") || TextBox_Numbers.Text == "-" ) TextBox_Numbers.Text = TempOp;
            else
            {
                num1 = Convert.ToDouble(TextBox_Numbers.Text);
                op = TempOp;
                TextBox_Numbers.Text = "0";
            }
              
        }
        /// <summary>
        /// Выполняет опреацию
        /// </summary>
        private void runOperation()
        {
            double num2 = Convert.ToDouble(TextBox_Numbers.Text);
            double result = 0;
            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
            }
            op = null;
            TextBox_Numbers.Text = result.ToString();
        }

        /// <summary>
        /// Обработчик нажатия кнопки =.
        /// </summary>
        private void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            runOperation();
        }

        /// <summary>
        /// Обработчик кнопки удаления одного символа <- 
        /// </summary>
        private void ButtonDeleteNum_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Numbers.Text != "0" && TextBox_Numbers.Text.Length > 1) TextBox_Numbers.Text = TextBox_Numbers.Text.Remove(TextBox_Numbers.Text.Length - 1);
            else TextBox_Numbers.Text = "0";
        }

        /// <summary>
        /// Обработчик нажатия кнопки точки.
        /// </summary>
        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            if (!TextBox_Numbers.Text.Contains(TextBox_Numbers.Text) && TextBox_Numbers.Text != "-" ) TextBox_Numbers.Text += (string) ((Button) sender).Content;
        }
    }
}