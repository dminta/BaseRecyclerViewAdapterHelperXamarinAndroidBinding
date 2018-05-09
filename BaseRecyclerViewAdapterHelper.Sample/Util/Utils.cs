using System;
using Android.Content;

namespace BaseRecyclerViewAdapterHelper.Sample.Util
{
    public static class Utils
    {
        static Context _context;

        public static Context Context => _context ?? throw new ArgumentNullException("u should init first");

        public static void Init(Context context)
        {
            _context = context.ApplicationContext;
        }
    }
}
