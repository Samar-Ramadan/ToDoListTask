using Application.Services.TaskManagement;
using AutoMapper;
using Core.Enum;
using Core.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tests.UnitTests
{
    [TestClass]
    public class TaskServiceTests
    {
        private readonly TaskService _taskService;
        private readonly AppDbContext _context;
        private const string connectionstrings = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ToDoList;Integrated Security=True;Encrypt=False;Pooling=False; TrustServerCertificate=True";
        public TaskServiceTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
           .UseSqlServer(connectionstrings)
           .Options;

            _context = new AppDbContext(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Tasks, TaskDto>().ReverseMap();
            });
            var mapper = config.CreateMapper();

            _taskService = new TaskService(_context, mapper);
        }

        [TestMethod]
        public async Task AddTask_Should_Add_To_Db()
        {
            var task = new TaskDto { Title = "Test Task", Description = "false", IsCompleted = false, Priority = 1, Category = "Category", DueDate = DateTime.Now, CreatedAt = DateTime.Now, UsersId = 2 };

            _taskService.Insert(task);
            await _context.SaveChangesAsync();

            var saved = _context.Tasks.FirstOrDefault(t => t.Title == "Test Task");

            Assert.IsNotNull(saved);
            Assert.IsFalse(saved.IsCompleted);
        }

        [TestMethod]
        public async Task GetAllTasks_Should_Return_All()
        {
            TaskSearchInput input = new TaskSearchInput { Skip = 1 };
            // Act
            var result = _taskService.GetBy(input);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}