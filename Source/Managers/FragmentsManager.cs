using Android.Support.V4.App;
using Fragments.Source.Enums;
using Fragments.Source.Fragments;
using System.Collections.Generic;

namespace Fragments.Source.Managers
{
    public static class FragmentsManager
    {
        private static FragmentManager SupportFragmentManager { get; set; }
        public static Dictionary<FragmentsList, Fragment> Fragments { get; set; } = new Dictionary<FragmentsList, Fragment>();

        public static void Initialize(FragmentManager supportFragmentManager)
        {
            SupportFragmentManager = supportFragmentManager;

            Fragments.Add(FragmentsList.Fragment1, new Fragment1());
            Fragments.Add(FragmentsList.Fragment2, new Fragment2());
            Fragments.Add(FragmentsList.Fragment3, new Fragment3());
        }

        public static void SetFragment(int containerViewId, Fragment fragment)
        {
            var supportFragmentManager = SupportFragmentManager.BeginTransaction();

            supportFragmentManager.Replace(containerViewId, fragment);
            supportFragmentManager.AddToBackStack(null);
            supportFragmentManager.Commit();
        }
    }
}