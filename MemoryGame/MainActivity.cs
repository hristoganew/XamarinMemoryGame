using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemoryGame
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        TextView scoreElement;
        ImageView iv11, iv12, iv13, iv14, iv21, iv22, iv23, iv24, iv31, iv32, iv33, iv34, liv;
        JavaDictionary<string, int> dict = new JavaDictionary<string, int>();
        int counter = 0;
        int score = 100;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            scoreElement = FindViewById<TextView>(Resource.Id.score);

            iv11 = FindViewById<ImageView>(Resource.Id.iv11);
            iv11.Click += delegate { checkCard(iv11); };

            iv12 = FindViewById<ImageView>(Resource.Id.iv12);
            iv12.Click += delegate { checkCard(iv12); };

            iv13 = FindViewById<ImageView>(Resource.Id.iv13);
            iv13.Click += delegate { checkCard(iv13); };

            iv14 = FindViewById<ImageView>(Resource.Id.iv14);
            iv14.Click += delegate { checkCard(iv14); };

            iv21 = FindViewById<ImageView>(Resource.Id.iv21);
            iv21.Click += delegate { checkCard(iv21); };

            iv22 = FindViewById<ImageView>(Resource.Id.iv22);
            iv22.Click += delegate { checkCard(iv22); };

            iv23 = FindViewById<ImageView>(Resource.Id.iv23);
            iv23.Click += delegate { checkCard(iv23); };

            iv24 = FindViewById<ImageView>(Resource.Id.iv24);
            iv24.Click += delegate { checkCard(iv24); };

            iv31 = FindViewById<ImageView>(Resource.Id.iv31);
            iv31.Click += delegate { checkCard(iv31); };

            iv32 = FindViewById<ImageView>(Resource.Id.iv32);
            iv32.Click += delegate { checkCard(iv32); };

            iv33 = FindViewById<ImageView>(Resource.Id.iv33);
            iv33.Click += delegate { checkCard(iv33); };

            iv34 = FindViewById<ImageView>(Resource.Id.iv34);
            iv34.Click += delegate { checkCard(iv34); };

            prepareGame();

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        private void checkCard(ImageView im) {

            counter = counter + 1;

            var image = dict[im.Id.ToString()];

            if (liv != null)
            {
                if (image == dict[liv.Id.ToString()])
                {
                    im.SetImageResource(image);
                    liv = null;
                }
                else {

                    Task.Run(async () =>
                    {
                        im.SetImageResource(image);
                        await Task.Delay(1000);
                    }).ContinueWith(cw => {
                        liv.SetImageDrawable(null);
                        im.SetImageDrawable(null);
                        liv = null;
                    });
                }

            }
            else {
                im.SetImageResource(image);
                liv = im;
            }

            calculateScore();
        }


        private void prepareGame() {
            var arr1 = new List<int> {
                Resource.Drawable.car,
                Resource.Drawable.car,
                Resource.Drawable.spider,
                Resource.Drawable.spider,
                Resource.Drawable.motorcycle,
                Resource.Drawable.motorcycle,
                Resource.Drawable.spade,
                Resource.Drawable.spade,
                Resource.Drawable.tree,
                Resource.Drawable.tree,
                Resource.Drawable.house,
                Resource.Drawable.house };

            Random generator = new Random();
            int index = generator.Next(arr1.Count);
            dict[iv11.Id.ToString()] = arr1[index];
            arr1.RemoveAt(index);

            index = generator.Next(arr1.Count);
            dict[iv12.Id.ToString()] = arr1[index];
            arr1.RemoveAt(index);

            index = generator.Next(arr1.Count);
            dict[iv13.Id.ToString()] = arr1[index];
            arr1.RemoveAt(index);

            index = generator.Next(arr1.Count);
            dict[iv14.Id.ToString()] = arr1[index];
            arr1.RemoveAt(index);

            index = generator.Next(arr1.Count);
            dict[iv21.Id.ToString()] = arr1[index];
            arr1.RemoveAt(index);

            index = generator.Next(arr1.Count);
            dict[iv22.Id.ToString()] = arr1[index];
            arr1.RemoveAt(index);

            index = generator.Next(arr1.Count);
            dict[iv23.Id.ToString()] = arr1[index];
            arr1.RemoveAt(index);

            index = generator.Next(arr1.Count);
            dict[iv24.Id.ToString()] = arr1[index];
            arr1.RemoveAt(index);

            index = generator.Next(arr1.Count);
            dict[iv31.Id.ToString()] = arr1[index];
            arr1.RemoveAt(index);

            index = generator.Next(arr1.Count);
            dict[iv32.Id.ToString()] = arr1[index];
            arr1.RemoveAt(index);

            index = generator.Next(arr1.Count);
            dict[iv33.Id.ToString()] = arr1[index];
            arr1.RemoveAt(index);

            index = generator.Next(arr1.Count);
            dict[iv34.Id.ToString()] = arr1[index];
            arr1.RemoveAt(index);
        }

        private void calculateScore() {
            if (counter < 24)
            {
                var finalscore = score;
                scoreElement.Text = "Score - " + finalscore;
            }

            if (counter >= 24 && counter <= 30)
            {
                var finalscore = score / 2;
                scoreElement.Text = "Score - " + finalscore;
            }

            if (counter >= 30 && counter <= 36)
            {
                var finalscore = score / 3;
                scoreElement.Text = "Score - " + finalscore;
            }

            if (counter >= 36 && counter <= 40)
            {
                var finalscore = score / 4;
                scoreElement.Text = "Score - " + finalscore;
            }

            if (counter > 40)
            {
                var finalscore = 0;
                scoreElement.Text = "Score - " + finalscore;
            }
        }
    }
}