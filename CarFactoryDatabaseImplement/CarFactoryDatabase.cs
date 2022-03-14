﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFactoryDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace CarFactoryDatabaseImplement
{
    public class CarFactoryDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=CarFactory;Trusted_Connection=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Component> Components { set; get; }

        public virtual DbSet<Car> Cars { set; get; }

        public virtual DbSet<CarComponent> CarComponents { set; get; }

        public virtual DbSet<Order> Orders { set; get; }
    }
}
