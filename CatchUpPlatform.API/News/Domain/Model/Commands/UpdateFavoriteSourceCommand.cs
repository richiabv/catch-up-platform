namespace CatchUpPlatform.API.News.Domain.Model.Commands
{
    public record UpdateFavoriteSourceCommand(int Id, string NewsApiKey, string SourceId);
}