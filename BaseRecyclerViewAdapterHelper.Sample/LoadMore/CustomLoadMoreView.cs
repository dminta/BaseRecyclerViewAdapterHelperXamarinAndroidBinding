using Chad.BaseRecyclerViewAdapterHelper.Adapter.Base.LoadMore;

namespace BaseRecyclerViewAdapterHelper.Sample.LoadMore
{
    public class CustomLoadMoreView : LoadMoreView
    {
        public override int LayoutId => Resource.Layout.view_load_more;

        protected override int LoadEndViewId => Resource.Id.load_more_load_end_view;

        protected override int LoadFailViewId => Resource.Id.load_more_load_fail_view;

        protected override int LoadingViewId => Resource.Id.load_more_loading_view;
    }
}