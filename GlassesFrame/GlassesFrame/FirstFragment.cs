using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Realms;


namespace GlassesFrame
{
    public class FirstFragment : Fragment
    {
        TextView userinfo;
        Person personObj;
        Activity context;

        public FirstFragment(Person userInfo)
        {
            this.personObj = userInfo;
            //this.context = context;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {


            View myView = inflater.Inflate(Resource.Layout.tab1, container, false);


            userinfo = myView.FindViewById<TextView>(Resource.Id.userInfoID);


            userinfo.Text = personObj.Name;

            return myView;
        }
    }
}