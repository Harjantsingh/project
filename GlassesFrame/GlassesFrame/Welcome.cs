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
using Realms;

namespace GlassesFrame
{
    [Activity(Label = "Welcome")]
    public class Welcome : Activity
    {
        TextView userinfo;
        string nameInfo;
        Realm realmDB;
        Fragment[] _FragmentsArray;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.ActionBar);
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.welcome_layout);
            realmDB = Realm.GetInstance();
            nameInfo = Intent.GetStringExtra("email");

            userinfo = FindViewById<TextView>(Resource.Id.userInfoID);
            var personObj = realmDB.All<Person>().Where(d => d.Email == nameInfo.ToLower()).First();
            userinfo.Text = "Welcome" + personObj.Name;

            _FragmentsArray = new Fragment[]
            {
                new FirstFragment(personObj),
                //new SecondFragment(this),
                //new ThirdFragment()
            };


            AddTabToActionBar("First Tab");
            AddTabToActionBar("Second Tab");
            AddTabToActionBar("Third Tab");
        }



        void AddTabToActionBar(string tabTitle)
        {
            Android.App.ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetText(tabTitle);
            tab.SetIcon(Android.Resource.Drawable.IcInputAdd); //Means plus "+" icon
            tab.TabSelected += TabOnTabSelected;
            this.ActionBar.AddTab(tab);
        }

        void TabOnTabSelected(object sender, Android.App.ActionBar.TabEventArgs tabEventArgs)
        {
            Android.App.ActionBar.Tab tab = (Android.App.ActionBar.Tab)sender;
            //Log.Debug(Tag, "The tab {0} has been selected.", tab.Text); 
            Fragment frag = _FragmentsArray[tab.Position];
            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
        }

    }
}