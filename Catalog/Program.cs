using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CoreContext>(options => options.UseNpgsql(connection));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/cities", (CoreContext db) =>
{
    var cities = from u in (from house in db.Houses
                            join street in db.Streets on house.StreetId equals street.Id
                            join city in db.Cities on street.CityId equals city.Id
                            select new
                            {
                                CityName = city.Name,
                                houseId = house.Id
                            })
                 group u by u.CityName into g
                 select new
                 {
                     CityName = g.Key,
                     Count = g.Count()
                 };


    return Results.Json(cities);
});


app.MapGet("/cities/{city_id}/streets", (CoreContext db, string city_id) =>
{
    int n;
    bool isNumeric = int.TryParse(city_id, out n);

    if(isNumeric == true)
    {
        var streets = from street in db.Streets
                      join city in db.Cities on street.CityId equals city.Id
                      where (city.Id == n)
                      select new
                      {
                          streetName = street.Name,
                          CountHouses = street.Houses.Count()
                      };

        return Results.Json(streets);
    }
    else
    {
        return Results.Json(null);
    }



});

app.MapGet("/cities/{city_id}/houses", (CoreContext db, string city_id) =>
{
int n;
bool isNumeric = int.TryParse(city_id, out n);

    if (isNumeric == true)
    {
        var houses = from house in db.Houses
                     join street in db.Streets on house.StreetId equals street.Id
                     join city in db.Cities on street.CityId equals city.Id
                     where (city.Id == n)
                     select new
                     {
                         Address = city.Name + "," + street.Name + "," + house.Number,
                         CountOfApartmens = house.Apartments.Count()
                     };
        return Results.Json(houses);
    }
    else
    {
        return Results.Json(null);
    }
});

app.MapGet("/streets/{street_id}/houses", (CoreContext db, string street_id) =>
{
int n;

bool isNumeric = int.TryParse(street_id, out n);

    if (isNumeric == true)
    {
        var houses =
                      from house in db.Houses
                      join street in db.Streets on house.StreetId equals street.Id
                      join city in db.Cities on street.CityId equals city.Id
                      where (street.Id == n)
                      select new
                      {
                          Address = city.Name + "," + street.Name + "," + house.Number,
                          CountOfApartmens = house.Apartments.Count()
                      };
        return Results.Json(houses);
    }
    else
    {
        return Results.Json(null);
    }
});

app.Run();
