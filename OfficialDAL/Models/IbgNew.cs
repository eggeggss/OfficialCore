using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class IbgNew
    {
        public string Site { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Office { get; set; }
        public string Mobil { get; set; }
        public string Eat { get; set; }
        public string Meat { get; set; }
        public string Remarks { get; set; }
        public string Ctdate { get; set; }
        public int? StatVoid { get; set; }
        public DateTime? DtCreate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? DtUpdate { get; set; }
    }
}
