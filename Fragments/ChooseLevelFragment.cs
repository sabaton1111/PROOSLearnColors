using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PROOSLearnColors.Fragments
{
    public class ChooseLevelFragment : Android.Support.V4.App.Fragment
    {
        private MediaPlayer player;
        
      //  private Android.Support.V4.App.FragmentManager fm = ;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.choose_level_fragment, container, false);
            ImageView levelOne = view.FindViewById<ImageView>(Resource.Id.imageViewLevelOne);
            ImageView levelTwo = view.FindViewById<ImageView>(Resource.Id.imageViewLevelTwo);
            ImageView buttonHelp = view.FindViewById<ImageView>(Resource.Id.buttonHelp);
            ImageView levelThree = view.FindViewById<ImageView>(Resource.Id.imageViewLevelThree);
            buttonHelp.Click += ButtonHelp_Click;
            levelTwo.Click += LevelTwo_Click;
            levelOne.Click += LevelOne_Click;
            levelThree.Click += LevelThree_Click;
            return view;
        }

        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            player = MediaPlayer.Create(Activity, Resource.Raw.plop_sound);
            player.Start();
            Android.Support.V4.App.Fragment fragmentLogin = new HelpFragment();
            FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();
        }

        private void LevelThree_Click(object sender, EventArgs e)
        {
            player = MediaPlayer.Create(Activity, Resource.Raw.plop_sound);

            player.Start();
            Android.Support.V4.App.Fragment fragmentLogin = new LevelThreeFragment();
            FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();

        }

        private void LevelTwo_Click(object sender, EventArgs e)
        {
            player = MediaPlayer.Create(Activity, Resource.Raw.plop_sound);
            player.Start();
            Android.Support.V4.App.Fragment fragmentLogin = new LevelTwoFragment(0);
            FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();
        }

        private void LevelOne_Click(object sender, EventArgs e)
        {
            player = MediaPlayer.Create(Activity, Resource.Raw.plop_sound);
            player.Start();
            Android.Support.V4.App.Fragment fragmentLogin = new LevelOneFragment(0);
            FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();
        }
    }
}