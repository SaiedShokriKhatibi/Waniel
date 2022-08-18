using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Waniel.Domains;

namespace Waniel.Test
{
    [TestClass]
    public class AirportTest
    {
        private readonly HttpClient _httpClient;
        public AirportTest()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }
        [TestMethod]
        public async Task Route_ReturnTheAirport()
        {
            var response = await _httpClient.GetAsync("api/airports/AMS");
            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Airport>(resultString);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Name, "Amsterdam");
        }
        [TestMethod]
        public async Task Route_WrongIATACode()
        {
            var response = await _httpClient.GetAsync("api/airports/AMSS");
            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Airport>(resultString);
            
            Assert.IsNull(result);
        }
        [TestMethod]
        public async Task Route_DistanceBetweenTwoAirports()
        {
            var response = await _httpClient.GetAsync("api/airports/AMS/dist/IST");
            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<DistanceResult>(resultString);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Distance, 3617840573.87795);
        }
        [TestMethod]
        public async Task Route_DistanceBetweenTwoAirportsWithWrongCodes()
        {
            Exception expectedException = null;

            try
            {
                var response = await _httpClient.GetAsync("api/airports/AMSS/dist/IST");
                var resultString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<DistanceResult>(resultString);
            }
            catch (Exception exp)
            {
                expectedException = exp;
            }

            Assert.IsNotNull(expectedException);
            
        }
    }
}