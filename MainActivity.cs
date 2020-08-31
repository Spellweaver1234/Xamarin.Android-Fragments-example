using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Fragments.Resources.layout;
using System.Runtime.CompilerServices;
using Fragment = Android.Support.V4.App.Fragment;

namespace Fragments
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Fragment fragment1=new Fragment1();
        private Fragment fragment2=new Fragment2();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            // Create a new fragment and a transaction.
            var supportFragmentManager = this.SupportFragmentManager.BeginTransaction();
            var aDifferentDetailsFrag = new Fragment1();

            // Replace the fragment that is in the View fragment_container (if applicable).
            supportFragmentManager.Replace(Resource.Id.frameLayout1, aDifferentDetailsFrag, null);

            // Add the transaction to the back stack.
            supportFragmentManager.AddToBackStack(null);

            // Commit the transaction.
            supportFragmentManager.Commit();

            var button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button1_Click;
            var button2 = FindViewById<Button>(Resource.Id.button2);
            button2.Click += Button2_Click;
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            SetFragment(fragment2);
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            SetFragment(fragment1);
        }
        private void SetFragment(Android.Support.V4.App.Fragment fragment)
        {
            var trans = this.SupportFragmentManager.BeginTransaction();
            trans.Replace(Resource.Id.frameLayout1, fragment, null);
            trans.AddToBackStack(null);
            trans.Commit();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}