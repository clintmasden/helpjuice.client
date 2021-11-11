using System;
using System.IO;
using System.Threading.Tasks;
using HelpJuice.Client;
using HelpJuice.Client.Commands;
using HelpJuice.Client.Queries.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountSettings = HelpJuice.Client.Commands.Models.AccountSettings;
using Article = HelpJuice.Client.Commands.Models.Article;
using Category = HelpJuice.Client.Commands.Models.Category;
using Group = HelpJuice.Client.Commands.Models.Group;
using User = HelpJuice.Client.Commands.Models.User;

namespace HelpJuice.Tests
{
    [TestClass]
    public class HelpJuiceClientTests
    {
        private static HelpJuiceClient _client;

        [ClassInitialize]
        public static void SetupClient(TestContext context)
        {
            var fileText = File.ReadAllText(@"C:\Users\user\Desktop\helpJuiceContents.txt");
            var helpJuiceContent = fileText.Split("||", StringSplitOptions.RemoveEmptyEntries);

            _client = new HelpJuiceClient(helpJuiceContent[0], helpJuiceContent[1]);
        }

        [TestMethod]
        public async Task GetSearches_Pass()
        {
            var result = await _client.GetSearches("functional test");

            Assert.IsFalse(result.HasException);
            Assert.AreEqual(25, result.Payload.Meta.Limit);
        }

        [TestMethod]
        public async Task GetSearchesWithPageParameters_Pass()
        {
            var result = await _client.GetSearches("functional test", new PageParameters {Page = 1, Limit = 1000});

            Assert.IsFalse(result.HasException);
            Assert.AreEqual(1000, result.Payload.Meta.Limit);
        }

        [TestMethod]
        public async Task GetUsers_Pass()
        {
            var result = await _client.GetUsers();

            Assert.IsFalse(result.HasException);
            Assert.AreEqual(25, result.Payload.Meta.Limit);
        }

        [TestMethod]
        public async Task GetUsersWithPageParameters_Pass()
        {
            var result = await _client.GetUsers(new PageParameters {Page = 1, Limit = 1000});

            Assert.IsFalse(result.HasException);
            Assert.AreEqual(1000, result.Payload.Meta.Limit);
        }

        [TestMethod]
        public async Task GetUser_Pass()
        {
            var result = await _client.GetUser(290500);
            Assert.IsFalse(result.HasException);
        }


        /// <summary>
        ///     This failure will pass when the same email is used twice for any user
        /// </summary>
        /// <returns></returns>
        [Ignore]
        [TestMethod]
        public async Task CreateUser_Fail()
        {
            //Create user
            var createResult = await _client.CreateUser(new CreateUserCommand
            {
                User = new User
                {
                    FirstName = "Functional",
                    LastName = "Test",
                    Email = "FunctionalTest@FunctionalTest.com",
                    RoleId = "collaborator",
                    GroupIds = new[] {2407}
                }
            });

            Assert.IsTrue(createResult.HasException);
        }


        [TestMethod]
        public async Task MethodsUser_Pass()
        {
            //Create user
            var createResult = await _client.CreateUser(new CreateUserCommand
            {
                User = new User
                {
                    FirstName = "Functional",
                    LastName = "Test",
                    Email = $"{Guid.NewGuid():N}@FunctionalTest.com",
                    RoleId = "collaborator",
                    GroupIds = new[] {2407}
                }
            });

            Assert.IsFalse(createResult.HasException);

            // Get user
            var getResult = await _client.GetUser(createResult.Payload.Id);
            Assert.IsFalse(getResult.HasException);

            // Update user
            var updateResult = await _client.UpdateUser(createResult.Payload.Id, new UpdateUserCommand
            {
                User = new User
                {
                    FirstName = "Functional - Update",
                    LastName = "Test - Update",
                    Email = $"{createResult.Payload.Email}",
                    RoleId = "collaborator",
                    GroupIds = new[] {2407}
                }
            });

            Assert.IsFalse(updateResult.HasException);

            // Deactivate user
            var deactivateResult = await _client.DeactivateUser(createResult.Payload.Id);
            Assert.IsFalse(deactivateResult.HasException);


            // Activate user
            var activateResult = await _client.ActivateUser(createResult.Payload.Id);
            Assert.IsFalse(activateResult.HasException);

            // Delete user
            var deleteResult = await _client.DeleteUser(createResult.Payload.Id);
            Assert.IsFalse(deleteResult.HasException);
        }

