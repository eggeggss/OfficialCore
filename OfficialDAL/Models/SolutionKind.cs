using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class SolutionKind
    {
        public int Num { get; set; }
        public string Kind { get; set; }
        public int? Root { get; set; }
        public string Lang { get; set; }
        public string Pic1 { get; set; }
        public int? Range { get; set; }
    }
}
