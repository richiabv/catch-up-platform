using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.News.Domain.Model.Queries;
using CatchUpPlatform.API.News.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatchUpPlatform.API.News.Application.Internal.QueryServices
{
    public class FavoriteSourceQueryService : IFavoriteSourceQueryService
    {
        private readonly List<FavoriteSource> _favoriteSources;

        public FavoriteSourceQueryService(List<FavoriteSource> sharedFavoriteSources)
        {
            _favoriteSources = sharedFavoriteSources; 
        }

        public async Task<FavoriteSource?> Handle(GetFavoriteSourceByIdQuery query)
        {
            return _favoriteSources.FirstOrDefault(x => x.Id == query.Id);
        }

        public async Task<FavoriteSource?> Handle(GetFavoriteSourceByNewsApiKeyAndSourceIdQuery query)
        {
            return _favoriteSources.FirstOrDefault(x => x.NewsApiKey == query.NewsApiKey && x.SourceId == query.SourceId);
        }

        public async Task<IEnumerable<FavoriteSource>> Handle(GetAllFavoriteSourcesByNewsApiKeyQuery query)
        {
            return _favoriteSources.Where(x => x.NewsApiKey == query.NewsApiKey);
        }
    }
}