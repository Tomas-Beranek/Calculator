using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

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

            DoMath._isPressingNumbers = true;

            ZeroDivideHandle:
            if(DoMath._isShowResult && DoMath._EqualsPressed) { DoMath._input = ""; DoMath._lastFunction = ""; window.displayHistory.Text = ""; DoMath._isShowResult = false; }//reset displaye
            if(window.display.Text == "0" && !window.display.Text.Contains(","))
            {
                if (button.Content.ToString() == ",")
                    window.display.Text += button.Content.ToString();
                else
                    window.display.Text = button.Content.ToString();
            }
            else
            {
                if(window.display.Text.Length <= 15)
                {
                    if (window.display.Text != "0" && !window.display.Text.Contains(",") && button.Content.ToString() == ",")
                        window.display.Text += button.Content.ToString();
                    else if (button.Content.ToString() != "," && !DoMath._isPressingfunction)
                        window.display.Text += button.Content.ToString();
                    else if (button.Content.ToString() != "," && DoMath._isPressingfunction)
                    {
                        window.display.Text = button.Content.ToString();
                        DoMath._isPressingfunction = false;
                    }
                }
                else
                {
                    window.display.Text = "";
                    window.displayHistory.Text = "";
                    DoMath._isPressingfunction = false;
                    DoMath._input = "";
                    goto ZeroDivideHandle;
                }

            }
        }
    }
}
