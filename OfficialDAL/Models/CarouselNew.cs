using System;
using System.Collections.Generic;

namespace OfficialDAL.Models
{
    public partial class CarouselNew
    {
        public int Num { get; set; }
        public string Slogan { get; set; }
        public string Pic1 { get; set; }
        public int? StatVoid { get; set; }
        public DateTime? DtCreate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? DtUpdate { get; set; }
        public int? Sort { get; set; }
        public int? LangType { get; set; }
        public int? UrlType { get; set; }
        public string YoutubeCode { get; set; }
        public string Link { get; set; }
        public string PopupImg { get; set; }
        public string PopupLink { get; set; }
        public DateTime? DtExpire { get; set; }
    }
}
