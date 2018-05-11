using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using BaseRecyclerViewAdapterHelper.Sample.Adapter;
using BaseRecyclerViewAdapterHelper.Sample.Base;
using BaseRecyclerViewAdapterHelper.Sample.Data;
using BaseRecyclerViewAdapterHelper.Sample.Entity;

namespace BaseRecyclerViewAdapterHelper.Sample
{
    [Activity]
    public class SectionUseActivity : BaseActivity
    {
        RecyclerView _recyclerView;
        List<MySection> _data;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_section_uer);
            SetBackBtn();
            SetTitle("Section Use");
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.rv_list);
            _recyclerView.SetLayoutManager(new GridLayoutManager(this, 2));
            _data = DataServer.GetSampleData();
            var sectionAdapter = new SectionAdapter(Resource.Layout.item_section_content, Resource.Layout.def_section_head, _data);

            sectionAdapter.ItemClick += (s, e) =>
            {
                var mySection = _data[e.Position];
                if (mySection.IsHeader)
                {
                    Toast.MakeText(this, mySection.Header, ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, (mySection.T as Video).Name, ToastLength.Long).Show();
                }
            };
            sectionAdapter.ItemChildClick += (s, e) =>
            {
                Toast.MakeText(this, "onItemChildClick" + e.Position, ToastLength.Long).Show();
            };
            _recyclerView.SetAdapter(sectionAdapter);
        }
    }
}
