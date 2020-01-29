using Microsoft.EntityFrameworkCore;
using OfficialDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficialDAL.Common
{
    public static class DbSPContextExtention
    {
        public static IList<String> zp_auto_complete(this MIRLE_WEBContext context,string content)
        {
            return null;
            //var result =
            //  context.zp_auto_complete
            //  .FromSqlInterpolated($@"execute dbo.zp_auto_complete
            //   {content}").ToList();

            //return result;
        }

        public static IEnumerable<zp_page_search_Result> zp_page_search(this MIRLE_WEBContext context,
            string content,int lang_type, int type)
        {

            var result =
              context.zp_page_search_Result
              .FromSqlInterpolated($@"execute dbo.zp_page_search
               {content} ,{lang_type} ,{type}").ToList();

            return result;
        }

        public static IEnumerable<zp_get_pronews_list_Result> zp_get_pronews_list(this MIRLE_WEBContext context,
             int lang_type)
        {

            var result =
               context.zp_get_pronews_list_Result
               .FromSqlInterpolated($@"execute dbo.zp_get_pronews_list
               {lang_type} ").ToList();

            return result;
        }

        public static IEnumerable<zp_get_parent_cate_by_page_Result> zp_get_parent_cate_by_page(this MIRLE_WEBContext context,
             int num,int lang_type,int number,int pageindex)
        {
            var result =
               context.zp_get_parent_cate_by_page_Result
               .FromSqlInterpolated($@"execute dbo.zp_get_parent_cate_by_page
               {num},{lang_type},{number},{pageindex} ").ToList();

            return result;
        }

        public static IEnumerable<zp_get_sub_cate_by_page_Result> zp_get_sub_cate_by_page(this MIRLE_WEBContext context,
            int prokind, int lang_type, int number, int pageindex)
        {

            var result =
               context.zp_get_sub_cate_by_page_Result
               .FromSqlInterpolated($@"execute dbo.zp_get_sub_cate_by_page
               {prokind},{lang_type},{number},{pageindex} ").ToList();

            return result;
        }

        public static IEnumerable<zp_get_product_new_list_Result> zp_get_product_new_list(this MIRLE_WEBContext context,
            int lang_type, int prokind,string pro_name)
        {

            var result =
               context.zp_get_product_new_list_Result
               .FromSqlInterpolated($@"execute dbo.zp_get_product_new_list
               {lang_type},{prokind},{pro_name}").ToList();

            return result;
        }

        public static IEnumerable<zp_get_prokind_list_Result> zp_get_prokind_list(this MIRLE_WEBContext context,
            int lang_type)
        {

            var result =
               context.zp_get_prokind_list_Result
               .FromSqlInterpolated($@"execute dbo.zp_get_prokind_list
               {lang_type}").ToList();

            return result;
        }

        public static IEnumerable<zp_get_prodkind_parent_Result> zp_get_prodkind_parent(this MIRLE_WEBContext context,
            int num)
        {

            var result =
              context.zp_get_prodkind_parent_Result
              .FromSqlInterpolated($@"execute dbo.zp_get_prodkind_parent
               {num}").ToList();

            return result;
        }

        public  static  IEnumerable<zp_get_cate_all_Result> zp_get_cate_all(this MIRLE_WEBContext context,
            int langytpe)
        {
            var result =
             context.zp_get_cate_all_Result
             .FromSqlInterpolated($@"execute dbo.zp_get_cate_all
               {langytpe}").ToList();

            return result;
        }
        public static IEnumerable<zp_get_solution_new_list_Result> zp_get_solution_new_list(this MIRLE_WEBContext context,
           int langytpe,int pro_kind,string pro_name)
        {

            var result =
            context.zp_get_solution_new_list_Result
            .FromSqlInterpolated($@"execute dbo.zp_get_solution_new_list
               {langytpe} ,{pro_kind},{pro_name}").ToList();

            return result;
        }

        public static IEnumerable<zp_get_solution_news_Result> zp_get_solution_news(
            this MIRLE_WEBContext context,
           int num, int type)
        {

            var result =
            context.zp_get_solution_news_Result
            .FromSqlInterpolated($@"execute dbo.zp_get_solution_news
               {num} ,{type}").ToList();

            return result;
        }

        public static IEnumerable<zp_get_sol_sub_cate_by_page_Result> zp_get_sol_sub_cate_by_page(this MIRLE_WEBContext context,
          int prokind, int lang_type, int number, int pageindex)
        {

            var result =
            context.zp_get_sol_sub_cate_by_page_Result
            .FromSqlInterpolated($@"execute dbo.zp_get_sol_sub_cate_by_page
               {prokind} ,{lang_type} ,{number},{pageindex}").ToList();

            return result;
        }


        public static IEnumerable<zp_get_sol_parent_cate_by_page_Result> zp_get_sol_parent_cate_by_page(this MIRLE_WEBContext context,
          int prokind, int lang_type, int number, int pageindex)
        {

            var result =
            context.zp_get_sol_parent_cate_by_page_Result
            .FromSqlInterpolated($@"execute dbo.zp_get_sol_parent_cate_by_page
               {prokind} ,{lang_type} ,{number},{pageindex}").ToList();

            return result;
        }


        public static IEnumerable<zp_get_solutionkind_list_Result> zp_get_solutionkind_list(this MIRLE_WEBContext context,
         int lang_type)
        {

            var result =
            context.zp_get_solutionkind_list_Result
            .FromSqlInterpolated($@"execute dbo.zp_get_solutionkind_list
               {lang_type}").ToList();

            return result;
        }

        public static IEnumerable<zp_get_solutionkind_list_detail_Result> zp_get_solutionkind_list_detail(this MIRLE_WEBContext context,
        int lang_type)
        {

            var result =
            context.zp_get_solutionkind_list_detail_Result
            .FromSqlInterpolated($@"execute dbo.zp_get_solutionkind_list_detail
               {lang_type}").ToList();

            return result;
        }

        public static IEnumerable<zp_get_news_sol_category_Result> zp_get_news_sol_category(this MIRLE_WEBContext context,
          int num, int lang_type)
        {

            var result =
           context.zp_get_news_sol_category_Result
           .FromSqlInterpolated($@"execute dbo.zp_get_news_sol_category
               {num},{lang_type}").ToList();

            return result;
        }

        //zp_get_news_sol_category



    }
}
