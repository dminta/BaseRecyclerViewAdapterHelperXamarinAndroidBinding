using Android.Animation;
using Android.Views;
using CymChad.BaseRecyclerViewAdapterHelper.Adapter.Base.Animation;

namespace BaseRecyclerViewAdapterHelper.Sample.Animation
{
    public class CustomAnimation : Java.Lang.Object, IBaseAnimation
    {
        public Animator[] GetAnimators(View view)
        {
            return new Animator[]
            {
                ObjectAnimator.OfFloat(view, "scaleY", 1, 1.1f, 1),
                ObjectAnimator.OfFloat(view, "scaleX", 1, 1.1f, 1)
            };
        }
    }
}
