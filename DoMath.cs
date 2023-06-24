using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calc
{
    internal static class DoMath
    {
        internal static decimal _baseNumber = 0;

        internal static decimal _lastInsertedNumber = 0;
        internal static bool _functionIsPressed = false;
        internal static bool _isPressingNumbers = false;
        
        internal static string _function = "";
        internal static string _lastFunction = "";
        


        public static void Count(MainWindow mainWindow)
        {
            if (_isPressingNumbers)
            {
                _lastInsertedNumber = Convert.ToDecimal(mainWindow.display.Text);
                UpdateNumber(mainWindow);
                
            }
            else if(_functionIsPressed)
            {
                //if(_function == "—") { _function = "-"; }
                mainWindow.displayHistory.Text = _baseNumber.ToString() + " " + _function + " ";
            }

            
            
        }
        private static void UpdateHistory(MainWindow mainWindow)
        {
            mainWindow.displayHistory.Text = _baseNumber.ToString() + " " + _function + " ";

            if (_isPressingNumbers)
            {
                if (_baseNumber != 0)
                    mainWindow.displayHistory.Text = _baseNumber.ToString() + " " + _function + " " + mainWindow.display.Text;
                else
                    mainWindow.displayHistory.Text = mainWindow.display.Text + " " + _function + " ";
            }

        }
        private static void UpdateNumberWithLastFunction()
        {
            switch (_lastFunction)
            {
                case "+":
                    _baseNumber += _lastInsertedNumber;
                    DecimalZeroCHeck();
                    break;
                case "—":
                    _baseNumber -= _lastInsertedNumber;
                    DecimalZeroCHeck();
                    break;
                case "*":
                    //code
                    break;
                case "/":
                    //code
                    break;
                case "%":
                    //code
                    break;
                default:
                    break;
            }
        }
        private static void UpdateNumber(MainWindow mainWindow) 
        {
            UpdateHistory(mainWindow);
            switch (_function)
            {
                case "+":
                    if (_lastFunction == "+" || _lastFunction == "")
                    {
                        _baseNumber += _lastInsertedNumber;
                        DecimalZeroCHeck();
                        mainWindow.display.Text = _baseNumber.ToString();
                        _lastFunction = _function;
                    }
                    else
                    {
                        UpdateNumberWithLastFunction();
                        DecimalZeroCHeck();
                        mainWindow.display.Text = _baseNumber.ToString();
                    }
                    
                    break;
                case "—":
                    if(_baseNumber == 0) { _baseNumber = _lastInsertedNumber; }
                    else if(_lastFunction == "—" || _lastFunction == "")
                    {
                        _baseNumber -= _lastInsertedNumber;
                        DecimalZeroCHeck();
                        mainWindow.display.Text = _baseNumber.ToString();
                        _lastFunction = _function;
                    }
                    else
                    {
                        UpdateNumberWithLastFunction();
                        DecimalZeroCHeck();
                        mainWindow.display.Text = _baseNumber.ToString();
                    }
                    break;
                case "*":
                    //code
                    break;
                case "/":
                    //code
                    break;
                case "%":
                    //code
                    break;
                case "=":
                    //code
                    break;
            }

            DecimalZeroCHeck();
        }
        private static decimal DecimalZeroCHeck()
        {
            if (_baseNumber % 1 == 0) { _baseNumber = Math.Truncate(_baseNumber); }
            return _baseNumber;
        }
    }
}
