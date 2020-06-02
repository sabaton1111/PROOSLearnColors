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
using Android.Webkit;
using Android.Widget;

namespace PROOSLearnColors.Fragments
{
    public class YouTubeVideo : Android.Support.V4.App.Fragment
    {
        private ImageView homeButton;
        private ImageView skipButton;
        private MediaPlayer player;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.youtube, container, false);
            var webview = view.FindViewById<WebView>(Resource.Id.webviewYoutube);
            homeButton = view.FindViewById<ImageView>(Resource.Id.imageViewHomeButtonYoutube);
            skipButton = view.FindViewById<ImageView>(Resource.Id.imageViewSkip);
            homeButton.Click += HomeButton_Click;
            skipButton.Click += SkipButton_Click;
            WebSettings settings = webview.Settings;
            settings.JavaScriptEnabled = true;
            webview.SetWebChromeClient(new WebChromeClient());
            webview.LoadUrl("https://www.youtube.com/embed/gavT_q9CLME");
            
            return view;
        }

        private void SkipButton_Click(object sender, EventArgs e)
        {
            player = MediaPlayer.Create(Activity, Resource.Raw.plop_sound);
            player.Start();
            Android.Support.V4.App.Fragment fragmentLogin = new LevelOneFragment(0);
            FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            player = MediaPlayer.Create(Activity, Resource.Raw.plop_sound);
            player.Start();
            Android.Support.V4.App.Fragment fragmentLogin = new ChooseLevelFragment();
            FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();
        }
    }
}