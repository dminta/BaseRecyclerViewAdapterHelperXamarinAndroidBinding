using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;

namespace BaseRecyclerViewAdapterHelper.Sample.Util
{
    public class SpannableStringUtils // TODO
    {
        public class Builder
        {
            const int DefaultValue = 0x12000000;

            string _text;
            SpanTypes _flag;
            int _foregroundColor;
            int _backgroundColor;
            int _quoteColor;
            float _proportion;
            float _xProportion;
            ClickableSpan _clickSpan;
            SpannableStringBuilder _builder;

            public Builder(string text)
            {
                _text = text;
                _flag = SpanTypes.ExclusiveExclusive;
                _foregroundColor = DefaultValue;
                _backgroundColor = DefaultValue;
                _quoteColor = DefaultValue;
                _proportion = -1;
                _xProportion = -1;
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
                // TODO
                if (_clickSpan != null)
                {
                    _builder.SetSpan(_clickSpan, start, end, _flag);
                    _clickSpan = null;
                }
                // TODO
                _flag = SpanTypes.ExclusiveExclusive;
            }
        }

        public static Builder GetBuilder(string text) => new Builder(text);
    }
}
