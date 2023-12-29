using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ForumWebApp;
using SOLIDCheckingLibrary;
using ForumWebApp.Repositories;
using ForumWebApp.Controllers;

namespace ForumWebApp.Tests
{
    public class SingleResponsibilityTests
    {
        [Fact]
        public void CommentRepositoryFollowsSingleResponsibility()
        {
            var result = SingleResponsibility.CheckClassForSingleResponsibility(typeof(CommentRepository));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ForumThreadRepositoryFollowsSingleResponsibility()
        {
            var result = SingleResponsibility.CheckClassForSingleResponsibility(typeof(ForumThreadRepository));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ForumThreadUserFollowRepositoryFollowsSingleResponsibility()
        {
            var result = SingleResponsibility.CheckClassForSingleResponsibility(typeof(ForumThreadUserFollowRepository));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ThreadPostRepositoryFollowsSingleResponsibility()
        {
            var result = SingleResponsibility.CheckClassForSingleResponsibility(typeof(ThreadPostRepository));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void UserRepositoryFollowsSingleResponsibility()
        {
            var result = SingleResponsibility.CheckClassForSingleResponsibility(typeof(UserRepository));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void VoteRepositoryFollowsSingleResponsibility()
        {
            var result = SingleResponsibility.CheckClassForSingleResponsibility(typeof(VoteRepository));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void AccountControllerFollowsSingleResponsibility()
        {
            var result = SingleResponsibility.CheckClassForSingleResponsibility(typeof(AccountController));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void CommentControllerFollowsSingleResponsibility()
        {
            var result = SingleResponsibility.CheckClassForSingleResponsibility(typeof(CommentController));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void DashboardControllerFollowsSingleResponsibility()
        {
            var result = SingleResponsibility.CheckClassForSingleResponsibility(typeof(DashboardController));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ForumThreadControllerFollowsSingleResponsibility()
        {
            var result = SingleResponsibility.CheckClassForSingleResponsibility(typeof(ForumThreadController));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ThreadPostControllerFollowsSingleResponsibility()
        {
            var result = SingleResponsibility.CheckClassForSingleResponsibility(typeof(ThreadPostController));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void UserControllerFollowsSingleResponsibility()
        {
            var result = SingleResponsibility.CheckClassForSingleResponsibility(typeof(UserController));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void VotesControllerFollowsSingleResponsibility()
        {
            var result = SingleResponsibility.CheckClassForSingleResponsibility(typeof(VotesController));

            Assert.True(result.Item1, result.Item2);
        }
    }
}
