namespace TimeApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TimeApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TimeApp.Models.TimeAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TimeApp.Models.TimeAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            DateTime dateNow = DateTime.Now;

            context.TrainConnections.AddOrUpdate(x => x.Id,
            new Models.TrainConnection() { Id = 1, Name = "IC 6306 (KOSSAK)", Start = "Wroclaw Glowny", Destination = "Krakow Glowny", ConnectionType = Models.TrainConnectionType.Pendolino });

            context.Stations.AddOrUpdate(x => x.Id,
            new Station() { Id = 1, Name = "Wroclaw Glowny", DepartureTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 18, 20, 0), TrainConnectionId = 1 },
            new Station() { Id = 1, Name = "Olawa", ArrivalTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 18, 36, 0), DepartureTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 18, 37, 0), TrainConnectionId = 1 },
            new Station() { Id = 1, Name = "Brzeg", ArrivalTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 18, 46, 0), DepartureTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 18, 47, 0), TrainConnectionId = 1 },
            new Station() { Id = 1, Name = "Opole Glowne", ArrivalTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 19, 08, 0), DepartureTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 19, 10, 0), TrainConnectionId = 1 },
            new Station() { Id = 1, Name = "Lubliniec", ArrivalTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 19, 41, 0), DepartureTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 19, 42, 0), TrainConnectionId = 1 },
            new Station() { Id = 1, Name = "Czestochowa Stradom", ArrivalTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 20, 05, 0), DepartureTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 20, 06, 0), TrainConnectionId = 1 },
            new Station() { Id = 1, Name = "Koniecpol", ArrivalTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 20, 50, 0), DepartureTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 20, 52, 0), TrainConnectionId = 1 },
            new Station() { Id = 1, Name = "Krakow Glowny", ArrivalTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 21, 35, 0), TrainConnectionId = 1 });

            context.SaveChanges();

        }
    }
}
