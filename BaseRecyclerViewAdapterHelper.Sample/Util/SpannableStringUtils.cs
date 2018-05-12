using Android.Text;
using Android.Text.Style;

namespace BaseRecyclerViewAdapterHelper.Sample.Util
{
    public class SpannableStringUtils
    {
        public class Builder
        {
            const int DefaultValue = 0x12000000;

            string _text;
            SpanTypes _flag;
            ClickableSpan _clickSpan;
            SpannableStringBuilder _builder;

            public Builder(string text)
            {
                _text = text;
                _flag = SpanTypes.ExclusiveExclusive;
                _builder = new SpannableStringBuilder();
            }

            public Builder SetClickSpan(ClickableSpan clickSpan)
            {
                _clickSpan = clickSpan;
                return this;
            }

            public Builder Append(string text)
            {
                SetSpan();
                _text = text;
                return this;
            }

            public SpannableStringBuilder Create()
            {
                SetSpan();
                return _builder;
            }

            void SetSpan()
            {
                var start = _builder.Length();
                _builder.Append(_text);
                var end = _builder.Length();
                if (_clickSpan != null)
                {
                    _builder.SetSpan(_clickSpan, start, end, _flag);
                    _clickSpan = null;
                }
                _flag = SpanTypes.ExclusiveExclusive;
            }
        }

        public static Builder GetBuilder(string text) => new Builder(text);
    }
}
