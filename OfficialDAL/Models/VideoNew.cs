using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class VideoNew
    {
        public int Num { get; set; }
        public string Title { get; set; }
        public DateTime? Uptime { get; set; }
        public int? StatVoid { get; set; }
        public DateTime? DtCreate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? DtUpdate { get; set; }
        public string Url { get; set; }
        public int? Demo { get; set; }
    }
}
