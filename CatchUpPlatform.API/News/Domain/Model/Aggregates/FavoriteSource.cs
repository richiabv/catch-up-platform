using CatchUpPlatform.API.News.Domain.Model.Commands;

namespace CatchUpPlatform.API.News.Domain.Model.Aggregates
{
    public class FavoriteSource
    {
        public int Id { get; set; }  

        public string NewsApiKey { get; private set; }
        
        public string SourceId { get; private set; }

        protected FavoriteSource()
        {
            this.NewsApiKey = string.Empty;
            this.SourceId = string.Empty;
        }

        public FavoriteSource(CreateFavoriteSourceCommand command)
        {
            this.NewsApiKey = command.NewsApiKey;
            this.SourceId = command.SourceId;
        }

        public void Update(string newsApiKey, string sourceId)
        {
            this.NewsApiKey = newsApiKey;
            this.SourceId = sourceId;
        }
    }
}