﻿using Microsoft.AspNetCore.Identity;
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
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        [Display(Name = "Address")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        public string Country { get; set; }
        [Column(TypeName = "decimal(10, 8)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(11, 8)")]
        public decimal Longitude { get; set; }
        [Display(Name = "Date to Begin Suspension")]
        [DataType(DataType.Date)]
        public DateTime stopPickup { get; set; }
        [Display(Name = "Date to Resume Pickups")]
        [DataType(DataType.Date)]
        public DateTime restartPickup { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Total Balance")]
        public decimal customerBalance { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Balance Owed for Current Month")]
        public decimal currentMonthlyBalance { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Total Charges this Month")]
        public decimal currentMonthlyCharges { get; set; }
        [Display(Name = "Weekly Pickup Day")]
        public DayOfWeek DayOfWeek { get; set; }
        [NotMapped]
        public List<Pickup> Pickups { get; set; }









    }
}
