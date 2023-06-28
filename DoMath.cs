using System;
using System.Data;
using System.Text.RegularExpressions;

namespace Calc
{
    internal static class DoMath
    {
        internal static bool _isPressingfunction = false;
        internal static bool _isPressingNumbers = false;
        internal static bool _isShowResult = false;
        internal static bool _EqualsPressed = false;

        internal static string _input = "";
        internal static string _lastFunction = "";

        public static void UpdateNumber(MainWindow mainWindow, string func)
        {
            if (func == "=") { _EqualsPressed = true; }
            else { _EqualsPressed = false; }

            if (_isPressingNumbers)
            {
                
                if (_input == "" && func != "=")
                {
                    _lastFunction = func;
                    _input = mainWindow.display.Text + " " + func;
                    mainWindow.displayHistory.Text = historyDisplayCorrection(_input);
                }
                else
                {
                    _input += " " + mainWindow.display.Text;
                    _lastFunction = _lastFunction.Length>2 ? _lastFunction.Substring(0, 2) : _lastFunction;
                    _lastFunction += " " + mainWindow.display.Text;
                    mainWindow.displayHistory.Text = historyDisplayCorrection(_input);
                    mainWindow.display.Text = Result(_input);
                    if (func != "=")
                    {
                        _input = mainWindow.display.Text + " " + func;
                    }
                }
            }
            else if (_isPressingfunction)
            {

                if (mainWindow.display.Text == "0" || mainWindow.display.Text == "Nulou se dělit nedá!")
                {
                    _input = "0" + " " + func;
                    mainWindow.display.Text = "0";
                    mainWindow.displayHistory.Text = historyDisplayCorrection(_input);
                }
                else
                {
                    if (func != "=")
                    {
                        _input = mainWindow.display.Text;
                        _input += " " + func;
                        mainWindow.displayHistory.Text = historyDisplayCorrection(_input);
                    }
                    else if (func == "=")
                    {
                        _input = mainWindow.display.Text + " " + _lastFunction;
                        mainWindow.displayHistory.Text = historyDisplayCorrection(_input);
                        mainWindow.display.Text = Result(_input);
                    }
                }
            }
        }

        public static string Result(string input)
        {
            if (input.Contains("×")) { input = input.Replace("×", "*"); }
            if (input.Contains("÷")) { input = input.Replace("÷", "/"); }
            if (input.Contains("−")) { input = input.Replace("−", "-"); }
            if (input.Contains(",")) { input = input.Replace(",", "."); }
            if (input.Contains("/ 0")) { return "Nulou se dělit nedá!"; }

            //MessageBox.Show(input);

            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), input);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            
            decimal result = Convert.ToDecimal(row["expression"]);

            if (input.Contains("%"))
            {
                decimal percentageValue = result / 100;
                result = result + (result * percentageValue);
            }

            if (result % 1 == 0) { result = Math.Truncate(result); }

            _isShowResult = true;
            return result.ToString();
        }


        public static string historyDisplayCorrection(string input) 
        {
            if (input.Contains("−")) { return input.Replace("−", "-"); }
            else { return input; }
        }
        //public static string ExtractNumericalPart(string input)
        //{
        //    Regex regex = new Regex(@"(-?\d+(?:,\d+)?)");
        //    Match match = regex.Match(input);

        //    if (match.Success)
        //    {
        //        return match.Value;
        //    }
        //    return string.Empty;
        //}



    }

    
}
