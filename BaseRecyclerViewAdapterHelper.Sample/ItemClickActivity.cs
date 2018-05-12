using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Widget;
using BaseRecyclerViewAdapterHelper.Sample.Adapter;
using BaseRecyclerViewAdapterHelper.Sample.Base;
using BaseRecyclerViewAdapterHelper.Sample.Entity;

namespace BaseRecyclerViewAdapterHelper.Sample
{
    [Activity]
    public class ItemClickActivity : BaseActivity
    {
        RecyclerView _recyclerView;
        ItemClickAdapter _adapter;
        const int PageSize = 10;
        const string Tag = "ItemClickActivity";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetBackBtn();
            SetTitle("ItemClickActivity Activity");
            SetContentView(Resource.Layout.activity_item_click);
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.list);
            _recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            InitAdapter();
            _adapter.ItemClick += (s, e) =>
            {
                Log.Debug(Tag, "onItemClick: ");
                Toast.MakeText(this, "onItemClick" + e.Position, ToastLength.Short).Show();
            };
            _adapter.ItemLongClick += (s, e) =>
            {
                Log.Debug(Tag, "onItemLongClick: ");
                Toast.MakeText(this, "onItemLongClick" + e.Position, ToastLength.Short).Show();
                e.Handled = true;
            };
            _adapter.ItemChildClick += (s, e) =>
            {
                Log.Debug(Tag, "onItemChildClick: ");
                Toast.MakeText(this, "onItemChildClick" + e.Position, ToastLength.Short).Show();
            };
            _adapter.ItemChildLongClick += (s, e) =>
            {
                Log.Debug(Tag, "onItemChildLongClick: ");
                Toast.MakeText(this, "onItemChildLongClick" + e.Postition, ToastLength.Short).Show();
                e.Handled = true;
            };
        }

        void InitAdapter()
        {
            var data = new List<ClickEntity>();
            data.Add(new ClickEntity(ClickEntity.ClickItemView));
            data.Add(new ClickEntity(ClickEntity.ClickItemChildView));
            data.Add(new ClickEntity(ClickEntity.LongClickItemView));
            data.Add(new ClickEntity(ClickEntity.LongClickItemChildView));
            data.Add(new ClickEntity(ClickEntity.NestClickItemChildView));
            _adapter = new ItemClickAdapter(data);
            _adapter.OpenLoadAnimation();
            _recyclerView.SetAdapter(_adapter);
        }
    }
}
