using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class FuntionNew
    {
        public int Num { get; set; }
        public string GGame { get; set; }
        public string Funname { get; set; }
        public int? Sort { get; set; }
        public int? StatVoid { get; set; }
        public DateTime? DtCreate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? DtUpdate { get; set; }
    }
}
