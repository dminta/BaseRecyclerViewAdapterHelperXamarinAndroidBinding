using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BaseRecyclerViewAdapterHelper.Sample.Entity;
using BaseRecyclerViewAdapterHelper.Sample.Util;
using CymChad.BaseRecyclerViewAdapterHelper.Adapter.Base;
using Com.Orhanobut.Logger;

namespace BaseRecyclerViewAdapterHelper.Sample.Adapter
{
    public class ItemClickAdapter : BaseMultiItemQuickAdapter, BaseQuickAdapter.IOnItemClickListener, BaseQuickAdapter.IOnItemChildClickListener
    {
        NestAdapter _nestAdapter;

        public ItemClickAdapter(List<ClickEntity> data) : base(data)
        {
            AddItemType(ClickEntity.ClickItemView, Resource.Layout.item_click_view);
            AddItemType(ClickEntity.ClickItemChildView, Resource.Layout.item_click_childview);
            AddItemType(ClickEntity.LongClickItemView, Resource.Layout.item_long_click_view);
            AddItemType(ClickEntity.LongClickItemChildView, Resource.Layout.item_long_click_childview);
            AddItemType(ClickEntity.NestClickItemChildView, Resource.Layout.item_nest_click);
        }

        protected override void Convert(BaseViewHolder helper, Java.Lang.Object item)
        {
            switch (helper.ItemViewType)
            {
                case ClickEntity.ClickItemView:
                    helper.AddOnClickListener(Resource.Id.btn);
                    break;
                case ClickEntity.ClickItemChildView:
                    helper.AddOnClickListener(Resource.Id.iv_num_reduce).AddOnClickListener(Resource.Id.iv_num_add)
                        .AddOnLongClickListener(Resource.Id.iv_num_reduce).AddOnLongClickListener(Resource.Id.iv_num_add);
                    break;
                case ClickEntity.LongClickItemView:
                    helper.AddOnLongClickListener(Resource.Id.btn);
                    break;
                case ClickEntity.LongClickItemChildView:
                    helper.AddOnClickListener(Resource.Id.iv_num_reduce).AddOnClickListener(Resource.Id.iv_num_add)
                        .AddOnLongClickListener(Resource.Id.iv_num_reduce).AddOnLongClickListener(Resource.Id.iv_num_add);
                    break;
                case ClickEntity.NestClickItemChildView:
                    helper.SetNestView(Resource.Id.item_click);
                    var recyclerView = (RecyclerView)helper.GetView(Resource.Id.nest_list);
                    recyclerView.SetLayoutManager(new LinearLayoutManager(helper.ItemView.Context, LinearLayoutManager.Vertical, false));
                    recyclerView.HasFixedSize = true;

                    _nestAdapter = new NestAdapter();
                    _nestAdapter.OnItemClickListener = this;
                    _nestAdapter.OnItemChildClickListener = this;
                    recyclerView.SetAdapter(_nestAdapter);
                    break;
            }
        }

        public void OnItemChildClick(BaseQuickAdapter adapter, View view, int position)
        {
            Toast.MakeText(Utils.Context, "childView click", ToastLength.Short).Show();
        }

        public void OnItemClick(BaseQuickAdapter adapter, View view, int position)
        {
            Logger.D("嵌套RecycleView item 收到: " + "点击了第 " + position + " 一次");
            Toast.MakeText(Utils.Context, "嵌套RecycleView item 收到: " + "点击了第 " + position + " 一次", ToastLength.Short).Show();
        }
    }
}
