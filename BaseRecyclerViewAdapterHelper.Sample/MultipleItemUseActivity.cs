using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BaseRecyclerViewAdapterHelper.Sample.Adapter;
using BaseRecyclerViewAdapterHelper.Sample.Base;
using BaseRecyclerViewAdapterHelper.Sample.Data;
using BaseRecyclerViewAdapterHelper.Sample.Entity;
using Chad.BaseRecyclerViewAdapterHelper.Adapter.Base;

namespace BaseRecyclerViewAdapterHelper.Sample
{
    [Activity]
    public class MultipleItemUseActivity : BaseActivity, BaseQuickAdapter.ISpanSizeLookup
    {
        RecyclerView _recyclerView;
        List<MultipleItem> _data;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_multiple_item_use);
            SetTitle("MultipleItem Use");
            SetBackBtn();
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.rv_list);
            _data = DataServer.GetMultipleItemData();
            var multipleItemAdapter = new MultipleItemQuickAdapter(this, _data);
            var manager = new GridLayoutManager(this, 4);
            _recyclerView.SetLayoutManager(manager);
            multipleItemAdapter.SetSpanSizeLookup(this);
            _recyclerView.SetAdapter(multipleItemAdapter);
        }

        public int GetSpanSize(GridLayoutManager gridLayoutManager, int position)
        {
            return _data[position].SpanSize;
        }
    }
}
