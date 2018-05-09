
using Android.App;
using Android.Runtime;
using BaseRecyclerViewAdapterHelper.Sample.Util;
using Com.Orhanobut.Logger;
using System;

namespace BaseRecyclerViewAdapterHelper.Sample
{
    [Application(AllowBackup = true, Icon = "@mipmap/logo", Label = "@string/app_name", SupportsRtl = true, Theme = "@style/AppTheme")]
    public class MyApplication : Application
    {
        static MyApplication _appContext;

        public static MyApplication Instance => _appContext;

        public MyApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

        public override void OnCreate()
        {
            base.OnCreate();
            _appContext = this;
            Utils.Init(this);
#if DEBUG
            Logger.AddLogAdapter(new AndroidLogAdapter());
#endif
        }
    }
}
