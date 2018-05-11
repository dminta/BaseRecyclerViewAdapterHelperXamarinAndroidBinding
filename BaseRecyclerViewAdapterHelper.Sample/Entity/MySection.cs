using Chad.BaseRecyclerViewAdapterHelper.Adapter.Base.Entity;

namespace BaseRecyclerViewAdapterHelper.Sample.Entity
{
    public class MySection : SectionEntity
    {
        public bool IsMore { get; set; }

        public MySection(bool isHeader, string header, bool isMore) : base(isHeader, header)
        {
            IsMore = isMore;
        }

        public MySection(Video t) : base(t) { }
    }
}
