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
    Console.WriteLine("Choose an option: 1. Create, 2. Get All, 3. Update, 4. Delete, 5. Exit");
    option = Console.ReadLine();

    if (option == "1") // Create
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
    else if (option == "3")
    {
        Console.WriteLine("Enter Favorite Source ID to update:");
    
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Enter new NewsApiKey:");
            string newsApiKey = Console.ReadLine()!;

            Console.WriteLine("Enter new SourceId:");
            string sourceId = Console.ReadLine()!;

            var updateCommand = new UpdateFavoriteSourceCommand(id, newsApiKey, sourceId);
            try
            {
                await favoriteSourceCommandService.Handle(updateCommand);
                Console.WriteLine("Favorite Source updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format. Please enter a valid numeric ID.");
        }
    }
    else if (option == "4") 
    {
        Console.WriteLine("Enter Favorite Source ID to delete:");
    
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var deleteCommand = new DeleteFavoriteSourceCommand(id);
            try
            {
                await favoriteSourceCommandService.Handle(deleteCommand);
                Console.WriteLine("Favorite Source deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format. Please enter a valid numeric ID.");
        }
    }


} while (option != "5");

Console.WriteLine("Exit.");
