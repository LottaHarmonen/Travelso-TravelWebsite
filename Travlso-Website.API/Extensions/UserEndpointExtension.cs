using Microsoft.AspNetCore.Components.Forms;
using Travelso_Website.DataAccess.Repositories;
using Travelso_Website_Shared.DTOs.UserDTOs;
using Travelso_Website_Shared.Entities;

namespace Travlso_Website.API.Extensions;

public static class UserEndpointExtension
{
    public static IEndpointRouteBuilder UserEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/users");

        group.MapGet("/", GetAllUsers);
        group.MapGet("/{userId}", GetUserById);
        group.MapGet("/userMail/{userMail}", GetUserByMail);
        group.MapPost("/", AddUser);
        group.MapPut("/{userId}", UpdateUser);
        group.MapDelete("/{userId}", DeleteUser);
        

        return app;
    }

    private static async Task<TravelsoUser?> GetUserByMail(UserRepository repo, string userMail)
    {
        var userByMail = await repo.GetByMail(userMail);
        if (userByMail == null)
        {
            Results.NotFound();
        }

        Results.Ok();
        return userByMail;
    }

    private static async Task UpdateUser(UserRepository repo, UpdatedUserInformationDTO updatedUser, string userId)
    {
        //get user with id
        var userToUpdate = await repo.GetById(userId);

        TravelsoUser user = new TravelsoUser()
        {
            UserId = userId,
            City = updatedUser.City,
            Country = updatedUser.Country,
            ProfileImage = updatedUser.ProfileImage,
            UserName = updatedUser.UserName,
            BlogPosts = userToUpdate.BlogPosts,
            MyVisitedCountries = userToUpdate.MyVisitedCountries,
            Email = userToUpdate.Email

        };

        var isUserUpdated = await repo.Update(user);
        if (isUserUpdated)
        {
            Results.Ok();
        }

        Results.NotFound();
    }

    private static async Task<IResult> DeleteUser(UserRepository repo, string userId)
    {
        var isUserDeleted = await repo.Delete(userId);
        if (isUserDeleted)
        {
           return Results.Ok();
        }

        return Results.BadRequest();
    }

    private static async Task AddUser(UserRepository repo, TravelsoUser user)
    {
        var isUserAdded = await repo.Add(user);
        if (isUserAdded)
        {
            Results.Ok();
        }

        Results.BadRequest();
    }

    private static async Task<TravelsoUser?> GetUserById(UserRepository repo, string userId)
    {
        var user = await repo.GetById(userId);
        if (user is null)
        {
            Results.NotFound($"No user found with the given id {userId}");
        }
        Results.Ok();
        return user;
    }

    private static async Task<IEnumerable<TravelsoUser>?> GetAllUsers(UserRepository repo)
    {
        var allUsers = await repo.GetAll();
        if (allUsers is null)
        {
            Results.NotFound();
        }

        Results.Ok();
        return allUsers;
    }
}

