using cloudscribe.Pagination.Models;
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
    public class SubProductViewModel
    {
        public int Num { get; set; }
        public string Lang { get; set; }

        int defaultPageIndex = 3;

        public ProKindNew Parent { set; get; }

        public ProKindNew Current { set; get; }

        //public IList<pro_kind_new> ChildSub { set; get; }
        public ProKindNew ChildSub { set; get; }
        //public IList<zp_get_sub_cate_by_page_Result> Child { set; get; }
        public PagedResult<zp_get_sub_cate_by_page_Result> Child { set; get; }

        public IEnumerable<zp_get_prodkind_parent_Result> ParentList { set; get; }

        public string Location { get; set; }

        public ProductService _productservice  { get; set; }

        public SubProductViewModel(ProductService productservice)
        {
            _productservice = productservice;
        }

        public void SetData(int num, string lang, int? page)
        {
            this.Num = num;
            this.Lang = lang;

            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;

            if (currentPageIndex < 0)
            {
                currentPageIndex = 0;
            }

            int lang_type = LangConverter.Convert(lang);
            //ProductService productService = new ProductService(Location);

            Current = _productservice.GetProductFirstCategory(lang_type, num).FirstOrDefault();

            ChildSub = _productservice.GetByLangRootByid(lang_type, Current.Num).ToList().FirstOrDefault();

            //麵包屑
            ParentList = _productservice.GetProdkindParent(num);

            Parent = _productservice.GetProductFirstCategory(lang_type, (int)Current.Root).FirstOrDefault();

            //leaf
            if (ChildSub == null)
            {
                /*
                Child = _productservice.GetSubCategoryByPage(num, lang_type, 1000, 0).ToList()
                    .ToPagedList(currentPageIndex, defaultPageIndex);*/
                int offset = (defaultPageIndex * currentPageIndex) - defaultPageIndex;

                var query= _productservice.GetSubCategoryByPage(num, lang_type, 1000, 0).OrderBy(x => x.num)
                .Select(p => p)
                .Skip(offset)
                .Take(defaultPageIndex);

                var result = new PagedResult<zp_get_sub_cate_by_page_Result>();
                result.Data =  query.ToList();
                result.TotalItems = query.ToList().Count;
                result.PageNumber = currentPageIndex;
                result.PageSize = defaultPageIndex;
                this.Child = result;
            }


        }
    }
}
