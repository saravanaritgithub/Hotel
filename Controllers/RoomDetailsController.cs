using ConsoleToDB.Data;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomDetailsController : ControllerBase
    {
        private readonly IRoomDetailServices _IRoomDetailServices;
        private readonly ICustomerDetailServices Customers;
        private readonly IHotelBookingServices Hotels;
        public RoomDetailsController(IRoomDetailServices iRoomDetailServices)
        {
            _IRoomDetailServices = iRoomDetailServices;
        }
        [HttpGet("GetRoomDetail")]
        public async Task<IEnumerable<RoomDetail>> GetRoomDetail()
        {
            var address = await _IRoomDetailServices.GetRoomDetail();
            return address;
        }
        [HttpGet("GetRoomDetailById")]
        public async Task<RoomDetail> GetRoomDetailById(int id)
        {
            var address = await _IRoomDetailServices.GetRoomDetailById(id);
            return address;
        }
        [HttpPost("AddRoomDetail")]
        public async Task<RoomDetail> AddRoomDetail(RoomDetail roomDetail)
        {
            await _IRoomDetailServices.AddRoomDetail(roomDetail);
            return roomDetail;
        }
        [HttpPut("UpdateRoomDetail/{id}")]
        public async Task<RoomDetail> UpdateRoomDetail(RoomDetail roomDetail)
        {
            var update = await _IRoomDetailServices.UpdateRoomDetail(roomDetail);
            return update;
        }
        [HttpDelete("DeleteRoomDetail/{id}")]
        public async Task<IActionResult> DeleteRoomDetail(int id)
        {
            await _IRoomDetailServices.DeleteRoomDetail(id);
            return NoContent();
        }
    }
}
