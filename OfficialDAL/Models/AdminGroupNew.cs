using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class AdminGroupNew
    {
        public int Num { get; set; }
        public string GName { get; set; }
        public string Items { get; set; }
        public string Demo { get; set; }
        public int? StatVoid { get; set; }
        public DateTime? DtCreate { get; set; }
        public string UpdateBy { get; set; }
        public string CreateBy { get; set; }
    }
}
