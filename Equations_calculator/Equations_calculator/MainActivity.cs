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
        private double D;


        //int count = 1;

        protected override void OnCreate (Bundle bundle)
        {
             base.OnCreate(bundle);
             SetContentView(Resource.Layout.Main);

            var a = (Convert.ToDouble(editText2));
            var b = (Convert.ToDouble(editText3));
            var c = (Convert.ToDouble(editText4));

            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate
            {
                button.Text = string.Format("{0} ", D );
            };
        }
            void diskriminant  (double a, double b, double c)
        {
            D = b * b - 4 * a * c;
        }
    }
}

