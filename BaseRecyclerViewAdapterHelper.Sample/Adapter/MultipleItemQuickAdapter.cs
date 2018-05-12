using System.Collections;
using Android.Content;
using BaseRecyclerViewAdapterHelper.Sample.Entity;
using CymChad.BaseRecyclerViewAdapterHelper.Adapter.Base;

namespace BaseRecyclerViewAdapterHelper.Sample.Adapter
{
    public class MultipleItemQuickAdapter : BaseMultiItemQuickAdapter
    {
        public MultipleItemQuickAdapter(Context context, IList data) : base(data)
        {
            AddItemType(MultipleItem.Text, Resource.Layout.item_text_view);
            AddItemType(MultipleItem.Img, Resource.Layout.item_image_view);
            AddItemType(MultipleItem.ImgText, Resource.Layout.item_img_text_view);
        }

        protected override void Convert(BaseViewHolder helper, Java.Lang.Object item)
        {
            switch (helper.ItemViewType)
            {
                case MultipleItem.Text:
                    helper.SetText(Resource.Id.tv, (item as MultipleItem).Content);
                    break;

                case MultipleItem.ImgText:
                    switch (helper.LayoutPosition % 2)
                    {
                        case 0:
                            helper.SetImageResource(Resource.Id.iv, Resource.Mipmap.animation_img1);
                            break;
                        case 1:
                            helper.SetImageResource(Resource.Id.iv, Resource.Mipmap.animation_img2);
                            break;
                    }
                    break;
            }
        }
    }
}
