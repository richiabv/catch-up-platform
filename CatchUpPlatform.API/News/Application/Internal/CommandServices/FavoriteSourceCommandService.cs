using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.News.Domain.Model.Commands;
using CatchUpPlatform.API.News.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CatchUpPlatform.API.News.Application.Internal.CommandServices
{
    public class FavoriteSourceCommandService : IFavoriteSourceCommandService
    {
        private readonly List<FavoriteSource> _favoriteSources;

        public FavoriteSourceCommandService(List<FavoriteSource> favoriteSources)
        {
            _favoriteSources = favoriteSources;
        }

        public async Task<FavoriteSource> Handle(CreateFavoriteSourceCommand command)
        {
            var favoriteSource = _favoriteSources
                .FirstOrDefault(x => x.NewsApiKey == command.NewsApiKey && x.SourceId == command.SourceId);

            if (favoriteSource != null)
                throw new Exception("Favorite source with this SourceId already exists for the given NewsApiKey");

            favoriteSource = new FavoriteSource(command);
            _favoriteSources.Add(favoriteSource);

            return favoriteSource;
        }
    }
}