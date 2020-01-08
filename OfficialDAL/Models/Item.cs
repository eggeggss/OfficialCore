using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class Item
    {
        public int Num { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Target { get; set; }
        public string Price { get; set; }
        public string Demo { get; set; }
        public string Other { get; set; }
        public int? Root { get; set; }
        public int? Range { get; set; }
        public string OtherUrl { get; set; }
        public string SId { get; set; }
    }
}
