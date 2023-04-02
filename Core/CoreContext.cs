using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;

namespace Core
{
    public class CoreContext : DbContext
    {
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Street> Streets { get; set; } = null!;
        public DbSet<House> Houses { get; set; } = null!;
        public DbSet<Apartment> Apartments { get; set; } = null!;

        public CoreContext(DbContextOptions<CoreContext> options)
        : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
            new City[]
            {
                new City {Id=1, Name="Москва"},
                new City{Id=2, Name="Владимир"},
                new City {Id=3, Name="Ярославль"}
            });

            modelBuilder.Entity<Street>().HasData(
            new Street[]
            {
                new Street {Id=1, Name="Андреевская", CityId=1},
                new Street{Id=2, Name="Боисовская", CityId=1},
                new Street {Id=3, Name="Владимирская", CityId=1},
                new Street {Id=4, Name="Григорьевская", CityId=1},
                new Street {Id=5, Name="Ангарская", CityId=2},
                new Street{Id=6, Name="Белая", CityId=2},
                new Street {Id=7, Name="Волжская", CityId=2},
                new Street {Id=8, Name="Агрономов", CityId=3},
                new Street{Id=9, Name="Биохимиков", CityId=3},
            });

            modelBuilder.Entity<House>().HasData(
            new House[]
            {
                new House {Id=1, Number="1", StreetId=1},
                new House {Id=2, Number="2", StreetId=1},
                new House {Id=3, Number="3", StreetId=1},
                new House {Id=4, Number="4а", StreetId=1},
                new House {Id=5, Number="1", StreetId=2},
                new House {Id=6, Number="2а", StreetId=2},
                new House {Id=7, Number="2б", StreetId=2},
                new House {Id=8, Number="3", StreetId=2},
                new House {Id=9, Number="4", StreetId=2},
                new House {Id=10, Number="5", StreetId=2},
                new House {Id=11, Number="1", StreetId=3},
                new House {Id=12, Number="2", StreetId=3},
                new House {Id=13, Number="3", StreetId=3},
                new House {Id=14, Number="4", StreetId=3},
                new House {Id=15, Number="1", StreetId=4},
                new House {Id=16, Number="2", StreetId=4},
                new House {Id=17, Number="3", StreetId=4},
                new House {Id=18, Number="4", StreetId=4},
                new House {Id=19, Number="5а", StreetId=4},
                new House {Id=20, Number="1", StreetId=5},
                new House {Id=21, Number="2", StreetId=5},
                new House {Id=22, Number="3", StreetId=5},
                new House {Id=23, Number="3а", StreetId=5},
                new House {Id=24, Number="4", StreetId=5},
                new House {Id=25, Number="1", StreetId=6},
                new House {Id=26, Number="2", StreetId=6},
                new House {Id=27, Number="3", StreetId=6},
                new House {Id=28, Number="4", StreetId=6},
                new House {Id=29, Number="5", StreetId=6},
                new House {Id=30, Number="1", StreetId=7},
                new House {Id=31, Number="2", StreetId=7},
                new House {Id=32, Number="1", StreetId=8},
                new House {Id=33, Number="2", StreetId=8},
                new House {Id=34, Number="3", StreetId=8},
                new House {Id=35, Number="3 стр. 1", StreetId=8},
                new House {Id=36, Number="1", StreetId=9},
                new House {Id=37, Number="2-1", StreetId=9},
                new House {Id=38, Number="3", StreetId=9},
                new House {Id=39, Number="3", StreetId=9}
            });

