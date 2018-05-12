using BaseRecyclerViewAdapterHelper.Sample.Adapter;
using CymChad.BaseRecyclerViewAdapterHelper.Adapter.Base.Entity;

namespace BaseRecyclerViewAdapterHelper.Sample.Entity
{
    public class Level1Item : AbstractExpandableItem, IMultiItemEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }

        public Level1Item(string title, string subTitle)
        {
            SubTitle = subTitle;
            Title = title;
        }

        public int ItemType => ExpandableItemAdapter.TypeLevel1;

        public override int Level => 1;
    }
}
