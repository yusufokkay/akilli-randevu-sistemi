using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AkilliRandevuAPI.Interfaces;
using AkilliRandevuAPI.Models;

namespace AkilliRandevuAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Business")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAllAppointments()
        {
            var appointments = await _appointmentRepository.GetAllAsync();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(string id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            // Kullanıcının kendi randevusunu veya işletmenin kendi randevusunu görüntülemesine izin ver
            var userId = User.FindFirst("sub")?.Value;
            if (appointment.CustomerId != userId && 
                appointment.BusinessId != userId && 
                !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            return Ok(appointment);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetCustomerAppointments(string customerId)
        {
            // Kullanıcının sadece kendi randevularını görüntülemesine izin ver
            var userId = User.FindFirst("sub")?.Value;
            if (customerId != userId && !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            var appointments = await _appointmentRepository.GetByCustomerIdAsync(customerId);
            return Ok(appointments);
        }

        [HttpGet("business/{businessId}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetBusinessAppointments(string businessId)
        {
            // İşletmenin sadece kendi randevularını görüntülemesine izin ver
            var userId = User.FindFirst("sub")?.Value;
            if (businessId != userId && !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            var appointments = await _appointmentRepository.GetByBusinessIdAsync(businessId);
            return Ok(appointments);
        }

        [HttpGet("daterange")]
        [Authorize(Roles = "Admin,Business")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentsByDateRange(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            var appointments = await _appointmentRepository.GetByDateRangeAsync(startDate, endDate);
            return Ok(appointments);
        }

        [HttpGet("status/{status}")]
        [Authorize(Roles = "Admin,Business")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentsByStatus(string status)
        {
            var appointments = await _appointmentRepository.GetByStatusAsync(status);
            return Ok(appointments);
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> CreateAppointment(Appointment appointment)
        {
            var userId = User.FindFirst("sub")?.Value;
            
            // Müşteri rolündeki kullanıcılar sadece kendi adlarına randevu oluşturabilir
            if (User.IsInRole("Customer") && appointment.CustomerId != userId)
            {
                return Forbid();
            }

            // İşletme rolündeki kullanıcılar sadece kendi işletmeleri için randevu oluşturabilir
            if (User.IsInRole("Business") && appointment.BusinessId != userId)
            {
                return Forbid();
            }

            appointment.CreatedAt = DateTime.UtcNow;
            appointment.UpdatedAt = DateTime.UtcNow;
            await _appointmentRepository.CreateAsync(appointment);
            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(string id, Appointment appointment)
        {
            var existingAppointment = await _appointmentRepository.GetByIdAsync(id);
            if (existingAppointment == null)
            {
                return NotFound();
            }

            var userId = User.FindFirst("sub")?.Value;
            
            // Sadece randevunun sahibi olan müşteri, işletme veya admin güncelleyebilir
            if (existingAppointment.CustomerId != userId && 
                existingAppointment.BusinessId != userId && 
                !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            appointment.Id = id;
            appointment.CreatedAt = existingAppointment.CreatedAt;
            appointment.UpdatedAt = DateTime.UtcNow;
            await _appointmentRepository.UpdateAsync(id, appointment);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(string id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            var userId = User.FindFirst("sub")?.Value;
            
            // Sadece randevunun sahibi olan müşteri, işletme veya admin silebilir
            if (appointment.CustomerId != userId && 
                appointment.BusinessId != userId && 
                !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            await _appointmentRepository.DeleteAsync(id);
            return NoContent();
        }
    }
} 