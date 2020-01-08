using OfficialDAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficialDAL.Models;

namespace OfficialDAL.DAL
{
    public class news_page_present
    {
        public int num { get; set; }
        public string subject { get; set; }
        public DateTime selltime1 { get; set; }
        public string showtime { set; get; }

        public DateTime uptime { set; get; }

        public string createby { set; get; }

    }
    public class NewsDAL
    {
        public string Location { set; get; }
        private EFAdapter _adapter;
        private MIRLE_WEBContext _entity;
        public NewsDAL(EFAdapter adapter, MIRLE_WEBContext entity)
        {
            Location = adapter.Location;
            _adapter = adapter;
            _entity = entity;
        }


        public NewsNew Get(int num)
        {
            
            {
                Func<NewsNew> func = new Func<NewsNew>(() =>
                {

                    

                    var result = _entity.NewsNew.Where(e => e.Num == num && e.StatVoid == 0).FirstOrDefault();

                    return result;

                });

                return _adapter.Catch<NewsNew>(func);
            }
        }



        public IEnumerable<news_page_present> GetByKindPresent(int lang_type, int pro_kind)
        {
            
            {
                Func<IEnumerable<news_page_present>> func = new Func<IEnumerable<news_page_present>>(() =>
                {

                    

                    var result = _entity.NewsNew
                    .Where(e => e.Kind.Equals(pro_kind.ToString()) && e.LangType == lang_type)
                    .Select(e => new news_page_present
                    {
                        num = e.Num,
                        subject = e.Subject,
                        selltime1 = ((DateTime)e.Uptime),
                    }).OrderByDescending(e => e.num).ToList();
                    return result;

                });

                return _adapter.Catch<IEnumerable<news_page_present>>(func);
            }
        }

        public bool Insert(NewsNew product)
        {
            
            {
                Func<bool> func = new Func<bool>(() =>
                {

                    

                    _entity.Entry(product).State = EntityState.Added;

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }

        }

        public bool Update(NewsNew product)
        {
            
            {
                Func<bool> func = new Func<bool>(() =>
                {

                    


                    _entity.Entry(product).State = EntityState.Modified;
                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }
        }

        public bool Delete(int num)
        {
            
            {
                Func<bool> func = new Func<bool>(() =>
                {

                    

                    var product_new = _entity.NewsNew.Where(e => e.Num == num).FirstOrDefault();

                    _entity.Entry(product_new).State = EntityState.Deleted;

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }
        }

        public bool Delete(NewsNew product)
        {
            
            {
                Func<bool> func = new Func<bool>(() =>
                {

                    


                    var product_new = _entity.NewsNew.Where(e => e.Num == product.Num).FirstOrDefault();

                    _entity.NewsNew.Remove(product);

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }
        }

        /// <summary>
        /// 首頁前幾筆的top news
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="pro_kind"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public IEnumerable<news_page_present> GetTopNews(int langtype, int pro_kind, int top)
        {
            //using (MIRLE_WEBContext entity = new MIRLE_WEBContext())
            {
                Func<IEnumerable<news_page_present>> func = new Func<IEnumerable<news_page_present>>(() =>
                {

                    


                    var result = _entity.NewsNew
                    .Where(e => e.Kind.Equals(pro_kind.ToString()) && e.LangType == langtype)
                    .Select(e => new news_page_present
                    {
                        num = e.Num,
                        subject = e.Subject,
                        selltime1 = ((DateTime)e.Uptime),
                        createby = e.CreateBy,
                    }).OrderByDescending(e => e.num).Take(top).ToList();
                    return result;

                });

                return _adapter.Catch<IEnumerable<news_page_present>>(func);
            }
        }


        public IEnumerable<news_present> GetNews(int langtype, int pro_kind)
        {
            //using (MIRLE_WEBContext entity = new MIRLE_WEBContext())
            {
                Func<IEnumerable<news_present>> func = new Func<IEnumerable<news_present>>(() =>
                {

                    


                    var result = _entity.NewsNew
                    .Where(e => e.Kind.Equals(pro_kind.ToString()) && e.LangType == langtype && e.StatVoid == 0)
                    .OrderByDescending(e => e.Num)
                    .Take(1000).Select(e => new news_present { num = e.Num, subject = e.Subject,
                        person = e.Person, uptime = (DateTime)e.Uptime }).ToList();

                    return result;

                });

                return _adapter.Catch<IEnumerable<news_present>>(func);
            }
        }


    }
}
