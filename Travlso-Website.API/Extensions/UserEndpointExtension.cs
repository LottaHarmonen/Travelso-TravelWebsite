using Travelso_Website_Shared.Entities;

namespace Travlso_Website.API.Extensions;

public static class UserEndpointExtension
{
    public static IEndpointRouteBuilder UserEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/users");

        //group.MapGet("/", GetAllUsers);
        //group.MapGet("/{userId}", GetUserById);
        //group.MapGet("/email/{userEmail}", GetUserByEmail);
        //group.MapPost("/", AddUser);
        //group.MapPut("/{userId}", UpdateUser);
        //group.MapDelete("/{userId}", DeleteUser);

        return app;
    }

    //private static async Task<IResult> GetAllUsers(IUserService<TravelsoUser> repo)
    //{
    //    var allUsers = await repo.GetAllUsers();
    //    return Results.Ok(allUsers);
    //}
    //private static async Task<TravelsoUser?> GetUserById(IUserService<TravelsoUser> repo, string userId)
    //{
    //    return await repo.GetUserById(userId);
    //}
    //private static async Task<IResult> GetUserByEmail(IUserService<TravelsoUser> repo, string userEmail)
    //{
    //    var TravelsoUser = await repo.GetUserByEmail(userEmail);

    //    if (TravelsoUser is null)
    //    {
    //        return Results.NotFound($"No product exists with the given number: {TravelsoUser}");
    //    }

    //    return Results.Ok(TravelsoUser);
    //}
    //private static async Task AddUser(IUserService<TravelsoUser> repo, TravelsoUser newUser)
    //{
    //    await repo.AddUser(newUser);
    //}

    //private static async Task<IResult> UpdateUser(IUserService<TravelsoUser> repo, string userId, TravelsoUser TravelsoUser)
    //{
    //    return Results.Ok(await repo.UpdateUser(userId, TravelsoUser));
    //}
    //private static async Task DeleteUser(IUserService<TravelsoUser> repo, string userId)
    //{
    //    await repo.RemoveUser(userId);
    //}
}

