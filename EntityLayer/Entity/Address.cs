using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
	public class Address
	{
        public int AddressId { get; set; }
        [ForeignKey("AppUser")]
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
        public string? CompanyName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? LineOne { get; set; }
        public string? LineTwo { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? PostCode { get; set; }
        public string? OrderDetail { get; set; }
    }
}
