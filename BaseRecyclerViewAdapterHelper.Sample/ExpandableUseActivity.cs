using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using BaseRecyclerViewAdapterHelper.Sample.Adapter;
using BaseRecyclerViewAdapterHelper.Sample.Base;
using BaseRecyclerViewAdapterHelper.Sample.Entity;
using CymChad.BaseRecyclerViewAdapterHelper.Adapter.Base.Entity;

namespace BaseRecyclerViewAdapterHelper.Sample
{
    [Activity]
    public class ExpandableUseActivity : BaseActivity
    {
        class SpanSizeLookup : GridLayoutManager.SpanSizeLookup
        {
            readonly GridLayoutManager _manager;
            readonly ExpandableItemAdapter _adapter;

            public SpanSizeLookup(GridLayoutManager manager, ExpandableItemAdapter adapter)
            {
                _manager = manager;
                _adapter = adapter;
            }

            public override int GetSpanSize(int position)
            {
                return _adapter.GetItemViewType(position) == ExpandableItemAdapter.TypePerson ? 1 : _manager.SpanCount;
            }
        }

        RecyclerView _recyclerView;
        ExpandableItemAdapter _adapter;
        List<IMultiItemEntity> _list;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetBackBtn();
            SetTitle("ExpandableItem Activity");
            SetContentView(Resource.Layout.activity_expandable_item_use);

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.rv);

            _list = GenerateData();
            _adapter = new ExpandableItemAdapter(_list);

            var manager = new GridLayoutManager(this, 3);
            manager.SetSpanSizeLookup(new SpanSizeLookup(manager, _adapter));

            _recyclerView.SetAdapter(_adapter);
            _recyclerView.SetLayoutManager(manager);
            _adapter.ExpandAll();
        }

        List<IMultiItemEntity> GenerateData()
        {
            var lv0Count = 9;
            var lv1Count = 3;
            var personCount = 5;

            var nameList = new string[] { "Bob", "Andy", "Lily", "Brown", "Bruce" };
            var random = new Random();

            var res = new List<IMultiItemEntity>();
            for (int i = 0; i < lv0Count; i++)
            {
                var lv0 = new Level0Item("This is " + i + "th item in Level 0", "subtitle of " + i);
                for (int j = 0; j < lv1Count; j++)
                {
                    var lv1 = new Level1Item("Level 1 item: " + j, "(no animation)");
                    for (int k = 0; k < personCount; k++)
                    {
                        lv1.AddSubItem(new Person(nameList[k], random.Next(40)));
                    }
                    lv0.AddSubItem(lv1);
                }
                res.Add(lv0);
            }
            res.Add(new Level0Item("This is " + lv0Count + "th item in Level 0", "subtitle of " + lv0Count));
            return res;
        }
    }
}
