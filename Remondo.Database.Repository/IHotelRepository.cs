using System.Linq;

namespace Remondo.Database.Repositories
{
    public interface IHotelRepository 
    {
        IQueryable<Hotel> FindHotelsByCity(City city);
    }
}