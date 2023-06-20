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
    /// Interakční logika pro topRowFunctions.xaml
    /// </summary>
    public partial class topRowFunctions : UserControl
    {
        public topRowFunctions()
        {
            InitializeComponent();
            btnTopFunc.FontSize = 25;
        }

        private string contentFill;
        public string ContentFill
        {
            get { return contentFill; }
            set
            {
                contentFill = value;
                OnPropertyChanged(nameof(ContentFill));
                btnTopFunc.Content = contentFill;
            }
        }

        private int sizeFill;

        public int SizeFill
        {
            get { return sizeFill; }
            set
            {
                sizeFill = value;
                btnTopFunc.FontSize = sizeFill;
            }
        }





        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnTopFunc_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var window = Window.GetWindow(this) as MainWindow;

            switch (button.Content.ToString())
            {
                case "AC":
                    window.display.Text = "0";
                    window._baseNumber = 0;
                    break;
                case "±":
                    window.display.Text = window.display.Text == "0" ? "0" : (Convert.ToDouble(window.display.Text) * -1).ToString();
                    break;
                case "%":
                    window.display.Text = (Convert.ToDouble(window.display.Text) /100).ToString();
                    break;

                default:
                    break;
            }
        }
    }
}
