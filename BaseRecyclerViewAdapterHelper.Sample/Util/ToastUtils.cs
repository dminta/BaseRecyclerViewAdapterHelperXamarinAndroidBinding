using Android.Widget;

namespace BaseRecyclerViewAdapterHelper.Sample.Util
{
    public class ToastUtils
    {
        static Toast _toast;

        public static void ShowShortToast(string text) => ShowToast(text, ToastLength.Short);

        static void ShowToast(string text, ToastLength duration)
        {
            CancelToast();
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
