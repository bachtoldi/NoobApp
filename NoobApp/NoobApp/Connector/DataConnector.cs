﻿using NoobApp.Entity;
using System.Data.Entity;

namespace NoobApp.Connector {

    class DataConnector : DbContext {

        public DbSet<Attendance> Attendaces { get; set; }
        public DbSet<AttendanceType> AttendaceTypes { get; set; }
        public DbSet<DisplayItem>  DisplayItems { get; set; }
        //public DbSet<Enums>  Enums{ get; set; }
        public DbSet<Entity.Event> Events{ get; set; }
        public DbSet<EventInventory> EventInventories { get; set; }
        public DbSet<EventPrice> EventPrices { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