        [TestMethod]
        public async Task GetGroups_Pass()
        {
            var result = await _client.GetGroups();

            Assert.IsFalse(result.HasException);
            Assert.AreEqual(25, result.Payload.Meta.Limit);
        }

        [TestMethod]
        public async Task GetGroupsWithPageParameters_Pass()
        {
            var result = await _client.GetGroups(new PageParameters {Page = 1, Limit = 1000});

            Assert.IsFalse(result.HasException);
            Assert.AreEqual(1000, result.Payload.Meta.Limit);
        }

        [TestMethod]
        public async Task GetGroup_Pass()
        {
            var result = await _client.GetGroup(5756);
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task MethodsGroup_Pass()
        {
            //Create group
            var createResult = await _client.CreateGroup(new CreateGroupCommand
            {
                Group = new Group
                {
                    Name = "Functional Test",
                    SmartLoad = false
                }
            });

            Assert.IsFalse(createResult.HasException);

            // Get group
            var getResult = await _client.GetGroup(createResult.Payload.Id);
            Assert.IsFalse(getResult.HasException);

            // Update group
            var updateResult = await _client.UpdateGroup(createResult.Payload.Id, new UpdateGroupCommand
            {
                Group = new Group
                {
                    Name = "Functional Test - Update",
                    SmartLoad = true
                }
            });

            Assert.IsFalse(updateResult.HasException);


            // Delete group
            var deleteResult = await _client.DeleteGroup(createResult.Payload.Id);
            Assert.IsFalse(deleteResult.HasException);
        }


        [TestMethod]
        public async Task GetCategories_Pass()
        {
            var result = await _client.GetCategories();

            Assert.IsFalse(result.HasException);
            Assert.AreEqual(25, result.Payload.Meta.Limit);
        }

        [TestMethod]
        public async Task GetCategoriesWithPageParameters_Pass()
        {
            var result = await _client.GetCategories(new PageParameters {Page = 1, Limit = 1000});

            Assert.IsFalse(result.HasException);
            Assert.AreEqual(1000, result.Payload.Meta.Limit);
        }

        [TestMethod]
        public async Task GetCategory_Pass()
        {
            var result = await _client.GetCategory(225461);
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task MethodsCategory_Pass()
        {
            //Create category
            var createResult = await _client.CreateCategory(new CreateCategoryCommand
            {
                Category = new Category
                {
                    ParentId = 190467,
                    Accessibility = 1,
                    Name = "Functional Test",
                    Description = "Functional Test Description",
                    Codename = "functional-test",
                    IsArchived = false
                }
            });

            Assert.IsFalse(createResult.HasException);

            // Get category
            var getResult = await _client.GetCategory(createResult.Payload.Id);
            Assert.IsFalse(getResult.HasException);

            // Update category
            var updateResult = await _client.UpdateCategory(createResult.Payload.Id, new UpdateCategoryCommand
            {
                Category = new Category
                {
                    Accessibility = 1,
                    Name = "Functional Test - Update",
                    Description = "Functional Test Description - Update",
                    Codename = "functional-test-update",
                    IsArchived = true
                }
            });

            Assert.IsFalse(updateResult.HasException);


            // Delete category
            var deleteResult = await _client.DeleteCategory(createResult.Payload.Id);
            Assert.IsFalse(deleteResult.HasException);
        }

        [TestMethod]
        public async Task GetArticles_Pass()
        {
            var result = await _client.GetArticles();

            Assert.IsFalse(result.HasException);
            Assert.AreEqual(25, result.Payload.Meta.Limit);
        }

        [TestMethod]
        public async Task GetArticlesWithPageParameters_Pass()
        {
            var result = await _client.GetArticles(new ArticlePageParameters {Page = 1, Limit = 1000, Accessibility = 0, CreatedSince = DateTime.Now.AddDays(-30)});

            Assert.IsFalse(result.HasException);
            Assert.AreEqual(1000, result.Payload.Meta.Limit);
        }

        [TestMethod]
        public async Task GetArticle_Pass()
        {
            var result = await _client.GetArticle(1112747);
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task MethodsArticle_Pass()
        {
            //Create article
            var createResult = await _client.CreateArticle(new CreateArticleCommand
            {
                Article = new Article
                {
                    Name = "Functional Test",
                    Description = "Functional Test Description",
                    Codename = "functional-test",
                    VisibilityId = 1,
                    Body = "<p>this is the article functional test body</p>",
                    IsPublished = true,
                    CategoryIds = new[] {151886},
                    ContributorUserIds = new[] {727541}
                }
            });

            Assert.IsFalse(createResult.HasException);

            // Get article
            var getResult = await _client.GetArticle(createResult.Payload.Id);
            Assert.IsFalse(getResult.HasException);

            // Update article
            var updateResult = await _client.UpdateArticle(createResult.Payload.Id, new UpdateArticleCommand
            {
                Article = new Article
                {
                    Name = "Functional Test - Update",
                    Description = "Functional Test Description - Update",
                    Codename = "functional-test-update",
                    VisibilityId = 1,
                    Body = "<p>this is the article functional test update body</p>",
                    IsPublished = true,
                    CategoryIds = new[] {151886},
                    ContributorUserIds = new[] {727541}
                }
            });

            Assert.IsFalse(updateResult.HasException);


            // Delete article
            var deleteResult = await _client.DeleteArticle(createResult.Payload.Id);
            Assert.IsFalse(deleteResult.HasException);
        }

        [TestMethod]
        public async Task GetActivities_Pass()
        {
            var result = await _client.GetActivities();

            Assert.IsFalse(result.HasException);
            Assert.AreEqual(25, result.Payload.Meta.Limit);
        }

        [TestMethod]
        public async Task GetActivitiesWithPageParameters_Pass()
        {
            var result = await _client.GetActivities(new PageParameters {Page = 1, Limit = 1000});

            Assert.IsFalse(result.HasException);
            Assert.AreEqual(1000, result.Payload.Meta.Limit);
        }

        [TestMethod]
        public async Task GetActivity_Pass()
        {
            var result = await _client.GetActivity(53612534);
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task GetAccountSettings_Pass()
        {
            var result = await _client.GetAccountSettings();
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task UpdateAccountSettings_Pass()
        {
            var accountSettingsResult = await _client.GetAccountSettings();
            Assert.IsFalse(accountSettingsResult.HasException);

            var result = await _client.UpdateAccountSettings(new UpdateAccountSettingsCommand
            {
                AccountSettings = new AccountSettings
                {
                    Name = accountSettingsResult.Payload.Name,
                    Subdomain = accountSettingsResult.Payload.Subdomain,
                    TopQuestionsCount = 1, //accountSettingsResult.Payload.TopQuestionsCount,
                    InternalKb = accountSettingsResult.Payload.InternalKb,
                    ExpirePasswordAfterDays = accountSettingsResult.Payload.ExpirePasswordAfterDays,
                    ContactUsEmail = accountSettingsResult.Payload.ContactUsEmail,
                    ContactUsSubject = accountSettingsResult.Payload.ContactUsSubject,
                    ContactUsSingleSender = accountSettingsResult.Payload.ContactUsSingleSender,
                    OnlyInternalArticleRequests = accountSettingsResult.Payload.OnlyInternalArticleRequests
                }
            });

            Assert.IsFalse(result.HasException);
        }
    }
}