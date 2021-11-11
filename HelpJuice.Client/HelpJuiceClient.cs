using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;
using HelpJuice.Client.Commands;
using HelpJuice.Client.Exceptions;
using HelpJuice.Client.Models;
using HelpJuice.Client.Queries;
using HelpJuice.Client.Queries.Models;
using HelpJuice.Client.Responses;

namespace HelpJuice.Client
{
    /// <summary>
    ///     <see href="https://help.helpjuice.com/">Help Juice Client (Version 3 of the Help Juice API) </see>
    /// </summary>
    public class HelpJuiceClient
    {
        /// <param name="apiUrl">The knowledge base URL/api/v3/. (youraccountname.helpjuice.com/api/v3/)</param>
        /// <param name="apiKey">
        ///     <see href="https://help.helpjuice.com/en_US/API/284079-how-do-i-get-my-api-key">The API key</see>
        /// </param>
        public HelpJuiceClient(string apiUrl, string apiKey)
        {
            _client = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            })
            {
                BaseAddress = new Uri(apiUrl.EndsWith("/") ? apiUrl : $"{apiUrl}/")
            };

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", $"{apiKey}");
            _client.DefaultRequestHeaders.Add("User-Agent", "PostmanRuntime/7.28.4"); // Help Juice throws status 500 without this header when leveraging their search endpoint. /sob /sigh.
            _client.DefaultRequestHeaders.Add("Accept", "*/*");
            _client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip,deflate,br");
            _client.DefaultRequestHeaders.Connection.Add("keep-alive");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private HttpClient _client { get; }

