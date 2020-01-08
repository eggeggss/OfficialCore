using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class BotLog
    {
        public int Id { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public DateTime? DtCreate { get; set; }
        public DateTime? DtUpdate { get; set; }
        public int? StatVoid { get; set; }
    }
}
