﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseWork
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=Model1Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Order> OrderSet { get; set; }
        public virtual DbSet<User> UserSet { get; set; }
        public virtual DbSet<Customer> CustomerSet { get; set; }
        public virtual DbSet<Person> PersonSet { get; set; }
        public virtual DbSet<Stavka> StavkaSet { get; set; }
        public virtual DbSet<Meter> MeterSet { get; set; }
        public virtual DbSet<OrderEntry> OrderEntrySet { get; set; }
        public virtual DbSet<MeterType> MeterTypeSet { get; set; }
        public virtual DbSet<Status> StatusSet { get; set; }
        public virtual DbSet<City> CitySet { get; set; }
        public virtual DbSet<Street> StreetSet { get; set; }
        public virtual DbSet<House> HouseSet { get; set; }
        public virtual DbSet<Address> AddressSet { get; set; }
    }
}