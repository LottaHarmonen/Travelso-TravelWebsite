using Travelso_Website.DataAccess.Repositories;
using Travelso_Website_Shared.Entities;

namespace Travlso_Website.API.Extensions;

public static class CommentEndpointExtension
{
    public static IEndpointRouteBuilder CommentEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/comment");

        group.MapGet("/", GetAllComments);
        group.MapGet("/blogPostId/{blogPostId}", GetCommentsByBlogPost);
        group.MapGet("/commentId/{commentId}", GetCommentById);
        group.MapPost("/", AddComment);
        group.MapPut("/commentId/{commentId}", UpdateComment);
        group.MapDelete("/commentId/{commentId}", DeleteComment);


        return app;
    }

    private static async Task<IEnumerable<Comment>>? GetCommentsByBlogPost(CommentRepository repo, int blogPostId)
    {

        var commentsByBlogPost = await repo.CommentsByBlogPost(blogPostId)!;
        if (commentsByBlogPost is null)
        {
            Results.NotFound();
            return null;
        }

        Results.Ok();
        return commentsByBlogPost;

    }

    private static async Task UpdateComment(CommentRepository repo, int commentId, Comment comment)
    {
        var IsCommentUpdated = await repo.Update(commentId, comment);
        if (IsCommentUpdated)
        {
            Results.Ok();
        }

        Results.BadRequest();
    }

    private static async Task<Comment> GetCommentById(CommentRepository repo, int commentId)
    {
        var comment = await repo.GetById(commentId);
        if (comment == null)
        {
            Results.NotFound();
            return null;
        }

        Results.Ok();
        return comment;

    }

    private static async Task DeleteComment(CommentRepository repo, int commentId)
    {
        var isCommentDeleted = await repo.Delete(commentId);
        if (isCommentDeleted)
        {
            Results.Ok();
        }

        Results.BadRequest();
    }

    private static async Task AddComment(CommentRepository repo, Comment comment)
    {
        var isCommentAdded = await repo.Add(comment);
        if (isCommentAdded)
        {
            Results.Ok();

        }

        Results.BadRequest();
    }

    private static async Task<IEnumerable<Comment>?>? GetAllComments(CommentRepository repo)
    {
        var comments = await repo.GetAll();
        if (comments is null)
        {
            Results.NotFound();
            return null;
        }

        Results.Ok();
        return comments;

    }
}