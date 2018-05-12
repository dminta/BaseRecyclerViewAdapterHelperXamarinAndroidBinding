using BaseRecyclerViewAdapterHelper.Sample.Adapter;
using CymChad.BaseRecyclerViewAdapterHelper.Adapter.Base.Entity;

namespace BaseRecyclerViewAdapterHelper.Sample.Entity
{
    public class Person : Java.Lang.Object, IMultiItemEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int ItemType => ExpandableItemAdapter.TypePerson;
    }
}
