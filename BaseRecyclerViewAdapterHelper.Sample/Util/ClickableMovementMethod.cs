using Android.Text;
using Android.Text.Method;
using Android.Text.Style;
using Android.Views;
using Android.Widget;

namespace BaseRecyclerViewAdapterHelper.Sample.Util
{
    public class ClickableMovementMethod : BaseMovementMethod
    {
        static ClickableMovementMethod _instance;

        public static ClickableMovementMethod Instance => (_instance ?? (_instance = new ClickableMovementMethod()));

        public override bool OnTouchEvent(TextView widget, ISpannable buffer, MotionEvent e)
        {
            var action = e.ActionMasked;
            if (action == MotionEventActions.Up || action == MotionEventActions.Down)
            {
                var x = e.GetX();
                var y = e.GetY();
                x -= widget.TotalPaddingLeft;
                y -= widget.TotalPaddingTop;
                x += widget.ScrollX;
                y += widget.ScrollY;

                var layout = widget.Layout;
                var line = layout.GetLineForVertical((int)y);
                var off = layout.GetOffsetForHorizontal(line, x);

                var link = buffer.GetSpans(off, off, Java.Lang.Class.FromType(typeof(ClickableSpan)));
                if (link.Length > 0)
                {
                    if (action == MotionEventActions.Up)
                    {
                        (link[0] as ClickableSpan).OnClick(widget);
                    }
                    else
                    {
                        Selection.SetSelection(buffer, buffer.GetSpanStart(link[0]), buffer.GetSpanEnd(link[0]));
                    }
                    return true;
                }
                else
                {
                    Selection.RemoveSelection(buffer);
                }
            }

            return false;
        }

        public override void Initialize(TextView widget, ISpannable text)
        {
            Selection.RemoveSelection(text);
        }
    }
}
