﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Calc.view.UserControls
{
    /// <summary>
    /// Interakční logika pro rightColumnFunctions.xaml
    /// </summary>
    public partial class rightColumnFunctions : UserControl
    {
        public rightColumnFunctions()
        {
            InitializeComponent();
            btnRightFunc.FontSize = 25;
        }

        private string contentFill;
        public string ContentFill
        {
            get { return contentFill; }
            set
            {
                contentFill = value;
                OnPropertyChanged(nameof(ContentFill));
                btnRightFunc.Content = contentFill;
            }
        }

        private int sizeFill;

        public int SizeFill
        {
            get { return sizeFill; }
            set
            {
                sizeFill = value;
                btnRightFunc.FontSize = sizeFill;
            }
        }





        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnRightFunc_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var window = Window.GetWindow(this) as MainWindow;

            switch (button.Content.ToString())
            {
                case "+":
                    window._functionIsPressed = true;
                    window.display.Text = (Convert.ToDecimal(window.display.Text) + window._baseNumber).ToString();
                    window._baseNumber = Convert.ToDecimal(window.display.Text);
                    break;
                default:
                    break;
            }

        }
    }
}
