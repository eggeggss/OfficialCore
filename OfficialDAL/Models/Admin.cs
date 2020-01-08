using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class Admin
    {
        public int Num { get; set; }
        public string UId { get; set; }
        public string UPassword { get; set; }
        public string UName { get; set; }
        public string Sex { get; set; }
        public string Kind { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Address { get; set; }
        public string Uid1 { get; set; }
        public string Demo { get; set; }
        public string Power { get; set; }
        public bool Online { get; set; }
        public DateTime? RegTime { get; set; }
        public DateTime? LoginTime { get; set; }
        public string LoginIp { get; set; }
        public string LoginCode { get; set; }
    }
}
