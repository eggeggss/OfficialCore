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
    public class DetailProductViewModel
    {
        public int Num { get; set; }
        public string Lang { get; set; }
        public string Location { get; set; }

        public ProKindNew SuperParent { set; get; }
        public ProKindNew Parent { set; get; }
        public ProductNew Current { set; get; }

        public IList<ProductNew> Carousels { set; get; }

        public IEnumerable<zp_get_prodkind_parent_Result> ParentList { set; get; }

        private ProductService _productservice;

        public DetailProductViewModel(ProductService productservice)
        {
            _productservice = productservice;
        }

        public void SetData(int num, string lang)
        {
            this.Num = num;
            this.Lang = lang;

            //ProductService productservice = new ProductService(Location);
            Current = _productservice.GetProductDetail(num);

            int lang_type = LangConverter.Convert(lang);

            if (Current != null)
            {
                Parent = _productservice
                    .GetProductFirstCategory(lang_type, Convert.ToInt32(Current.ProKind)).FirstOrDefault();

                SuperParent = _productservice
                    .GetProductFirstCategory(lang_type, Convert.ToInt32(Parent.Root)).FirstOrDefault();
            }


            //麵包屑
            ParentList = _productservice.GetProdkindParent(Convert.ToInt32(Current.ProKind));

            this.Carousels = _productservice.GetParentForCarcoual(Current.ProKind);

        }

    }
}
