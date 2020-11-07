using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Fragments.Source.Enums;
using Fragments.Source.Managers;

namespace Fragments.Source.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var frameLayout = FindViewById(Resource.Id.frameLayout1);

            FragmentsManager.Initialize(SupportFragmentManager);
            FragmentsManager.SetFragment(frameLayout.Id, FragmentsManager.Fragments[FragmentsList.Fragment1]);

            var button1 = FindViewById<Button>(Resource.Id.button1);
            var button2 = FindViewById<Button>(Resource.Id.button2);
            var button3 = FindViewById<Button>(Resource.Id.button3);

            button1.Click += (o, e)
                => FragmentsManager.SetFragment(frameLayout.Id, FragmentsManager.Fragments[FragmentsList.Fragment1]);
            button2.Click += (o, e)
                => FragmentsManager.SetFragment(frameLayout.Id, FragmentsManager.Fragments[FragmentsList.Fragment2]); 
            button3.Click += (o, e)
                 => FragmentsManager.SetFragment(frameLayout.Id, FragmentsManager.Fragments[FragmentsList.Fragment3]);
        }
    }
}