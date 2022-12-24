using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargingStationPayment.Data.Models
{
    public class Cities
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long CityID { get; set; }
        public string CityName { get; set; }
        public double CityChargeRatePerSecond { get; set; }
    }
}
