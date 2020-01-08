using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class NewsMappingTable
    {
        public int Id { get; set; }
        public int? IdOld { get; set; }
        public int? IdNew { get; set; }
        public DateTime? DtCreate { get; set; }
        public int? StatVoid { get; set; }
        public DateTime? DtUpdate { get; set; }
    }
}
