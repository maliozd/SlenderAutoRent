using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence.Seeder
{
    public static class DataSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>();
            var context = new AppDbContext(options);
            SeedCustomers(context);
            SeedLocations(context);
            //SeedRentals(context);
            //SeedCarInventories(context);
        }
        public static void SeedCustomers(AppDbContext context)
        {
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(new List<Customer>
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Address = "İstanbul",
                        Email = "ahmetgunduz@gmail.com",
                        Name = "Ahmet Gündüz",
                        PhoneNumber = "1234567890",
                        RegistrationDate = DateTime.Now
                    },
                    new() {
                        Id = Guid.NewGuid(),
                        Address = "Ankara",
                        Email = "ayselisik@gmail.com",
                        Name = "Aysel Işık",
                        PhoneNumber = "12325547890",
                        RegistrationDate = DateTime.Now
                    }
                });
            }
        }
        public static void SeedLocations(AppDbContext context)
        {
            if (!context.Locations.Any())
            {
                context.Locations.AddRange(new List<Location>()
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Address = "Sabiha Gökçen Airport",
                        City = "Istanbul"
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Address ="Atatürk Airport",
                        City = "Istanbul"
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Address = "Kizilay Square",
                        City = "Ankara"
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Address = "Konak",
                        City = "İzmir"
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Address = "Sakarya Bus Station",
                        City = "Sakarya"
                    }
                });
            }
        }
        //public static void SeedRentals(AppDbContext context)
        //{
        //    if (!context.Rentals.Any())
        //    {
        //        context.Rentals.AddRange(new List<Rental>
        //        {
        //            new()
        //            {
        //                CarId = context.Cars.FirstOrDefault(x => x.Id.GetType() == string).Id,
        //                 CustomerId = context.Customers.FirstOrDefault().Id,
        //                 PickUpDate = new DateTime(2021,4,14),
        //                 ReturnDate = new DateTime(2021,4,21)
        //            },
        //            new()
        //            {
        //                CarId = context.Cars.LastOrDefault().Id,
        //                CustomerId = context.Customers.LastOrDefault().Id,
        //                PickUpDate= new DateTime(2022,11,21),
        //                ReturnDate = new DateTime(2022,12,3)
        //            }

        //        });
        //    }
        //}
        //public static void SeedCarInventories(AppDbContext context)
        //{
        //    if (!context.CarInventories.Any())
        //    {
        //        context.CarInventories.AddRange(new List<CarInventory>()
        //        {
        //            new()
        //            {
        //                LocationId = context.Locations.FirstOrDefault().Id,
        //            },
        //            new()
        //            {
        //                LocationId = context.Locations.LastOrDefault().Id
        //            }
        //        });
        //    }
        //}

    }
}
