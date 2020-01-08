using OfficialDAL;
using OfficialDAL.DAL;
using OfficialDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficialBLL
{
    public class SolutionService
    {

        private SolutionDAL _SolutionDAL;
        public SolutionDAL SolutionDAL
        {
            set;get;
        }

        private SolutionKindDAL _SolutionKindDAL;

        public SolutionKindDAL SolutionKindDAL
        {
            set;get;
        }


        public SolutionService(SolutionDAL solutionDAL, SolutionKindDAL solutionKindDAL)
        {
            //Location = location;
            SolutionKindDAL = solutionKindDAL;
            SolutionDAL = solutionDAL;
        }

        public IEnumerable<solution_kind_present> GetAllCategory(int lang_type)
        {
            IEnumerable<solution_kind_present> result = null;
            try
            {
                return this.SolutionKindDAL.GetAllCategory(lang_type);

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
        public IEnumerable<SolutionKindNew> GetProductFirstCategory(int lang_type, int num)
        {
            IEnumerable<SolutionKindNew> result = null;
            try
            {
                return this.SolutionKindDAL.GetByLangNum(lang_type, num);

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
        public IEnumerable<SolutionKindNew> GetProductSecondCategory(int lang_type, int root)
        {
            IEnumerable<SolutionKindNew> result = null;
            try
            {
                return this.SolutionKindDAL.GetByLangRoot(lang_type, root);

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
        public IEnumerable<SolutionNew> GetProductThirdCategory(int lang_type, int pro_kind)
        {
            IEnumerable<SolutionNew> result = null;
            try
            {
                return this.SolutionDAL.GetByKind(lang_type, pro_kind);

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
        public SolutionNew GetProductDetail(int num)
        {
            SolutionNew result = null;
            try
            {
                return this.SolutionDAL.Get(num);

            }
            catch (Exception ex)
            {
                return result;
            }
        }


        public IEnumerable<zp_get_sol_parent_cate_by_page_Result> GetParentCategoryByPage(int num, int lang_type, int pageindex)
        {
            try
            {
                return this.SolutionDAL.GetParentPage(num, lang_type, pageindex);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public IEnumerable<zp_get_sol_sub_cate_by_page_Result> GetSubCategoryByPage(int prokind, int lang_type, int number, int pageindex)
        {
            try
            {
                return this.SolutionDAL.GetSubPageALL(prokind, lang_type, number, pageindex);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Search All
        /// </summary>
        /// <param name="lang_type"></param>
        /// <returns></returns>
        public IEnumerable<zp_get_solution_new_list_Result> GetProductDetailAll(int lang_type)
        {
            try
            {
                return this.SolutionDAL.GetProductDetailAll(lang_type, 0, "");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Search All
        /// </summary>
        /// <param name="lang_type"></param>
        /// <returns></returns>
        public IEnumerable<zp_get_solution_new_list_Result> FilterProductDetail(int lang_type, int pro_kind, string pro_name)
        {
            try
            {
                return this.SolutionDAL.GetProductDetailAll(lang_type, pro_kind, pro_name);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 取得prod_kind清單
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public IEnumerable<zp_get_solutionkind_list_Result> GetProdKindsListAll(int lang_type)
        {
            try
            {

                return this.SolutionKindDAL.GetProkindlist(lang_type);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public IEnumerable<zp_get_solution_news_Result> GetSolutionNews(int num, int type)
        {
            try
            {

                return this.SolutionDAL.GetSolutionNews(num, type);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<zp_get_solutionkind_list_detail_Result> GetProkindlistDetail(int lang_type)
        {
            try
            {

                return this.SolutionKindDAL.GetProkindlistDetail(lang_type);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<zp_get_news_sol_category_Result> GetNewsSolCate(int num, int lang_type)
        {
            try
            {

                return this.SolutionKindDAL.GetNewsSolCate(num, lang_type);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #region Transaction

        public bool UpdateProd(SolutionNew prod_new)
        {
            try
            {
                return this.SolutionDAL.Update(prod_new);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateSolRel(int id_news, string[] id_solutions)
        {
            try
            {
                //using (TransactionScope tsCope = new TransactionScope())
                {

                    this.SolutionKindDAL.DeleteSolRel(id_news);
                    IList<SolutionNewsRel> solnewsrel = new List<SolutionNewsRel>();

                    foreach (var item in id_solutions)
                    {
                        solnewsrel.Add(new SolutionNewsRel
                        {
                            IdNews = id_news,
                            IdSolution = Convert.ToInt32(item),
                        });
                    }
                    this.SolutionKindDAL.InsertSolRel(solnewsrel);

                    //tsCope.Complete();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool InsertProd(SolutionNew prod_new)
        {
            try
            {
                return this.SolutionDAL.Insert(prod_new);
            }
            catch (Exception ex)
            {
                throw new Exception($"SolutionService:{ex.Message}");
            }
        }
        #endregion



    }
}
