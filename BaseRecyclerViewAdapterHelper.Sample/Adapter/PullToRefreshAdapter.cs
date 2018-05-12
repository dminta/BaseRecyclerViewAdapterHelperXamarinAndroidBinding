using Android.Views;
using Android.Widget;
using CymChad.BaseRecyclerViewAdapterHelper.Adapter.Base;
using Android.Text.Style;
using Android.Text;
using BaseRecyclerViewAdapterHelper.Sample.Util;

namespace BaseRecyclerViewAdapterHelper.Sample.Adapter
{
    public class PullToRefreshAdapter : BaseQuickAdapter
    {
        class ClickableSpanImpl : ClickableSpan
        {
            public override void OnClick(View widget)
            {
                ToastUtils.ShowShortToast("事件触发了 landscapes and nedes");
            }

            public override void UpdateDrawState(TextPaint ds)
            {
                ds.Color = Utils.Context.Resources.GetColor(Resource.Color.clickspan_color);
                ds.UnderlineText = true;
            }
        }

        readonly ClickableSpan _clickableSpan = new ClickableSpanImpl();

        public PullToRefreshAdapter() : base(Resource.Layout.layout_animation, null) { }

        protected override void Convert(BaseViewHolder helper, Java.Lang.Object item)
        {
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

            var msg = "\"He was one of Australia's most of distinguished artistes, renowned for his portraits\"";
            TextView textView = (TextView)helper.GetView(Resource.Id.tweetText);
            textView.TextFormatted = SpannableStringUtils.GetBuilder(msg).Append("landscapes and nedes").SetClickSpan(_clickableSpan).Create();
            textView.MovementMethod = ClickableMovementMethod.Instance;
        }
    }
}
