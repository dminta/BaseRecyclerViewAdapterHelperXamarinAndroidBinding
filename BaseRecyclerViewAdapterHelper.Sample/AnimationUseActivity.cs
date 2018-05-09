using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using BaseRecyclerViewAdapterHelper.Sample.Adapter;
using BaseRecyclerViewAdapterHelper.Sample.Animation;
using BaseRecyclerViewAdapterHelper.Sample.Entity;
using Chad.BaseRecyclerViewAdapterHelper.Adapter.Base;
using Com.Jaredrummler.Materialspinner;
using Com.Kyleduo.Switchbutton;
using System.Collections.Generic;

namespace BaseRecyclerViewAdapterHelper.Sample
{
    [Activity]
    public class AnimationUseActivity : Activity
    {
        RecyclerView _recyclerView;
        AnimationAdapter _animationAdapter;
        ImageView _imgBtn;
        int _firstPageItemCount = 3;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_adapter_use);
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.rv_list);
            _recyclerView.HasFixedSize = true;
            _recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            InitAdapter();
            InitMenu();
            InitView();
        }

        void InitView()
        {
            _imgBtn = FindViewById<ImageView>(Resource.Id.img_back);
            _imgBtn.Click += (s, e) => Finish();
        }

        void InitAdapter()
        {
            _animationAdapter = new AnimationAdapter();
            _animationAdapter.OpenLoadAnimation();
            _animationAdapter.SetNotDoAnimationCount(_firstPageItemCount);
            _animationAdapter.ItemChildClick += (s, e) =>
            {
                string content = null;
                var status = (Status)e.Adapter.GetItem(e.Position);
                var id = e.View.Id;

                if (id == Resource.Id.img)
                {
                    content = $"img:{status.UserAvatar}";
                    Toast.MakeText(this, content, ToastLength.Long).Show();
                }
                else if (id == Resource.Id.tweetName)
                {
                    content = $"name:{status.UserAvatar}";
                    Toast.MakeText(this, content, ToastLength.Long).Show();
                }
                else if (id == Resource.Id.tweetText)
                {
                    content = $"tweetText:{status.UserAvatar}";
                    Toast.MakeText(this, content, ToastLength.Long).Show();
                }
            };
            _recyclerView.SetAdapter(_animationAdapter);
        }

        void InitMenu()
        {
            var spinner = FindViewById<MaterialSpinner>(Resource.Id.spinner);
            spinner.SetItems(new List<string>() { "AlphaIn", "ScaleIn", "SlideInBottom", "SlideInLeft", "SlideInRight", "Custom" });
            spinner.ItemSelected += (s, e) =>
            {
                switch (e.P1)
                {
                    case 0:
                        _animationAdapter.OpenLoadAnimation(BaseQuickAdapter.AlphaIn);
                        break;
                    case 1:
                        _animationAdapter.OpenLoadAnimation(BaseQuickAdapter.ScaleIn);
                        break;
                    case 2:
                        _animationAdapter.OpenLoadAnimation(BaseQuickAdapter.SlideInBottom);
                        break;
                    case 3:
                        _animationAdapter.OpenLoadAnimation(BaseQuickAdapter.SlideInLeft);
                        break;
                    case 4:
                        _animationAdapter.OpenLoadAnimation(BaseQuickAdapter.SlideInRight);
                        break;
                    case 5:
                        _animationAdapter.OpenLoadAnimation(new CustomAnimation());
                        break;
                }
                _recyclerView.SetAdapter(_animationAdapter);
            };

            _animationAdapter.IsFirstOnly(false);
            var switchButton = FindViewById<SwitchButton>(Resource.Id.switch_button);
            switchButton.CheckedChange += (s, e) =>
            {
                _animationAdapter.IsFirstOnly(e.IsChecked);
                _animationAdapter.NotifyDataSetChanged();
            };
        }
    }
}
