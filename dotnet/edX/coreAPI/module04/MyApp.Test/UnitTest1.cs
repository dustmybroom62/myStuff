using System;
using Xunit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MyApp.Controllers;
using MyApp.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;

namespace MyApp.Test
{
/*
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(1 + 1 == 2);
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(1, 1);
        }
    }

    public class ActorsControllerFunctionTest
    {
        IConfiguration _configuration;

        public ActorsControllerFunctionTest()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets("MyApp-9238af9a-ddd9-48cd-8b03-57c44d9c988b")
                .AddEnvironmentVariables()
                .Build();
        }

        [Fact]
        public void GetActorByIdSmokeTest()
        {
            var controller = new ActorsController(_configuration);
            var result = controller.Get(101) as OkObjectResult;
            var actor = result.Value as Actor;
            Assert.Equal(101, actor.ActorId);
            Assert.Equal("SUSAN", actor.FirstName);
            Assert.Equal("DAVIS", actor.LastName);
        }
    }
*/
    public class ActorsControllerEndToEndTest
    {
        [Fact]
        public async void GetActorByIdSmokeTest()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:5000/");
                var acceptType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(acceptType);
                var response = await httpClient.GetAsync("api/actors/101");
                string jsonString = null;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                    Assert.NotNull(jsonString);
                }

                Actor actor = JsonConvert.DeserializeObject<Actor>(jsonString);
                Assert.NotNull(actor);
                Assert.Equal(101, actor.ActorId);
                Assert.Equal("SUSAN", actor.FirstName);
                Assert.Equal("DAVIS", actor.LastName);
            }
        }
    }
}
