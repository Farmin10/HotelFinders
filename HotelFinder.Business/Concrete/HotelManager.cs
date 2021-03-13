﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelFinders.Business.Abstract;
using HotelFinders.DataAccess.Abstract;
using HotelFinders.DataAccess.Concrete;
using HotelFinders.Entities;

namespace HotelFinders.Business.Concrete
{
    public class HotelManager : IHotelService
    {
        private IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            return await _hotelRepository.CreateHotel(hotel);
        }

        public async Task DeleteHotel(int id)
        {
            await _hotelRepository.DeleteHotel(id);
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            return await _hotelRepository.GetHotels();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            return await _hotelRepository.GetHotelById(id);
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            return await _hotelRepository.GetHotelByName(name);
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            return await _hotelRepository.UpdateHotel(hotel);
        }
    }
}
