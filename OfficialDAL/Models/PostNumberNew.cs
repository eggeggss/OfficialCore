using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class PostNumberNew
    {
        public int Id { get; set; }
        public string PostNumber { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public int? StatVoid { get; set; }
        public DateTime? DtCreate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? DtUpdate { get; set; }
    }
}
