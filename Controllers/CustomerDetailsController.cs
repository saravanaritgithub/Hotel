using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailsController : ControllerBase
    {
        private readonly ICustomerDetailServices _ICustomerDetailServices;
        private readonly IRoomDetailServices Rooms;
        private readonly IHotelBookingServices Hotels;
        public CustomerDetailsController(ICustomerDetailServices iCustomerDetailServices)
        {
            _ICustomerDetailServices = iCustomerDetailServices;
        }
        [HttpGet("GetCustomerDetail")]
        public async Task<IEnumerable<CustomerDetail>> GetCustomerDetail()
        {
            var address = await _ICustomerDetailServices.GetCustomerDetail();
            return address;
        }
        [HttpGet("GetCustomerDetailById")]
        public async Task<CustomerDetail> GetCustomerDetailById(int id)
        {
            var address = await _ICustomerDetailServices.GetCustomerDetailById(id);
            return address;
        }
        [HttpPost("AddCustomerDetail")]
        public async Task<CustomerDetail> AddCustomerDetail(CustomerDetail customerDetail)
        {
            await _ICustomerDetailServices.AddCustomerDetail(customerDetail);
            return customerDetail;
        }
        [HttpPut("UpdateCustomerDetail/{id}")]
        public async Task<CustomerDetail> UpdateCustomerDetail(CustomerDetail customerDetail)
        {
            var update = await _ICustomerDetailServices.UpdateCustomerDetail(customerDetail);
            return update;
        }
        [HttpDelete("DeleteCustomerDetail/{id}")]
        public async Task<IActionResult> DeleteCustomerDetail(int id)
        {
            await _ICustomerDetailServices.DeleteCustomerDetail(id);
            return NoContent();
        }
    }
}
