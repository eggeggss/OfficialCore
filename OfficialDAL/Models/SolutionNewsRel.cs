using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class SolutionNewsRel
    {
        public int Id { get; set; }
        public int IdSolution { get; set; }
        public int IdNews { get; set; }
        public DateTime? DtCreate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? DtUpdate { get; set; }
        public int? StatVoid { get; set; }
    }
}
