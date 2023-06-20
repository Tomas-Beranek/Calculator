using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Calc.view.UserControls
{
    /// <summary>
    /// Interakční logika pro numberPad.xaml
    /// </summary>
    public partial class numberPad : UserControl
    {
        public numberPad()
        {
            InitializeComponent();
            btnNum.FontSize = 25;
        }
        private string contentFill;
        public string ContentFill
        {
            get { return contentFill; }
            set
            {
                contentFill = value;
                OnPropertyChanged(nameof(ContentFill));
                btnNum.Content = contentFill;
            }
        }

        private int sizeFill;

        public int SizeFill
        {
            get { return sizeFill; }
            set 
            { 
                sizeFill = value; 
                btnNum.FontSize = sizeFill;
            }
        }





        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnNum_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var window = Window.GetWindow(this) as MainWindow;
            if(window.display.Text == "0" && !window.display.Text.Contains(","))
            {
                if (button.Content.ToString() == ",")
                {
                    window.display.Text += button.Content.ToString();
                }
                else
                {
                    window.display.Text = button.Content.ToString();
                }
                
            }
            else
            {
                if(window.display.Text.Length <= 15)
                {
                    if (window.display.Text != "0" && !window.display.Text.Contains(",") && button.Content.ToString() == ",")
                    {
                        window.display.Text += button.Content.ToString();
                    }
                    else if (button.Content.ToString() != "," && !window._functionIsPressed)
                    {
                        window.display.Text += button.Content.ToString();
                    }
                    else if (button.Content.ToString() != "," && window._functionIsPressed)
                    {
                        window.display.Text = button.Content.ToString();
                        window._functionIsPressed = false;
                    }
                }
                
                

            }
            
            
        }
    }
}
