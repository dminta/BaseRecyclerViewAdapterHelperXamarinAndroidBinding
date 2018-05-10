using BaseRecyclerViewAdapterHelper.Sample.Data;
using Chad.BaseRecyclerViewAdapterHelper.Adapter.Base;

namespace BaseRecyclerViewAdapterHelper.Sample.Adapter
{
    public class HeaderAndFooterAdapter : BaseQuickAdapter
    {
        public HeaderAndFooterAdapter(int dataSize) : base(Resource.Layout.item_header_and_footer, DataServer.GetSampleData(dataSize)) { }

        protected override void Convert(BaseViewHolder helper, Java.Lang.Object item)
        {
            switch (helper.LayoutPosition % 3)
            {
                case 0:
                    helper.SetImageResource(Resource.Id.iv, Resource.Mipmap.animation_img1);
                    break;
                case 1:
                    helper.SetImageResource(Resource.Id.iv, Resource.Mipmap.animation_img2);
                    break;
                case 2:
                    helper.SetImageResource(Resource.Id.iv, Resource.Mipmap.animation_img3);
                    break;
            }
        }
    }
}
