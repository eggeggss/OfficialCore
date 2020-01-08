using OfficialDAL.Common;
using OfficialDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static IOfficialCommon.Common;

namespace OfficialDAL.DAL
{
    public class NewsKindDAL
    {
        public string Location { set; get; }
        private EFAdapter _adapter;
        private MIRLE_WEBContext _entity;
        public NewsKindDAL(EFAdapter adapter, 
            MIRLE_WEBContext entity)
        {
            Location = adapter.Location;
            _adapter = adapter;
            _entity = entity;
        }



        public IEnumerable<news_kind_present> GetAllCategory(int lang_type)
        {
            
            {
                Func<IEnumerable<news_kind_present>> func = new Func<IEnumerable<news_kind_present>>(() =>
                {

                    

                    var result = _entity.NewsKindNew
                    .Where(e => e.StatVoid == 0 && e.LangType == lang_type && e.Root == 0)
                    .OrderBy((e) => e.Range)
                    .Select(e => new news_kind_present()
                    {
                        num = e.Num,
                        kind = e.Kind

                    })
                    .ToList();
                    return result;

                });

                return _adapter.Catch<IEnumerable<news_kind_present>>(func);
            }
        }

        public IEnumerable<NewsKindNew> GetByLangNum(int lang_type, int num)
        {
            
            {
                Func<IEnumerable<NewsKindNew>> func = new Func<IEnumerable<NewsKindNew>>(() =>
                {
                    
                    var result = _entity.NewsKindNew.Where(e => e.LangType == lang_type
                    && e.Num == num).ToList();
                    return result;

                });

                return _adapter.Catch<IEnumerable<NewsKindNew>>(func);
            }
        }

        public IEnumerable<NewsKindNew> GetByLangNumByid(int lang_type, int num)
        {
            
            {
                Func<IEnumerable<NewsKindNew>> func = new Func<IEnumerable<NewsKindNew>>(() =>
                {

                    
                    var result = _entity.NewsKindNew
                    .Where(e => e.LangType == lang_type
                    && e.Num == num && e.StatVoid == 0).ToList();
                    return result;

                });

                return _adapter.Catch<IEnumerable<NewsKindNew>>(func);
            }
        }


        public IEnumerable<NewsKindNew> GetByLangRootByid(int lang_type, int root)
        {
            
            {
                Func<IEnumerable<NewsKindNew>> func = new Func<IEnumerable<NewsKindNew>>(() =>
                {

                    
                    var result = _entity.NewsKindNew.Where(e => e.LangType == lang_type
                    && e.Root == root
                    && e.StatVoid == 0).ToList();
                    return result;
                });
                return _adapter.Catch<IEnumerable<NewsKindNew>>(func);
            }
        }


        public IEnumerable<NewsKindNew> GetByLangRoot(int lang_type, int root)
        {
            
            {
                Func<IEnumerable<NewsKindNew>> func = new Func<IEnumerable<NewsKindNew>>(() =>
                {

                    
                    var result = _entity.NewsKindNew.Where(e => e.LangType == lang_type
                    && e.Root == root
                    && e.StatVoid == 0).ToList();
                    return result;
                });
                return _adapter.Catch<IEnumerable<NewsKindNew>>(func);
            }
        }

        public IEnumerable<NewsKindNew> Get(int num)
        {
            
            {
                Func<IEnumerable<NewsKindNew>> func = new Func<IEnumerable<NewsKindNew>>(() =>
                {

                    
                    var result = _entity.NewsKindNew.Where(e => e.Num == num).ToList();
                    return result;

                });
                return _adapter.Catch<IEnumerable<NewsKindNew>>(func);
            }
        }


        public bool Insert(NewsKindNew pro_kind)
        {
            
            {
                Func<bool> func = new Func<bool>(() =>
                {

                    

                    _entity.NewsKindNew.Add(pro_kind);
                    try
                    {
                        _entity.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return true;

                });

                return _adapter.Catch<bool>(func);
            }

        }

        public bool Update(NewsKindNew prokind)
        {
            
            {
                Func<bool> func = new Func<bool>(() =>
                {

                    

                    _entity.Entry(prokind).State = EntityState.Modified;
                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }
        }

        public bool Delete(int num, string update_by)
        {
            
            {
                Func<bool> func = new Func<bool>(() =>
                {

                    

                    var prokind_new = _entity.NewsKindNew
                    .Where(e => e.Num == num && e.StatVoid == 0)
                    .FirstOrDefault();
                    prokind_new.UpdateBy = update_by;
                    prokind_new.DtUpdate = DateTime.Now;
                    prokind_new.StatVoid = 1;

                    _entity.Entry(prokind_new).State = EntityState.Modified;

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }
        }


        public IEnumerable<zp_get_pronews_list_Result> GetProkindlist(string lang)
        {
            
            {
                Func<IEnumerable<zp_get_pronews_list_Result>> func = new Func<IEnumerable<zp_get_pronews_list_Result>>(() =>
                {

                    
                    int lang_type = LangConverter.Convert(lang);
                    var prokind_new = _entity.zp_get_pronews_list(lang_type).ToList();

                    return prokind_new;

                });

                return _adapter.Catch<IEnumerable<zp_get_pronews_list_Result>>(func);

            }
        }



    }
}
