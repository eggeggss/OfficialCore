﻿using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class ProKind
    {
        public int Num { get; set; }
        public string Kind { get; set; }
        public int? Root { get; set; }
        public string Lang { get; set; }
        public int? Range { get; set; }
        public string Words { get; set; }
        public string Pic1 { get; set; }
        public string Pic2 { get; set; }
        public string Pic3 { get; set; }
        public string Pic4 { get; set; }
        public string Pic5 { get; set; }
        public string LinkUrl { get; set; }
        public string LinkUrl2 { get; set; }
    }
}
