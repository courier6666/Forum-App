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
    public class InterfaceSegregationTests
    {
        [Fact]
        public void CommentRepositoryFollowsInterfaceSegregation()
        {
            var result = InterfaceSegregation.ClassFollowsPrinciple(typeof(CommentRepository));
            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ForumThreadRepositoryFollowsInterfaceSegregation()
        {
            var result = InterfaceSegregation.ClassFollowsPrinciple(typeof(ForumThreadRepository));
            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ForumThreadUserFollowRepositoryFollowsInterfaceSegregation()
        {
            var result = InterfaceSegregation.ClassFollowsPrinciple(typeof(ForumThreadUserFollowRepository));
            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ThreadPostRepositoryFollowsInterfaceSegregation()
        {
            var result = InterfaceSegregation.ClassFollowsPrinciple(typeof(ThreadPostRepository));
            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void UserRepositoryFollowsInterfaceSegregation()
        {
            var result = InterfaceSegregation.ClassFollowsPrinciple(typeof(UserRepository));
            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void VoteRepositoryFollowsInterfaceSegregation()
        {
            var result = InterfaceSegregation.ClassFollowsPrinciple(typeof(VoteRepository));
            Assert.True(result.Item1, result.Item2);
        }
    }
}
