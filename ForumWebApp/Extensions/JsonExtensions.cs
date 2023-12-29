using ForumWebApp.Models;
using Microsoft.Extensions.Hosting;
using System.Security.Policy;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace ForumWebApp.Extensions
{
    public static class JsonExtension
    {
        public static string CommentsToJsonRepliesIncluded(IEnumerable<Comment> comments)
        {
            string jsonResult = "[";

            foreach (var comment in comments) 
            {
                jsonResult += CommentToJsonRepliesIncluded(comment);
                jsonResult += ",";
            }
            jsonResult = jsonResult.Trim(' ').Trim(',');
            jsonResult += "]";
            return jsonResult;
        }
        public static string CommentsToJsonWithRepliesCount(IEnumerable<Comment> comments)
        {
            string jsonResult = "[";

            foreach (var comment in comments)
            {
                jsonResult += CommentToJsonWithRepliesCount(comment);
                jsonResult += ",";
            }
            jsonResult = jsonResult.Trim(' ').Trim(',');
            jsonResult += "]";
            return jsonResult;
        }
        public static string CommentToJsonWithRepliesCount(Comment comment)
        {
            string jsonResult = "{";
            jsonResult += $"\"Id\": {comment.Id}, ";
            jsonResult += $"\"Content\": \"{comment.Content}\", ";
            jsonResult += $"\"Replies\":";
            if (comment.Replies != null && comment.Replies.Any())
                jsonResult += comment.Replies.Count.ToString();
            else
                jsonResult += "0";
            jsonResult += ",";
            jsonResult += $"\"Author\":";

            if (comment.Author != null)
                jsonResult += UserToJson(comment.Author);
            else
                jsonResult += "null";
            jsonResult += ",";

            jsonResult += "\"Votes\": ";
            jsonResult += VotesToJson(comment.Votes);

            jsonResult += "}";
            return jsonResult;
        }
        public static string CommentToJsonRepliesIncluded(Comment comment)
        {
            string jsonResult = "{";
            jsonResult += $"\"Id\": {comment.Id}, ";
            jsonResult += $"\"Content\": \"{comment.Content}\", ";
            jsonResult += $"\"Replies\":";
            if(comment.Replies != null && comment.Replies.Any())
                jsonResult += CommentsToJsonRepliesIncluded(comment.Replies);
            else 
                jsonResult += "null";
            jsonResult += ",";
            jsonResult += $"\"Author\":";

            if (comment.Author != null)
                jsonResult += UserToJson(comment.Author);
            else
                jsonResult += "null";
            jsonResult += ",";

            jsonResult += "\"Votes\": ";
            jsonResult += VotesToJson(comment.Votes);

            jsonResult += "}";
            return jsonResult;
        }
        public static string UserToJson(AppUser appUser)
        {
            string jsonResult = "{";
            
            jsonResult += $"\"Id\": \"{appUser.Id}\",";
            jsonResult += $"\"Username\": \"{appUser.UserName}\",";
            jsonResult += $"\"Email\": \"{appUser.Email}\"";
            jsonResult += "}";

            return jsonResult;
        }

        public static string VotesToJson(ICollection<Vote> votes)
        {
            int downvoteCount = (votes == null) ? 0 : votes.Where(v => v.VoteType == Data.Enums.VoteType.DownVote).ToList().Count;
            int upvoteCount = (votes == null) ? 0 : votes.Where(v => v.VoteType == Data.Enums.VoteType.UpVote).ToList().Count;

            string jsonResult = "{";
            jsonResult += "\"Upvotes\":" + $"{upvoteCount}, ";
            jsonResult += "\"Downvotes\":" + $"{downvoteCount}";
            jsonResult += "}";

            return jsonResult;
        }
        public static string ThreadPostsToJson(ICollection<ThreadPost> threadPosts)
        {
            string jsonResult = "[";
            foreach(var post in threadPosts)
            {
                jsonResult += ThreadPostToJson(post);
                jsonResult += ",";
            }
            jsonResult = jsonResult.Trim(' ').Trim(',');
            jsonResult += "]";
            return jsonResult;
        }
        public static string ThreadPostToJson(ThreadPost threadPost)
        {
            string jsonResult = "{";
            jsonResult += $"AuthorId: {threadPost.AuthorId}, ";
            jsonResult += $"AuthorName: {threadPost.Author.UserName},";
            jsonResult += $"ThreadID: {threadPost.ThreadId},";
            jsonResult += $"PostId: {threadPost.Id},";
            jsonResult += $"PostTitle: {threadPost.Title},";
            jsonResult += $"TotalMillisecondsAfterCreation: {(DateTime.UtcNow - threadPost.CreateAtUtc).TotalMilliseconds}";

            jsonResult += "}";
            return jsonResult;
        }

        public static string ToJson(object obj)
        {
            return JsonSerializer.Serialize(obj, new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
        }
    }
}