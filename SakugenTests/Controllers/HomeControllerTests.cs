using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sakugen.Repository;
using System;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Sakugen.Interface;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Diagnostics;

namespace Sakugen.Controllers.Tests
{
    public class HomeControllerTests
    {
        private readonly HttpClient _client;

        public HomeControllerTests()
        {
            var server = new WebApplicationFactory<Program>();
            _client = server.CreateClient();
        }


        [Fact]
        public async void GetNotExistRecord()
        {
            var response = await _client.GetAsync("http://localhost:5073/notExistToken");

            Assert.AreEqual("/Home/NotFoundPage", response.RequestMessage.RequestUri.AbsolutePath);
        }
    }
}