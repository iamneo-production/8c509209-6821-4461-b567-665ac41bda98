using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using dotnetapp.Models;
using dotnetapp.Data;
using System.Text;

namespace dotnetapp.Test
{
    [TestFixture]
    public class ServiceCenterControllerTests
    {
        private HttpClient _client;
        [SetUp]
        public void Setup()
        {
            _client = new HttpClient();
            _client.BaseAddress = new System.Uri("http://localhost:8080/");
        }

        [Test]
        public async Task GetServiceCenters_ReturnsSuccess()
        {
          HttpResponseMessage response = await _client.GetAsync("api/ServiceCenter");
            // Assert that the response status code is 200 OK.
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            // Assert that the response content is not empty.
            string responseBody = await response.Content.ReadAsStringAsync();
            Assert.IsNotEmpty(responseBody);
        }
        [Test]
        public async Task GetAppointments_ReturnsSuccess()
        {
            HttpResponseMessage response = await _client.GetAsync("api/Appointment");
            // Assert that the response status code is 200 OK.
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            // Assert that the response content is not empty.
            string responseBody = await response.Content.ReadAsStringAsync();
            Assert.IsNotEmpty(responseBody);
        }
        
        [Test]
        public async Task GetAllUsers_ReturnsSuccess()
        {
          HttpResponseMessage response = await _client.GetAsync("api/User");
            // Assert that the response status code is 200 OK.
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            // Assert that the response content is not empty.
            string responseBody = await response.Content.ReadAsStringAsync();
            Assert.IsNotEmpty(responseBody);
        }
    }
}
