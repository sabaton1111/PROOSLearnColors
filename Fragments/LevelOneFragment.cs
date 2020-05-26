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
        private Block leftBlock = new Block();
        private Block rightBlock = new Block();

        private class Block
        {
            private ImageView color;
            private bool isCorrectAnswer;
            private MediaPlayer player;

            public Block()
            {
                isCorrectAnswer = false;
            }

            public Block(ImageView color, bool isCorrectAnswer, MediaPlayer player)
            {
                this.Color = color;
                this.IsCorrectAnswer = isCorrectAnswer;
                this.Player = player;
            }

            public ImageView Color { get => color; set => color = value; }
            public bool IsCorrectAnswer { get => isCorrectAnswer; set => isCorrectAnswer = value; }
            public MediaPlayer Player { get => player; set => player = value; }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.level_one_fragment, container, false);
            leftBlock.Color = view.FindViewById<ImageView>(Resource.Id.imageViewLeftBox);
            rightBlock.Color = view.FindViewById<ImageView>(Resource.Id.imageViewRightBox);
            GenerateRandomColorAndSetPlayer(leftBlock, rightBlock);
            leftBlock.Color.Click += LeftBlock_Click;
            rightBlock.Color.Click += RightBlock_Click;

            int correctAnswer = DecideCorrecttAnswer();
            if (correctAnswer == 0)
            {
                leftBlock.IsCorrectAnswer = true;
            }
            else
            {
                rightBlock.IsCorrectAnswer = true;
            }

            if (leftBlock.IsCorrectAnswer)
            {
                leftBlock.Player.Start();
            }
            else
            {
                rightBlock.Player.Start();
            }

            return view;
        }

        private void LeftBlock_Click(object sender, EventArgs e)
        {
            player = MediaPlayer.Create(Activity, Resource.Raw.plop_sound);
            player.Start();
            if (leftBlock.IsCorrectAnswer)
            {
                player = MediaPlayer.Create(Activity, Resource.Raw.correctAnswer);
                player.Start();
                Android.Support.V4.App.Fragment fragmentLogin = new LevelOneFragment();
                FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();
            }
            else
            {
                player = MediaPlayer.Create(Activity, Resource.Raw.hmmThinkAgain);
                player.Start();
            }            
        }

        private void RightBlock_Click(object sender, EventArgs e)
        {
            player = MediaPlayer.Create(Activity, Resource.Raw.plop_sound);
            player.Start();
            if (rightBlock.IsCorrectAnswer)
            {
                player = MediaPlayer.Create(Activity, Resource.Raw.correctAnswer);
                player.Start();
                Android.Support.V4.App.Fragment fragmentLogin = new LevelOneFragment();
                FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();
            }
            else
            {
                player = MediaPlayer.Create(Activity, Resource.Raw.hmmThinkAgain);
                player.Start();
            }
            
        }

        private void GenerateRandomColorAndSetPlayer(Block leftBlock, Block rightBlock)
        {
            Random rnd = new Random();
            int pickedLeftColor = rnd.Next(0, 6);
            int pickedRightColor = rnd.Next(0, 6);
            while (pickedLeftColor == pickedRightColor)
            {
                pickedRightColor = rnd.Next(0, 6);
            }
            //Getting image id(from drawable folder in Resources)
            int resourceId;

            switch (pickedLeftColor)
            {
                case 0:
                    //setting image background from id 
                    resourceId = Context.Resources.GetIdentifier("white_color", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.whiteColor);
                    break;
                case 1:
                    resourceId = Context.Resources.GetIdentifier("green_color", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.greenColor);
                    break;
                case 2:
                    resourceId = Context.Resources.GetIdentifier("blue_color", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.blueColor);
                    break;
                case 3:
                    resourceId = Context.Resources.GetIdentifier("yellow_color", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.yellowColor);
                    break;
                case 4:
                    resourceId = Context.Resources.GetIdentifier("red_color", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.redColor);
                    break;
                case 5:
                    resourceId = Context.Resources.GetIdentifier("black_color", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.blackColor);
                    break;
            }

            switch (pickedRightColor)
            {
                case 0:
                    //setting image background from id 
                    resourceId = Context.Resources.GetIdentifier("white_color", "drawable", Context.PackageName);
                    rightBlock.Color.SetImageResource(resourceId);
                    rightBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.whiteColor);
                    break;
                case 1:
                    resourceId = Context.Resources.GetIdentifier("green_color", "drawable", Context.PackageName);
                    rightBlock.Color.SetImageResource(resourceId);
                    rightBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.greenColor);
                    break;
                case 2:
                    resourceId = Context.Resources.GetIdentifier("blue_color", "drawable", Context.PackageName);
                    rightBlock.Color.SetImageResource(resourceId);
                    rightBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.blueColor);
                    break;
                case 3:
                    resourceId = Context.Resources.GetIdentifier("yellow_color", "drawable", Context.PackageName);
                    rightBlock.Color.SetImageResource(resourceId);
                    rightBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.yellowColor);
                    break;
                case 4:
                    resourceId = Context.Resources.GetIdentifier("red_color", "drawable", Context.PackageName);
                    rightBlock.Color.SetImageResource(resourceId);
                    rightBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.redColor);
                    break;
                case 5:
                    resourceId = Context.Resources.GetIdentifier("black_color", "drawable", Context.PackageName);
                    rightBlock.Color.SetImageResource(resourceId);
                    rightBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.blackColor);
                    break;
            }
        }

        private int DecideCorrecttAnswer()
        {
            Random rnd = new Random();
            return rnd.Next(0, 2); // 0 - Left color is correct, 1 - right
        }
    }
}