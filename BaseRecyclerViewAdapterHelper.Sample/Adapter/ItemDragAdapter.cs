using System.Collections;
using CymChad.BaseRecyclerViewAdapterHelper.Adapter.Base;

namespace BaseRecyclerViewAdapterHelper.Sample.Adapter
{
    public class ItemDragAdapter : BaseItemDraggableAdapter
    {
        public ItemDragAdapter(IList data) : base(Resource.Layout.item_draggable_view, data) { }

        protected override void Convert(BaseViewHolder helper, Java.Lang.Object item)
        {
            var stringItem = (item as Java.Lang.String).ToString();

            switch (helper.LayoutPosition % 3)
            {
                case 0:
                    helper.SetImageResource(Resource.Id.iv_head, Resource.Mipmap.head_img0);
                    break;
                case 1:
                    helper.SetImageResource(Resource.Id.iv_head, Resource.Mipmap.head_img1);
                    break;
                case 2:
                    helper.SetImageResource(Resource.Id.iv_head, Resource.Mipmap.head_img2);
                    break;
            }
            helper.SetText(Resource.Id.tv, stringItem);
        }
    }
}
