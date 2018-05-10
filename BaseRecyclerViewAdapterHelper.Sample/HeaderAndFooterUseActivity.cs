using System;

using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BaseRecyclerViewAdapterHelper.Sample.Adapter;
using BaseRecyclerViewAdapterHelper.Sample.Base;
using BaseRecyclerViewAdapterHelper.Sample.Data;

namespace BaseRecyclerViewAdapterHelper.Sample
{
    [Activity]
    public class HeaderAndFooterUseActivity : BaseActivity
    {
        RecyclerView _recyclerView;
        HeaderAndFooterAdapter _headerAndFooterAdapter;

        const int PageSize = 3;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetBackBtn();
            SetTitle("HeaderAndFooter Use");

            SetContentView(Resource.Layout.activity_header_and_footer_use);
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.rv_list);
            _recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            InitAdapter();

            var headerView = GetHeaderView(0, v => _headerAndFooterAdapter.AddHeaderView(GetHeaderView(1, GetRemoveHeaderAction()), 0));
            _headerAndFooterAdapter.AddHeaderView(headerView);

            var footerView = GetFooterView(0, v => _headerAndFooterAdapter.AddFooterView(GetFooterView(1, GetRemoveFooterAction()), 0));
            _headerAndFooterAdapter.AddFooterView(footerView, 0);

            _recyclerView.SetAdapter(_headerAndFooterAdapter);
        }

        View GetHeaderView(int type, Action<View> action)
        {
            var view = LayoutInflater.Inflate(Resource.Layout.head_view, (ViewGroup)_recyclerView.Parent, false);
            if (type == 1)
            {
                var imageView = view.FindViewById<ImageView>(Resource.Id.iv);
                imageView.SetImageResource(Resource.Mipmap.rm_icon);
            }
            view.Click += (s, e) => action(s as View);
            return view;
        }

        View GetFooterView(int type, Action<View> action)
        {
            var view = LayoutInflater.Inflate(Resource.Layout.footer_view, (ViewGroup)_recyclerView.Parent, false);
            if (type == 1)
            {
                var imageView = view.FindViewById<ImageView>(Resource.Id.iv);
                imageView.SetImageResource(Resource.Mipmap.rm_icon);
            }
            view.Click += (s, e) => action(s as View);
            return view;
        }

        Action<View> GetRemoveHeaderAction() => v => _headerAndFooterAdapter.RemoveHeaderView(v);

        Action<View> GetRemoveFooterAction() => v => _headerAndFooterAdapter.RemoveFooterView(v);

        void InitAdapter()
        {
            _headerAndFooterAdapter = new HeaderAndFooterAdapter(PageSize);
            _headerAndFooterAdapter.OpenLoadAnimation();
            _recyclerView.SetAdapter(_headerAndFooterAdapter);
            _headerAndFooterAdapter.ItemClick += (s, e) =>
            {
                e.Adapter.SetNewData(DataServer.GetSampleData(PageSize));
                Toast.MakeText(this, $"{e.Position}", ToastLength.Long).Show();
            };
        }
    }
}
