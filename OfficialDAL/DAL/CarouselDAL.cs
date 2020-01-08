using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficialDAL.Common;
using OfficialDAL.Models;

namespace OfficialDAL.DAL
{

    public class CarouselDAL
    {

        public string Location { set; get; }
        private EFAdapter _adapter;
        private MIRLE_WEBContext _entity;
        public CarouselDAL(EFAdapter adapter, MIRLE_WEBContext entity)
        {
            Location = adapter.Location;
            _adapter = adapter;
            _entity = entity;
        }

        /// <summary>
        /// 後臺用
        /// </summary>
        /// <param name="lang_type"></param>
        /// <returns></returns>
        public IEnumerable<carousel_present> GetAll(int lang_type)
        {
            
            {
                Func<IEnumerable<carousel_present>> func = new Func<IEnumerable<carousel_present>>(() => {

                    
                    
                    var result = _entity.CarouselNew.Where(
                        e => e.StatVoid == 0
                        && e.LangType == lang_type

                        ).OrderBy(e => e.Sort).
                    Select(e => new carousel_present
                    {
                        num = e.Num,
                        slogan = e.Slogan,
                        pic1 = e.Pic1,
                        sort = (int)e.Sort,
                        url_type = (int)e.UrlType,
                        link = e.Link,
                        youtbue_code = e.YoutubeCode,
                        popup_img = e.PopupImg,
                        popup_link = e.PopupLink,

                    }).ToList();

                    return result;

                });

                return _adapter.Catch<IEnumerable<carousel_present>>(func);
            }
        }

        /// <summary>
        /// 前台用
        /// </summary>
        /// <param name="lang_type"></param>
        /// <returns></returns>
        public IEnumerable<carousel_present> GetAllForExpire(int lang_type)
        {
            
            {
                Func<IEnumerable<carousel_present>> func = new Func<IEnumerable<carousel_present>>(() => {

                    //entity.Database.Connection.ConnectionString = _adapter.DbString;
                    
                    //entity.Database.Log = (log1) => System.Diagnostics.Debug.WriteLine(log1);
                    var result = _entity.CarouselNew.Where(
                        e => e.StatVoid == 0
                        && e.LangType == lang_type
                        && ((DateTime)e.DtExpire) > DateTime.Now
                        ).OrderBy(e => e.Sort).
                    Select(e => new carousel_present
                    {
                        num = e.Num,
                        slogan = e.Slogan,
                        pic1 = e.Pic1,
                        sort = (int)e.Sort,
                        url_type = (int)e.UrlType,
                        link = e.Link,
                        youtbue_code = e.YoutubeCode,
                        popup_img = e.PopupImg,
                        popup_link = e.PopupLink,

                    }).ToList();

                    return result;

                });

                return _adapter.Catch<IEnumerable<carousel_present>>(func);
            }
        }

        public CarouselNew Get(int num)
        {
            
            {
                Func<CarouselNew> func = new Func<CarouselNew>(() => {

                   

                    var carousel = _entity.CarouselNew.Where(e => e.Num == num 
                    && e.StatVoid == 0).ToList().FirstOrDefault();

                    return carousel;

                });

                return _adapter.Catch<CarouselNew>(func);
            }
        }

        public bool Insert(CarouselNew carousel)
        {
            
            {
                Func<bool> func = new Func<bool>(() => {

                    

                    _entity.Entry(carousel).State = EntityState.Added;

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }
        }

        public bool Update(CarouselNew carousel)
        {
            
            {
                Func<bool> func = new Func<bool>(() => {

                    

                    _entity.Entry(carousel).State = EntityState.Modified;

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }
        }

        public bool Delete(int num, string username)
        {
            
            {
                Func<bool> func = new Func<bool>(() => {

                    

                    var carousel = _entity.CarouselNew
                    .Where(e => e.Num == num && e.StatVoid == 0)
                    .ToList()
                    .First();

                    carousel.UpdateBy = username;
                    carousel.StatVoid = 1;
                    carousel.DtUpdate = DateTime.Now;

                    _entity.Entry(carousel).State = EntityState.Modified;

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }
        }

        public IList<String> AutoComplete(string content)
        {
            
            {
                Func<IList<String>> func = new Func<IList<String>>(() => {

                    

                    return _entity.zp_auto_complete(content).ToList();

                });

                return _adapter.Catch<IList<String>>(func);
            }
        }
        /// <summary>
        /// type:0 news,type:1 product type:2 solution type3:all
        /// </summary>
        /// <param name="lang_type"></param>
        /// <param name="content"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<zp_page_search_Result> SearchPage(int lang_type, string content, int type)
        {

            
            {
                Func<IEnumerable<zp_page_search_Result>> func = new Func<IEnumerable<zp_page_search_Result>>(() => {

                    

                    IEnumerable<zp_page_search_Result> result = _entity.zp_page_search(content, lang_type, type).ToList();


                    return result;
                });

                return _adapter.Catch<IEnumerable<zp_page_search_Result>>(func);
            }

        }

    }
}
