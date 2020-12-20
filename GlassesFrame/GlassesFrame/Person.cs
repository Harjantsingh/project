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
    [Activity(Label = "Person")]
    class Person : RealmObject
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public int Age { get; set; }
        public int ItemImage { get; set; }
        public int ItemQuantity { get; set; }
        public string ItemImageName { get; set; }
    }
}