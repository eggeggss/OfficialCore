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
    public class SolutionDAL
    {
        public string Location { set; get; }
        private EFAdapter _adapter;
        private MIRLE_WEBContext _entity;
        public SolutionDAL(EFAdapter adapter,
            MIRLE_WEBContext entity)
        {
            Location = adapter.Location;
            _adapter = adapter;
            _entity = entity;
        }


        public SolutionNew Get(int num)
        {
            
                Func<SolutionNew> func = new Func<SolutionNew>(() => {

                    
                    var result = _entity.SolutionNew
                    .Where(e => e.Num == num
                    && e.StatVoid == 0).ToList().FirstOrDefault();
                    return result;

                });

                return _adapter.Catch<SolutionNew>(func);
            
        }

        public IEnumerable<SolutionNew> GetByKind(int lang_type, int pro_kind)
        {
            
            {
                Func<IEnumerable<SolutionNew>> func = new Func<IEnumerable<SolutionNew>>(() => {

                    
                    var result = _entity.SolutionNew
                    .Where(e => e.ProKind.Equals(pro_kind.ToString())
                    && e.LangType == lang_type && e.StatVoid == 0).ToList();
                    return result;

                });

                return _adapter.Catch<IEnumerable<SolutionNew>>(func);
            }
        }

        public bool Insert(SolutionNew product)
        {
            
                Func<bool> func = new Func<bool>(() => {

                    

                    _entity.SolutionNew.Add(product);

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            

        }



        public bool Update(SolutionNew product)
        {
            
                Func<bool> func = new Func<bool>(() => {

                    

                    _entity.Entry(product).State = EntityState.Modified;
                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            
        }

        public bool Delete(SolutionNew product)
        {
            //
            {
                Func<bool> func = new Func<bool>(() => {

                    

                    var product_new = _entity.SolutionNew
                    .Where(e => e.Num == product.Num).FirstOrDefault();

                    _entity.SolutionNew.Remove(product_new);

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }
        }

        public bool Delete(int num)
        {
            //
            {
                Func<bool> func = new Func<bool>(() => {

                    

                    var product_new = _entity.SolutionNew.Where(e => e.Num == num)
                    .FirstOrDefault();

                    product_new.StatVoid = 1;
                    product_new.DtUpdate = DateTime.Now;
                    _entity.Entry(product_new).State = EntityState.Modified;

                    //_entity.SolutionNew.Remove(product_new);

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }
        }


        public IEnumerable<zp_get_sol_parent_cate_by_page_Result> GetParentPage(int num, int lang_type, int pageindex)
        {
            //
            {
                Func<IEnumerable<zp_get_sol_parent_cate_by_page_Result>> func = new Func<IEnumerable<zp_get_sol_parent_cate_by_page_Result>>(() => {

                    

                    var result = _entity.zp_get_sol_parent_cate_by_page((int)num, lang_type, 3, pageindex).ToList();

                    return result;

                });

                return _adapter.Catch<IEnumerable<zp_get_sol_parent_cate_by_page_Result>>(func);
            }
        }

        public IEnumerable<zp_get_sol_sub_cate_by_page_Result> GetSubPageALL(int prokind, int lang_type, int number, int pageindex)
        {
            //
            {
                Func<IEnumerable<zp_get_sol_sub_cate_by_page_Result>> func = new Func<IEnumerable<zp_get_sol_sub_cate_by_page_Result>>(() => {

                    

                    var result = _entity.zp_get_sol_sub_cate_by_page((int)prokind, lang_type, number, pageindex).ToList();

                    return result;

                });

                return _adapter.Catch<IEnumerable<zp_get_sol_sub_cate_by_page_Result>>(func);
            }

        }


        public IEnumerable<zp_get_solution_new_list_Result> GetProductDetailAll(int lang_type, int pro_kind, string pro_name)
        {
            //
            {
                Func<IEnumerable<zp_get_solution_new_list_Result>> func = new Func<IEnumerable<zp_get_solution_new_list_Result>>(() => {

                    

                    var result = _entity.zp_get_solution_new_list(lang_type, pro_kind, pro_name).ToList();
                    // var result= _entity.product_new.Where(e => e.pro_lang == lang && e.stat_void==0).ToList();

                    return result;

                });

                return _adapter.Catch<IEnumerable<zp_get_solution_new_list_Result>>(func);
            }
        }

        public IEnumerable<zp_get_solution_news_Result> GetSolutionNews(int num, int type)
        {
            //
            {
                Func<IEnumerable<zp_get_solution_news_Result>> func = new Func<IEnumerable<zp_get_solution_news_Result>>(() => {

                    

                    var result = _entity.zp_get_solution_news(num, type).ToList();

                    return result;

                });

                return _adapter.Catch<IEnumerable<zp_get_solution_news_Result>>(func);
            }
        }



    }
}
