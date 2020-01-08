using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MirleOfficial.Common
{

    public static class EnumExtensions
    {
        /// <summary>
        /// Get the Description from the DescriptionAttribute.
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetEnumDescription(this Enum enumValue)
        {
            return enumValue.GetType()
                       .GetMember(enumValue.ToString())
                       .First()
                       .GetCustomAttribute<DescriptionAttribute>()?
                       .Description ?? string.Empty;
        }
    }

    public enum LangEnum
    {
        [Description("zh-TW")]
        zhTW,
        [Description("zh-CN")]
        zhCN,
        [Description("en-US")]
        enUS

    }

    public class LangConverter
    {

        public static String ConvertFormCode(String lang)
        {
            switch (lang)
            {
                case "zh-TW":
                    return "繁體";

                case "zh-CN":
                    return "簡體";

                default:
                    return "English";
            }
        }

        public static int Convert(string lang)
        {
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
                    return "繁體";
                case 1:
                    return "简体";//"簡體";
                default:
                    return "English";
            }
        }

        public static String ChangeLanguage(IRequestCookieCollection Cookies)
        {
            string MyLang = Cookies["Lang"];

            if (MyLang != null)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture =
                new System.Globalization.CultureInfo(MyLang);
                System.Threading.Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo(MyLang);

                return ConvertFormCode(MyLang);
            }
            else
            {
                return LangEnum.zhTW.GetEnumDescription();
            }
        }



    }
}
