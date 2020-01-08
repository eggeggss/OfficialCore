using MirleOfficial.Common;
using OfficialBLL;
using OfficialDAL;
using OfficialDAL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirleOfficial.ViewModel
{
    public class FirstViewModel
    {
        public string Location { set; get; }

        public IEnumerable<pro_kind_present> Pro_kind
        { set; get; }
        public IEnumerable<solution_kind_present> Solution_Kind { set; get; }

        public IEnumerable<solution_kind_present> Solution_Kind_Top10 { set; get; }

        /// <summary>
        /// 產品訊息
        /// </summary>
        public IEnumerable<news_page_present> News_ProdTop { set; get; }

        /// <summary>
        /// 新聞訊息
        /// </summary>
        public IEnumerable<news_page_present> News_NewTop { set; get; }

        /// <summary>
        /// 財務訊息
        /// </summary>
        public IEnumerable<news_page_present> News_FinTop { set; get; }


        public IEnumerable<carousel_present> Carousel { set; get; }



        public Site whichSite { set; get; }

        public string DemoCode { set; get; }

        public ProductService ProductService { get; set; }

        public SolutionService Solutionservice { get; set; }
        public CarouselService CarouselService { get; set; }

        public NewService NewService { get; set; }

        public VideoService VideoService { get; set; }

        public FirstViewModel(ProductService  productservice,
            SolutionService solutionservice,
            CarouselService sarouselService,
            NewService newService,
            VideoService videoservice)
        {
            //Location = location;
            whichSite = Common.Site.CompanyHeadquarter;
            ProductService = productservice;
            Solutionservice = solutionservice;
            NewService = newService;
            VideoService = videoservice;
            CarouselService = sarouselService;

        }

        public void SetData(string lang)
        {
            int lang_type = LangConverter.Convert(lang);

            
            this.Pro_kind = ProductService.GetAllCategory(lang_type);

            
            this.Solution_Kind = this.Solutionservice.GetAllCategory(lang_type);
            this.Solution_Kind_Top10 = this.Solution_Kind.OrderBy(e => e.num).Take(10);

            //CarouselService carouselservice = new CarouselService(Location);
            this.Carousel = this.CarouselService.GetCarouselAllForExpire(lang_type);

            //NewService newService = new NewService(Location);
            this.News_FinTop = this.NewService.GetTopNews(lang_type, 3, 5);
            this.News_ProdTop = this.NewService.GetTopNews(lang_type, 2, 5);
            this.News_NewTop = this.NewService.GetTopNews(lang_type, 1, 3);

            //VideoService videoService = new VideoService(Location);

            DemoCode = this.VideoService.GetAll().Where(e => e.StatVoid == 0 
            && e.Demo == 1)
                .FirstOrDefault().Url;

        }


    }
}
