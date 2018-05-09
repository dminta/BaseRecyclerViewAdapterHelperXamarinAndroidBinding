namespace BaseRecyclerViewAdapterHelper.Sample.Entity
{
    public class Status : Java.Lang.Object
    {
        public bool IsRetweet { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public string UserAvatar { get; set; }
        public string CreatedAt { get; set; }

        public override string ToString() => $"Status{{IsRetweet={IsRetweet} Text='{Text}' UserName='{UserName}' UserAvatar='{UserAvatar}' CreatedAt='{CreatedAt}'}}";
    }
}
