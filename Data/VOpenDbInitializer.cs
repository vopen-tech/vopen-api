using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace vopen_api.Data
{
    public static class VOpenDbInitializer
    {
        public static void Seed(DbContextOptions<VOpenDbContext> options)
        {
            using (var context = new VOpenDbContext(options))
            {
                context.Database.EnsureCreated();

                // Create vOpen event
                // var vopenEvent = new Event()
                // {
                //     Id = "vopen",
                //     Details = new EventDetail[]
                //     {
                //         new EventDetail { Language = "es-AR", Name = "vOpen", Description = "El ciclo de eventos de tecnología más importante en Latinoamérica" },
                //         new EventDetail { Language = "en-US", Name = "vOpen", Description = "The most important technology-related cycle of events in Latin America" }
                //     },
                // };

                // context.Events.Add(vopenEvent);

                // // Create users
                // var user1 = new User
                // {
                //     Details = new UserDetail[]
                //     {
                //         new UserDetail { Name = "Mariano Vazquez", Country = }
                //     }
                // }


                // // Create locations
                // var argLocation = new Location
                // {
                //     Details = new LocationDetail[]
                //     {
                //         new LocationDetail { Language = "es-AR", Name = "Auditorio de la Casa del GCBA", FullAddress = "Uspallata 3160, C1437JCL CABA", Country = "Argentina" },
                //         new LocationDetail { Language = "en-US", Name = "Auditorio de la Casa del GCBA", FullAddress = "Uspallata 3160, C1437JCL CABA", Country = "Argentina" }
                //     }
                // };

                // context.Locations.Add(argLocation);

                // TODO: create sponsors

                // Create AR Edition

                // Create UY Edition

                // Create CHI Edition

                // Create CO Edition

                // Create PE Edition

                context.SaveChanges();
            }
        }

        public static void Cleanup(DbContextOptions<VOpenDbContext> options)
        {
            using (var context = new VOpenDbContext(options))
            {
                context.Database.EnsureCreated();

                context.Events.RemoveRange(context.Events);
                context.Locations.RemoveRange(context.Locations);
                context.Sponsors.RemoveRange(context.Sponsors);
                context.Users.RemoveRange(context.Users);

                context.SaveChanges();
            }
        }
    }
}
