using Chad.BaseRecyclerViewAdapterHelper.Adapter.Base.Entity;

namespace BaseRecyclerViewAdapterHelper.Sample.Entity
{
    public class MultipleItem : Java.Lang.Object, IMultiItemEntity
    {
        public const int Text = 1;
        public const int Img = 2;
        public const int ImgText = 3;
        public const int TextSpanSize = 3;
        public const int ImgSpanSize = 1;
        public const int ImgTextSpanSize = 4;
        public const int ImgTextSpanSizeMin = 2;

        public int ItemType { get; }
        public int SpanSize { get; set; }
        public string Content { get; set; }

        public MultipleItem(int itemType, int spanSize, string content) : this(itemType, spanSize)
        {
            Content = content;
        }

        public MultipleItem(int itemType, int spanSize)
        {
            ItemType = itemType;
            SpanSize = spanSize;
        }
    }
}
