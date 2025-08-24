using Application.Services.TaskManagement;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApi; // 👈 الـ namespace اللي فيه Program

namespace Tests.IntegrationTests
{
    [TestClass]
    public class TasksControllerIntegrationTests
    {
        private static WebApplicationFactory<Program> _factory;
        private static HttpClient _client;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            // إنشاء Factory للتطبيق
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TestMethod]
        public async Task InsertTask_Should_Return_Success()
        {
            // Arrange
            var task = new TaskDto { Title = "Test Task", Description = "false", IsCompleted = false, Priority = 1, Category = "Category", DueDate = DateTime.Now, CreatedAt = DateTime.Now, UsersId = 2 };


            // Act
            var response = await _client.PostAsJsonAsync("/api/Tasks/Insert", task);

            // Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(result.Contains("Task added successfully"));
        }

        [TestMethod]
        public async Task GetBy_Should_Return_Success()
        {
            // Arrange

            TaskSearchInput input = new TaskSearchInput { Skip = 1 };

            // Act
            var response = await _client.PostAsJsonAsync("/api/Tasks/GetBy", input);

            // Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(result.Contains("Success"));
        }
    }
}
