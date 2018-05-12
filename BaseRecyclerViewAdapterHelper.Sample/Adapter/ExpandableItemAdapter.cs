using Android.Util;
using Android.Views;
using BaseRecyclerViewAdapterHelper.Sample.Entity;
using CymChad.BaseRecyclerViewAdapterHelper.Adapter.Base;
using System;
using System.Collections;

namespace BaseRecyclerViewAdapterHelper.Sample.Adapter
{
    public class ExpandableItemAdapter : BaseMultiItemQuickAdapter
    {
        class ClickListener : Java.Lang.Object, View.IOnClickListener
        {
            readonly Action<View> _action;
            
            public ClickListener(Action<View> action)
            {
                _action = action;
            }

            public void OnClick(View v)
            {
                _action.Invoke(v);
            }
        }

        class LongClickListener : Java.Lang.Object, View.IOnLongClickListener
        {
            readonly Func<View, bool> _func;

            public LongClickListener(Func<View, bool> func)
            {
                _func = func;
            }
            
            public bool OnLongClick(View v)
            {
                return _func.Invoke(v);
            }
        }

        new string Tag => Java.Lang.Class.FromType(GetType()).SimpleName;

        public const int TypeLevel0 = 0;
        public const int TypeLevel1 = 1;
        public const int TypePerson = 2;

        public ExpandableItemAdapter(IList data) : base(data)
        {
            AddItemType(TypeLevel0, Resource.Layout.item_expandable_lv0);
            AddItemType(TypeLevel1, Resource.Layout.item_expandable_lv1);
            AddItemType(TypePerson, Resource.Layout.item_expandable_lv2);
        }

        protected override void Convert(BaseViewHolder holder, Java.Lang.Object item)
        {
            switch (holder.ItemViewType)
            {
                case TypeLevel0:
                    switch (holder.LayoutPosition % 3)
                    {
                        case 0:
                            holder.SetImageResource(Resource.Id.iv_head, Resource.Mipmap.head_img0);
                            break;
                        case 1:
                            holder.SetImageResource(Resource.Id.iv_head, Resource.Mipmap.head_img1);
                            break;
                        case 2:
                            holder.SetImageResource(Resource.Id.iv_head, Resource.Mipmap.head_img2);
                            break;
                    }
                    var lv0 = (Level0Item)item;
                    holder.SetText(Resource.Id.title, lv0.Title)
                        .SetText(Resource.Id.sub_title, lv0.SubTitle)
                        .SetImageResource(Resource.Id.iv, lv0.Expanded ? Resource.Mipmap.arrow_b : Resource.Mipmap.arrow_r);
                    holder.ItemView.SetOnClickListener(new ClickListener(v =>
                    {
                        var pos = holder.AdapterPosition;
                        Log.Debug(Tag, "Level 0 item pos: " + pos);
                        if (lv0.Expanded)
                        {
                            Collapse(pos);
                        }
                        else
                        {
                            Expand(pos);
                        }
                    }));
                    break;
                case TypeLevel1:
                    var lv1 = (Level1Item)item;
                    holder.SetText(Resource.Id.title, lv1.Title)
                        .SetText(Resource.Id.sub_title, lv1.SubTitle)
                        .SetImageResource(Resource.Id.iv, lv1.Expanded ? Resource.Mipmap.arrow_b : Resource.Mipmap.arrow_r);
                    holder.ItemView.SetOnClickListener(new ClickListener(v =>
                    {
                        var pos = holder.AdapterPosition;
                        Log.Debug(Tag, "Level 1 item pos: " + pos);
                        if (lv1.Expanded)
                        {
                            Collapse(pos, false);
                        }
                        else
                        {
                            Expand(pos, false);
                        }
                    }));
                    
                    holder.ItemView.SetOnLongClickListener(new LongClickListener(v =>
                    {
                        var pos = holder.AdapterPosition;
                        Remove(pos);
                        return true;
                    }));
                    break;
                case TypePerson:
                    var person = (Person)item;
                    holder.SetText(Resource.Id.tv, person.Name + " parent pos: " + GetParentPosition(person));
                    holder.ItemView.SetOnClickListener(new ClickListener(v =>
                    {
                        var pos = holder.AdapterPosition;
                        Remove(pos);
                    }));
                    break;
            }
        }
    }
}
