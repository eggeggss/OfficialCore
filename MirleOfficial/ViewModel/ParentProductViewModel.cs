using MirleOfficial.Common;
using OfficialBLL;
using OfficialDAL;
using OfficialDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirleOfficial.ViewModel
{
    public abstract class ParentViewModel<T1>
    {

        public string Location { set; get; }
        public string Title { set; get; }
        public string Desc { set; get; }

        public string BannerImage { set; get; }
        public string Lang { set; get; }
        public int Num { set; get; }

        public IEnumerable<T1> Pro_kinds { set; get; }

        public abstract void SetData(string lang, int num);
    }
    public class ParentProductViewModel : ParentViewModel<ProKindNew>
    {
        private ProductService _productservice;

        public IEnumerable<OfficialDAL.zp_get_cate_all_Result> pro_kinds { set; get; }

        public IEnumerable<zp_get_parent_cate_by_page_Result> prod_category { set; get; }

        public ParentProductViewModel(ProductService productservice)
        {
            //Location = location;
            _productservice = productservice;

        }

        public override void SetData(string lang, int num)
        {
            //ProductService productService = new ProductService(Location);
           

            this.Num = num;
            this.Lang = lang;
            int lang_type = LangConverter.Convert(Lang);
            
            //tree view
            this.pro_kinds = _productservice.GetCateAll(lang_type);

            //product category
            this.prod_category  = _productservice
                .GetParentCategoryByPage(num, lang_type, 0);



            var parent = _productservice.GetProductFirstCategory(lang_type, num).FirstOrDefault();
            if (parent != null)
            {
                this.Title = parent.Kind;
                this.Desc = parent.Words;
                this.BannerImage = parent.Pic2;
                Pro_kinds = _productservice.GetProductSecondCategory(lang_type, num);
            }

        }

    }
}
