using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ForumWebApp;
using SOLIDCheckingLibrary;
using Microsoft.AspNetCore.Mvc;
using ForumWebApp.Models;
using ForumWebApp.Repositories;
using ForumWebApp.ViewModels;
using ForumWebApp.Controllers;

namespace ForumWebApp.Tests
{
    public class OpenForExtensionTests
    {
        [Fact]
        public void ControllerOpenForExtension()
        {
            var result = OpenExtClosedMod.IsClassExtensible(typeof(Controller));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void CommentRepositoryOpenForExtension() {
            var result = OpenExtClosedMod.IsClassExtensible(typeof(CommentRepository));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ForumThreadRepositoryOpenForExtension()
        {
            var result = OpenExtClosedMod.IsClassExtensible(typeof(ForumThreadRepository));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ForumThreadUserFollowRepositoryOpenForExtension()
        {
            var result = OpenExtClosedMod.IsClassExtensible(typeof(ForumThreadUserFollowRepository));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ThreadPostRepositoryOpenForExtension()
        {
            var result = OpenExtClosedMod.IsClassExtensible(typeof(ThreadPostRepository));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void UserRepositoryOpenForExtension()
        {
            var result = OpenExtClosedMod.IsClassExtensible(typeof(UserRepository));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void VoteRepositoryOpenForExtension()
        {
            var result = OpenExtClosedMod.IsClassExtensible(typeof(VoteRepository));

            Assert.True(result.Item1, result.Item2);
        }

        [Fact]
        public void ForumThreadOpenForExtension()
        {
            var result = OpenExtClosedMod.IsClassExtensible(typeof(ForumThread));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void CommentOpenForExtension()
        {
            var result = OpenExtClosedMod.IsClassExtensible(typeof(Comment));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ThreadPostOpenForExtension()
        {
            var result = OpenExtClosedMod.IsClassExtensible(typeof(ThreadPost));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void VotesControllerOpenForExtension()
        {
            var result = OpenExtClosedMod.IsClassExtensible(typeof(VotesController));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void CommentControllerOpenForExtension()
        {
            var result = OpenExtClosedMod.IsClassExtensible(typeof(CommentController));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ThreadPostControllerOpenForExtension()
        {
            var result = OpenExtClosedMod.IsClassExtensible(typeof(CommentController));

            Assert.True(result.Item1, result.Item2);
        }
    }
}
