﻿using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class News
    {
        public int Num { get; set; }
        public string Subject { get; set; }
        public string Word { get; set; }
        public string Demo { get; set; }
        public DateTime? Uptime { get; set; }
        public string Pic1 { get; set; }
        public string Kind { get; set; }
        public DateTime? Selltime1 { get; set; }
        public DateTime? Selltime2 { get; set; }
        public string Lang { get; set; }
        public string Department { get; set; }
        public string Person { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