            modelBuilder.Entity<Apartment>().HasData(
            new Apartment[]
            {
                new Apartment {Id=1, Number="1", HouseId=1},
                new Apartment {Id=2, Number="2", HouseId=1},
                new Apartment {Id=3, Number="3", HouseId=1},
                new Apartment {Id=4, Number="1", HouseId=2},
                new Apartment {Id=5, Number="2", HouseId=2},
                new Apartment {Id=6, Number="1", HouseId=3},
                new Apartment {Id=7, Number="2", HouseId=3},
                new Apartment {Id=8, Number="3", HouseId=3},
                new Apartment {Id=9, Number="4", HouseId=3},
                new Apartment {Id=10, Number="1", HouseId=4},
                new Apartment {Id=11, Number="2", HouseId=4},
                new Apartment {Id=12, Number="3", HouseId=4},
                new Apartment {Id=13, Number="1", HouseId=5},
                new Apartment {Id=14, Number="1", HouseId=6},
                new Apartment {Id=15, Number="2", HouseId=6},
                new Apartment {Id=16, Number="3", HouseId=6},
                new Apartment {Id=17, Number="4", HouseId=6},
                new Apartment {Id=18, Number="5", HouseId=6},
                new Apartment {Id=19, Number="1", HouseId=7},
                new Apartment {Id=20, Number="2", HouseId=7},
                new Apartment {Id=21, Number="1", HouseId=8},
                new Apartment {Id=22, Number="2", HouseId=8},
                new Apartment {Id=23, Number="3", HouseId=8},
                new Apartment {Id=24, Number="4", HouseId=8},
                new Apartment {Id=25, Number="1", HouseId=9},
                new Apartment {Id=26, Number="1", HouseId=10},
                new Apartment {Id=27, Number="1", HouseId=11},
                new Apartment {Id=28, Number="1", HouseId=12},
                new Apartment {Id=29, Number="2", HouseId=12},
                new Apartment {Id=30, Number="3", HouseId=12},
                new Apartment {Id=31, Number="1", HouseId=13},
                new Apartment {Id=32, Number="2", HouseId=13},
                new Apartment {Id=33, Number="3", HouseId=13},
                new Apartment {Id=34, Number="4", HouseId=13},
                new Apartment {Id=35, Number="1", HouseId=14},
                new Apartment {Id=36, Number="2", HouseId=14},
                new Apartment {Id=37, Number="1", HouseId=15},
                new Apartment {Id=38, Number="1", HouseId=16},
                new Apartment {Id=39, Number="2", HouseId=16},
                new Apartment {Id=40, Number="1", HouseId=17},
                new Apartment {Id=41, Number="1", HouseId=18},
                new Apartment {Id=42, Number="2", HouseId=18},
                new Apartment {Id=43, Number="3", HouseId=18},
                new Apartment {Id=44, Number="1", HouseId=19},
                new Apartment {Id=45, Number="2", HouseId=19},
                new Apartment {Id=46, Number="3", HouseId=19},
                new Apartment {Id=47, Number="4", HouseId=19},
                new Apartment {Id=48, Number="5", HouseId=19},
                new Apartment {Id=49, Number="6", HouseId=19},
                new Apartment {Id=50, Number="1", HouseId=20},
                new Apartment {Id=51, Number="1", HouseId=21},
                new Apartment {Id=52, Number="1", HouseId=22},
                new Apartment {Id=53, Number="1", HouseId=23},
                new Apartment {Id=54, Number="2", HouseId=23},
                new Apartment {Id=55, Number="1", HouseId=24},
                new Apartment {Id=56, Number="2", HouseId=24},
                new Apartment {Id=57, Number="3", HouseId=24},
                new Apartment {Id=58, Number="1", HouseId=25},
                new Apartment {Id=59, Number="2", HouseId=25},
                new Apartment {Id=60, Number="3", HouseId=25},
                new Apartment {Id=61, Number="4", HouseId=25},
                new Apartment {Id=62, Number="1", HouseId=26},
                new Apartment {Id=63, Number="1", HouseId=27},
                new Apartment {Id=64, Number="1", HouseId=29},
                new Apartment {Id=65, Number="1", HouseId=30},
                new Apartment {Id=66, Number="2", HouseId=30},
                new Apartment {Id=67, Number="1", HouseId=31},
                new Apartment {Id=68, Number="2", HouseId=31},
                new Apartment {Id=69, Number="3", HouseId=31},
                new Apartment {Id=70, Number="1", HouseId=32},
                new Apartment {Id=71, Number="2", HouseId=32},
                new Apartment {Id=72, Number="3", HouseId=32},
                new Apartment {Id=73, Number="4", HouseId=32},
                new Apartment {Id=74, Number="1", HouseId=33},
                new Apartment {Id=75, Number="2", HouseId=33},
                new Apartment {Id=76, Number="1", HouseId=34},
                new Apartment {Id=77, Number="2", HouseId=34},
                new Apartment {Id=78, Number="3", HouseId=34},
                new Apartment {Id=79, Number="1", HouseId=35},
                new Apartment {Id=80, Number="1", HouseId=36},
                new Apartment {Id=81, Number="2", HouseId=36},
                new Apartment {Id=82, Number="3", HouseId=36},
                new Apartment {Id=83, Number="1", HouseId=37},
                new Apartment {Id=84, Number="2", HouseId=37},
                new Apartment {Id=85, Number="1", HouseId=38},
                new Apartment {Id=86, Number="2", HouseId=38},
                new Apartment {Id=87, Number="1", HouseId=39},
                new Apartment {Id=88, Number="2", HouseId=39},
                new Apartment {Id=89, Number="3", HouseId=39},
                new Apartment {Id=90, Number="4", HouseId=39},
                new Apartment {Id=91, Number="5", HouseId=39},
                new Apartment {Id=92, Number="6", HouseId=39}
                });
        }
    }
}
