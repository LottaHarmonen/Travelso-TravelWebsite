using Microsoft.EntityFrameworkCore.Metadata;
using Travelso_Website.DataAccess.Repositories;
using Travelso_Website_Shared.Entities;

namespace Travlso_Website.API.Extensions;

public static class BlogPostEndpointExtension
{

    public static IEndpointRouteBuilder BlogPostEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/blogpost");

        group.MapGet("/", GetAllBlogPosts);
        group.MapGet("/blogPostId/{blogPostId}", GetBlogPostById);
        group.MapGet("/countryId/{countryId}", GetBlogPostsByCountry);
        group.MapGet("/userId/{userId}", GetBlogPostsByUserId);
        group.MapPost("/", AddBlogPost);
        group.MapPut("/blogPostId/{blogPostId}", UpdateBlogPost);
        group.MapDelete("/blogPostId/{blogPostId}", DeleteBlogPost);

        return app;
    }

    private static async Task<IEnumerable<BlogPost>> GetBlogPostsByUserId(BlogPostRepository repo, string userId)
    {
        var blogPosts = await repo.GetPostsByUserId(userId);
        if (blogPosts is null)
        {
            Results.NotFound();
            return null;
        }

        Results.Ok();
        return blogPosts;
    }

    private static async Task DeleteBlogPost(BlogPostRepository repo, int blogPostId)
    {
        var isBlogPostDeleted = await repo.Delete(blogPostId);
        if (isBlogPostDeleted)
        {
            Results.Ok();
        }

        Results.BadRequest();
    }


    private static async Task UpdateBlogPost(BlogPostRepository repo, int blogPostId, BlogPost blogPost)
    {
        var isBlogPostUpdated = await repo.Update(blogPost);
        if (isBlogPostUpdated)
        {
            Results.Ok();
        }

        Results.BadRequest();
    }

    private static async Task AddBlogPost(BlogPostRepository repo, BlogPost blogPost)
    {
        var IsBlogPostAdded = await repo.Add(blogPost);
        if (IsBlogPostAdded)
        {
            Results.Ok();
        }

        Results.BadRequest();
    }

    private static async Task<IEnumerable<BlogPost>?> GetBlogPostsByCountry(BlogPostRepository repo, int countryId)
    {
        var blogPosts = await repo.GetPostsByCountryAsync(countryId);
        if (blogPosts is null)
        {
            Results.NotFound();
            return null;
        }

        Results.Ok();
        return blogPosts;

    }

    private static async Task<BlogPost?> GetBlogPostById(BlogPostRepository repo, int blogPostId)
    {
        var blogPost = await repo.GetById(blogPostId);
        if (blogPost is null)
        {
            Results.NotFound();
        }

        Results.Ok();
        return blogPost;
    }


    private static async Task<IEnumerable<BlogPost>?> GetAllBlogPosts(BlogPostRepository repo)
    {
        var allBlogPosts = await repo.GetAll();
        if (allBlogPosts is null)
        {
            Results.NotFound();
        }

        Results.Ok();
        return allBlogPosts;
    }
}