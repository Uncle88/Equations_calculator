﻿using System;
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
            { };
                ActionBar.AddTab(tab);

            Spinner sp_a = FindViewById<Spinner>(Resource.Id.spinner1);
            Spinner sp_b = FindViewById<Spinner>(Resource.Id.spinner2);
            Spinner sp_c = FindViewById<Spinner>(Resource.Id.spinner3);

            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.numbers_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            sp_a.Adapter = adapter;

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            sp_b.Adapter = adapter;
            
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            sp_c.Adapter = adapter;

            button.Click += delegate
            {
                double aArg, bArg, cArg;

                var a = (Double.TryParse(sp_a.SelectedItem.ToString(), out aArg));
                var b = (Double.TryParse(sp_b.SelectedItem.ToString(), out bArg));
                var c = (Double.TryParse(sp_c.SelectedItem.ToString(), out cArg));

                string toast = string.Format(" {0} ", Diskriminant(aArg, bArg, cArg));
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                // button.Text = Diskriminant( aArg, bArg, cArg);
            };
        }

        public string Diskriminant(double aArg, double bArg, double cArg)
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

