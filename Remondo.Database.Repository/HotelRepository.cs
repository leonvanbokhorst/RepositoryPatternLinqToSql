using System.Data.Linq;
using System.Linq;

namespace Remondo.Database.Repositories
{
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        public HotelRepository(DataContext dataContext) 
            : base(dataContext)
        {
        }

        public IQueryable<Hotel> FindHotelsByCity(City city)
        {
            return DataTable.Where(h => h.City.Equals(city));
        }
    }
}