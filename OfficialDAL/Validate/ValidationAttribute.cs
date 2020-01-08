using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OfficialDAL
{
    public class pic1LenthCheck : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            string lengh = "";
            if (value == null)
            {
                lengh = "";
            }
            else
            {
                lengh = (String)value;
            }

            if (lengh.Length > 50)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
