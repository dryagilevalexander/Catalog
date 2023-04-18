using Catalog.Models;

namespace Catalog.Services
{
    public interface IOperationsService
    {
        public IQueryable<CityModel>? GetCities();
        public IQueryable<StreetModel>? GetStreetsByCityId(int cityId);

        public IQueryable<HouseModel>? GetHousesByCityId(int cityId);

        public IQueryable<HouseModel>? GetHousesByStreetId(int streetId);

    }
}
