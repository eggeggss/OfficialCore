using OfficialDAL.Common;
using OfficialDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace OfficialDAL.DAL
{
    public class ProductDAL
    {
        public string Location { set; get; }
        private EFAdapter _adapter;
        private MIRLE_WEBContext _entity;
        public ProductDAL(EFAdapter adapter,
            MIRLE_WEBContext entity)
        {
            Location = adapter.Location;
            _adapter = adapter;
            _entity = entity;
        }

        public ProductNew Get(int num)
        {
            
            {
                Func<ProductNew> func = new Func<ProductNew>(() => {

                     
                    var result = _entity.ProductNew.Where(e => e.Num == num 
                    && e.StatVoid == 0).ToList().FirstOrDefault();
                    return result;

                });

                return _adapter.Catch<ProductNew>(func);
            }
        }

        public IEnumerable<ProductNew> GetByKind(string lang, int pro_kind)
        {
            
            {
                Func<IEnumerable<ProductNew>> func = new Func<IEnumerable<ProductNew>>(() => {

                     
                    var result = _entity.ProductNew
                    .Where(e => e.ProKind.Equals(pro_kind.ToString()) 
                    && e.ProLang.Equals(lang)).ToList();
                    return result;

                });

                return _adapter.Catch<IEnumerable<ProductNew>>(func);
            }
        }

        public bool Insert(ProductNew product)
        {
            
            {
                Func<bool> func = new Func<bool>(() => {

                     

                    _entity.Entry(product).State =EntityState.Added;

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }

        }

        public bool Update(ProductNew product)
        {
            
            {
                Func<bool> func = new Func<bool>(() => {

                     
                    if (product.Person != null)
                        product.Person = product.Person.Trim();
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
                Func<bool> func = new Func<bool>(() => {

                     

                    var ProductNew = _entity.ProductNew
                    .Where(e => e.Num == num).FirstOrDefault();

                    _entity.Entry(ProductNew).State = EntityState.Deleted;

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }
        }


        public bool Delete(ProductNew product)
        {
            
            {
                Func<bool> func = new Func<bool>(() => {

                     

                    var ProductNew = _entity.ProductNew
                    .Where(e => e.Num == product.Num).FirstOrDefault();

                    _entity.ProductNew.Remove(product);

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }
        }

        public IEnumerable<zp_get_parent_cate_by_page_Result> GetParentPage(int num, int lang_type, int pageindex)
        {
            return GetParentPageSize(num, lang_type, 3, pageindex);
        }

        public IEnumerable<zp_get_parent_cate_by_page_Result> GetParentPageSize(int num, int lang_type, int pagesize, int pageindex)
        {
            
            {
                Func<IEnumerable<zp_get_parent_cate_by_page_Result>> func = new Func<IEnumerable<zp_get_parent_cate_by_page_Result>>(() => {

                     

                    var result = _entity
                    .zp_get_parent_cate_by_page((int)num, lang_type, 100, pageindex).ToList();

                    return result;

                });

                return _adapter.Catch<IEnumerable<zp_get_parent_cate_by_page_Result>>(func);
            }
        }

        public IEnumerable<zp_get_sub_cate_by_page_Result> GetSubPageALL(int prokind, int lang_type, int number, int pageindex)
        {
            
            {
                Func<IEnumerable<zp_get_sub_cate_by_page_Result>> func = new Func<IEnumerable<zp_get_sub_cate_by_page_Result>>(() => {

                     

                    var result = _entity
                    .zp_get_sub_cate_by_page((int)prokind, lang_type, number, pageindex).ToList();

                    return result;

                });

                return _adapter.Catch<IEnumerable<zp_get_sub_cate_by_page_Result>>(func);
            }

        }

        public IEnumerable<zp_get_product_new_list_Result> GetProductDetailAll(int lang_type, int pro_kind, string pro_name)
        {
            
            {
                Func<IEnumerable<zp_get_product_new_list_Result>> func = new Func<IEnumerable<zp_get_product_new_list_Result>>(() => {

                     

                    var result = _entity.zp_get_product_new_list(lang_type,
                        pro_kind, pro_name).ToList();
                    // var result= _entity.ProductNew.Where(e => e.pro_lang == lang && e.stat_void==0).ToList();

                    return result;

                });

                return _adapter.Catch<IEnumerable<zp_get_product_new_list_Result>>(func);
            }
        }


        public IList<ProductNew> GetParentForCarcoual(string pro_kind)
        {
            
            {
                Func<IList<ProductNew>> func = new Func<IList<ProductNew>>(() => {

                     

                    var result = _entity.ProductNew.Where(e => e.StatVoid == 0 &&
                    e.ProKind == pro_kind
                    ).ToList();
                    return result;

                });

                return _adapter.Catch<IList<ProductNew>>(func);
            }
        }


    }
}
