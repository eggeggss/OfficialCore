using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOfficialCommon
{
    public class Common
    {
        public class LangConverter
        {
            public static int Convert(string lang)
            {
                lang = lang.TrimEnd();
                switch (lang)
                {
                    case "中文":
                    case "繁體":
                        return 0;
                    case "簡體":
                    case "简体":
                        return 1;
                    default:
                        return 2;
                }
            }


            public static string DeConvert(int langtype)
            {
                switch (langtype)
                {
                    case 0:
                        return "中文";
                    case 1:
                        return "簡體";
                    default:
                        return "English";
                }
            }
        }

    }
}
