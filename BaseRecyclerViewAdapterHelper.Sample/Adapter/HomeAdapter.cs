using BaseRecyclerViewAdapterHelper.Sample.Entity;
using CymChad.BaseRecyclerViewAdapterHelper.Adapter.Base;

namespace BaseRecyclerViewAdapterHelper.Sample.Adapter
{
    public class HomeAdapter : BaseQuickAdapter
    {
        public HomeAdapter(int layoutResId, System.Collections.IList data) : base(layoutResId, data) { }

        protected override void Convert(BaseViewHolder helper, Java.Lang.Object item)
        {
            var homeItem = item as HomeItem;
            helper.SetText(Resource.Id.text, homeItem.Title);
            helper.SetImageResource(Resource.Id.icon, homeItem.ImageResource);
        }
    }
}
