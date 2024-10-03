using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Request.Models
{
    public class VendorModel
    {
        public int Id { get; set; }
        public string VendorCode { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string Position { get; set; }
        public string TelNo { get; set; }
        public string Email { get; set; }
        public string TinNo { get; set; }
        public string Address { get; set; }
        public bool IsArchived { get; set; }  
    }
}