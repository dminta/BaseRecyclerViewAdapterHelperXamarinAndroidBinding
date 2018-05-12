using System;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Orhanobut.Logger;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace BaseRecyclerViewAdapterHelper.Sample.Base
{
    public class BaseActivity : AppCompatActivity
    {
        class OnClickListenerImpl : Java.Lang.Object, View.IOnClickListener
        {
            readonly BaseActivity _activity;
            
            public OnClickListenerImpl(BaseActivity activity)
            {
                _activity = activity;
            }

            public void OnClick(View v)
            {
                if (v == _activity._back)
                {
                    _activity.Finish();
                }
            }
        }

        TextView _title;
        ImageView _back;

        protected string Tag => Java.Lang.Class.FromType(GetType()).SimpleName;

        protected void SetTitle(string msg)
        {
            if (msg != null)
            {
                _title.Text = msg;
            }
        }

        protected void SetBackBtn()
        {
            if (_back != null)
            {
                _back.Visibility = ViewStates.Visible;
                _back.SetOnClickListener(new OnClickListenerImpl(this));
            }
            else
            {
                Logger.T(Tag).E("back is null ,please check out");
            }
        }

        protected void SetBackClickListener(View.IOnClickListener l)
        {
            if (_back != null)
            {
                _back.Visibility = ViewStates.Visible;
                _back.SetOnClickListener(l);
            }
            else
            {
                Logger.T(Tag).E("back is null ,please check out");
            }
        }

        LinearLayout _rootLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                Window.SetFlags(WindowManagerFlags.TranslucentStatus,
                    WindowManagerFlags.TranslucentStatus);
            }
            base.SetContentView(Resource.Layout.activity_base);
            InitToolbar();
        }

        void InitToolbar()
        {
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
            }

            SupportActionBar?.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar?.SetDisplayShowTitleEnabled(false);

            _back = FindViewById<ImageView>(Resource.Id.img_back);
            _title = FindViewById<TextView>(Resource.Id.title);
        }

        public override void SetContentView(int layoutId)
        {
            SetContentView(View.Inflate(this, layoutId, null));
        }

        public override void SetContentView(View view)
        {
            _rootLayout = FindViewById<LinearLayout>(Resource.Id.root_layout);
            if (_rootLayout == null)
            {
                return;
            }
            _rootLayout.AddView(view, new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
            InitToolbar();
        }
    }
}