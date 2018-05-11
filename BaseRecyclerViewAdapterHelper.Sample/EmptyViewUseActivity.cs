
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using BaseRecyclerViewAdapterHelper.Sample.Adapter;
using BaseRecyclerViewAdapterHelper.Sample.Base;
using BaseRecyclerViewAdapterHelper.Sample.Data;

namespace BaseRecyclerViewAdapterHelper.Sample
{
    [Activity]
    public class EmptyViewUseActivity : BaseActivity, View.IOnClickListener
    {
        RecyclerView _recyclerView;
        QuickAdapter _quickAdapter;
        View _notDataView;
        View _errorView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetBackBtn();
            SetTitle("EmptyView Use");
            SetContentView(Resource.Layout.activity_empty_view_use);
            FindViewById(Resource.Id.btn_reset).SetOnClickListener(this);
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.rv_list);
            _recyclerView.HasFixedSize = true;
            _recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            _notDataView = LayoutInflater.Inflate(Resource.Layout.empty_view, (ViewGroup)_recyclerView.Parent, false);
            _notDataView.Click += (s, e) => OnRefresh();

            _errorView = LayoutInflater.Inflate(Resource.Layout.error_view, (ViewGroup)_recyclerView.Parent, false);
            _errorView.Click += (s, e) => OnRefresh();

            InitAdapter();
            OnRefresh();
        }

        void InitAdapter()
        {
            _quickAdapter = new QuickAdapter(0);
            _recyclerView.SetAdapter(_quickAdapter);
        }

        public void OnClick(View v)
        {
            _error = true;
            _noData = true;
            _quickAdapter.SetNewData(null);
            OnRefresh();
        }

        bool _error = true;
        bool _noData = true;

        void OnRefresh()
        {
            _quickAdapter.SetEmptyView(Resource.Layout.loading_view, (ViewGroup)_recyclerView.Parent);
            new Handler().PostDelayed(() =>
            {
                if (_error)
                {
                    _quickAdapter.EmptyView = _errorView;
                    _error = false;
                }
                else
                {
                    if (_noData)
                    {
                        _quickAdapter.EmptyView = _notDataView;
                        _noData = false;
                    }
                    else;
                    {
                        _quickAdapter.SetNewData(DataServer.GetSampleData(10));
                    }
                }

            }, 1000);
        }
    }
}
