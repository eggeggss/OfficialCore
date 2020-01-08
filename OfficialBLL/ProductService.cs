using OfficialDAL;
using OfficialDAL.DAL;
using OfficialDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficialBLL
{
    public class ProductService
    {
        public ProKindDAL Prokind_dal
        {
            set;get;
        }

        public ProductDAL Product_dal
        {
            set;get;
        }


        public ProductService(ProductDAL proddal, ProKindDAL prodkinddal )
        {
            //Location = location;
            Product_dal = proddal;
            Prokind_dal = prodkinddal;
        }

        /// <summary>
        /// 最上層的分類
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public IEnumerable<pro_kind_present> GetAllCategory(int lang_type)
        {
            IEnumerable<pro_kind_present> result = null;
            try
            {
                return this.Prokind_dal.GetAllCategory(lang_type);

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
        public IEnumerable<ProKindNew> GetProductFirstCategory(int lang_type, int num)
        {
            IEnumerable<ProKindNew> result = null;
            try
            {
                return this.Prokind_dal.GetByLangNum(lang_type, num);

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
        public IEnumerable<ProKindNew> GetProductSecondCategory(int lang_type, int root)
        {
            IEnumerable<ProKindNew> result = null;
            try
            {
                return this.Prokind_dal.GetByLangRoot(lang_type, root);

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
        public IEnumerable<ProductNew> GetProductThirdCategory(string lang, int pro_kind)
        {
            IEnumerable<ProductNew> result = null;
            try
            {
                return this.Product_dal.GetByKind(lang, pro_kind);

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
        public ProductNew GetProductDetail(int num)
        {
            ProductNew result = null;
            try
            {
                return this.Product_dal.Get(num);

            }
            catch (Exception ex)
            {
                return result;
            }
        }



        public IEnumerable<zp_get_parent_cate_by_page_Result> GetParentCategoryByPage(int num, int lang_type, int pageindex)
        {
            try
            {
                return this.Product_dal.GetParentPage(num, lang_type, pageindex);
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public IEnumerable<zp_get_parent_cate_by_page_Result> GetParentCategoryByPageSize(int num, int lang_type, int size, int pageindex)
        {
            try
            {
                return this.Product_dal.GetParentPageSize(num, lang_type, size, pageindex);
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public IEnumerable<zp_get_sub_cate_by_page_Result> GetSubCategoryByPage(int prokind, int lang_type, int number, int pageindex)
        {
            try
            {
                return this.Product_dal.GetSubPageALL(prokind, lang_type, number, pageindex);
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
        public IEnumerable<zp_get_product_new_list_Result> GetProductDetailAll(int lang_type)
        {
            try
            {
                return this.Product_dal.GetProductDetailAll(lang_type, 0, "");
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
        public IEnumerable<zp_get_product_new_list_Result> FilterProductDetail(int lang_type, int pro_kind, string pro_name)
        {
            try
            {
                return this.Product_dal.GetProductDetailAll(lang_type, pro_kind, pro_name);
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
        public IEnumerable<zp_get_prokind_list_Result> GetProdKindsListAll(string lang)
        {
            try
            {

                return this.Prokind_dal.GetProkindlist(lang);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public IEnumerable<ProKindNew> GetByLangRootByid(int lang_type, int root)
        {
            try
            {

                return this.Prokind_dal.GetByLangRootByid(lang_type, root);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IList<ProductNew> GetParentForCarcoual(string pro_kind)
        {
            try
            {
                return this.Product_dal.GetParentForCarcoual(pro_kind);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #region Transaction

        public bool UpdateProd(ProductNew prod_new)
        {
            try
            {
                return this.Product_dal.Update(prod_new);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool InsertProd(ProductNew prod_new)
        {
            try
            {
                return this.Product_dal.Insert(prod_new);
            }
            catch (Exception ex)
            {
                throw new Exception($"ProductService:{ex.Message}");
            }
        }



        public bool DeleteProd(int num)
        {
            try
            {
                return this.Product_dal.Delete(num);
            }
            catch (Exception ex)
            {
                throw new Exception($"ProductService:{ex.Message}");
            }
        }

        public IEnumerable<zp_get_prodkind_parent_Result> GetProdkindParent(int num)
        {


            try
            {
                return this.Prokind_dal.GetProdkindParent(num);
            }
            catch (Exception ex)
            {
                throw new Exception($"ProductService:{ex.Message}");
            }
        }


        public IEnumerable<zp_get_cate_all_Result> GetCateAll(int langytpe)
        {
            try
            {
                return this.Prokind_dal.GetCateAll(langytpe);
            }
            catch (Exception ex)
            {
                throw new Exception($"ProductService GetCateAll:{ex.Message}");
            }
        }


        #endregion


    }
}
