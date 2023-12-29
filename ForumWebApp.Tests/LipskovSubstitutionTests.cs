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
    public class LipskovSubstitutionTests
    {
        [Fact]
        public void AccountControllerFollowsLipskoPrinciple()
        {
            var result = LiskovPrinciple.CheckMethodsOfParentIsOverriden(typeof(AccountController), typeof(Controller));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void CommentControllerFollowsLipskoPrinciple()
        {
            var result = LiskovPrinciple.CheckMethodsOfParentIsOverriden(typeof(CommentController), typeof(Controller));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void DashboardControllerFollowsLipskoPrinciple()
        {
            var result = LiskovPrinciple.CheckMethodsOfParentIsOverriden(typeof(DashboardController), typeof(Controller));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ForumThreadControllerFollowsLipskoPrinciple()
        {
            var result = LiskovPrinciple.CheckMethodsOfParentIsOverriden(typeof(ForumThreadController), typeof(Controller));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ThreadPostControllerFollowsLipskoPrinciple()
        {
            var result = LiskovPrinciple.CheckMethodsOfParentIsOverriden(typeof(ThreadPostController), typeof(Controller));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void UserControllerFollowsLipskoPrinciple()
        {
            var result = LiskovPrinciple.CheckMethodsOfParentIsOverriden(typeof(UserController), typeof(Controller));

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void VotesControllerFollowsLipskoPrinciple()
        {
            var result = LiskovPrinciple.CheckMethodsOfParentIsOverriden(typeof(VotesController), typeof(Controller));

            Assert.True(result.Item1, result.Item2);
        }
    }
}
