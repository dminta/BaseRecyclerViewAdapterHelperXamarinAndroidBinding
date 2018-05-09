
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;

namespace BaseRecyclerViewAdapterHelper.Sample
{
    [Activity(MainLauncher = true)]
    public class WelcomeActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_welcome);
            new Handler().PostDelayed(() =>
            {
                var intent = new Intent(this, typeof(HomeActivity));
                StartActivity(intent);
                Finish();
            }, 2000);
        }
    }
}
