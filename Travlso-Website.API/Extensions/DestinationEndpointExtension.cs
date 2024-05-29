using Microsoft.EntityFrameworkCore.Metadata;
using Travelso_Website.DataAccess.Repositories;
using Travelso_Website_Shared.Entities;

namespace Travlso_Website.API.Extensions;

public static class DestinationEndpointExtension
{
    public static IEndpointRouteBuilder DestinationEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/destination");

        group.MapGet("/", GetAllDestinations);
        group.MapGet("/destinationId/{destinationId}", GetDestinationById);
        group.MapPost("/", AddDestination);
        group.MapPut("/destinationId/{destinationId}", UpdateDestination);
        group.MapDelete("/destinationId/{destinationId}", DeleteDestination);

        return app;
    }

    private static async Task<Destination?> GetDestinationById(DestinationRepository repo, int destinationId)
    {
        var destination = await repo.GetById(destinationId);
        if (destination is null)
        {
            Results.NotFound($"No destination found with the given id {destinationId}");
        }
        Results.Ok();
        return destination;

    }

    private static async Task DeleteDestination(DestinationRepository repo, int destinationId)
    {
        
        var isDeleted = await repo.Delete(destinationId);
        if (isDeleted)
        {
            Results.Ok();
        }
        Results.NotFound($"No destination found with the given id {destinationId}");

    }

    private static async Task UpdateDestination(DestinationRepository repo, Destination destination, int destinationId)
    {
        var destinationToUpdate = await repo.GetById(destinationId);

        var destinationFound = await repo.Update(destinationToUpdate.DestinationId, destination);
        if (destinationFound)
        {
            Results.Ok();
        }
        Results.NotFound($"No destination found with the given id {destination.DestinationId}");

    }

    private static async Task AddDestination(DestinationRepository repo, Destination destination)
    {
        await repo.Add(destination);
        Results.Ok();

    }

    private static async Task<IEnumerable<Destination>?> GetAllDestinations(DestinationRepository repo)
    {
        var destinations = await repo.GetAll();
        if (destinations is null)
        {
            Results.NotFound();
        }

        Results.Ok();
        return destinations;
        
    }
}