using ForumWebApp.Models;
using System.Security.Policy;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ForumWebApp.Extensions
{
    public static class JsonExtension
    {
        public static string CommentsToJson(IEnumerable<Comment> comments)
        {
            string jsonResult = "[";

            foreach (var comment in comments) 
            {
                jsonResult += CommentToJson(comment);
                jsonResult += ",";
            }
            jsonResult = jsonResult.Trim(' ').Trim(',');
            jsonResult += "]";
            return jsonResult;
        }
        public static string CommentToJson(Comment comment)
        {
            string jsonResult = "{";
            jsonResult += $"\"Id\": {comment.Id}, ";
            jsonResult += $"\"Content\": \"{comment.Content}\", ";
            jsonResult += $"\"Replies\":";
            if(comment.Replies != null && comment.Replies.Any())
                jsonResult += CommentsToJson(comment.Replies);
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

        public static string ToJson(object obj)
        {
            return JsonSerializer.Serialize(obj, new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
        }
    }
}