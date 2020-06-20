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
            LoadRandomUrl(webview);

            return view;
        }

        private void LoadRandomUrl(WebView webview)
        {
            Random radnom = new Random();
            int n = radnom.Next(0, 11);
            switch (n)
            {
                case 0://zhaba zhaburana
                    webview.LoadUrl("https://www.youtube.com/embed/eiT3b4zM_DA");
                    break;
                case 1://Spok-a Dudle
                    webview.LoadUrl("https://www.youtube.com/embed/fK7PEb3Ap4A");
                    break;
                case 2://Zaicheto Bialo
                    webview.LoadUrl("https://www.youtube.com/embed/ndTVqwfzkA4");
                    break;
                case 3://Cvetovete
                    webview.LoadUrl("https://www.youtube.com/embed/hjswb6xnHdw");
                    break;
                case 4://Happy and you know it
                    webview.LoadUrl("https://www.youtube.com/embed/M6LoRZsHMSs");
                    break;
                case 5://What Color Am I Wearing?
                    webview.LoadUrl("https://www.youtube.com/embed/TCYVm0aS-Ks");
                    break;
                case 6://Aram zam zam
                    webview.LoadUrl("https://www.youtube.com/embed/d8IJpspU2m0");
                    break;
                case 7://5 malki pateta
                    webview.LoadUrl("https://www.youtube.com/embed/pwqLXrWMbj0");
                    break;
                case 8: // kravata lola
                    webview.LoadUrl("https://www.youtube.com/embed/yVEqtpr-OQs");
                    break;
                case 9://kolelata na avtobusa
                    webview.LoadUrl("https://www.youtube.com/embed/cW1Dx9GbQz4");
                    break;
                case 10://kucheto Bingo
                    webview.LoadUrl("https://www.youtube.com/embed/tx5Qb2K2nkA");
                    break;                
            }
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