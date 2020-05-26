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
    public class LevelOneFragment : Android.Support.V4.App.Fragment
    {
        private MediaPlayer player;
        private ImageView leftColor;
        private ImageView rightColor;

        private ImageView[] colors = new ImageView[] { };
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.level_one_fragment, container, false);
            leftColor = view.FindViewById<ImageView>(Resource.Id.imageViewLeftBox);
            rightColor = view.FindViewById<ImageView>(Resource.Id.imageViewRightBox);
            GenerateRandomColor(leftColor, rightColor);

            return view;
        }

        //Playing sound from raw folder (in Resources)
        private void GreenColor()
        {
            player = MediaPlayer.Create(Activity, Resource.Raw.greenColor);
            player.Start();
        }
        private void GenerateRandomColor(ImageView leftColor, ImageView rightColor)
        {
            Random rnd = new Random();
            int pickedColor = rnd.Next(0,1);

            //Getting image id(from drawable folder in Resources)
            int resourceId = Context.Resources.GetIdentifier("green_color", "drawable", Context.PackageName);

            switch (pickedColor)
            {
                case 0:
                    //setting image background from id 
                    leftColor.SetImageResource(resourceId);
                    GreenColor();
                    break;
                case 1: 
                    leftColor.SetImageResource(resourceId);
                    break;
            }

            //for (int i = 0; i < 6; i++)
            //{
                
            //}
        }
        //public void GetColor(ImageView leftColor, ImageView rightColor)
        //{
        //    Random rnd = new Random();
        //    Array colors = Enum.GetValues(typeof(Colors));
        //    Colors randomValue = (Colors)colors.GetValue(rnd.Next(colors.Length));
        //  //  leftColor.SetImageResource(Co)

        //}
    }
}