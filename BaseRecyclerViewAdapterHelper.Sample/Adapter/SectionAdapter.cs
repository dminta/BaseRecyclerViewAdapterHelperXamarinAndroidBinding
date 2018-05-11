using System.Collections;
using BaseRecyclerViewAdapterHelper.Sample.Entity;
using Chad.BaseRecyclerViewAdapterHelper.Adapter.Base;

namespace BaseRecyclerViewAdapterHelper.Sample.Adapter
{
    public class SectionAdapter : BaseSectionQuickAdapter
    {
        public SectionAdapter(int layoutResId, int sectionHeadResId, IList data) : base(layoutResId, sectionHeadResId, data) { }
        
        protected override void ConvertHead(BaseViewHolder helper, Java.Lang.Object item)
        {
            var section = item as MySection;
            helper.SetText(Resource.Id.header, section.Header);
            helper.SetVisible(Resource.Id.more, section.IsMore);
            helper.AddOnClickListener(Resource.Id.more);
        }

        protected override void Convert(BaseViewHolder helper, Java.Lang.Object item)
        {
            var video = ((item as MySection).T as Video);
            switch (helper.LayoutPosition % 2)
            {
                case 0:
                    helper.SetImageResource(Resource.Id.iv, Resource.Mipmap.m_img1);
                    break;
                case 1:
                    helper.SetImageResource(Resource.Id.iv, Resource.Mipmap.m_img2);
                    break;
            }
            helper.SetText(Resource.Id.tv, video.Name);
        }
    }
}
