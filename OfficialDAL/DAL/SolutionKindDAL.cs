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
    public class SolutionKindDAL
    {
        public string Location { set; get; }
        private EFAdapter _adapter;
        private MIRLE_WEBContext _entity;
        public SolutionKindDAL(EFAdapter adapter,
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
        public IEnumerable<solution_kind_present> GetAllCategory(int lang_type)
        {
            //
            //{
                Func<IEnumerable<solution_kind_present>> func = new Func<IEnumerable<solution_kind_present>>(() =>
                {
                    //_entity._optionsBuilder = new DbContextOptionsBuilder();

                    //_entity._optionsBuilder.UseSqlServer(this._adapter.DbString);

                    var result = _entity.SolutionKindNew
                    .Where(e => e.StatVoid == 0
                     && e.LangType == lang_type
                     && e.Root == 0
                     && e.StatVoid == 0)
                    .OrderBy((e) => e.Range)
                    .Select(e => new solution_kind_present()
                    {
                        num = e.Num,
                        kind = e.Kind

                    }).ToList();
                    return result;

                });

                return _adapter.Catch<IEnumerable<solution_kind_present>>(func);
            //}
        }


        public IEnumerable<SolutionKindNew> GetByLangNum(int lang_type, int num)
        {
            //
            {
                Func<IEnumerable<SolutionKindNew>> func = new Func<IEnumerable<SolutionKindNew>>(() =>
                {

                    //
                    var result = _entity.SolutionKindNew.Where(
                        e => e.LangType== lang_type
                        && e.Num == num
                        && e.StatVoid == 0).ToList();
                    return result;

                });

                return _adapter.Catch<IEnumerable<SolutionKindNew>>(func);
            }
        }


        public IEnumerable<SolutionKindNew> GetByLangNumByid(int lang_type, int num)
        {
            //
            {
                Func<IEnumerable<SolutionKindNew>> func = new Func<IEnumerable<SolutionKindNew>>(() =>
                {

                    //
                    var result = _entity.SolutionKindNew.Where(e => e.LangType == lang_type
                    && e.Num == num && e.StatVoid == 0).ToList();
                    return result;

                });

                return _adapter.Catch<IEnumerable<SolutionKindNew>>(func);
            }
        }

        public IEnumerable<SolutionKindNew> GetByLangRoot(int lang_type, int root)
        {
            //
            {
                Func<IEnumerable<SolutionKindNew>> func = new Func<IEnumerable<SolutionKindNew>>(() =>
                {

                    //
                    var result = _entity.SolutionKindNew.Where(e => e.LangType == lang_type
                    && e.Root == root
                    && e.StatVoid == 0).ToList();
                    return result;
                });
                return _adapter.Catch<IEnumerable<SolutionKindNew>>(func);
            }
        }


        public IEnumerable<SolutionKindNew> Get(int num)
        {
            //
            {
                Func<IEnumerable<SolutionKindNew>> func = new Func<IEnumerable<SolutionKindNew>>(() =>
                {

                    //
                    var result = _entity.SolutionKindNew.Where(e => e.Num == num 
                    && e.StatVoid == 0).ToList();
                    return result;

                });
                return _adapter.Catch<IEnumerable<SolutionKindNew>>(func);
            }
        }

        public bool Insert(SolutionKindNew solution_kind)
        {
            //
            {
                Func<bool> func = new Func<bool>(() =>
                {

                    //

                    _entity.SolutionKindNew.Add(solution_kind);

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }

        }

        public bool Update(SolutionKindNew solution_kind)
        {
            //
            {
                Func<bool> func = new Func<bool>(() =>
                {

                    //

                    var solutionkind_new = _entity.SolutionKindNew
                    .Where(e => e.Num == solution_kind.Num).FirstOrDefault();

                    solutionkind_new.Kind = solution_kind.Kind;
                    solutionkind_new.Range = solution_kind.Range;
                    solutionkind_new.Pic1 = solution_kind.Pic1;
                    solutionkind_new.DtUpdate = DateTime.Now;
                    solutionkind_new.UpdateBy = solution_kind.UpdateBy;



                    _entity.Entry(solutionkind_new).State = EntityState.Modified;
                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }
        }

        public bool Delete(SolutionKindNew solution_kind)
        {
            //
            {
                Func<bool> func = new Func<bool>(() =>
                {

                    //

                    var solution_kind_new = _entity.SolutionKindNew
                    .Where(e => e.Num == solution_kind.Num && e.StatVoid == 0)
                    .FirstOrDefault();

                    _entity.SolutionKindNew.Remove(solution_kind_new);

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }
        }

        public bool Delete(int num, string username)
        {
            //
            {
                Func<bool> func = new Func<bool>(() =>
                {

                    //

                    var solution_kind_new = _entity.SolutionKindNew
                    .Where(e => e.Num == num && e.StatVoid == 0).FirstOrDefault();

                    solution_kind_new.DtUpdate = DateTime.Now;
                    solution_kind_new.UpdateBy = username;
                    solution_kind_new.StatVoid = 1;

                    _entity.Entry(solution_kind_new).State = EntityState.Modified;

                    //_entity.Solution_kind_new.Remove(solution_kind_new);

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }
        }

        public bool InsertSolRel(IList<SolutionNewsRel> sol_rel_news)
        {

            //
            {
                Func<bool> func =
                    new Func<bool>(() =>
                    {

                       // 

                        foreach (var item in sol_rel_news)
                        {

                            SolutionNewsRel solnews = new SolutionNewsRel();
                            solnews.IdNews = item.IdNews;
                            solnews.IdSolution = item.IdSolution;
                            solnews.DtCreate = DateTime.Now;
                            solnews.StatVoid = 0;
                            _entity.SolutionNewsRel.Add(solnews);
                            //_entity.Entry(solnews).State = System.Data._entity._entityState.Added;
                            _entity.SaveChanges();

                        }
                        return true;

                    });

                return _adapter.Catch<bool>(func);

            }

        }

        public bool DeleteSolRel(int id_news)
        {
            //
            {
                Func<bool> func =
                    new Func<bool>(() =>
                    {

                        //

                        var sol_news = _entity.SolutionNewsRel.Where((e) => e.IdNews == id_news
                        && e.StatVoid == 0).ToList();

                        foreach (var item in sol_news)
                        {
                            item.StatVoid = 1;
                            item.DtUpdate = DateTime.Now;
                            _entity.Entry(item).State = EntityState.Modified;
                            _entity.SaveChanges();
                        }
                        return true;

                    });

                return _adapter.Catch<bool>(func);

            }

        }


        public IEnumerable<zp_get_solutionkind_list_Result> GetProkindlist(int lang_type)
        {
           // 
            {
                Func<IEnumerable<zp_get_solutionkind_list_Result>> func =
                    new Func<IEnumerable<zp_get_solutionkind_list_Result>>(() =>
                    {

                        //

                        var prokind_new = _entity.zp_get_solutionkind_list(lang_type).ToList();

                        return prokind_new;

                    });

                return _adapter.Catch<IEnumerable<zp_get_solutionkind_list_Result>>(func);

            }
        }

        public IEnumerable<zp_get_solutionkind_list_detail_Result> GetProkindlistDetail(int lang_type)
        {
            //
            {
                Func<IEnumerable<zp_get_solutionkind_list_detail_Result>> func =
                    new Func<IEnumerable<zp_get_solutionkind_list_detail_Result>>(() =>
                    {

                       // 

                        var prokind_new = _entity.zp_get_solutionkind_list_detail(lang_type).ToList();

                        return prokind_new;

                    });

                return _adapter.Catch<IEnumerable<zp_get_solutionkind_list_detail_Result>>(func);

            }
        }


        public IEnumerable<zp_get_news_sol_category_Result> GetNewsSolCate(int num, int lang_type)
        {
            //
            {
                Func<IEnumerable<zp_get_news_sol_category_Result>> func =
                    new Func<IEnumerable<zp_get_news_sol_category_Result>>(() =>
                    {

                        //

                        var prokind_new = _entity.zp_get_news_sol_category(num, lang_type).ToList();

                        return prokind_new;

                    });

                return _adapter.Catch<IEnumerable<zp_get_news_sol_category_Result>>(func);

            }
        }



        public IEnumerable<SolutionKindNew> GetByLangRootByid(int lang_type, int root)
        {
            //
            {
                Func<IEnumerable<SolutionKindNew>> func = new Func<IEnumerable<SolutionKindNew>>(() =>
                {

                    //
                    var result = _entity.SolutionKindNew.Where(e => e.LangType == lang_type
                    && e.Root == root && e.StatVoid == 0).ToList().OrderBy(e => e.Range);
                    return result;
                });
                return _adapter.Catch<IEnumerable<SolutionKindNew>>(func);
            }
        }
    }



}

