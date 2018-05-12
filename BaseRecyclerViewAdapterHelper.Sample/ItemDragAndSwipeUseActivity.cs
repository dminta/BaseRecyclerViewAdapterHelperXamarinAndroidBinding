using System.Collections.Generic;

using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using Android.Util;
using BaseRecyclerViewAdapterHelper.Sample.Adapter;
using BaseRecyclerViewAdapterHelper.Sample.Base;
using BaseRecyclerViewAdapterHelper.Sample.Util;
using CymChad.BaseRecyclerViewAdapterHelper.Adapter.Base;
using CymChad.BaseRecyclerViewAdapterHelper.Adapter.Base.Callback;

namespace BaseRecyclerViewAdapterHelper.Sample
{
    [Activity]
    public class ItemDragAndSwipeUseActivity : BaseActivity
    {
        static string Tag => Java.Lang.Class.FromType(typeof(ItemDragAndSwipeUseActivity)).SimpleName;

        RecyclerView _recyclerView;
        List<string> _data;
        ItemDragAdapter _adapter;
        ItemTouchHelper _itemTouchHelper;
        ItemDragAndSwipeCallback _itemDragAndSwipeCallback;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_item_touch_use);
            SetBackBtn();
            SetTitle("ItemDrag  And Swipe");
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.rv_list);
            _recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            _data = GenerateData(50);

            var paint = new Paint();
            paint.AntiAlias = true;
            paint.TextSize = 20;
            paint.Color = Color.Black;

            _adapter = new ItemDragAdapter(_data);
            _adapter.ItemDragStart += (s, e) =>
            {
                Log.Debug(Tag, "drag start");
                var holder = e.ViewHolder as BaseViewHolder;
                // holder.SetTextColor(Resource.Id.tv, Color.White);
            };
            _adapter.ItemDragMoving += (s, e) =>
            {
                Log.Debug(Tag, $"move from: {e.Source.AdapterPosition} to: {e.Target.AdapterPosition}");
            };
            _adapter.ItemDragEnd += (s, e) =>
            {
                Log.Debug(Tag, "drag end");
                var holder = e.ViewHolder as BaseViewHolder;
                // holder.SetTextColor(Resource.Id.tv, Color.Black);
            };
            _adapter.ItemSwipeStart += (s, e) =>
            {
                Log.Debug(Tag, "view swiped start: " + e.Pos);
                var holder = e.ViewHolder as BaseViewHolder;
                // holder.SetTextColor(Resource.Id.tv, Color.White);
            };
            _adapter.ClearView += (s, e) =>
            {
                Log.Debug(Tag, "View reset: " + e.Pos);
                var holder = e.ViewHolder as BaseViewHolder;
                // holder.SetTextColor(Resource.Id.tv, Color.Black);
            };
            _adapter.ItemSwiped += (s, e) =>
            {
                Log.Debug(Tag, "View Swiped: " + e.Pos);
            };
            _adapter.ItemSwipeMoving += (s, e) =>
            {
                e.Canvas.DrawColor(new Color(ContextCompat.GetColor(this, Resource.Color.color_light_blue)));
                // e.Canvas.DrawText("Just some text", 0, 40, paint);
            };

            _itemDragAndSwipeCallback = new ItemDragAndSwipeCallback(_adapter);
            _itemTouchHelper = new ItemTouchHelper(_itemDragAndSwipeCallback);
            _itemTouchHelper.AttachToRecyclerView(_recyclerView);

            //_itemDragAndSwipeCallback.SetDragMoveFlags(ItemTouchHelper.Left | ItemTouchHelper.Right | ItemTouchHelper.Up | ItemTouchHelper.Down);
            _itemDragAndSwipeCallback.SetSwipeMoveFlags(ItemTouchHelper.Start | ItemTouchHelper.End);
            _adapter.EnableSwipeItem();
            _adapter.EnableDragItem(_itemTouchHelper);

            _recyclerView.SetAdapter(_adapter);
            _adapter.ItemClick += (s, e) =>
            {
                ToastUtils.ShowShortToast("点击了" + e.Position);
            };
        }

        List<string> GenerateData(int size)
        {
            var data = new List<string>(size);
            for (int i=0; i < size; i++)
            {
                data.Add("item " + i);
            }
            return data;
        }
    }
}
