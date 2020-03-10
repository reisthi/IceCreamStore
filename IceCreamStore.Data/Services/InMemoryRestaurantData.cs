using IceCreamStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IceCreamStore.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Acai Du Du", Location = RestarurantLocation.LittleRock},
                new Restaurant { Id = 2, Name = "OakBerry", Location = RestarurantLocation.Houston },
                new Restaurant { Id = 3, Name = "Carreta Furacao", Location = RestarurantLocation.Austin}
            };
        }



        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
            if (existing != null)
            {
                existing.Name = restaurant.Name;
                existing.Location = restaurant.Location;

            }
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);

        }

        public void Delete(int id)
        {
            var restaurant = Get(id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

        }
    }
}
