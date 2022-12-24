using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChargingStationPayment.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ChargingStationPayment.Data
{
    public class DataCon : DbContext
    {
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        public DataCon(DbContextOptions<DataCon> options) : base(options) {}
    }
}
