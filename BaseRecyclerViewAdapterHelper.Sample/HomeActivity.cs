using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using BaseRecyclerViewAdapterHelper.Sample.Adapter;
using BaseRecyclerViewAdapterHelper.Sample.Entity;
using System;
using System.Collections.Generic;

namespace BaseRecyclerViewAdapterHelper.Sample
{
    [Activity(LaunchMode = LaunchMode.SingleTask)] // TODO
    public class HomeActivity : AppCompatActivity
    {
        static readonly Type[] ActivityTypes = new Type[] { typeof(AnimationUseActivity), typeof(MultipleItemUseActivity), typeof(HeaderAndFooterUseActivity)/*, typeof(PullToRefreshUseActivity), typeof(SectionUseActivity), typeof(EmptyViewUseActivity), typeof(ItemDragAndSwipeUseActivity), typeof(ItemClickActivity), typeof(ExpandableUseActivity), typeof(DataBindingUseActivity), typeof(UpFetchUseActivity)*/};
        static readonly string[] Titles = { "Animation", "MultipleItem", "Header/Footer" /*, "PullToRefresh", "Section", "EmptyView", "DragAndSwipe", "ItemClick", "ExpandableItem", "DataBinding", "UpFetchData" */ };
        static readonly int[] Images = { Resource.Mipmap.gv_animation, Resource.Mipmap.gv_multipleltem, Resource.Mipmap.gv_header_and_footer /*, Resource.Mipmap.gv_pulltorefresh, Resource.Mipmap.gv_section, Resource.Mipmap.gv_empty, Resource.Mipmap.gv_drag_and_swipe, Resource.Mipmap.gv_item_click, Resource.Mipmap.gv_expandable, Resource.Mipmap.gv_databinding, Resource.Drawable.gv_up_fetch */ };

        List<HomeItem> _dataList;
        RecyclerView _recyclerView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_home);
            InitView();
            InitData();
            InitAdapter();
        }

        void InitView()
        {
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.rv_list);
            _recyclerView.SetLayoutManager(new GridLayoutManager(this, 2));
        }

        void InitAdapter()
        {
            var homeAdapter = new HomeAdapter(Resource.Layout.home_item_view, _dataList);
            homeAdapter.OpenLoadAnimation();
            View top = LayoutInflater.Inflate(Resource.Layout.top_view, (ViewGroup)_recyclerView.Parent, false);
            homeAdapter.AddHeaderView(top);
            homeAdapter.ItemClick += (s, e) =>
            {
                var intent = new Intent(this, ActivityTypes[e.Position]);
                StartActivity(intent);
            };

            _recyclerView.SetAdapter(homeAdapter);
        }

        void InitData()
        {
            _dataList = new List<HomeItem>();
            for (int i = 0; i < Titles.Length; i++)
            {
                var item = new HomeItem()
                {
                    Title = Titles[i],
                    ActivityType = ActivityTypes[i],
                    ImageResource = Images[i]
                };
                _dataList.Add(item);
            }
        }
    }
}
