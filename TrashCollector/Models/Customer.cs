using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;
using NetTopologySuite;


namespace TrashCollector.Models
{
    
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; }
        public  Geometry LocationID { get; set; }
        [Column(TypeName = "decimal(10, 8)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(11, 8)")]
        public decimal Longitude { get; set; }
        [DataType(DataType.Date)]
        public DateTime pickupDay { get; set; }
        public bool isActive { get; set; }
        [DataType(DataType.Date)]
        public DateTime stopPickup { get; set; }
        [DataType(DataType.Date)]
        public DateTime restartPickup { get; set; }
        [DataType(DataType.Date)]
        public DateTime extraPickup { get; set; }

        public double customerBalance { get; set; }

        public double currentMonthlyBalance { get; set; }

        public bool weeklyPickupCompleted { get; set; }









    }
}