        /// <summary>
        ///     Get searches from the knowledge base.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<SearchesQuery>> GetSearches(string searchQuery, PageParameters parameters = null)
        {
            searchQuery = HttpUtility.HtmlEncode(searchQuery);

            var endpoint = parameters != null ? $"{_client.BaseAddress}search{parameters.HttpQueryParameters}&query={searchQuery}" : $"{_client.BaseAddress}search?query={searchQuery}";
            return await Request<SearchesQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get users.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<UsersQuery>> GetUsers(PageParameters parameters = null)
        {
            var endpoint = parameters != null ? $"{_client.BaseAddress}users/{parameters.HttpQueryParameters}" : $"{_client.BaseAddress}users/";
            return await Request<UsersQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get a user.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<User>> GetUser(int id)
        {
            var endpoint = $"{_client.BaseAddress}users/{id}";
            var response = await Request<UserQuery>(endpoint, HttpMethods.Get);

            return response.HasException ? Result<User>.Fail(response.Exception) : Result<User>.Success(response.Payload.User);
        }

        /// <summary>
        ///     Create a user.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<User>> CreateUser(CreateUserCommand command)
        {
            var endpoint = $"{_client.BaseAddress}users/";
            var response = await Request<UserQuery>(endpoint, HttpMethods.Post, command);

            return response.HasException ? Result<User>.Fail(response.Exception) : Result<User>.Success(response.Payload.User);
        }

        /// <summary>
        ///     Update a user.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<User>> UpdateUser(int id, UpdateUserCommand command)
        {
            var endpoint = $"{_client.BaseAddress}users/{id}";
            var response = await Request<UserQuery>(endpoint, HttpMethods.Put, command);

            return response.HasException ? Result<User>.Fail(response.Exception) : Result<User>.Success(response.Payload.User);
        }

        /// <summary>
        ///     Delete a user.
        /// </summary>
        /// <returns></returns>
        public async Task<Result> DeleteUser(int id)
        {
            var endpoint = $"{_client.BaseAddress}users/{id}";
            return await Request(endpoint, HttpMethods.Delete);
        }

        /// <summary>
        ///     Deactivate a user.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<User>> DeactivateUser(int id)
        {
            var endpoint = $"{_client.BaseAddress}users/{id}/deactivate";
            var response = await Request<UserQuery>(endpoint, HttpMethods.Put);

            return response.HasException ? Result<User>.Fail(response.Exception) : Result<User>.Success(response.Payload.User);
        }

        /// <summary>
        ///     Deactivate a user.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<User>> ActivateUser(int id)
        {
            var endpoint = $"{_client.BaseAddress}users/{id}/activate";
            var response = await Request<UserQuery>(endpoint, HttpMethods.Put);

            return response.HasException ? Result<User>.Fail(response.Exception) : Result<User>.Success(response.Payload.User);
        }

        /// <summary>
        ///     Get groups.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<GroupsQuery>> GetGroups(PageParameters parameters = null)
        {
            var endpoint = parameters != null ? $"{_client.BaseAddress}groups/{parameters.HttpQueryParameters}" : $"{_client.BaseAddress}groups/";
            return await Request<GroupsQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get a group.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<Group>> GetGroup(int id)
        {
            var endpoint = $"{_client.BaseAddress}groups/{id}";
            var response = await Request<GroupQuery>(endpoint, HttpMethods.Get);

            return response.HasException ? Result<Group>.Fail(response.Exception) : Result<Group>.Success(response.Payload.Group);
        }

        /// <summary>
        ///     Create a group.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<Group>> CreateGroup(CreateGroupCommand command)
        {
            var endpoint = $"{_client.BaseAddress}groups/";
            var response = await Request<GroupQuery>(endpoint, HttpMethods.Post, command);

            return response.HasException ? Result<Group>.Fail(response.Exception) : Result<Group>.Success(response.Payload.Group);
        }

        /// <summary>
        ///     Update a group.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<Group>> UpdateGroup(int id, UpdateGroupCommand command)
        {
            var endpoint = $"{_client.BaseAddress}groups/{id}";
            var response = await Request<GroupQuery>(endpoint, HttpMethods.Put, command);

            return response.HasException ? Result<Group>.Fail(response.Exception) : Result<Group>.Success(response.Payload.Group);
        }

        /// <summary>
        ///     Delete a group.
        /// </summary>
        /// <returns></returns>
        public async Task<Result> DeleteGroup(int id)
        {
            var endpoint = $"{_client.BaseAddress}groups/{id}";
            return await Request(endpoint, HttpMethods.Delete);
        }

        /// <summary>
        ///     Get categories.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<CategoriesQuery>> GetCategories(PageParameters parameters = null)
        {
            var endpoint = parameters != null ? $"{_client.BaseAddress}categories/{parameters.HttpQueryParameters}" : $"{_client.BaseAddress}categories/";
            return await Request<CategoriesQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get a category.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<Category>> GetCategory(int id)
        {
            var endpoint = $"{_client.BaseAddress}categories/{id}";
            var response = await Request<CategoryQuery>(endpoint, HttpMethods.Get);

            return response.HasException ? Result<Category>.Fail(response.Exception) : Result<Category>.Success(response.Payload.Category);
        }

        /// <summary>
        ///     Create a category.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<Category>> CreateCategory(CreateCategoryCommand command)
        {
            var endpoint = $"{_client.BaseAddress}categories/";
            var response = await Request<CategoryQuery>(endpoint, HttpMethods.Post, command);

            return response.HasException ? Result<Category>.Fail(response.Exception) : Result<Category>.Success(response.Payload.Category);
        }

        /// <summary>
        ///     Update a category.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<Category>> UpdateCategory(int id, UpdateCategoryCommand command)
        {
            var endpoint = $"{_client.BaseAddress}categories/{id}";
            var response = await Request<CategoryQuery>(endpoint, HttpMethods.Put, command);

            return response.HasException ? Result<Category>.Fail(response.Exception) : Result<Category>.Success(response.Payload.Category);
        }

        /// <summary>
        ///     Delete a category.
        /// </summary>
        /// <returns></returns>
        public async Task<Result> DeleteCategory(int id)
        {
            var endpoint = $"{_client.BaseAddress}categories/{id}";
            return await Request(endpoint, HttpMethods.Delete);
        }


        /// <summary>
        ///     Get articles.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<ArticlesQuery>> GetArticles(ArticlePageParameters parameters = null)
        {
            var endpoint = parameters != null ? $"{_client.BaseAddress}articles/{parameters.HttpQueryParameters}" : $"{_client.BaseAddress}articles/";
            return await Request<ArticlesQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get an articles.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<Article>> GetArticle(int id)
        {
            var endpoint = $"{_client.BaseAddress}articles/{id}";
            var response = await Request<ArticleQuery>(endpoint, HttpMethods.Get);

            return response.HasException ? Result<Article>.Fail(response.Exception) : Result<Article>.Success(response.Payload.Article);
        }

        /// <summary>
        ///     Create an articles.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<Article>> CreateArticle(CreateArticleCommand command)
        {
            var endpoint = $"{_client.BaseAddress}articles/";
            var response = await Request<ArticleQuery>(endpoint, HttpMethods.Post, command);

            return response.HasException ? Result<Article>.Fail(response.Exception) : Result<Article>.Success(response.Payload.Article);
        }

        /// <summary>
        ///     Update an articles.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<Article>> UpdateArticle(int id, UpdateArticleCommand command)
        {
            var endpoint = $"{_client.BaseAddress}articles/{id}";
            var response = await Request<ArticleQuery>(endpoint, HttpMethods.Put, command);

            return response.HasException ? Result<Article>.Fail(response.Exception) : Result<Article>.Success(response.Payload.Article);
        }

        /// <summary>
        ///     Delete an articles.
        /// </summary>
        /// <returns></returns>
        public async Task<Result> DeleteArticle(int id)
        {
            var endpoint = $"{_client.BaseAddress}articles/{id}";
            return await Request(endpoint, HttpMethods.Delete);
        }

        /// <summary>
        ///     Get activities.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<ActivitiesQuery>> GetActivities(PageParameters parameters = null)
        {
            var endpoint = parameters != null ? $"{_client.BaseAddress}activities/{parameters.HttpQueryParameters}" : $"{_client.BaseAddress}activities/";
            return await Request<ActivitiesQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get an activity.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<Activity>> GetActivity(int id)
        {
            var endpoint = $"{_client.BaseAddress}activities/{id}";
            var response = await Request<ActivityQuery>(endpoint, HttpMethods.Get);

            return response.HasException ? Result<Activity>.Fail(response.Exception) : Result<Activity>.Success(response.Payload.Activity);
        }

        /// <summary>
        ///     Get account settings.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<AccountSettings>> GetAccountSettings()
        {
            var endpoint = $"{_client.BaseAddress}settings/account/";
            var response = await Request<AccountSettingsQuery>(endpoint, HttpMethods.Get);

            return response.HasException ? Result<AccountSettings>.Fail(response.Exception) : Result<AccountSettings>.Success(response.Payload.AccountSettings);
        }

        /// <summary>
        ///     Update account settings.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<AccountSettings>> UpdateAccountSettings(UpdateAccountSettingsCommand command)
        {
            var endpoint = $"{_client.BaseAddress}settings";
            var response = await Request<AccountSettingsQuery>(endpoint, HttpMethods.Put, command);

            return response.HasException ? Result<AccountSettings>.Fail(response.Exception) : Result<AccountSettings>.Success(response.Payload.AccountSettings);
        }


        /// <summary>
        ///     Client's HTTP/CRUD methods
        /// </summary>
        /// <remarks>
        ///     Leveraging POST, PUT
        /// </remarks>
        private async Task<Result<T>> Request<T>(string endpoint, HttpMethods method = HttpMethods.Post, object content = null)
        {
            try
            {
                switch (method)
                {
                    case HttpMethods.Post:
                        var postResponse = await _client.PostAsJsonAsync(endpoint, content);

                        await ThrowHelpJuiceException(postResponse);
                        postResponse.EnsureSuccessStatusCode();

                        return Result<T>.Success(await postResponse.Content.ReadFromJsonAsync<T>());

                    case HttpMethods.Put:
                        var putResponse = await _client.PutAsJsonAsync(endpoint, content);

                        await ThrowHelpJuiceException(putResponse);
                        putResponse.EnsureSuccessStatusCode();

                        return Result<T>.Success(await putResponse.Content.ReadFromJsonAsync<T>());

                    default:
                        throw new Exception("Invalid HTTP Method/Request");
                }
            }
            catch (Exception e)
            {
                return Result<T>.Fail(e);
            }
        }

        private async Task ThrowHelpJuiceException(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new HelpJuiceHttpException(response.StatusCode, "The API key is not provided.");
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new HelpJuiceHttpException(response.StatusCode, "The requested data does not exist.");
            }

            if ((int) response.StatusCode == 422) //System.Net.HttpStatusCode.UnprocessableEntity
            {
                throw new HelpJuiceHttpException(response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }


        /// <summary>
        ///     Client's HTTP/CRUD methods
        /// </summary>
        private async Task<Result<T>> Request<T>(string endpoint, HttpMethods method = HttpMethods.Get)
        {
            try
            {
                switch (method)
                {
                    case HttpMethods.Get:
                        return Result<T>.Success(await _client.GetFromJsonAsync<T>(endpoint));

                    case HttpMethods.Post:
                        var postResponse = await _client.PostAsync(endpoint, null);

                        await ThrowHelpJuiceException(postResponse);
                        postResponse.EnsureSuccessStatusCode();

                        return Result<T>.Success(await postResponse.Content.ReadFromJsonAsync<T>());

                    case HttpMethods.Put:
                        var putResponse = await _client.PutAsync(endpoint, null);

                        await ThrowHelpJuiceException(putResponse);
                        putResponse.EnsureSuccessStatusCode();

                        return Result<T>.Success(await putResponse.Content.ReadFromJsonAsync<T>());

                    case HttpMethods.Delete:
                        var deleteResponse = await _client.DeleteAsync(endpoint);

                        await ThrowHelpJuiceException(deleteResponse);
                        deleteResponse.EnsureSuccessStatusCode();

                        return Result<T>.Success(await deleteResponse.Content.ReadFromJsonAsync<T>());
                    default:
                        throw new Exception("Invalid HTTP Method/Request");
                }
            }
            catch (Exception e)
            {
                return Result<T>.Fail(e);
            }
        }

        /// <summary>
        ///     Client's HTTP/CRUD methods
        /// </summary>
        private async Task<Result> Request(string endpoint, HttpMethods method = HttpMethods.Get)
        {
            try
            {
                switch (method)
                {
                    case HttpMethods.Get:
                        var getResponse = await _client.GetAsync(endpoint);

                        await ThrowHelpJuiceException(getResponse);
                        getResponse.EnsureSuccessStatusCode();

                        return Result.Success;

                    case HttpMethods.Post:
                        var postResponse = await _client.PostAsync(endpoint, null);

                        await ThrowHelpJuiceException(postResponse);
                        postResponse.EnsureSuccessStatusCode();

                        return Result.Success;

                    case HttpMethods.Put:
                        var putResponse = await _client.PutAsync(endpoint, null);

                        await ThrowHelpJuiceException(putResponse);
                        putResponse.EnsureSuccessStatusCode();

                        return Result.Success;

                    case HttpMethods.Delete:
                        var deleteResponse = await _client.DeleteAsync(endpoint);

                        await ThrowHelpJuiceException(deleteResponse);
                        deleteResponse.EnsureSuccessStatusCode();

                        return Result.Success;
                    default:
                        throw new Exception("Invalid HTTP Method/Request");
                }
            }
            catch (Exception e)
            {
                return Result.Fail(e);
            }
        }
    }
}