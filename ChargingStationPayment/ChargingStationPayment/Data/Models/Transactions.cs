using System;

namespace ChargingStationPayment.Data.Models
{
    public class Transactions
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long TxID { get; set; }
        public long CityID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double ChargingTimeSeconds { get; set; }
        public double PayableAmount { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public double CityChargeRatePerSecond { get; set; }
    }
}
