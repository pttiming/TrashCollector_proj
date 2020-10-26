using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Pickup
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customer")]
        [Display(Name ="Customer Name")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int PickupZipCode { get; set; }
        [Display(Name = "Completed")]
        public DateTime ActualPickupDate { get; set; }
        [Display(Name = "Scheduled")]
        [DataType(DataType.Date)]
        public DateTime ScheduledPickupDate { get; set; }
        public bool IsComplete { get; set; }
        public bool IsOneOff { get; set; }
        public bool IsActive { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Pickup Charge")]
        public decimal AmountCharged { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Amout Paid")]
        public decimal AmountPaid { get; set; }

        public Pickup()
        {
            IsActive = true;

        }

    }
}
