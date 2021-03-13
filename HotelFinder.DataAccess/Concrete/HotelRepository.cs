using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelFinders.DataAccess;
using HotelFinders.DataAccess.Abstract;
using HotelFinders.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelFinders.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
       
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            using (var hotelDb = new HotelDbContext())
            {
                hotelDb.Hotels.Add(hotel);
                await hotelDb.SaveChangesAsync();
                return  hotel;
            }
        }

        public async Task DeleteHotel(int id)
        {
            using (var hotelDb = new HotelDbContext())
            {
                var deleteHotel =await GetHotelById(id);
                hotelDb.Hotels.Remove(deleteHotel);
                await hotelDb.SaveChangesAsync();
            }
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            using (var hotelDb = new HotelDbContext())
            {
                return await hotelDb.Hotels.FindAsync(id);
            }
        }

        public async Task<Hotel> GetHotelByIdAndName(int id, string name)
        {
            using (var hotelDb = new HotelDbContext())
            {
                return await hotelDb.Hotels.FirstOrDefaultAsync(i=>i.Id==id&&i.Name==name);
            }
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            using (var hotelDb = new HotelDbContext())
            {
                return await hotelDb.Hotels.FirstOrDefaultAsync(i => i.Name == name);
            }
        }

        public async  Task<List<Hotel>> GetHotels()
        {
            using (var hotelDb = new HotelDbContext())
            {
                return await hotelDb.Hotels.ToListAsync();
            }
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            using (var hotelDb = new HotelDbContext())
            {
                hotelDb.Hotels.Update(hotel);
                await hotelDb.SaveChangesAsync();
                return hotel;
            }
        }
    }
}
