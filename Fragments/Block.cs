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
    public class Block
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
}