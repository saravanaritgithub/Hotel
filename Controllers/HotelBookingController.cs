using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly IHotelBookingServices _IHotelBookingServices;
        private readonly ICustomerDetailServices Customers;
        private readonly IRoomDetailServices Rooms;
        public HotelBookingController(IHotelBookingServices iHotelBookingServices)
        {
            _IHotelBookingServices = iHotelBookingServices;
        }
        [HttpGet("GetHotelBooking")]
        public async Task<IEnumerable<HotelBookings>> GetHotelBooking()
        {
            var address = await _IHotelBookingServices.GetHotelBooking();
            return address;
        }

        [HttpGet("GetHotelBookingById")]
        public async Task<HotelBookings> GetHotelBookingById(int id)
        {
            var address = await _IHotelBookingServices.GetHotelBookingById(id);
            return address;
        }
        [HttpPost("AddHotelBooking")]
        public async Task<HotelBookings> AddHotelBooking(HotelBookings hotelBookings)
        {
            await _IHotelBookingServices.AddHotelBooking(hotelBookings);
            return hotelBookings;
            
        }
        [HttpPut("UpdateHotelBooking/{id}")]
        public async Task<HotelBookings> UpdateHotelBooking(HotelBookings hotelBookings)
        {
            var update = await _IHotelBookingServices.UpdateHotelBooking(hotelBookings);
            return update;
        }
        [HttpDelete("DeleteHotelBooking/{id}")]
        public async Task<IActionResult> DeleteHotelBooking(int id)
        {
            await _IHotelBookingServices.DeleteHotelBooking(id);
            return NoContent();
        }
    }
}
