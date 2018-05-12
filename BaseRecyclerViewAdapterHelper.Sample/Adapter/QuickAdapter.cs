using BaseRecyclerViewAdapterHelper.Sample.Data;
using BaseRecyclerViewAdapterHelper.Sample.Entity;
using CymChad.BaseRecyclerViewAdapterHelper.Adapter.Base;

namespace BaseRecyclerViewAdapterHelper.Sample.Adapter
{
    public class QuickAdapter : BaseQuickAdapter
    {
        public QuickAdapter(int dataSize) : base(Resource.Layout.layout_animation, DataServer.GetSampleData(dataSize)) { }

        protected override void Convert(BaseViewHolder helper, Java.Lang.Object item)
        {
            var status = item as Status;
            
            switch (helper.LayoutPosition % 3)
            {
                case 0:
                    helper.SetImageResource(Resource.Id.img, Resource.Mipmap.animation_img1);
                    break;
                case 1:
                    helper.SetImageResource(Resource.Id.img, Resource.Mipmap.animation_img2);
                    break;
                case 2:
                    helper.SetImageResource(Resource.Id.img, Resource.Mipmap.animation_img3);
                    break;
            }
            helper.SetText(Resource.Id.tweetName, "Hoteis in Rio de Janeiro");
            helper.SetText(Resource.Id.tweetText, "O ever youthful,O ever weeping");
        }
    }
}
