using System;

namespace Ravio.Entities
{
    public class NewsEntity
    {
        public string Status { get; set; }

        public int TotalResults { get; set; }

        public ArticleEntity[] Articles { get; set; }
    }

    public class ArticleEntity
    {
        public ArticleSourceEntity Source { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string UrlToImage { get; set; }

        public DateTime PublishedAt { get; set; }

        public string Content { get; set; }
    }

    public class ArticleSourceEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
