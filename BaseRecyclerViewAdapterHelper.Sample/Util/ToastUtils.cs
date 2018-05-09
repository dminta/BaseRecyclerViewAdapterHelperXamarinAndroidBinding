using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BaseRecyclerViewAdapterHelper.Sample.Util
{
    public class ToastUtils // TODO
    {
        static Toast _toast;
        static bool _isJumpWhenMore;

        public static void ShowShortToast(string text) => ShowToast(text, ToastLength.Short);

        static void ShowToast(string text, ToastLength duration)
        {
            if (_isJumpWhenMore)
            {
                CancelToast();
            }
            if (_toast == null)
            {
                _toast = Toast.MakeText(Utils.Context, text, duration);
            }
            else
            {
                _toast.SetText(text);
                _toast.Duration = duration;
            }
            _toast.Show();
        }

        static void CancelToast()
        {
            _toast?.Cancel();
            _toast = null;
        }
    }
}
