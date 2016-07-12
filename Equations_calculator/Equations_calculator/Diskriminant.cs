
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Equations_calculator
{
   public class Diskriminant
    {
       static public string MyDiskriminant(double aArg, double bArg, double cArg)
        {
            var tmpResult = bArg * bArg - 4 * aArg * cArg;
            if (tmpResult > 0)
            {
                return "D>0 - The equation has two radicals";
            }
            else if (tmpResult == 0)
            {
                return "D=0 - The equation has two equal radicals";
            }
            else if (tmpResult < 0)
            {
                return "D<0 - The equation hasn't real radicals";
            }
            else
            {
                throw new Exception("Unknown Diskriminant value");
            }
        }
    }
}