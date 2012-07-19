using System;
using System.Collections.Generic;
using System.Linq;
using Remondo.Database;
using Remondo.Database.Repositories;

namespace LinqToSqlRepositoryConsole
{
    internal class Program
    {
        private static void Main()
        {
            using (var dataContext = new HotelDataContext())
            {
                var cityRepository = new Repository<City>(dataContext);

                City city = cityRepository
                    .SearchFor(c => c.Name.StartsWith("Paris"))
                    .Single();

                var hotelRepository = new HotelRepository(dataContext);

                IEnumerable<Hotel> orderedHotels = hotelRepository
                    .FindHotelsByCity(city);

                Console.WriteLine("* Hotels in {0} *", city.Name);

                foreach (Hotel orderedHotel in orderedHotels)
                {
                    Console.WriteLine(orderedHotel.Name);
                }

                Console.ReadKey();
            }
        }
    }
}