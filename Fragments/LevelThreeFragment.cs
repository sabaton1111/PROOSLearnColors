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
    public class LevelThreeFragment : Android.Support.V4.App.Fragment
    {
        private MediaPlayer player;
        private Block leftBlock = new Block();
        private Block rightBlock = new Block();
        private Block middleBlock = new Block();
        private int pickedLeftColor;
        private int pickedMiddleColor;
        private int pickedRightColor;
        private int correctAnswer;
        private Stack<int> shapes = new Stack<int>();
        private ImageView homeButton;
        public int PickedLeftColor { get; set; }
        public int PickedRightColor { get; set; }
        public int PickedMiddleColor { get; set; }
        public int CorrectAnswer { get; set; }
        private int DecideCorrecttAnswer()
        {
            Random rnd = new Random();
            return rnd.Next(0, 3); // 0 - Left color is correct, 1 - right
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.level_three_fragment, container, false);
            leftBlock.Color = view.FindViewById<ImageView>(Resource.Id.imageViewLeftBox);
            rightBlock.Color = view.FindViewById<ImageView>(Resource.Id.imageViewRightBox);
            middleBlock.Color = view.FindViewById<ImageView>(Resource.Id.imageViewMiddleBox);
            homeButton = view.FindViewById<ImageView>(Resource.Id.imageViewHome);
            homeButton.Click += HomeButton_Click;
            GenerateRandomColorAndSetMediaPlayer(leftBlock, middleBlock, rightBlock);
            //leftBlock.Color.Click += LeftBlock_Click;
            //middleBlock.Color.Click += MiddleBlock_Click;
            //rightBlock.Color.Click += RightBlock_Click;


            //if (correctAnswer == 0)
            //{
            //    leftBlock.IsCorrectAnswer = true;
            //}
            //else if (correctAnswer == 1)
            //{
            //    middleBlock.IsCorrectAnswer = true;
            //}
            //else
            //{
            //    rightBlock.IsCorrectAnswer = true;
            //}
            

            return view;

        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            player = MediaPlayer.Create(Activity, Resource.Raw.plop_sound);
            player.Start();
            Android.Support.V4.App.Fragment fragmentLogin = new ChooseLevelFragment();
            FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();
        }

        private void Box(int pickedColor, int pickedShape, Block pickedBlock)
        {
            int resourceId;
            switch (pickedColor)
            {
                case 0:
                    if (pickedShape == 0)
                    {
                       
                        resourceId = Context.Resources.GetIdentifier("black_rectangle", "drawable", Context.PackageName);

                    }
                    else if (pickedShape == 1)
                    {
                       
                        resourceId = Context.Resources.GetIdentifier("circle_black", "drawable", Context.PackageName);

                    }
                    else if (pickedShape == 2)
                    {
                       
                        resourceId = Context.Resources.GetIdentifier("black_triangle", "drawable", Context.PackageName);

                    }
                    else
                    {
                      
                        resourceId = Context.Resources.GetIdentifier("square_black", "drawable", Context.PackageName);

                    }
                    //setting image background from id 
                    //resourceId = Context.Resources.GetIdentifier("white_color", "drawable", Context.PackageName);
                    pickedBlock.Color.SetImageResource(resourceId);
                    //pickedBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.blackColor);
                    break;
                case 1:
                    if (pickedShape == 0)
                    {
                        
                        resourceId = Context.Resources.GetIdentifier("white_rectangle", "drawable", Context.PackageName);

                    }
                    else if (pickedShape == 1)
                    {
                 
                        resourceId = Context.Resources.GetIdentifier("circle_white", "drawable", Context.PackageName);

                    }
                    else if (pickedShape == 2)
                    {
                      
                        resourceId = Context.Resources.GetIdentifier("white_triangle", "drawable", Context.PackageName);

                    }
                    else
                    {
                     
                        resourceId = Context.Resources.GetIdentifier("square_white", "drawable", Context.PackageName);

                    }
                    // resourceId = Context.Resources.GetIdentifier("green_color", "drawable", Context.PackageName);
                    pickedBlock.Color.SetImageResource(resourceId);
                    // pickedBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.whiteColor);
                    break;
                case 2:
                    if (pickedShape == 0)
                    {
                       // shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("red_rectangle", "drawable", Context.PackageName);

                    }
                    else if (pickedShape == 1)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("circle_red", "drawable", Context.PackageName);

                    }
                    else if (pickedShape == 2)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("red_triangle", "drawable", Context.PackageName);

                    }
                    else
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("square_red", "drawable", Context.PackageName);

                    }
                    // resourceId = Context.Resources.GetIdentifier("blue_color", "drawable", Context.PackageName);
                    pickedBlock.Color.SetImageResource(resourceId);
                    //  pickedBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.redColor);
                    break;
                case 3:
                    if (pickedShape == 0)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("gray_rectangle", "drawable", Context.PackageName);

                    }
                    else if (pickedShape == 1)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("circle_gray", "drawable", Context.PackageName);

                    }
                    else if (pickedShape == 2)
                    {
                       // shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("gray_triangle", "drawable", Context.PackageName);

                    }
                    else
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("square_gray", "drawable", Context.PackageName);

                    }
                    // resourceId = Context.Resources.GetIdentifier("yellow_color", "drawable", Context.PackageName);
                    pickedBlock.Color.SetImageResource(resourceId);
                    //  pickedBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.grayColor);
                    break;
                case 4:
                    if (pickedShape == 0)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("purple_rectangle", "drawable", Context.PackageName);

                    }
                    else if (pickedShape == 1)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("circle_purple", "drawable", Context.PackageName);

                    }
                    else if (pickedShape == 2)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("purple_triangle", "drawable", Context.PackageName);

                    }
                    else
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("square_purple", "drawable", Context.PackageName);

                    }
                    //resourceId = Context.Resources.GetIdentifier("red_color", "drawable", Context.PackageName);
                    pickedBlock.Color.SetImageResource(resourceId);
                    //  pickedBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.purpleColor);
                    break;
                case 5:
                    if (pickedShape == 0)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("pink_rectangle", "drawable", Context.PackageName);

                    }
                    else if (pickedShape == 1)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("circle_pink", "drawable", Context.PackageName);

                    }
                    else if (pickedShape == 2)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("pink_triangle", "drawable", Context.PackageName);

                    }
                    else
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("square_pink", "drawable", Context.PackageName);

                    }
                    //resourceId = Context.Resources.GetIdentifier("black_color", "drawable", Context.PackageName);
                    pickedBlock.Color.SetImageResource(resourceId);
                    //     pickedBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.pinkColor);
                    break;
                case 6:
                    if (pickedShape == 0)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("blue_rectangle", "drawable", Context.PackageName);

                    }
                    else if (pickedShape == 1)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("circle_blue", "drawable", Context.PackageName);

                    }
                    else if (pickedShape == 2)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("blue_triangle", "drawable", Context.PackageName);

                    }
                    else
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("square_blue", "drawable", Context.PackageName);

                    }
                    pickedBlock.Color.SetImageResource(resourceId);
                    //     pickedBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.blueColor);
                    break;
                case 7:
                    if (pickedShape == 0)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("green_rectangle", "drawable", Context.PackageName);

                    }
                    else if (pickedShape == 1)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("circle_green", "drawable", Context.PackageName);

                    }
                    else if (pickedShape == 2)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("green_triangle", "drawable", Context.PackageName);

                    }
                    else
                    {
                        resourceId = Context.Resources.GetIdentifier("square_green", "drawable", Context.PackageName);
                        //shapes.Push(pickedShape);
                    }
                    //resourceId = Context.Resources.GetIdentifier("brown", "drawable", Context.PackageName);
                    pickedBlock.Color.SetImageResource(resourceId);
                    //      pickedBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.greenColor);
                    break;
                case 8:
                    if (pickedShape == 0)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("yellow_rectangle", "drawable", Context.PackageName);

                    }
                    else if (pickedShape == 1)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("circle_yellow", "drawable", Context.PackageName);

                    }
                    else if (pickedShape == 2)
                    {
                        //shapes.Push(pickedShape);
                        resourceId = Context.Resources.GetIdentifier("yellow_triangle", "drawable", Context.PackageName);

                    }
                    else
                    {
                        resourceId = Context.Resources.GetIdentifier("square_yellow", "drawable", Context.PackageName);
                        //shapes.Push(pickedShape);
                    }
                    pickedBlock.Color.SetImageResource(resourceId);
                    //   pickedBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.yellowColor);
                    break;
                case 9:
                    if (pickedShape == 0)
                    {
                        resourceId = Context.Resources.GetIdentifier("brown_rectangle", "drawable", Context.PackageName);
                        //shapes.Push(pickedShape);
                    }
                    else if (pickedShape == 1)
                    {
                        resourceId = Context.Resources.GetIdentifier("circle_brown", "drawable", Context.PackageName);
                        //shapes.Push(pickedShape);
                    }
                    else if (pickedShape == 2)
                    {
                        resourceId = Context.Resources.GetIdentifier("brown_triangle", "drawable", Context.PackageName);
                        //shapes.Push(pickedShape);
                    }
                    else
                    {
                        resourceId = Context.Resources.GetIdentifier("square_brown", "drawable", Context.PackageName);
                        //shapes.Push(pickedShape);
                    }
                    //resourceId = Context.Resources.GetIdentifier("darkGreen", "drawable", Context.PackageName);
                    pickedBlock.Color.SetImageResource(resourceId);
                    //     pickedBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.brownColor);
                    break;
                case 10:
                    if (pickedShape == 0)
                    {
                        resourceId = Context.Resources.GetIdentifier("orange_rectangle", "drawable", Context.PackageName);
                        //shapes.Push(pickedShape);
                    }
                    else if (pickedShape == 1)
                    {
                        resourceId = Context.Resources.GetIdentifier("circle_orange", "drawable", Context.PackageName);
                        //shapes.Push(pickedShape);
                    }
                    else if (pickedShape == 2)
                    {
                        resourceId = Context.Resources.GetIdentifier("orange_triangle", "drawable", Context.PackageName);
                        //shapes.Push(pickedShape);
                    }
                    else
                    {
                        resourceId = Context.Resources.GetIdentifier("square_orange", "drawable", Context.PackageName);
                        //shapes.Push(pickedShape);
                    }
                    pickedBlock.Color.SetImageResource(resourceId);
                    //pickedBlock.Player = MediaPlayer.Create(Activity, Resource.Raw.orangeColor);
                    break;

            }
        }
        private void GenerateRandomColorAndSetMediaPlayer(Block leftBlock, Block middleBlock, Block rightBlock)
        {
            Random rnd = new Random();
            int pickedLeftColor = rnd.Next(0, 11);
            int pickedRightColor = rnd.Next(0, 11);
            int pickedMiddleColor = rnd.Next(0, 11);
            int leftShape = rnd.Next(0, 4);
            shapes.Push(leftShape);
            int rightShape = rnd.Next(0, 4);
            
            int middleShape = rnd.Next(0, 4);
            shapes.Push(middleShape);
            shapes.Push(rightShape);
            while (pickedLeftColor == pickedRightColor || pickedLeftColor == pickedMiddleColor)
            {
                pickedRightColor = rnd.Next(0, 11);
            }
            while (pickedMiddleColor == pickedRightColor || pickedMiddleColor == pickedLeftColor)
            {
                pickedMiddleColor = rnd.Next(0, 11);
            }
            while (pickedMiddleColor == pickedRightColor || pickedRightColor == pickedLeftColor)
            {
                pickedRightColor = rnd.Next(0, 11);
            }

            while (leftShape == rightShape || leftShape == middleShape)
            {
                leftShape = rnd.Next(0, 4);
            }
            while (middleShape == rightShape || middleShape == leftShape)
            {
                middleShape = rnd.Next(0, 4);
            }
            while (rightShape == leftShape || rightShape == middleShape)
            {
                rightShape = rnd.Next(0, 4);
            }
            Box(pickedLeftColor, leftShape, leftBlock);
            Box(pickedMiddleColor, middleShape, middleBlock);
            Box(pickedRightColor, rightShape, rightBlock);
            player = MediaPlayer.Create(Activity, Resource.Raw.rememberObjects);
            player.Start();

            PickedLeftColor = pickedLeftColor;
            PickedMiddleColor = pickedMiddleColor;
            PickedRightColor = pickedRightColor;
            CorrectAnswer = DecideCorrecttAnswer();

            var t = Task.Run(() => {
                Thread.Sleep(6000);
                Android.Support.V4.App.Fragment fragmentLogin = new PickColor(PickedLeftColor, PickedMiddleColor, PickedRightColor, CorrectAnswer, shapes);
                FragmentManager.BeginTransaction().Replace(Resource.Id.parent_fragment, fragmentLogin).Commit();
            });
            
        }
        //10 1 9
    }
}