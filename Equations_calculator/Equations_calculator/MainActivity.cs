using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Equations_calculator
{
    [Activity(Label = "Equations_calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.MyButton);

            EditText ed_a = FindViewById<EditText>(Resource.Id.editText2);
            EditText ed_b = FindViewById<EditText>(Resource.Id.editText3);
            EditText ed_c = FindViewById<EditText>(Resource.Id.editText4);           

            button.Click += delegate
            {
                var a = (Convert.ToDouble(ed_a.Text));
                var b = (Convert.ToDouble(ed_b.Text));
                var c = (Convert.ToDouble(ed_c.Text));

                button.Text = Diskriminant(a,b,c);
            };
        }

        private string Diskriminant (double a, double b, double c)
        {
            var tmpResult = b * b - 4 * a * c;
            if (tmpResult > 0)
            {
                return "The equation has two radicals";
            }
            else if (tmpResult == 0)
            {
                return "The equation has two equal radicals";
            }
            else if (tmpResult <0)
            {
                return "The equation hasn't real radicals";
            }
            else
            {
                throw new Exception("Unknown Diskriminant value");
            }
        }
    }
}

