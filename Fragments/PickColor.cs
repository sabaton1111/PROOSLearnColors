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
    public class PickColor : Android.Support.V4.App.Fragment
    {
        private int colorOne;
        private int colorTwo;
        private int colorThree;
        private int correctColor;
        private int colorOnScreen;
        private MediaPlayer player;
        private Stack<int> shapes;
        private Random rnd = new Random();
        private Block leftBlock = new Block();
        private ImageView homeButton;
        public int ColorOne { get; set; }
        public int ColorTwo { get; set; }
        public int ColorThree { get; set; }
        public int CorrectColor { get; set; }
        public Stack<int> Shapes { get; set; }
        public PickColor(int colorOne, int colorTwo, int colorThree, int correctColor, Stack<int> shapes)
        {
            ColorOne = colorOne;
            ColorTwo = colorTwo;
            ColorThree = colorThree;
            CorrectColor = correctColor;
            Shapes = new Stack<int>(shapes);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.pick_color_fragment, container, false);
            leftBlock.Color = view.FindViewById<ImageView>(Resource.Id.imageViewMiddleBox);
            homeButton = view.FindViewById<ImageView>(Resource.Id.imageViewHome);
            homeButton.Click += HomeButton_Click;
            Ask();

            return view;
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            player = MediaPlayer.Create(Activity, Resource.Raw.plop_sound);
            player.Start();
            Android.Support.V4.App.Fragment fragmentLogin = new ChooseLevelFragment();
            FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();
        }

        public void Ask()
        {

            int color = CorrectColor; // 0 - left color is correct, 1 - middle, 2 - right
            int getShape;
            if (color == 0)
            {
                getShape = Shapes.Peek();
            }
            else if (color == 1)
            {
                Shapes.Pop();
                getShape = Shapes.Peek();

            }
            else
            {
                Shapes.Pop();
                Shapes.Pop();
                getShape = Shapes.Peek();

            }
            switch (getShape)
            {
                case 0:
                    player = MediaPlayer.Create(Activity, Resource.Raw.sound_rectangle);
                    break;
                case 1:
                    player = MediaPlayer.Create(Activity, Resource.Raw.sound_circle);
                    break;
                case 2:
                    player = MediaPlayer.Create(Activity, Resource.Raw.whatWasTheColor);
                    break;
                case 3:
                    player = MediaPlayer.Create(Activity, Resource.Raw.sound_square);
                    break;
            }

            //      player = MediaPlayer.Create(Activity, Resource.Raw.plop_sound);
            player.Start();
            //   Task.Delay(TimeSpan.FromSeconds(3));
            if (CorrectColor == 0)
            {
                CorrectColor = ColorOne;
            }
            else if (CorrectColor == 1)
            {
                CorrectColor = ColorTwo;
            }
            else
            {
                CorrectColor = ColorThree;
            }
            var task = Task.Run(() =>
            {
                Thread.Sleep(4000);
                Android.Support.V4.App.Fragment fragmentLogin = new ChooseColor(ColorOne, ColorTwo, ColorThree, CorrectColor, Shapes, player);
                FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();

            }
            );

        }

    }
}