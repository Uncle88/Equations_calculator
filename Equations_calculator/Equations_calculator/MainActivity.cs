using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using static Android.App.ActionBar;

namespace Equations_calculator
{
    [Activity(Label = "Equations_calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.MyButton);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            Tab tab = ActionBar.NewTab();
            tab.SetIcon(Resource.Drawable.Icon);
            tab.TabSelected += (sender, args) =>
            {
                 
            };
                ActionBar.AddTab(tab);

           

            //Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

            Spinner sp_a = FindViewById<Spinner>(Resource.Id.spinner1);
            Spinner sp_b = FindViewById<Spinner>(Resource.Id.spinner2);
            Spinner sp_c = FindViewById<Spinner>(Resource.Id.spinner3);

            //sp_a.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.numbers_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            sp_a.Adapter = adapter;

            //sp_b.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
           // var adapter = ArrayAdapter.CreateFromResource(
                   // this, Resource.Array.numbers_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            sp_b.Adapter = adapter;

            //sp_c.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
           //var adapter = ArrayAdapter.CreateFromResource(
            //        this, Resource.Array.numbers_array, Android.Resource.Layout.SimpleSpinnerItem);
            
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            sp_c.Adapter = adapter;

            button.Click += delegate
            {
                double aArg, bArg, cArg;

                var a = (Double.TryParse(sp_a.SelectedItem.ToString(), out aArg));
                var b = (Double.TryParse(sp_b.SelectedItem.ToString(), out bArg));
                var c = (Double.TryParse(sp_c.SelectedItem.ToString(), out cArg));

                button.Text = Diskriminant(aArg, bArg, cArg);
            };
        }

        //private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        //{
        //    Spinner spinner = (Spinner)sender;
        //}

        public string Diskriminant(double a, double b, double c)
        {
            var tmpResult = b * b - 4 * a * c;
            if (tmpResult > 0)
            {
                //double X1 = (-b + Math.Sqrt(tmpResult)) / (2 * a);
                //double X2 = (-b - Math.Sqrt(tmpResult)) / (2 * a);

                return "D>0 - The equation has two radicals";
            }
            else if (tmpResult == 0)
            {
                //double X1= (-b) / (2 * a);
                //double X2= (-b) / (2 * a);

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

