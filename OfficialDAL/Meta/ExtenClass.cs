using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OfficialDAL
{

    public partial class zp_filter_product_new_list_Result
    {
        public int num { get; set; }
        public string catekind { get; set; }
        public string pro_name { get; set; }
        public string person { get; set; }
    }

    public partial class zp_filter_solution_new_list_Result
    {
        public int num { get; set; }
        public string catekind { get; set; }
        public string pro_name { get; set; }
    }

    public partial class zp_get_cate_all_Result
    {
        public string parent { get; set; }
        public string child { get; set; }
        public string pro_name { get; set; }
        public Nullable<int> lang_type { get; set; }
        public string lang { get; set; }
        public Nullable<int> parentid { get; set; }
        public int subid { get; set; }
        public Nullable<int> detailid { get; set; }
        public Nullable<int> range { get; set; }
    }

    public partial class zp_get_detail_solutionkind_list_Result
    {
        public string pro_kind { get; set; }
        public int num { get; set; }
    }

    public partial class zp_get_news_parent_cate_by_page_Result
    {
        public int num { get; set; }
        public string kind { get; set; }
        public string lang { get; set; }
    }
    public partial class zp_get_news_sol_category_Result
    {
        public string kind { get; set; }
        public int num { get; set; }
    }


    public partial class zp_get_parent_cate_by_page_Result
    {
        public int num { get; set; }
        public string kind { get; set; }
        public string lang { get; set; }
        public string pic1 { get; set; }
        public string pic2 { get; set; }
        public string words { get; set; }
    }

    public partial class zp_get_prodkind_parent_Result
    {
        public Nullable<int> root { get; set; }
        public Nullable<int> num { get; set; }
        public string kind { get; set; }
        public Nullable<int> lang_type { get; set; }
        public string lang { get; set; }
        public Nullable<int> level { get; set; }
    }

    public partial class zp_get_product_by_page_Result
    {
        public int num { get; set; }
        public string pro_name { get; set; }
        public string words { get; set; }
        public string words2 { get; set; }
        public string pic1 { get; set; }
        public string pic2 { get; set; }
        public string pic3 { get; set; }
        public string desc { get; set; }
    }

    public partial class zp_get_product_new_list_Result
    {
        public int num { get; set; }
        public string catekind { get; set; }
        public string pro_name { get; set; }
        public string person { get; set; }
    }


    public partial class zp_get_prokind_list_Result
    {
        public string kind { get; set; }
        public int num { get; set; }
    }


    public partial class zp_get_pronews_list_Result
    {
        public string kind { get; set; }
        public int num { get; set; }
    }


    public partial class zp_get_prosolution_list_Result
    {
        public string kind { get; set; }
        public int num { get; set; }
    }

    public partial class zp_get_sol_parent_cate_by_page_Result
    {
        public int num { get; set; }
        public string kind { get; set; }
        public string lang { get; set; }
        public string pic1 { get; set; }
    }

    public partial class zp_get_sol_sub_cate_by_page_Result
    {
        public int num { get; set; }
        public string pro_name { get; set; }
        public string words { get; set; }
        public string words2 { get; set; }
        public string pic1 { get; set; }
        public string pic2 { get; set; }
        public string pic3 { get; set; }
        public string desc { get; set; }
    }

    public partial class zp_get_solution_by_page_Result
    {
        public int num { get; set; }
        public string pro_name { get; set; }
        public string words { get; set; }
        public string words2 { get; set; }
        public string pic1 { get; set; }
        public string pic2 { get; set; }
        public string pic3 { get; set; }
        public string desc { get; set; }
    }

    public partial class zp_get_solution_new_list_Result
    {
        public int num { get; set; }
        public string catekind { get; set; }
        public string pro_name { get; set; }
    }

    public partial class zp_get_solution_news_Result
    {
        public int num { get; set; }
        public string subject { get; set; }
        public string word { get; set; }
        public string demo { get; set; }
        public Nullable<System.DateTime> uptime { get; set; }
        public string pic1 { get; set; }
        public string kind { get; set; }
        public Nullable<System.DateTime> selltime1 { get; set; }
        public Nullable<System.DateTime> selltime2 { get; set; }
        public string lang { get; set; }
        public string department { get; set; }
        public string person { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Nullable<int> stat_void { get; set; }
        public Nullable<System.DateTime> dt_create { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }
        public Nullable<System.DateTime> dt_update { get; set; }
        public Nullable<int> lang_type { get; set; }
    }


    public partial class zp_get_solutionkind_list_detail_Result
    {
        public string pro_kind { get; set; }
        public int num { get; set; }
    }



    public partial class zp_get_solutionkind_list_Result
    {
        public string kind { get; set; }
        public int num { get; set; }
    }


    public partial class zp_get_sub_cate_by_page_Result
    {
        public int num { get; set; }
        public string pro_name { get; set; }
        public string words { get; set; }
        public string words2 { get; set; }
        public string pic1 { get; set; }
        public string pic2 { get; set; }
        public string pic3 { get; set; }
        public string desc { get; set; }
    }


    public partial class zp_page_search_Result
    {
        public string category { get; set; }
        public string subject { get; set; }
        public string search { get; set; }
        public Nullable<int> num { get; set; }
        public Nullable<int> kind { get; set; }
        public Nullable<int> lang_type { get; set; }
        public Nullable<System.DateTime> uptime { get; set; }
        public Nullable<int> type { get; set; }
    }


    public class EmpData
    {
        public int pk { set; get; }
        public String empno { set; get; }
        public String empname { set; get; }
        public String email { set; get; }

        public String password { set; get; }

        public String osver { set; get; }
        public decimal appver { set; get; }
        public String device { set; get; }


        public int haslogined { set; get; }
        public string path { set; get; }
        public string message { set; get; }
        public string token { set; get; }

    }

    public class ProdKindsList
    {
        public string CategoryKind { get; set; }
        public int Num { get; set; }

        public string Kind { set; get; }
    }

    /// <summary>
    /// 首頁的清單
    /// </summary>
    public class pro_kind_present
    {
        public int num { get; set; }
        public string kind { get; set; }

        public int ispresent { set; get; }

        public string pic { set; get; }
    }

    public class solution_kind_present
    {
        public int num { get; set; }
        public string kind { get; set; }
    }

    public class news_kind_present
    {
        public int num { get; set; }
        public string kind { get; set; }
    }

    [ModelMetadataType(typeof(Metaic_carousel_present))]
    public class carousel_present
    {

        private bool _none_bool;
        public bool none_bool
        {
            set
            {

                //this.url_type = 0;
                this._none_bool = value;
            }
            get
            {
                return _none_bool;
            }
        }

        private bool _youtube_bool;

        public bool youtube_bool
        {
            set
            {
                //this.url_type = 2;
                this._youtube_bool = value;
            }
            get
            {
                return _youtube_bool;
            }
        }

        private bool _link_bool;
        public bool link_bool
        {
            set
            {
                //this.url_type = 1;
                _link_bool = value;
            }
            get
            {
                return _link_bool;
            }
        }

        private bool _popup_bool;
        public bool popup_bool
        {
            get
            {
                return _popup_bool;
            }
            set
            {
                this._popup_bool = value;
            }
        }

        public string pic1 { set; get; }
        public string slogan { set; get; }
        public int num { set; get; }
        public int sort { set; get; }

        private int _url_type;

        public int url_type
        {
            set
            {
                switch (value)
                {
                    case 0:
                        none_bool = true;
                        youtube_bool = false;
                        link_bool = false;
                        popup_bool = false;
                        break;
                    case 1:
                        none_bool = false;
                        youtube_bool = false;
                        link_bool = true;
                        popup_bool = false;
                        break;
                    case 2:
                        none_bool = false;
                        youtube_bool = true;
                        link_bool = false;
                        popup_bool = false;
                        break;
                    case 3:
                        none_bool = false;
                        youtube_bool = false;
                        link_bool = false;
                        popup_bool = true;
                        break;
                    default:
                        break;
                }

                this._url_type = value;
            }
            get
            {
                return _url_type;
            }
        }

        public string youtbue_code { get; set; }

        public string link { get; set; }

        public string popup_img { set; get; }
        public string popup_link { set; get; }

        public Nullable<System.DateTime> dt_expire { get; set; }
    }

    public class Metaic_carousel_present
    {
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "時間不能為空")]
        public Nullable<System.DateTime> dt_expire { set; get; }
    }



    public class news_present
    {
        public int num { get; set; }
        public string subject { get; set; }
        public DateTime uptime { get; set; }

        public string person { get; set; }
    }



    public class sol_rel_news
    {
        public int id_news { get; set; }
        public string[] id_solutions { get; set; }
    }
}
