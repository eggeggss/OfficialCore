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
    public class ProKindDAL
    {
        public string Location { set; get; }
        private EFAdapter _adapter;
        private  MIRLE_WEBContext _entity;
        public ProKindDAL(EFAdapter adapter,
            MIRLE_WEBContext entity)
        {
            Location = adapter.Location;
            _adapter = adapter;
            _entity = entity;
        }

        /// <summary>
        /// 首頁的產品分類
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public IEnumerable<pro_kind_present> GetAllCategory(int lang_type)
        {
            
            
            {
                Func<IEnumerable<pro_kind_present>> func = new Func<IEnumerable<pro_kind_present>>(() =>
                {

                   

                    var result = _entity.ProKindNew
                    .Where(e => e.StatVoid == 0
                    && e.LangType == lang_type && e.Root == 0)
                    .OrderBy((e) => e.Range)
                    .Select(e => new pro_kind_present()
                    {
                        num = e.Num,
                        kind = e.Kind,
                        ispresent = (e.Ispresent == null) ? 0 : (int)e.Ispresent,
                        pic = e.Pic1,

                    })
                    .ToList();
                    return result;

                });

                return _adapter.Catch<IEnumerable<pro_kind_present>>(func);
            }
        }

        public IEnumerable<ProKindNew> GetByLangNum(int lang_type, int num)
        {
            
            {
                Func<IEnumerable<ProKindNew>> func = new Func<IEnumerable<ProKindNew>>(() =>
                {

                   
                    var result = _entity.ProKindNew.Where(e => e.LangType == lang_type
                    && e.Num == num &&
                    e.StatVoid == 0).ToList();
                    return result;

                });

                return _adapter.Catch<IEnumerable<ProKindNew>>(func);
            }
        }

        public IEnumerable<ProKindNew> GetByLangNumByid(int lang_type, int num)
        {
            
            {
                Func<IEnumerable<ProKindNew>> func = new Func<IEnumerable<ProKindNew>>(() =>
                {

                   
                    var result = _entity.ProKindNew.Where(e => e.LangType == lang_type 
                    && e.Num == num && e.StatVoid == 0).ToList();
                    return result;

                });

                return _adapter.Catch<IEnumerable<ProKindNew>>(func);
            }
        }


        public IEnumerable<ProKindNew> GetByLangRootByid(int lang_type, int root)
        {
            
            {
                Func<IEnumerable<ProKindNew>> func = new Func<IEnumerable<ProKindNew>>(() =>
                {

                   
                    var result = _entity
                    .ProKindNew.Where(e => e.LangType == lang_type
                    && e.Root == root && e.StatVoid == 0)
                    .ToList().OrderBy(e => e.Range);
                    return result;
                });
                return _adapter.Catch<IEnumerable<ProKindNew>>(func);
            }
        }


        public IEnumerable<ProKindNew> GetByLangRoot(int lang_type, int root)
        {
            
            {
                Func<IEnumerable<ProKindNew>> func = new Func<IEnumerable<ProKindNew>>(() =>
                {

                   
                    var result = _entity.ProKindNew.Where(e => e.LangType == lang_type
                    && e.Root == root && e.StatVoid == 0)
                    .ToList().OrderBy(e => e.Range);
                    return result;
                });
                return _adapter.Catch<IEnumerable<ProKindNew>>(func);
            }
        }

        public IEnumerable<ProKindNew> Get(int num)
        {
            
            {
                Func<IEnumerable<ProKindNew>> func = new Func<IEnumerable<ProKindNew>>(() =>
                {

                   
                    var result = _entity.ProKindNew
                    .Where(e => e.Num == num).ToList();
                    return result;

                });
                return _adapter.Catch<IEnumerable<ProKindNew>>(func);
            }
        }


        public bool Insert(ProKindNew pro_kind)
        {
            
            {
                Func<bool> func = new Func<bool>(() =>
                {

                   

                    _entity.Entry(pro_kind).State = EntityState.Added;
                   
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

        public bool Update(ProKindNew prokind)
        {
            
            {
                Func<bool> func = new Func<bool>(() =>
                {

                   

                    _entity.Entry(prokind).State =EntityState.Modified;
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

                   

                    var prokind_new = _entity.ProKindNew
                    .Where(e => e.Num == num && e.StatVoid == 0)
                    .FirstOrDefault();
                    prokind_new.UpdateBy = update_by;
                    prokind_new.DtUpdate = DateTime.Now;
                    prokind_new.StatVoid = 1;

                    _entity.Entry(prokind_new).State =EntityState.Modified;

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }
        }


        public IEnumerable<zp_get_prokind_list_Result> GetProkindlist(string lang)
        {
            
            {
                Func<IEnumerable<zp_get_prokind_list_Result>> func = new Func<IEnumerable<zp_get_prokind_list_Result>>(() =>
                {

                   
                    int lang_type = LangConverter.Convert(lang);
                    var prokind_new = _entity.zp_get_prokind_list(lang_type)
                    .ToList();

                    return prokind_new;

                });

                return _adapter.Catch<IEnumerable<zp_get_prokind_list_Result>>(func);

            }
        }

        public IEnumerable<zp_get_prodkind_parent_Result> GetProdkindParent(int num)
        {
            
            {
                Func<IEnumerable<zp_get_prodkind_parent_Result>> func = new Func<IEnumerable<zp_get_prodkind_parent_Result>>(() =>
                {

                   
                    var prokind_new = _entity.zp_get_prodkind_parent(num).ToList();

                    return prokind_new;

                });

                return _adapter.Catch<IEnumerable<zp_get_prodkind_parent_Result>>(func);

            }
        }


        /// <summary>
        /// Tree
        /// </summary>
        /// <param name="langytpe"></param>
        /// <returns></returns>
        public IEnumerable<zp_get_cate_all_Result> GetCateAll(int langytpe)
        {
            
            {
                Func<IEnumerable<zp_get_cate_all_Result>> func = new Func<IEnumerable<zp_get_cate_all_Result>>(() =>
                {

                   
                    var prokind_new = _entity.zp_get_cate_all(langytpe).ToList();

                    return prokind_new;

                });

                return _adapter.Catch<IEnumerable<zp_get_cate_all_Result>>(func);
            }
        }



    }
}
