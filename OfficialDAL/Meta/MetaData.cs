using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OfficialDAL.Models
{ 
    [ModelMetadataType(typeof(MetaProKindNew))]
    public partial class ProKindNew
    {

    }

    public class MetaProKindNew
    {

        [DisplayName("分類名稱")]
        [Required(ErrorMessage = "分類名稱不能空白")]
        public string Kind { get; set; }

        [DisplayName("分類排序")]
        public Nullable<int> Range
        {
            get; set;
        }

        [DisplayName("分類說明")]
        public string Words { get; set; }

        [DisplayName("分類主圖")]
        [pic1LenthCheck(ErrorMessage = "檔名不能超過50個字")]
        public string Pic1 { get; set; }
    }

    [ModelMetadataType(typeof(MetaProductNew))]
    public partial class ProductNew
    {

    }


    public class MetaProductNew
    {

        [DisplayName("商品編號")]
        public string ProNum { get; set; }

        [DisplayName("商品名稱")]
        [Required(ErrorMessage = "商品名稱不能空白")]
        public string ProName { get; set; }

        [DisplayName("商品分類")]
        [Required(ErrorMessage = "商品分類不能空白")]
        public string ProKind { get; set; }


        [DisplayName("起")]
        public Nullable<System.DateTime> Selltime1 { get; set; }

        [DisplayName("迄")]
        public Nullable<System.DateTime> Selltime2 { get; set; }
        [DisplayName("內容")]
        [Required(ErrorMessage = "內容不能空白")]
        public string Words { get; set; }

        public string Words2 { get; set; }
        public string Demo { get; set; }

        [DisplayName("顯示方式")]
        [Required(ErrorMessage = "顯示方式不能空白")]
        public string ProSell { get; set; }


        [DisplayName("商品圖片")]
        public string Pic1 { get; set; }

        [DisplayName("商品小圖")]
        public string Pic2 { get; set; }

        public string ProLang { get; set; }

        [DisplayName("語言")]
        public string LangType { get; set; }

        [DisplayName("部門")]
        public string Department { get; set; }
        [DisplayName("姓名")]
        public string Person { get; set; }
        [DisplayName("電話")]
        public string Phone { get; set; }

        [DisplayName("傳真")]
        public string Fax { get; set; }

        [DisplayName("信箱")]
        public string Email { get; set; }

        [DisplayName("簡介")]
        //[Required(ErrorMessage = "簡介名稱不能空白")]
        public string Desc { get; set; }
    }


    [ModelMetadataType(typeof(MetaSolutionNew))]
    public partial class SolutionNew
    {

    }

    public class MetaSolutionNew
    {


        [DisplayName("商品編號")]
        public string ProNum { get; set; }

        [DisplayName("商品名稱")]
        [Required(ErrorMessage = "商品名稱不能空白")]
        public string ProName { get; set; }

        [DisplayName("商品分類")]
        [Required(ErrorMessage = "商品分類不能空白")]
        public string ProKind { get; set; }


        [DisplayName("起")]
        public Nullable<System.DateTime> Selltime1 { get; set; }

        [DisplayName("迄")]
        public Nullable<System.DateTime> Selltime2 { get; set; }
        [DisplayName("內容")]
        [Required(ErrorMessage = "內容不能空白")]
        public string Words { get; set; }

        [DisplayName("簡介")]
        public string Words2 { get; set; }
        public string Demo { get; set; }

        [DisplayName("顯示方式")]
        [Required(ErrorMessage = "顯示方式不能空白")]
        public string ProSell { get; set; }


        [DisplayName("商品圖片")]
        public string Pic1 { get; set; }

        [DisplayName("商品小圖")]
        public string Pic2 { get; set; }

        public string pro_lang { get; set; }

        [DisplayName("語言")]
        public int? LangType { get; set; }


        [DisplayName("簡介")]
        //[Required(ErrorMessage = "簡介名稱不能空白")]
        public string Desc { get; set; }
    }


    [ModelMetadataType(typeof(Meta_carousel_new))]
    public partial class CarouselNew
    {
        public string Lang { set; get; }
    }

    public class Meta_carousel_new
    {
        [DisplayName("標題")]
        [Required(ErrorMessage = "標題不能空白")]
        public string Slogan { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "時間不能為空")]
        public Nullable<System.DateTime> DtExpire { set; get; }
    }


    [ModelMetadataType(typeof(MetaNewsNew))]
    public partial class news_new
    {

        public IEnumerable<zp_get_news_sol_category_Result> news_menu { set; get; }

    }


    public class MetaNewsNew
    {
        public int Num { get; set; }
        [DisplayName("標題")]
        [Required(ErrorMessage = "標題不能空白")]
        public string Subject { get; set; }

        [DisplayName("內容")]
        [Required(ErrorMessage = "內容不能空白")]
        public string Word { get; set; }

        [DisplayName("簡短描述")]
        public string Demo { get; set; }

        [DisplayName("上線時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Uptime { get; set; }

        public string Pic1 { get; set; }

        [DisplayName("分類")]
        [Required(ErrorMessage = "分類不能空白")]
        public string Kind { get; set; }

        public Nullable<System.DateTime> Selltime1 { get; set; }
        public Nullable<System.DateTime> Selltime2 { get; set; }
        public string Lang { get; set; }

        [DisplayName("關鍵字")]
        public string Department { get; set; }

        [DisplayName("新聞聯絡人")]

        public string Person { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("電話")]
        [MaxLength(30, ErrorMessage = "字數過長")]
        public string Phone { get; set; }

        [DisplayName("語言")]
        public Nullable<int> LangType { get; set; }
    }

    [ModelMetadataType(typeof(Metaic_contact))]
    public partial class IcContact
    {


    }

    public class Metaic_contact
    {
        [DisplayName("姓名")]
        [Required(ErrorMessage = "姓名不能為空")]
        public string Name { get; set; }

    }




    [ModelMetadataType(typeof(Meta_new))]
    public partial class VideoNew
    {

        [NotMapped]
        public bool BoolCheck
        {
            get { return Demo == 1; }
            set { Demo = value ? 1 : 0; }
        }
        

    }

    public class Meta_new
    {
        [DisplayName("標題")]
        [Required(ErrorMessage = "標題不能為空")]
        public string Title { get; set; }

        [DisplayName("時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "時間不能為空")]
        public Nullable<System.DateTime> Uptime { get; set; }


        [DisplayName("Youtub code")]
        [Required(ErrorMessage = "youtube code不能為空")]
        public string Url { set; get; }

        [DisplayName("顯示於首頁")]
        public bool BoolCheck { set; get; }
    }

    public partial class MIRLE_WEBContext : DbContext
    {
        public virtual DbSet<zp_get_cate_all_Result> zp_get_cate_all_Result { get; set; }
        public virtual DbSet<zp_get_parent_cate_by_page_Result> zp_get_parent_cate_by_page_Result { get; set; }

        private void OnModelCreatingExtent(ModelBuilder modelBuilder)
        {
            //stored procedure
            modelBuilder.Entity<zp_get_cate_all_Result>().HasNoKey();
            modelBuilder.Entity<zp_get_parent_cate_by_page_Result>().HasNoKey();

        }
    }

    public partial class MIRLE_WEBContext01 : MIRLE_WEBContext
    {
        public MIRLE_WEBContext01()
        {
        }

        public MIRLE_WEBContext01(DbContextOptions<MIRLE_WEBContext> options)
            : base(options)
        {
        }

        public DbContextOptionsBuilder _optionsBuilder;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            this._optionsBuilder = optionsBuilder;
        }
    }
}
