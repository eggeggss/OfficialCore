using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class SolutionKindNew
    {
        public int Num { get; set; }
        public string Kind { get; set; }
        public int? Root { get; set; }
        public string Lang { get; set; }
        public string Pic1 { get; set; }
        public int? Range { get; set; }
        public int? StatVoid { get; set; }
        public DateTime? DtCreate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? DtUpdate { get; set; }
        public int? LangType { get; set; }
        public string Pic2 { get; set; }
    }
}
