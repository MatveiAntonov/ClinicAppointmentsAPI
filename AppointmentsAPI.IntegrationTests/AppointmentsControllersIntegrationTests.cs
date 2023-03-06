using Appointments.Domain.Entities;
using Appointments.WebApi.Models.DTOs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Engines;
using System.Net;

namespace AppointmentsAPI.IntegrationTests
{
    public class AppointmentsControllersIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;

        public AppointmentsControllersIntegrationTests(TestingWebAppFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllAppointments_WhenCalled_ReturnsIEnumerableOfAppointments()
        {
            var response = await _client.GetAsync("/Appointment");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("\"id\":1", responseString);
            Assert.Contains("\"id\":2", responseString);
        }

        [Fact]
        public async Task GetAllAppointments_ReturnsOk()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/appointment");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var responseString = await response.Content.ReadAsStringAsync();
            var appointments = JsonConvert.DeserializeObject<IEnumerable<AppointmentDto>>(responseString);
            Assert.NotEmpty(appointments);
        }

        [Fact]
        public async Task GetAppointment_ReturnsOk()
        {
            // Arrange
            var id = 1;
            var request = new HttpRequestMessage(HttpMethod.Get, $"/appointment/{id}");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var responseString = await response.Content.ReadAsStringAsync();
            var appointment = JsonConvert.DeserializeObject<AppointmentDto>(responseString);
            Assert.NotNull(appointment);
            Assert.Equal(id, appointment.Id);
        }

        [Fact]
        public async Task GetAppointment_ReturnsNoContent()
        {
            // Arrange
            var id = 100;
            var request = new HttpRequestMessage(HttpMethod.Get, $"/appointment/{id}");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode); // Status Code 204
        }

        [Fact]
        public async Task CreateAppointment_ReturnsBadRequest()
        {
            // Arrange
            var content = new MultipartFormDataContent();
            var request = new HttpRequestMessage(HttpMethod.Post, "/appointment");
            request.Content = content;

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode); // Status Code 400
        }
    }
}