﻿using System;
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
    class LevelTwoFragment : Android.Support.V4.App.Fragment
    {
        private MediaPlayer player;
        private Block leftBlock = new Block();
        private Block rightBlock = new Block();
        private ImageView homeButton;
        public int CorrectAnswers { get; set; }

        public LevelTwoFragment(int correctAnswers)
        {
            CorrectAnswers = correctAnswers;
        }
        private int DecideCorrecttAnswer()
        {
            Random rnd = new Random();
            return rnd.Next(0, 2); // 0 - Left color is correct, 1 - right
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.level_two_fragment, container, false);
            leftBlock.Color = view.FindViewById<ImageView>(Resource.Id.imageViewLeftBox);
            rightBlock.Color = view.FindViewById<ImageView>(Resource.Id.imageViewRightBox);
            homeButton = view.FindViewById<ImageView>(Resource.Id.imageViewHomeButtonLevelTwo);
            homeButton.Click += HomeButton_Click;
            GenerateRandomColorAndSetMediaPlayer(leftBlock, rightBlock);
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

        private void HomeButton_Click(object sender, EventArgs e)
        {
            player = MediaPlayer.Create(Activity, Resource.Raw.plop_sound);
            player.Start();
            Android.Support.V4.App.Fragment fragmentLogin = new ChooseLevelFragment();
            FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();
        }

        private void LeftBlock_Click(object sender, EventArgs e)
        {
            player = MediaPlayer.Create(Activity, Resource.Raw.plop_sound);
            player.Start();
            if (leftBlock.IsCorrectAnswer)
            {
                CorrectAnswers++;
                player = MediaPlayer.Create(Activity, Resource.Raw.correctAnswer);
                player.Start();
                if(CorrectAnswers == 5)
                {
                    Android.Support.V4.App.Fragment fragmentLogin = new YouTubeVideo();
                    FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();
                }
               else
                {
                    Android.Support.V4.App.Fragment fragmentLogin = new LevelTwoFragment(CorrectAnswers);
                    FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();
                }
            }
            else
            {
                player = MediaPlayer.Create(Activity, Resource.Raw.hmmThinkAgain);
                player.Start();
                //wait to 2 sec
                rightBlock.Player.Start();
            }
        }

        private void RightBlock_Click(object sender, EventArgs e)
        {
            player = MediaPlayer.Create(Activity, Resource.Raw.plop_sound);
            player.Start();
            if (rightBlock.IsCorrectAnswer)
            {
                CorrectAnswers++;
                player = MediaPlayer.Create(Activity, Resource.Raw.correctAnswer);
                player.Start();
                if (CorrectAnswers == 5)
                {
                  
                    Android.Support.V4.App.Fragment fragmentLogin = new YouTubeVideo();
                    FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();
                }
                else
                {
                    Android.Support.V4.App.Fragment fragmentLogin = new LevelTwoFragment(CorrectAnswers);
                    FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();
                }
              
            }
            else
            {
                player = MediaPlayer.Create(Activity, Resource.Raw.hmmThinkAgain);
                player.Start();
                // wait 2 sec.
                leftBlock.Player.Start();
            }

        }
        // Diference between level One and Level Two is here we have double chance for view new colors
        private void GenerateRandomColorAndSetMediaPlayer(Block leftBlock, Block rightBlock)
        {
            Random rnd = new Random();
            int pickedLeftColor = rnd.Next(0, 13);
            int pickedRightColor = rnd.Next(0, 13);
            while (pickedLeftColor == pickedRightColor)
            {
                pickedRightColor = rnd.Next(0, 13);
            }
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
                case 6:
                    resourceId = Context.Resources.GetIdentifier("brown", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.brownColor);
                    break;
                case 7:
                    resourceId = Context.Resources.GetIdentifier("dark_green", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.darkGreenColor);
                    break;
                case 8:
                    resourceId = Context.Resources.GetIdentifier("gray","drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.grayColor);
                    break;
                case 9:
                    resourceId = Context.Resources.GetIdentifier("light_blue", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.lightBlueColor);
                    break;
                case 10:
                    resourceId = Context.Resources.GetIdentifier("orange", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.orangeColor);
                    break;
                case 11:
                    resourceId = Context.Resources.GetIdentifier("purple", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.purpleColor);
                    break;
                case 12:
                    resourceId = Context.Resources.GetIdentifier("pink", "drawable", Context.PackageName);
                    leftBlock.Color.SetImageResource(resourceId);
                    leftBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.pinkColor);
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
                case 6:
                    resourceId = Context.Resources.GetIdentifier("brown", "drawable", Context.PackageName);
                    rightBlock.Color.SetImageResource(resourceId);
                    rightBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.brownColor);
                    break;
                case 7:
                    resourceId = Context.Resources.GetIdentifier("dark_green", "drawable", Context.PackageName);
                    rightBlock.Color.SetImageResource(resourceId);
                    rightBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.darkGreenColor);
                    break;
                case 8:
                    resourceId = Context.Resources.GetIdentifier("gray", "drawable", Context.PackageName);
                    rightBlock.Color.SetImageResource(resourceId);
                    rightBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.grayColor);
                    break;
                case 9:
                    resourceId = Context.Resources.GetIdentifier("light_blue", "drawable", Context.PackageName);
                    rightBlock.Color.SetImageResource(resourceId);
                    rightBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.lightBlueColor);
                    break;
                case 10:
                    resourceId = Context.Resources.GetIdentifier("orange", "drawable", Context.PackageName);
                    rightBlock.Color.SetImageResource(resourceId);
                    rightBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.orangeColor);
                    break;
                case 11:
                    resourceId = Context.Resources.GetIdentifier("purple", "drawable", Context.PackageName);
                    rightBlock.Color.SetImageResource(resourceId);
                    rightBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.purpleColor);
                    break;
                case 12:
                    resourceId = Context.Resources.GetIdentifier("pink", "drawable", Context.PackageName);
                    rightBlock.Color.SetImageResource(resourceId);
                    rightBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.pinkColor);
                    break;
            }
        }
    }
}