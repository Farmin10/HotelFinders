using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelFinders.Business.Abstract;
using HotelFinders.Business.Concrete;
using HotelFinders.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinders.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var hotels = await _hotelService.GetAllHotels();
            return Ok(hotels);
        }
        /// <summary>
        /// Get Hotel By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{action}/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var hotel = await _hotelService.GetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{action}/{name}")]
        public async Task<IActionResult> GetHotelByName(string name)
        {
            var hotel =await _hotelService.GetHotelByName(name);
            if (hotel!=null)
            {
                return Ok(hotel);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("{action}/{id}/{name}")]
        public async Task<IActionResult> GetHotelByName(int id,string name)
        {
            return Ok();
        }
        /// <summary>
        /// Delete Hotel By Id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _hotelService.GetHotelById(id) != null)
            {
                await _hotelService.DeleteHotel(id);
                return Ok();
            }
            return NotFound();
        }
        /// <summary>
        /// Create Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Hotel hotel)
        {
            var createHotel = await _hotelService.UpdateHotel(hotel);
            return CreatedAtAction("Get", new { id = createHotel.Id }, createHotel);
        }
        /// <summary>
        /// Update Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Hotel hotel)
        {
            if (await _hotelService.GetHotelById(hotel.Id)!=null)
            {
                return  Ok(_hotelService.UpdateHotel(hotel));
            }
            return NotFound();
        }
    }
}
