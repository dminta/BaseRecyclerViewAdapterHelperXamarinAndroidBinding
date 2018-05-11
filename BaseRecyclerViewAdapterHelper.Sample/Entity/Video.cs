namespace BaseRecyclerViewAdapterHelper.Sample.Entity
{
    public class Video : Java.Lang.Object
    {
        public string Img { get; set; }
        public string Name { get; set; }

        public Video(string img, string name)
        {
            Img = img;
            Name = name;
        }
    }
}
