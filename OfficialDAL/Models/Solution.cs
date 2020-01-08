using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class Solution
    {
        public int Num { get; set; }
        public string ProNum { get; set; }
        public string ProName { get; set; }
        public string ProKind { get; set; }
        public string ProKind2 { get; set; }
        public string ProKind3 { get; set; }
        public string Specification { get; set; }
        public int? Price { get; set; }
        public int? Price2 { get; set; }
        public int? Price3 { get; set; }
        public DateTime? Selltime1 { get; set; }
        public DateTime? Selltime2 { get; set; }
        public string Words { get; set; }
        public string Words2 { get; set; }
        public string Demo { get; set; }
        public string ProSell { get; set; }
        public string ProOther { get; set; }
        public int? Range { get; set; }
        public int? ProBonus { get; set; }
        public int? ProCount { get; set; }
        public string Pic1 { get; set; }
        public string Pic2 { get; set; }
        public string Pic3 { get; set; }
        public string Pic4 { get; set; }
        public int? MailCount { get; set; }
        public string ProQty { get; set; }
        public bool? ProQtyChk { get; set; }
        public string BuyKind1 { get; set; }
        public string BuyKind2 { get; set; }
        public string ProLang { get; set; }
        public string ProNews { get; set; }
    }
}
