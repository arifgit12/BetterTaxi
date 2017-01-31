using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetterTaxi.Models
{
    public enum TaxiStatus
    {
        /// <summary>
        /// On duty, available to be assigned to an order
        /// </summary>
        Available = 0,

        /// <summary>
        /// On duty, assigned to an order
        /// </summary>
        Busy = 1,

        /// <summary>
        /// OffDuty - not available for order assignment
        /// </summary>
        OffDuty = 2,

        /// <summary>
        /// Unassigned - availabe for decommissioning or driver assignment
        /// </summary>
        Unassigned = 3,

        /// <summary>
        /// Decommissioned and off-duty, driver can not be assigned
        /// </summary>
        Decommissioned = 4
    }

    [Table("Taxies")]
    public class Taxi
    {
        [Key]
        public int TaxiId { get; set; }

        [Required]
        [StringLength(10)]
        public string Plate { get; set; }
        
        [Required]
        public int Seats { get; set; }

        [Required]
        public int Luggage { get; set; }

        [DefaultValue(TaxiStatus.Unassigned)]
        public TaxiStatus Status { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public virtual ApplicationUser Driver { get; set; }
    }
}
