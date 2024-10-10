using CatchUpPlatform.API.News.Application.Internal.CommandServices;
using CatchUpPlatform.API.News.Application.Internal.QueryServices;
using CatchUpPlatform.API.News.Domain.Model.Commands;
using CatchUpPlatform.API.News.Domain.Model.Queries;
using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using System.Collections.Generic;

var sharedFavoriteSources = new List<FavoriteSource>();

var favoriteSourceCommandService = new FavoriteSourceCommandService(sharedFavoriteSources);
var favoriteSourceQueryService = new FavoriteSourceQueryService(sharedFavoriteSources);

Console.WriteLine("Catchup Platform: Favorite Sources Application");

string? option;
do
{
    Console.WriteLine("Choose an option: 1. Create, 2. Get All, 3. Exit");
    option = Console.ReadLine();

    if (option == "1")
    {
        Console.WriteLine("Enter NewsApiKey:");
        string newsApiKey = Console.ReadLine()!;
        Console.WriteLine("Enter SourceId:");
        string sourceId = Console.ReadLine()!;

        var command = new CreateFavoriteSourceCommand(newsApiKey, sourceId);
        try
        {
            await favoriteSourceCommandService.Handle(command);
            Console.WriteLine("Favorite Source created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    else if (option == "2")
    {
        Console.WriteLine("Enter NewsApiKey:");
        string newsApiKey = Console.ReadLine()!;

        var query = new GetAllFavoriteSourcesByNewsApiKeyQuery(newsApiKey);
        var favoriteSources = await favoriteSourceQueryService.Handle(query);

        if (favoriteSources.Any())
        {
            foreach (var source in favoriteSources)
            {
                Console.WriteLine($"SourceId: {source.SourceId}");
            }
        }
        else
        {
            Console.WriteLine("No favorite sources found for this NewsApiKey.");
        }
    }

} while (option != "3");

