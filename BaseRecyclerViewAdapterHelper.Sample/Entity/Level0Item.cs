using BaseRecyclerViewAdapterHelper.Sample.Adapter;
using CymChad.BaseRecyclerViewAdapterHelper.Adapter.Base.Entity;

namespace BaseRecyclerViewAdapterHelper.Sample.Entity
{
    public class Level0Item : AbstractExpandableItem, IMultiItemEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }

        public Level0Item(string title, string subTitle)
        {
            SubTitle = subTitle;
            Title = title;
        }

        public int ItemType => ExpandableItemAdapter.TypeLevel0;

        public override int Level => 0;
    }
}
