using Appointments.Application.Services;
using Appointments.Domain.Entities;
using Appointments.Domain.Interfaces.Repositories;
using Appointments.Domain.Interfaces.Services;
using Moq;

namespace AppointmentsAPI.Tests
{
    public class AppointmentsServicesTests
    {
        private readonly Mock<IAppointmentRepository> _mockRepository;
        private readonly AppointmentService _appointmentService;

        public AppointmentsServicesTests()
        {
            _mockRepository = new Mock<IAppointmentRepository>();
            _appointmentService = new AppointmentService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllAppointments_ReturnsAppointments()
        {
            // Arrange
            var appointments = new List<Appointment>
        {
            new Appointment { Id = 1, PatientId = 1, DoctorId = 1, ServiceId = 1, DateTime = DateTime.Now, IsApproved = true },
            new Appointment { Id = 2, PatientId = 2, DoctorId = 2, ServiceId = 2, DateTime = DateTime.Now.AddDays(1), IsApproved = false },
            new Appointment { Id = 3, PatientId = 3, DoctorId = 3, ServiceId = 3, DateTime = DateTime.Now.AddDays(2), IsApproved = true }
        };
            _mockRepository.Setup(x => x.GetAllAppointments()).ReturnsAsync(appointments);

            // Act
            var result = await _appointmentService.GetAllAppointments();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(appointments.Count, result.Count());
            Assert.Equal(appointments.First().Id, result.First().Id);
        }

        [Fact]
        public async Task GetAppointment_ValidId_ReturnsAppointment()
        {
            // Arrange
            var appointment = new Appointment { Id = 1, PatientId = 1, DoctorId = 1, ServiceId = 1, DateTime = DateTime.Now, IsApproved = true };
            _mockRepository.Setup(x => x.GetAppointment(appointment.Id)).ReturnsAsync(appointment);

            // Act
            var result = await _appointmentService.GetAppointment(appointment.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(appointment.Id, result.Id);
        }

        [Fact]
        public async Task GetAppointment_InvalidId_ReturnsNull()
        {
            // Arrange
            var appointmentId = 1;
            _mockRepository.Setup(x => x.GetAppointment(appointmentId)).ReturnsAsync((Appointment)null);

            // Act
            var result = await _appointmentService.GetAppointment(appointmentId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateAppointment_ValidAppointment_ReturnsTrue()
        {
            // Arrange
            var appointment = new Appointment { Id = 1, PatientId = 1, DoctorId = 1, ServiceId = 1, DateTime = DateTime.Now, IsApproved = true };
            _mockRepository.Setup(x => x.CreateAppointment(appointment)).ReturnsAsync(true);

            // Act
            var result = await _appointmentService.CreateAppointment(appointment);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CreateAppointment_NullAppointment_ReturnsFalse()
        {
            // Arrange
            Appointment appointment = null;

            // Act
            var result = await _appointmentService.CreateAppointment(appointment);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task GetAppointment_WithInvalidId_ReturnsNull()
        {
            // Arrange
            var mockRepository = new Mock<IAppointmentRepository>();
            mockRepository.Setup(repo => repo.GetAppointment(It.IsAny<int>())).ReturnsAsync((Appointment)null);
            var service = new AppointmentService(mockRepository.Object);

            // Act
            var result = await service.GetAppointment(1234);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateAppointment_WithValidAppointment_ReturnsTrue()
        {
            // Arrange
            var appointment = new Appointment { Id = 1, PatientId = 1, DoctorId = 1, ServiceId = 1, DateTime = null, IsApproved = false };
            var mockRepository = new Mock<IAppointmentRepository>();
            mockRepository.Setup(repo => repo.CreateAppointment(appointment)).ReturnsAsync(true);
            var service = new AppointmentService(mockRepository.Object);

            // Act
            var result = await service.CreateAppointment(appointment);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CreateAppointment_WithNullAppointment_ReturnsFalse()
        {
            // Arrange
            var mockRepository = new Mock<IAppointmentRepository>();
            var service = new AppointmentService(mockRepository.Object);

            // Act
            var result = await service.CreateAppointment(null);

            // Assert
            Assert.False(result);
        }
    }
}
