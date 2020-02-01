using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MirleOfficial.Common;
using OfficialBLL;
using Microsoft.Extensions.DependencyInjection;
using OfficialDAL;
using OfficialDAL.DAL;
using OfficialDAL.Models;
using MirleOfficial.ViewModel;
using System.Threading;
using cloudscribe.Pagination.Models;

namespace MirleOfficial.Controllers
{
    [Route("Product")]
    public class ProductController : MymvcController
    {
        private ProductService _prodService;
        private ParentProductViewModel _ParentProductViewModel;
        private ProKindDAL _proKindDAL;
        private SubProductViewModel _SubProductViewModel;
        private DetailProductViewModel _DetailProductViewModel;
        public ProductController(IServiceProvider serviceProvider):base(serviceProvider)
        {
            _prodService = serviceProvider.GetService<ProductService>();
            _proKindDAL = serviceProvider.GetService<ProKindDAL>();
            _ParentProductViewModel = serviceProvider.GetService<ParentProductViewModel>();
            _SubProductViewModel= serviceProvider.GetService<SubProductViewModel>();
            _DetailProductViewModel= serviceProvider.GetService<DetailProductViewModel>();
        }

        public ActionResult GetParentCategory(int num, string lang, int pageindex)
        {

            int lang_type = LangConverter.Convert(lang);

            IEnumerable<zp_get_parent_cate_by_page_Result> model = _prodService
                .GetParentCategoryByPage(num, lang_type, pageindex);

            int Col = (int)TempData["Col"];
            ViewBag.Col = (Col < 3) ? 6 : 4;

            if (Col == 1)
            {
                ViewBag.Col = 8;
            }
            ViewBag.Col = 4;

            return PartialView("_ParentCate", model);
        }

        public ActionResult GetSubCategory(int num, string lang, int pageindex, int leaf, int? page)
        {

            if (leaf == 0)
            {
                int lang_type = LangConverter.Convert(lang);
                //ProductService service = new ProductService(Site);
                //IEnumerable<zp_get_sub_cate_by_page_Result> model = service.GetSubCategoryByPage(num, lang_type, 3, pageindex);

                int currentPageIndex = page.HasValue ? page.Value - 1 : 0;

                if (currentPageIndex < 0)
                {
                    currentPageIndex = 0;
                }

                CancellationToken cancellationToken = default(CancellationToken);

                cancellationToken.ThrowIfCancellationRequested();
                int pageSize = 3;
                int offset = (pageSize * currentPageIndex) - pageSize;

                var query = _prodService.GetSubCategoryByPage(num, lang_type, 13, pageindex)
                    .OrderByDescending(x => x.num)
                    .Select(p => p)
                    .Skip(offset)
                    .Take(pageSize)
                    ;

                var model = new PagedResult<zp_get_sub_cate_by_page_Result>();
                model.Data =  query.ToList();
                model.TotalItems = query.ToList().Count();
                model.PageNumber = currentPageIndex;
                model.PageSize = pageSize;


                /*
                IPagedList<zp_get_sub_cate_by_page_Result> model = 
                    _prodService.GetSubCategoryByPage(num, lang_type, 13, pageindex)
                    .ToPagedList(currentPageIndex, 3);
                */

                int Col = (int)TempData["Col"];
                ViewBag.Col = (Col < 3) ? 6 : 4;
                ViewBag.Lang = lang;
                if (Col == 1)
                {
                    ViewBag.Col = 8;
                }

                return PartialView("_SubCate", model);
            }
            else
            {

                int lang_type = LangConverter.Convert(lang);
                //ProductService service = new ProductService(Site);
                IEnumerable<zp_get_parent_cate_by_page_Result> model = _prodService
                    .GetParentCategoryByPageSize(num, lang_type, 100, pageindex);

                return PartialView("_SubCate2", model);
            }
        }

        #region GetProductTree已廢棄
        //[OutputCache(Duration = 1300)]
        public ActionResult GetProductTree(string lang, int num, int currentnum, int subnum)
        {
            
            //ProductService service = new ProductService(this.Site);
            ViewBag.currentnum = currentnum;
            ViewBag.subnum = subnum;
            //TempData["subnum"] = subnum;
            int lang_type = LangConverter.Convert(lang);
            IEnumerable<OfficialDAL.zp_get_cate_all_Result> pro_kinds = _prodService.GetCateAll(lang_type);
            
            return PartialView("_ParentProductTree", pro_kinds);


        }
        #endregion

        //[OutputCache(Duration = 1300)]
        public ActionResult GetSubTree(string lang, int num)
        {
            //ProKindDAL prodal = new ProKindDAL(this.Site);
            int lang_type = LangConverter.Convert(lang.Trim());
            IEnumerable<ProKindNew> pro_kinds = _proKindDAL.GetByLangRoot(lang_type, num);
            return PartialView("_SubProductTree", pro_kinds);
        }

        

        [HttpGet]
        [Route("Parent/{lang}/{num}/{title}")]
        // GET: Product
        public ActionResult Parent(string lang, int num, string title)
        {
            //ParentProductViewModel parentVM = new ParentProductViewModel(Site);
            _ParentProductViewModel.SetData(lang, num);

            ViewBag.currentnum = _ParentProductViewModel.Num;
            ViewBag.subnum = 0;
            ViewBag.Col = 4;

            TempData["Col"] = _ParentProductViewModel.Pro_kinds.Count();
            //繁體/簡體
            if (num == 5 || num == 61 || num == 105)
            {
                this.firstViewModel.whichSite = Common.Site.Company900;
            }

            return View(_ParentProductViewModel);
        }

        [HttpGet]
        [Route("Sub/{pro_kind}/{lang}/{title}")]
        [Route("Sub/{page}/{pro_kind}/{lang}/{title}")]
        public ActionResult Sub(int? page, int pro_kind, string lang, string title)
        {
            //SubProductViewModel subVm = new SubProductViewModel(Site);
            int page_number = 0;
            if (page == null)
            {
                page_number = 0;
            }
            else
            {
                page_number = (int)page;
            }

            _SubProductViewModel.SetData(pro_kind, lang, page_number);

            if (_SubProductViewModel.Child != null)
                TempData["Col"] = _SubProductViewModel.Child.PageSize;


            if (_SubProductViewModel.Parent.Num == 5 || _SubProductViewModel.Parent.Num == 61 
                || _SubProductViewModel.Parent.Num == 105)
            {
                this.firstViewModel.whichSite = Common.Site.Company900;
            }

            ViewBag.currentnum = _SubProductViewModel.Parent.Num;
            ViewBag.subnum = _SubProductViewModel.Current.Num;

            _SubProductViewModel.GetSubCategory(_SubProductViewModel.Num, lang, page_number, page);


            return View("Sub", _SubProductViewModel);
        }

        /// <summary>
        /// pro_kind=parent的num
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Detail/{num}/{lang}/{title}")]
        public ActionResult Detail(int num, string lang, string title)
        {
            //DetailProductViewModel detailVm = new DetailProductViewModel(Site);
            _DetailProductViewModel.SetData(num, lang);

            if (_DetailProductViewModel.SuperParent.Num == 5
                || _DetailProductViewModel.SuperParent.Num == 61 
                || _DetailProductViewModel.Parent.Num == 105)
            {
                this.firstViewModel.whichSite = Common.Site.Company900;
            }
            return View("Detail", _DetailProductViewModel);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}