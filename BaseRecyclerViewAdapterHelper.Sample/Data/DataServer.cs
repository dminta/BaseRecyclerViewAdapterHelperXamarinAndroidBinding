﻿using System.Collections.Generic;
using BaseRecyclerViewAdapterHelper.Sample.Entity;

namespace BaseRecyclerViewAdapterHelper.Sample.Data
{
    public class DataServer
    {
        const string HttpsAvatars1GitHubUserContentComLink = "https://avatars1.githubusercontent.com/u/7698209?v=3&s=460";
        const string CymChad = "CymChad";

        public static List<Status> GetSampleData(int length)
        {
            var list = new List<Status>();
            for (int i = 0; i < length; i++)
            {
                var status = new Status()
                {
                    UserName = $"Chad{i}",
                    CreatedAt = $"04/05/{i}",
                    IsRetweet = i % 2 == 0,
                    UserAvatar = "https://avatars1.githubusercontent.com/u/7698209?v=3&s=460",
                    Text = "BaseRecyclerViewAdpaterHelper https://www.recyclerview.org"
                };
                list.Add(status);
            }
            return list;
        }
        
        public static List<MySection> GetSampleData()
        {
            var list = new List<MySection>
            {
                new MySection(true, "Section 1", true),
                new MySection(new Video(HttpsAvatars1GitHubUserContentComLink, CymChad)),
                new MySection(new Video(HttpsAvatars1GitHubUserContentComLink, CymChad)),
                new MySection(new Video(HttpsAvatars1GitHubUserContentComLink, CymChad)),
                new MySection(new Video(HttpsAvatars1GitHubUserContentComLink, CymChad)),
                new MySection(true, "Section 2", false),
                new MySection(new Video(HttpsAvatars1GitHubUserContentComLink, CymChad)),
                new MySection(new Video(HttpsAvatars1GitHubUserContentComLink, CymChad)),
                new MySection(new Video(HttpsAvatars1GitHubUserContentComLink, CymChad)),
                new MySection(true, "Section 3", false),
                new MySection(new Video(HttpsAvatars1GitHubUserContentComLink, CymChad)),
                new MySection(new Video(HttpsAvatars1GitHubUserContentComLink, CymChad)),
                new MySection(true, "Section 4", false),
                new MySection(new Video(HttpsAvatars1GitHubUserContentComLink, CymChad)),
                new MySection(new Video(HttpsAvatars1GitHubUserContentComLink, CymChad)),
                new MySection(true, "Section 5", false),
                new MySection(new Video(HttpsAvatars1GitHubUserContentComLink, CymChad)),
                new MySection(new Video(HttpsAvatars1GitHubUserContentComLink, CymChad))
            };
            return list;
        }

        public static List<MultipleItem> GetMultipleItemData()
        {
            var list = new List<MultipleItem>();
            for (int i = 0; i <= 4; i++)
            {
                list.Add(new MultipleItem(MultipleItem.Img, MultipleItem.ImgSpanSize));
                list.Add(new MultipleItem(MultipleItem.Text, MultipleItem.TextSpanSize, CymChad));
                list.Add(new MultipleItem(MultipleItem.ImgText, MultipleItem.ImgTextSpanSize));
                list.Add(new MultipleItem(MultipleItem.ImgText, MultipleItem.ImgTextSpanSizeMin));
                list.Add(new MultipleItem(MultipleItem.ImgText, MultipleItem.ImgTextSpanSizeMin));
            }
            return list;
        }
    }
}