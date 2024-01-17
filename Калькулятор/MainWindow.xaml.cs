using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Калькулятор
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

            foreach(UIElement el in GroupButton.Children)
            {
                if(el is Button)
                {
                    ((Button)el).Click += ButtonClick;
                }
            }
        }
        private void ButtonClick(Object sender, RoutedEventArgs e)
        {
            try
            {
                string textButton = ((Button)e.OriginalSource).Content.ToString();


                if (textButton == "C")
                {
                    Content.Clear();
                }
                else if (textButton == "=")
                {
                    Content.Text = new DataTable().Compute(Content.Text, null).ToString();
                }
                else if (textButton == "^2")
                {
                    double a = Double.Parse(Content.Text);
                    double b = 2;
                    double result = Math.Pow(a, b);
                    Content.Clear();
                    Content.Text = result.ToString();
                }
                else if (textButton == "√")
                {
                    double c = Double.Parse(Content.Text);
                    double result = Math.Sqrt(c);
                    Content.Clear();
                    Content.Text = result.ToString();
                }
                else if (textButton == "log2")
                {
                    double v = Double.Parse(Content.Text);
                    double result = Math.Log(v,2);
                    Content.Clear();
                    Content.Text = result.ToString();
                }
                else if (textButton == "sin")
                {
                    double s = Double.Parse(Content.Text);
                    double result = Math.Sin(s);
                    Content.Clear();
                    Content.Text = result.ToString();
                }
                else if (textButton == "cos")
                {
                    double m = Double.Parse(Content.Text);
                    double result = Math.Cos(m);
                    Content.Clear();
                    Content.Text = result.ToString();
                }
                else if (textButton == "!")
                {
                    int fact = 1;
                    int n = Int32.Parse(Content.Text);
                    for (int i = 1; i <= n; i++)
                    {
                        fact = fact * i;
                    }
                    Content.Clear();
                    Content.Text = fact.ToString();
                }
                else Content.Text += textButton;
          
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Вводите корректные значения");   
            }
        }
    }
}
