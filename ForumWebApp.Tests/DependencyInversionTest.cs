using ForumWebApp;
using Xunit;
using SOLIDCheckingLibrary;
using ForumWebApp.Controllers;

namespace ForumWebApp.Tests
{
    public class DependencyInversionTest
    {
        [Fact]
        public void CommentControllerConstructorsFollowDependecyInversion()
        {
            var result = DependencyInversion.ClassConstructorsFollowPrinciple(typeof(CommentController), 
                DependencyInversion.CheckingSettings.IgnoreBasicCollectionTypes);

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void CommentControllerMethodsFollowDependecyInversion()
        {
            var result = DependencyInversion.ClassMethodsFollowPrinciple(typeof(CommentController), 
                DependencyInversion.CheckingSettings.IgnoreBasicCollectionTypes | 
                DependencyInversion.CheckingSettings.IgnoreInheritedFields |
                DependencyInversion.CheckingSettings.IgnoreModels);

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void CommentControllerFieldsFollowDependecyInversion()
        {
            var result = DependencyInversion.ClassFieldsFollowPrinciple(typeof(CommentController),
                DependencyInversion.CheckingSettings.IgnoreBasicCollectionTypes |
                DependencyInversion.CheckingSettings.IgnoreInheritedFields |
                DependencyInversion.CheckingSettings.IgnoreModels);

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void AccountControllerConstructorsFollowDependecyInversion()
        {
            var result = DependencyInversion.ClassConstructorsFollowPrinciple(typeof(AccountController), DependencyInversion.CheckingSettings.IgnoreBasicCollectionTypes);

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void AccountControllerMethodsFollowDependecyInversion()
        {
            var result = DependencyInversion.ClassMethodsFollowPrinciple(typeof(AccountController),
                DependencyInversion.CheckingSettings.IgnoreBasicCollectionTypes | 
                DependencyInversion.CheckingSettings.IgnoreInheritedFields |
                DependencyInversion.CheckingSettings.IgnoreModels);

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void AccountControllerFeildsFollowDependecyInversion()
        {
            var result = DependencyInversion.ClassFieldsFollowPrinciple(typeof(AccountController),
                DependencyInversion.CheckingSettings.IgnoreBasicCollectionTypes |
                DependencyInversion.CheckingSettings.IgnoreInheritedFields |
                DependencyInversion.CheckingSettings.IgnoreModels);

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void VotesControllerConstructorsFollowDependecyInversion()
        {
            var result = DependencyInversion.ClassConstructorsFollowPrinciple(typeof(VotesController), DependencyInversion.CheckingSettings.IgnoreBasicCollectionTypes);

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void VotesControllerMethodsFollowDependecyInversion()
        {
            var result = DependencyInversion.ClassMethodsFollowPrinciple(typeof(VotesController),
                DependencyInversion.CheckingSettings.IgnoreBasicCollectionTypes | 
                DependencyInversion.CheckingSettings.IgnoreInheritedFields |
                DependencyInversion.CheckingSettings.IgnoreModels);

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void VotesControllerFieldsFollowDependecyInversion()
        {
            var result = DependencyInversion.ClassFieldsFollowPrinciple(typeof(VotesController),
                DependencyInversion.CheckingSettings.IgnoreBasicCollectionTypes |
                DependencyInversion.CheckingSettings.IgnoreInheritedFields |
                DependencyInversion.CheckingSettings.IgnoreModels);

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ThreadPostControllerConstructorsFollowDependecyInversion()
        {
            var result = DependencyInversion.ClassConstructorsFollowPrinciple(typeof(ThreadPostController), DependencyInversion.CheckingSettings.IgnoreBasicCollectionTypes);

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ThreadPostControllerMethodsFollowDependecyInversion()
        {
            var result = DependencyInversion.ClassMethodsFollowPrinciple(typeof(ThreadPostController),
                DependencyInversion.CheckingSettings.IgnoreBasicCollectionTypes |
                DependencyInversion.CheckingSettings.IgnoreInheritedFields |
                DependencyInversion.CheckingSettings.IgnoreModels);

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ThreadPostControllerFieldsFollowDependecyInversion()
        {
            var result = DependencyInversion.ClassFieldsFollowPrinciple(typeof(ThreadPostController),
                DependencyInversion.CheckingSettings.IgnoreBasicCollectionTypes |
                DependencyInversion.CheckingSettings.IgnoreInheritedFields |
                DependencyInversion.CheckingSettings.IgnoreModels);

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ForumThreadControllerConstructorsFollowDependecyInversion()
        {
            var result = DependencyInversion.ClassConstructorsFollowPrinciple(typeof(ForumThreadController), DependencyInversion.CheckingSettings.IgnoreBasicCollectionTypes);

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ForumThreadControllerMethodsFollowDependecyInversion()
        {
            var result = DependencyInversion.ClassMethodsFollowPrinciple(typeof(ForumThreadController),
                DependencyInversion.CheckingSettings.IgnoreBasicCollectionTypes |
                DependencyInversion.CheckingSettings.IgnoreInheritedFields |
                DependencyInversion.CheckingSettings.IgnoreModels);

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void ForumThreadControllerFieldsFollowDependecyInversion()
        {
            var result = DependencyInversion.ClassFieldsFollowPrinciple(typeof(ForumThreadController),
                DependencyInversion.CheckingSettings.IgnoreBasicCollectionTypes |
                DependencyInversion.CheckingSettings.IgnoreInheritedFields |
                DependencyInversion.CheckingSettings.IgnoreModels);

            Assert.True(result.Item1, result.Item2);
        }

        [Fact]
        public void DashboardControllerConstructorsFollowDependecyInversion()
        {
            var result = DependencyInversion.ClassConstructorsFollowPrinciple(typeof(DashboardController), DependencyInversion.CheckingSettings.IgnoreBasicCollectionTypes);

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void DahsboardControllerMethodsFollowDependecyInversion()
        {
            var result = DependencyInversion.ClassMethodsFollowPrinciple(typeof(DashboardController),
                DependencyInversion.CheckingSettings.IgnoreBasicCollectionTypes |
                DependencyInversion.CheckingSettings.IgnoreInheritedFields |
                DependencyInversion.CheckingSettings.IgnoreModels);

            Assert.True(result.Item1, result.Item2);
        }
        [Fact]
        public void DashboardControllerFieldsFollowDependecyInversion()
        {
            var result = DependencyInversion.ClassFieldsFollowPrinciple(typeof(DashboardController),
                DependencyInversion.CheckingSettings.IgnoreBasicCollectionTypes |
                DependencyInversion.CheckingSettings.IgnoreInheritedFields |
                DependencyInversion.CheckingSettings.IgnoreModels);

            Assert.True(result.Item1, result.Item2);
        }
    }
}