using cloudscribe.Pagination.Models;
using MirleOfficial.Common;
using OfficialBLL;
using OfficialDAL;
using OfficialDAL.DAL;
using OfficialDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public ProductService _productservice { get; set; }

        public ProKindDAL _proKindDAL { get; set; }

        public IEnumerable<ProKindNew> sub_pro_kinds { set; get; }

        public IEnumerable<OfficialDAL.zp_get_cate_all_Result> pro_kinds { set; get; }


        public PagedResult<zp_get_sub_cate_by_page_Result> SubPageModel { get; set; }

        public SubProductViewModel(ProductService productservice, ProKindDAL prokindnew)
        {
            _productservice = productservice;
            _proKindDAL = prokindnew;
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

                var query = _productservice.GetSubCategoryByPage(num, lang_type, 1000, 0).OrderBy(x => x.num)
                .Select(p => p)
                .Skip(offset)
                .Take(defaultPageIndex);

                var result = new PagedResult<zp_get_sub_cate_by_page_Result>();
                result.Data = query.ToList();
                result.TotalItems = query.ToList().Count;
                result.PageNumber = currentPageIndex;
                result.PageSize = defaultPageIndex;
                this.Child = result;
            }

            //tree view
            pro_kinds = _productservice.GetCateAll(lang_type);

            //get subs
            //sub_pro_kinds= _proKindDAL.GetByLangRoot(lang_type, num);

        }

        public void GetSubCategory(int num, string lang, int pageindex, int? page)
        {
            int lang_type = LangConverter.Convert(lang);
            //ProductService service = new ProductService(Site);
            //IEnumerable<zp_get_sub_cate_by_page_Result> model = service.GetSubCategoryByPage(num, lang_type, 3, pageindex);

            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;

            if (currentPageIndex < 0)
            {
                currentPageIndex = 0;
            }
            currentPageIndex++;

            CancellationToken cancellationToken = default(CancellationToken);

            cancellationToken.ThrowIfCancellationRequested();
            int pageSize = 3;
            int offset = (pageSize * currentPageIndex) - pageSize;

            var datas = _productservice.GetSubCategoryByPage(num, lang_type, 13, 0);

            var query = datas
                .OrderByDescending(x => x.num)
                .Select(p => p)
                .Skip(offset)
                .Take(pageSize)
                ;

            this.SubPageModel = new PagedResult<zp_get_sub_cate_by_page_Result>();
            SubPageModel.Data = query.ToList();
            SubPageModel.TotalItems = datas.Count();//query.ToList().Count();
            SubPageModel.PageNumber = currentPageIndex;
            SubPageModel.PageSize = pageSize;


            /*
            IPagedList<zp_get_sub_cate_by_page_Result> model = 
                _prodService.GetSubCategoryByPage(num, lang_type, 13, pageindex)
                .ToPagedList(currentPageIndex, 3);
            */

            //int Col = (int)TempData["Col"];
            //ViewBag.Col = (Col < 3) ? 6 : 4;
            //ViewBag.Lang = lang;
            //if (Col == 1)
            //{
            //    ViewBag.Col = 8;
            //}

            //return PartialView("_SubCate", model);


            //else
            //{

            //    int lang_type = LangConverter.Convert(lang);
            //    //ProductService service = new ProductService(Site);
            //    IEnumerable<zp_get_parent_cate_by_page_Result> model = _productservice
            //        .GetParentCategoryByPageSize(num, lang_type, 100, pageindex);

            //    return PartialView("_SubCate2", model);
            //}

        }



    }
}
