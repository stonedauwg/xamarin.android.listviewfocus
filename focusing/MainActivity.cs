using System;
using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace focusing
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize, LaunchMode = LaunchMode.SingleTop,
        WindowSoftInputMode = SoftInput.AdjustNothing)]
    public class MainActivity : AppCompatActivity, View.IOnFocusChangeListener
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.ReceiptViewPage);
            RelativeLayout centerView = FindViewById<RelativeLayout>(Resource.Id.ReceiptViewPageLayout);
            // Create our data detail view the NEW way
            RecyclerView dataDetailView = new RecyclerView(this);
            dataDetailView.SetLayoutManager(new LinearLayoutManager(this));
            dataDetailView.SetAdapter(new RecyclerDataDetailAdapter());
            // Create our data detail view the OLD
            //ERSDataDetailTableAdapter adapter = new ERSDataDetailTableAdapter(this)
            //ListView dataDetailView = new ListView(this)
            //{
            //    DescendantFocusability = DescendantFocusability.AfterDescendants,
            //    Enabled = true,
            //    Visibility = ViewStates.Visible,

            //    Divider = new ColorDrawable(Color.Argb(255, 170, 170, 170)), // UIColor.LightGrayColor
            //    DividerHeight = 1,
            //    //dataDetailView.FastScrollEnabled = true;
            //    //dataDetailView.FastScrollAlwaysVisible = true;
            //    VerticalScrollBarEnabled = true,
            //    //dataDetailView.ScrollBarSize = 10;
            //    ScrollBarStyle = ScrollbarStyles.InsideOverlay,
            //    ChoiceMode = ChoiceMode.None
            //};

            //dataDetailView.SetBackgroundColor(Color.Argb(230, 255, 255, 255));
            //dataDetailView.Adapter = adapter;
            centerView.AddView(dataDetailView);
            centerView.OnFocusChangeListener = this;
            dataDetailView.OnFocusChangeListener = this;
        }

        public void OnFocusChange(View v, bool hasFocus)
        {
            Console.WriteLine($"adapter focuschange:{v} hasfocus={hasFocus}");
            
        }
    }
}

