using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

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
                    window.displayHistory.Text = "";
                    DoMath._isPressingfunction = false;
                    DoMath._input = "";
                    break;
                case "±":
                    if (window.display.Text != "0")
                    {
                        DoMath._isPressingfunction = false;
                        DoMath._input = (Convert.ToDouble(window.display.Text) * -1).ToString();
                        window.display.Text = DoMath._input;
                    }
                    break;
                case "%":
                    DoMath._isPressingfunction = true;
                    DoMath.UpdateNumber(window, "%");
                    break;

                default:
                    break;
            }

            DoMath._isPressingNumbers = false;
        }
    }
}
