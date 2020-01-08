using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class Company
    {
        public int Num { get; set; }
        public string ComName { get; set; }
        public string ComMail { get; set; }
        public string PicUrl { get; set; }
        public bool? Menu { get; set; }
        public bool? LogClass { get; set; }
        public string LogMenu { get; set; }
    }
}
