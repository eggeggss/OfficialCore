using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class PostCityNew
    {
        public string City { get; set; }
        public int? StatVoid { get; set; }
        public DateTime? DtCreate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? DtUpdate { get; set; }
    }
}
