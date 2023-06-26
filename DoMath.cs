﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Calc
{
    internal static class DoMath
    {

        internal static bool _isPressingfunction = false;
        internal static bool _isPressingNumbers = false;

        internal static string _input = "";

        public static void UpdateNumber(MainWindow mainWindow, string func)
        {

            //if (func == "=")
            //{
            //    string posibleFunctions = "+−×÷";
            //    if (_input.Contains(posibleFunctions) && _input.Length > 3)
            //    {
            //        mainWindow.display.Text = Result(_input);
            //    }
            //}

            if (_isPressingNumbers)
            {
                if(_input == "" && func != "=")
                {
                    _input = mainWindow.display.Text + " " + func;
                    mainWindow.displayHistory.Text = historyDisplayCorrection(_input);
                }
                else
                {
                    if(func == "=")
                    {

                    }
                    _input += " " + mainWindow.display.Text;
                    mainWindow.displayHistory.Text = historyDisplayCorrection(_input);
                    mainWindow.display.Text = Result(_input);
                    _input = mainWindow.display.Text + " " + func;
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
                    _input = ExtractNumericalPart(_input);
                    _input += " " + func;
                    mainWindow.displayHistory.Text = historyDisplayCorrection(_input);
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

            DataTable table = new DataTable();
            //MessageBox.Show(input); //TEST
            table.Columns.Add("expression", typeof(string), input);
            DataRow row = table.NewRow();
            table.Rows.Add(row);

            decimal result = Convert.ToDecimal(row["expression"]);
            if (result % 1 == 0) { result = Math.Truncate(result); }

            return result.ToString();
        }


        public static string historyDisplayCorrection(string input) 
        {
            if (input.Contains("−")) { return input.Replace("−", "-"); }
            else { return input; }
        }
        public static string ExtractNumericalPart(string input)
        {
            Regex regex = new Regex(@"(-?\d+(?:,\d+)?)");
            Match match = regex.Match(input);

            if (match.Success)
            {
                return match.Value;
            }

            return string.Empty;
        }



    }

    
}
