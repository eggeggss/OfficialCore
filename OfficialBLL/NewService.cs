using OfficialDAL;
using OfficialDAL.DAL;
using OfficialDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficialBLL
{
    public class NewService
    {


        public NewsDAL News_dal { set; get; }
      
 
        public NewsKindDAL News_kind_dal
        {
            set;get;
        }

        public SolutionKindDAL SolutionKindDAL { get; set; }

        public NewService(NewsDAL newdal, NewsKindDAL kinddal, SolutionKindDAL solutiondal)
        {
            News_dal = newdal;
            News_kind_dal = kinddal;
            SolutionKindDAL = solutiondal;
        }



        /// <summary>
        /// 最上層的分類
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public IEnumerable<news_kind_present> GetAllCategory(int lang_type)
        {
            IEnumerable<news_kind_present> result = null;
            try
            {
                return this.News_kind_dal.GetAllCategory(lang_type);

            }
            catch (Exception ex)
            {
                return result;
            }
        }

        /// <summary>
        ///  取得第一層產品目錄
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public IEnumerable<NewsKindNew> GetProductFirstCategory(int lang_type, int num)
        {
            IEnumerable<NewsKindNew> result = null;
            try
            {
                return this.News_kind_dal.GetByLangNum(lang_type, num);

            }
            catch (Exception ex)
            {
                return result;
            }
        }

        /// <summary>
        /// 取得第二層產品目錄
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public IEnumerable<NewsKindNew> GetProductSecondCategory(int lang_type, int root)
        {
            IEnumerable<NewsKindNew> result = null;
            try
            {
                return this.News_kind_dal.GetByLangRoot(lang_type, root);

            }
            catch (Exception ex)
            {
                return result;
            }
        }

        /// <summary>
        /// 取得第三層產品目錄
        /// </summary>
        /// <param name="pro_kind"></param>
        /// <returns></returns>
        public IEnumerable<news_page_present> GetProductThirdCategory(int lang_type, int pro_kind)
        {
            IEnumerable<news_page_present> result = null;
            try
            {
                var news_presents = this.News_dal.GetByKindPresent(lang_type, pro_kind);

                foreach (var item in news_presents)
                {
                    item.showtime = item.selltime1.ToString("yyyy-MM-dd");
                    item.uptime = item.selltime1;
                }
                return news_presents.OrderByDescending(e => e.uptime);

            }
            catch (Exception ex)
            {
                return result;
            }
        }

        /// <summary>
        /// 取得產品細節
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public NewsNew GetProductDetail(int num)
        {
            NewsNew result = null;
            try
            {
                return this.News_dal.Get(num);

            }
            catch (Exception ex)
            {
                return result;
            }
        }

        /// <summary>
        /// 首頁前幾筆的top news
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="pro_kind"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public IEnumerable<news_page_present> GetTopNews(int lang_type, int pro_kind, int top)
        {
            IEnumerable<news_page_present> result = null;
            try
            {
                result = this.News_dal.GetTopNews(lang_type, pro_kind, top);

                foreach (var item in result)
                {
                    item.showtime = item.selltime1.ToString("yyyy-MM-dd");
                }

                return result.OrderByDescending(e => e.selltime1);

            }
            catch (Exception ex)
            {
                return result;
            }
        }




        public IEnumerable<news_present> GetNews(int lang_type, int pro_kind)
        {
            IEnumerable<news_present> result = null;
            try
            {
                result = this.News_dal.GetNews(lang_type, pro_kind);

                return result;

            }
            catch (Exception ex)
            {
                return result;
            }
        }


        public IEnumerable<news_present> FilterProductDetail(int lang_type, string Title, int kind)
        {

            IEnumerable<news_present> result = null;
            try
            {
                result = this.News_dal.GetNews(lang_type, kind).Where(e => e.subject.Contains(Title));

                return result;

            }
            catch (Exception ex)
            {
                return result;
            }

        }

        #region Transaction

        public bool UpdateProd(NewsNew news_new)
        {
            try
            {
                return this.News_dal.Update(news_new);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool InsertProd(NewsNew news_new)
        {
            try
            {
                return this.News_dal.Insert(news_new);
            }
            catch (Exception ex)
            {
                throw new Exception($"NewsService:{ex.Message}");
            }
        }



        public bool DeleteProd(int num)
        {
            try
            {
                return this.News_dal.Delete(num);
            }
            catch (Exception ex)
            {
                throw new Exception($"NewsService:{ex.Message}");
            }
        }






        #endregion

    }
}
