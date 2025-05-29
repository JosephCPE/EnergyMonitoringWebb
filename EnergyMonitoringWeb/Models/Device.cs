using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyMonitoringWeb.Models
{
    public partial class Device
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // <- Add this attribute
        [Column("DeviceID")]
        public int DeviceId { get; set; }

        [StringLength(100)]
        public string DeviceName { get; set; } = null!;

        [StringLength(100)]
        public string? Location { get; set; }

        [Column("UserID")]
        public int UserId { get; set; }
    }
}
