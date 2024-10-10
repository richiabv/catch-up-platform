using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.News.Domain.Model.Commands;
using System.Threading.Tasks;

namespace CatchUpPlatform.API.News.Domain.Services
{
    public interface IFavoriteSourceCommandService
    {
        Task<FavoriteSource> Handle(CreateFavoriteSourceCommand command);
    }
}