using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOfficialCommon
{
    public class Interface
    {

        public interface IKind
        {

        }

        public interface IKindDAL<T1> : IKind
        {
            string Location { get; set; }

            bool Delete(int num, string update_by);
            IEnumerable<T1> Get(int num);
            IEnumerable<T1> GetByLangNumByid(int lang_type, int num);
            IEnumerable<T1> GetByLangRoot(int lang_type, int root);
            IEnumerable<T1> GetByLangRootByid(int lang_type, int root);
            bool Insert(T1 pro_kind);
            bool Update(T1 prokind);
        }

        public interface IKindGetAllCategory<T> : IKind
        {
            IEnumerable<T> GetAllCategory(int lang_type);
        }

        public interface IKindGetProkindlist<T> : IKind
        {
            IEnumerable<T> GetProkindlist(int lang_type);
        }
    }
}
