using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using BaseRecyclerViewAdapterHelper.Sample.Data;
using BaseRecyclerViewAdapterHelper.Sample.Util;
using Chad.BaseRecyclerViewAdapterHelper.Adapter.Base;

namespace BaseRecyclerViewAdapterHelper.Sample.Adapter
{
    public class NestAdapter : BaseQuickAdapter
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

        public NestAdapter() : base(Resource.Layout.layout_nest_item, DataServer.GetSampleData(20)) { }

        protected override void Convert(BaseViewHolder helper, Java.Lang.Object item)
        {
            helper.AddOnClickListener(Resource.Id.tweetText);

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
            var textView = (TextView)helper.GetView(Resource.Id.tweetText);
            textView.TextFormatted = SpannableStringUtils.GetBuilder(msg).Append("landscapes and nedes").SetClickSpan(_clickableSpan).Create();
            textView.MovementMethod = ClickableMovementMethod.Instance;
        }
    }
}
