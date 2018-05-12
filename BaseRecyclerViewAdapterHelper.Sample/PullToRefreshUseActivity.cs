using System;
using System.Collections.Generic;

using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BaseRecyclerViewAdapterHelper.Sample.Adapter;
using BaseRecyclerViewAdapterHelper.Sample.Base;
using BaseRecyclerViewAdapterHelper.Sample.LoadMore;
using CymChad.BaseRecyclerViewAdapterHelper.Adapter.Base;
using CymChad.BaseRecyclerViewAdapterHelper.Adapter.Base.Listener;
using BaseRecyclerViewAdapterHelper.Sample.Entity;
using System.Threading.Tasks;
using BaseRecyclerViewAdapterHelper.Sample.Data;
using System.Collections;

namespace BaseRecyclerViewAdapterHelper.Sample
{
    [Activity]
    public class PullToRefreshUseActivity : BaseActivity
    {
        const int PageSize = 6;

        RecyclerView _recyclerView;
        SwipeRefreshLayout _swipeRefreshLayout;
        PullToRefreshAdapter _adapter;

        int _nextRequestPage = 1;

        static bool _firstPageNoMore;
        static bool _firstError = true;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.rv_list);
            _swipeRefreshLayout = FindViewById<SwipeRefreshLayout>(Resource.Id.swipeLayout);
            _swipeRefreshLayout.SetColorSchemeColors(Color.Rgb(47, 223, 189));
            _recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            SetTitle("Pull TO Refresh Use");
            SetBackBtn();
            InitAdapter();
            AddHeadView();
            InitRefreshLayout();
            _swipeRefreshLayout.Refreshing = true;
            Refresh();
        }

        void InitAdapter()
        {
            _adapter = new PullToRefreshAdapter();
            _adapter.LoadMore += (s, e) =>
            {
                LoadMore();
            };
            _adapter.OpenLoadAnimation(BaseQuickAdapter.SlideInLeft);
            _recyclerView.SetAdapter(_adapter);
            _recyclerView.AddOnItemTouchListener(new ItemClickListener(this));
        }

        void AddHeadView()
        {
            var headView = LayoutInflater.Inflate(Resource.Layout.head_view, (ViewGroup)_recyclerView.Parent, false);
            headView.FindViewById(Resource.Id.iv).Visibility = ViewStates.Gone;
            headView.FindViewById<TextView>(Resource.Id.tv).Text = "change load view";
            headView.Click += (s, e) =>
            {
                _adapter.SetNewData(null);
                _adapter.SetLoadMoreView(new CustomLoadMoreView());
                _recyclerView.SetAdapter(_adapter);
                Toast.MakeText(this, "change complete", ToastLength.Long).Show();

                _swipeRefreshLayout.Refreshing = true;
                Refresh();
            };
            _adapter.AddHeaderView(headView);
        }

        void InitRefreshLayout()
        {
            _swipeRefreshLayout.Refresh += (s, e) => Refresh();
        }

        void Refresh()
        {
            _nextRequestPage = 1;
            _adapter.SetEnableLoadMore(false);

            Request(_nextRequestPage, data =>
            {
                SetData(true, data);
                _adapter.SetEnableLoadMore(true);
                _swipeRefreshLayout.Refreshing = false;
            },
            e =>
            {
                Toast.MakeText(this, Resource.String.network_err, ToastLength.Long).Show();
                _adapter.SetEnableLoadMore(true);
                _swipeRefreshLayout.Refreshing = false;
            });
        }

        void LoadMore()
        {
            Request(_nextRequestPage, data =>
            {
                SetData(false, data);
            },
            e =>
            {
                _adapter.LoadMoreFail();
                Toast.MakeText(this, Resource.String.network_err, ToastLength.Long).Show();
            });
        }

        void SetData(bool isRefresh, IList data)
        {
            _nextRequestPage++;
            var size = data?.Count ?? 0;
            if (isRefresh)
            {
                _adapter.SetNewData(data);
            }
            else
            {
                if (size > 0)
                {
                    _adapter.AddData(data);
                }
            }
            if (size < PageSize)
            {
                _adapter.LoadMoreEnd(isRefresh);
                Toast.MakeText(this, "no more data", ToastLength.Short).Show();
            }
            else
            {
                _adapter.LoadMoreComplete();
            }
        }

        void Request(int page, Action<List<Status>> success, Action<Exception> fail)
        {
            var handler = new Handler(Looper.MainLooper);

            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(500);

                if (page == 2 && _firstError)
                {
                    _firstError = false;
                    handler.Post(() => fail(new Exception("fail")));
                }
                else
                {
                    var size = PageSize;
                    if (page == 1)
                    {
                        if (_firstPageNoMore)
                        {
                            size = 1;
                        }
                        _firstPageNoMore = !_firstPageNoMore;
                        if (!_firstError)
                        {
                            _firstError = true;
                        }
                    }
                    else if (page == 4)
                    {
                        size = 1;
                    }

                    var dataSize = size;
                    handler.Post(() => success(DataServer.GetSampleData(dataSize)));
                }
            });
        }

        class ItemClickListener : OnItemClickListener
        {
            readonly Activity _activity;

            public ItemClickListener(Activity activity)
            {
                _activity = activity;
            }

            public override void OnSimpleItemClick(BaseQuickAdapter adapter, View view, int position)
            {
                Toast.MakeText(_activity, $"{position}", ToastLength.Long).Show();
            }
        }
    }
}
