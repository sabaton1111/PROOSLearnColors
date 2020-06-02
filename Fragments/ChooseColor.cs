using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PROOSLearnColors.Fragments
{
    public class ChooseColor : Android.Support.V4.App.Fragment
    {
        private int colorOne;
        private int colorTwo;
        private int colorThree;
        private int correctColor;
        private MediaPlayer player;
        private int currectColor;
        private Stack<int> shapes;
        private Random rnd = new Random();
        private Block leftBlock = new Block();
        private ImageView homeButton;
        private ImageView soundButton;
        public int ColorOne { get; set; }
        public int ColorTwo { get; set; }
        public int ColorThree { get; set; }
        public int CorrectColor { get; set; }
        public Stack<int> Shapes { get; set; }
        public MediaPlayer Player { get; set; }
        public ChooseColor(int colorOne, int colorTwo, int colorThree, int correctColor, Stack<int> shapes, MediaPlayer player)
        {
            ColorOne = colorOne;
            ColorTwo = colorTwo;
            ColorThree = colorThree;
            CorrectColor = correctColor;
            Shapes = new Stack<int>(shapes);
            Player = player;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.choose_color_fragment, container, false);
            leftBlock.Color = view.FindViewById<ImageView>(Resource.Id.imageViewMiddleBoxOne);
            homeButton = view.FindViewById<ImageView>(Resource.Id.imageViewHome);
            soundButton = view.FindViewById<ImageView>(Resource.Id.imageViewSound);
            soundButton.Click += SoundButton_Click;
            homeButton.Click += HomeButton_Click;
            leftBlock.Color.Click += Color_Click1;
            GenerateColors(ColorOne);
            var task = Task.Run(() =>
            {
                GenerateColors(ColorOne);
                
                GenerateColors(ColorTwo);

                GenerateColors(ColorTwo);

                GenerateColors(ColorThree);

            });
            var task2 = Task.Run(() =>
            {

                //GenerateColors(ColorTwo);

                //GenerateColors(ColorThree);

                GenerateColors(ColorThree);

            });
          

            // GenerateColors(ColorThree);
            return view;
        }

        private void SoundButton_Click(object sender, EventArgs e)
        {
            Player.Start();
           
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            player = MediaPlayer.Create(Activity, Resource.Raw.plop_sound);
            player.Start();
            Android.Support.V4.App.Fragment fragmentLogin = new ChooseLevelFragment();
            FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();
        }

        private void Color_Click1(object sender, EventArgs e)
        {
            if (CorrectColor == currectColor)
            {
                leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.correctAnswer);
                leftBlock.Player.Start();
                Thread.Sleep(4000);
                var task = Task.Run(() =>
                {          
                    Android.Support.V4.App.Fragment fragmentLogin = new LevelThreeFragment();
                    FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();
                });
            }
            else
            {
                leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.hmmThinkAgain); 
                leftBlock.Player.Start();
            }
           
        }

        private void GenerateColors(int colorOne)
        {
            currectColor = colorOne;
            Thread.Sleep(3000);
            int resourceId;
            #region colors

                if (colorOne == 0)
                {
                    resourceId = Context.Resources.GetIdentifier("black_color", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.blackColor);
                }
                else if (colorOne == 1)
                {
                    resourceId = Context.Resources.GetIdentifier("white_color", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.whiteColor);

                }
                else if (colorOne == 2)
                {
                    resourceId = Context.Resources.GetIdentifier("red_color", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.redColor);

                }
                else if (colorOne == 3)
                {
                    resourceId = Context.Resources.GetIdentifier("gray", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.grayColor);

                }
                else if (colorOne == 4)
                {
                    resourceId = Context.Resources.GetIdentifier("purple", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.purpleColor);

                }
                else if (colorOne == 5)
                {
                    resourceId = Context.Resources.GetIdentifier("pink", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.pinkColor);

                }
                else if (colorOne == 6)
                {
                    resourceId = Context.Resources.GetIdentifier("blue_color", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.blueColor);

                }
                else if (colorOne == 7)
                {
                    resourceId = Context.Resources.GetIdentifier("green_color", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.greenColor);

                }
                else if (colorOne == 8)
                {
                    resourceId = Context.Resources.GetIdentifier("yellow_color", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.yellowColor);

                }
                else if (colorOne == 9)
                {
                    resourceId = Context.Resources.GetIdentifier("brown", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.brownColor);

                }
                else if (colorOne == 10)
                {

                    resourceId = Context.Resources.GetIdentifier("orange", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.orangeColor);

                }
                #endregion

            
            // leftBlock.Player.Start();

 
        }

        private void Color_Click(object sender, EventArgs e)
        {
            if(CorrectColor == currectColor)
            {
                leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.correctAnswer);

            }
            else
            {
                leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.hmmThinkAgain);

            }
        }
    }
}