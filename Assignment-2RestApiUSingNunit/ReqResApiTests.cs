using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2RestApiUSingNunit
{
    [TestFixture]
    internal class ReqResApiTests
    {
        private RestClient client;
        private string baseUrl = "https://jsonplaceholder.typicode.com/";
        [SetUp]
        public void Setup()
        {
            client = new RestClient(baseUrl);
        }
        [Test]
        [Order(1)]
        public void GetSingleUser()
        {
            var request = new RestRequest("users/2", Method.Get);
            var response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            var userdata = JsonConvert.DeserializeObject<UserData>(response.Content);
           
            Assert.NotNull(userdata);
            Assert.That(userdata.Id, Is.EqualTo(2));
            Assert.IsNotEmpty(userdata.Email);
        }
        [Test]
        [Order(0)]
        public void CreateUser()
        {
            var request = new RestRequest("users", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { name = "Vikash kumar", email = "vikash@1234" });
            var response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
            var user = JsonConvert.DeserializeObject<UserData>(response.Content);
            Assert.NotNull(user);
            //  Assert.IsNotEmpty(user.Email);
            //  Console.WriteLine(user.Email);
        }
        [Test]
        [Order(2)]
        public void UpdateUser()
        {
            var request = new RestRequest("users/2", Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { name = "Updated kumar vikash", email = "mishra@12334" });
            var response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            var user = JsonConvert.DeserializeObject<UserData>(response.Content);
            Assert.NotNull(user);
        }
        [Test]
        [Order(3)]
        public void DeleteUser()
        {
            var request = new RestRequest("users/2", Method.Delete);
            var response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }
        [Test]
        [Order(4)]
        public void GetNonExistingUser()
        {
            var request = new RestRequest("users/999", Method.Get);
            var response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }
        [Test]
        [Order(5)]
        public void GetAllUser()
        {
            var request = new RestRequest("users", Method.Get);
            var response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            //var userdata = JsonConvert.DeserializeObject<UserDataResponse>(response.Content);
            // UserData? user = userdata?.Data;
            List<UserData> users = JsonConvert.DeserializeObject<List<UserData>>(response.Content);

            Assert.NotNull(users);
            Console.WriteLine("get :" + response.Content);
        }
    }
}
