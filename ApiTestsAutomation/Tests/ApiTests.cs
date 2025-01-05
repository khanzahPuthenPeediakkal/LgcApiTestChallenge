using ApiTestsAutomation.TestData;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Net;

namespace ApiTestsAutomation.Tests
{
    [TestFixture]
    public class ApiTests : BaseTests
    {
       
        [Test]
        public void Validate_GetPostById_ReturnsCorrectData()
        {
            try
            {
                TestContext.WriteLine("Starting CheckGetPostByIdTest...");

                var response = clientHelper.ExecuteGetRequest("/posts/1");

                TestContext.WriteLine($"Response: {response.Content}");
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not 200");

                var responseData = JObject.Parse(response.Content);
                Assert.That(responseData["userId"].Value<int>(), Is.EqualTo(1), "userId does not match");
                Assert.That(responseData["id"].Value<int>(), Is.EqualTo(1), "id does not match");
                Assert.That(responseData["title"].ToString(), Is.Not.Empty, "Title is empty");
                Assert.That(responseData["body"].ToString(), Is.Not.Empty, "Body is empty");
                TestContext.WriteLine("CheckGetPostByIdTest passed.");

            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"CheckGetPostByIdTest failed: {ex.Message}");
                throw;
            }            
        }

        [Test]
        public void Validate_CreateNewPost_ReturnsCreatedData()
        {
            try
            {
                TestContext.WriteLine("Starting CheckCreateNewPostTest...");
                var newPost = PostData.CreatePost(1, "New Post", "This is a new post body");
                var response = clientHelper.ExecutePostRequest("/posts", newPost);

                TestContext.WriteLine($"Response: {response.Content}");
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Status code is not 201");

                var responseData = JObject.Parse(response.Content);
                Assert.That(responseData["userId"].Value<int>(), Is.EqualTo(1), "userId does not match");
                Assert.That(responseData["title"].ToString(), Is.EqualTo("New Post"), "Title does not match");
                Assert.That(responseData["body"].ToString(), Is.EqualTo("This is a new post body"), "Body does not match");
                TestContext.WriteLine("CheckCreateNewPostTest passed.");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"CheckCreateNewPostTest failed: {ex.Message}");
                throw;
            }            
        }

        [Test]
        public void Validate_UpdatePost_ReturnsUpdatedData()
        {
            try
            {
                TestContext.WriteLine("Starting CheckUpdatePostTest...");

                var updatedPost = PostData.CreatePost(1, "Updated Title", "Updated Body");
                var response = clientHelper.ExecutePutRequest("/posts/1", updatedPost);

                TestContext.WriteLine($"Response: {response.Content}");
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not 200");

                var responseData = JObject.Parse(response.Content);
                Assert.That(responseData["userId"].Value<int>(), Is.EqualTo(1), "userId does not match");
                Assert.That(responseData["title"].ToString(), Is.EqualTo("Updated Title"), "Title does not match");
                Assert.That(responseData["body"].ToString(), Is.EqualTo("Updated Body"), "Body does not match");
                TestContext.WriteLine("CheckUpdatePostTest passed.");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"CheckUpdatePostTest failed: {ex.Message}");
                throw;
            }           
        }

        [Test]
        public void Validate_DeletePost_ReturnsSuccess()
        {
            try
            {
                TestContext.WriteLine("Starting CheckDeletePostTest...");

                var response = clientHelper.ExecuteDeleteRequest("/posts/1");

                TestContext.WriteLine($"Response: {response.Content}");
                Assert.That(
                    response.StatusCode,
                    Is.EqualTo(HttpStatusCode.NoContent)
                     .Or.EqualTo(HttpStatusCode.OK),
                    "Status code is not 204 or 200"
                );

                if (!string.IsNullOrEmpty(response.Content))
                {
                    var responseData = JObject.Parse(response.Content);
                    Assert.That(responseData, Is.Empty, "Response body is not empty for DELETE request");
                }
                TestContext.WriteLine("CheckDeletePostTest passed.");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"CheckDeletePostTest failed: {ex.Message}");
                throw;
            }           

        }
    }
}
