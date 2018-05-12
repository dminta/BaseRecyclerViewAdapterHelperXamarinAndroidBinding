using CymChad.BaseRecyclerViewAdapterHelper.Adapter.Base.Entity;

namespace BaseRecyclerViewAdapterHelper.Sample.Entity
{
    public class ClickEntity : Java.Lang.Object, IMultiItemEntity
    {
        public const int ClickItemView = 1;
        public const int ClickItemChildView = 2;
        public const int LongClickItemView = 3;
        public const int LongClickItemChildView = 4;
        public const int NestClickItemChildView = 5;

        public int ItemType { get; }

        public ClickEntity(int type)
        {
            ItemType = type;
        }
    }
}
