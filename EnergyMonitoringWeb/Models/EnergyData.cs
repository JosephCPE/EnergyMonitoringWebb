using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyMonitoringWeb.Models
{
    public partial class EnergyData
    {
        [Key]
        [Column("DataID")]
        public int DataId { get; set; }

        [Column("DeviceID")]
        public int DeviceId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Timestamp { get; set; }

        public double PowerConsumption { get; set; }

        public double? Voltage { get; set; }
    }
}
