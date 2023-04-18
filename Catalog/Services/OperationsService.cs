using Catalog.Models;
using Core;

namespace Catalog.Services
{
    public class OperationsService: IOperationsService
    {
        CoreContext db;
        public OperationsService(CoreContext context)
        {
            db = context;
        }


        public IQueryable<CityModel>? GetCities()
        {
            try
            {
                IQueryable<CityModel> cities = from u in (from house in db.Houses
                                                          join street in db.Streets on house.StreetId equals street.Id
                                                          join city in db.Cities on street.CityId equals city.Id
                                                          select new
                                                          {
                                                              CityName = city.Name,
                                                              houseId = house.Id
                                                          })
                                               group u by u.CityName into g
                                               select new CityModel
                                               {
                                                   CityName = g.Key,
                                                   Count = g.Count()
                                               };
                return cities;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<StreetModel>? GetStreetsByCityId(int cityId)
        {
            try
            {
                IQueryable<StreetModel> streets = from street in db.Streets
                                              join city in db.Cities on street.CityId equals city.Id
                                              where (city.Id == cityId)
                                              select new StreetModel
                                              {
                                                  streetName = street.Name,
                                                  CountHouses = street.Houses.Count()
                                              };
                return streets;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<HouseModel>? GetHousesByCityId(int cityId)
        {
            try
            {
                IQueryable<HouseModel> houses = from house in db.Houses
                                            join street in db.Streets on house.StreetId equals street.Id
                                            join city in db.Cities on street.CityId equals city.Id
                                            where (city.Id == cityId)
                                            select new HouseModel
                                            {
                                                Address = city.Name + "," + street.Name + "," + house.Number,
                                                CountOfApartmens = house.Apartments.Count()
                                            };
            return houses;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<HouseModel>? GetHousesByStreetId(int streetId)
        {
            try
            {
                IQueryable<HouseModel> houses = from house in db.Houses
                                                join street in db.Streets on house.StreetId equals street.Id
                                                join city in db.Cities on street.CityId equals city.Id
                                                where (street.Id == streetId)
                                                select new HouseModel
                                                {
                                                    Address = city.Name + "," + street.Name + "," + house.Number,
                                                    CountOfApartmens = house.Apartments.Count()
                                                };
                return houses;
            }
            catch
            {
                return null;
            }

        }
    }
}
