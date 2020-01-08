using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class IcContact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public DateTime? DtCreate { get; set; }
        public DateTime? DtUpdate { get; set; }
        public int? StatUpdate { get; set; }
        public int? StatVoid { get; set; }
    }
}
