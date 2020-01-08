using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MirleOfficial.ViewModel;
using OfficialDAL.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirleOfficial.Common
{
    public class MymvcController : Controller
    {
        public FirstViewModel firstViewModel { set; get; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var cookie = context.HttpContext.Request.Cookies;

            var MyLang = cookie["Lang"];

            if (MyLang != null)
            {
                ViewBag.Lang = LangConverter.ConvertFormCode(MyLang);
            }
            else
            {
                ViewBag.Lang = "繁體";
            }

            this.Lang = ViewBag.Lang;

            this.lang_type = LangConverter.Convert(this.Lang);
            ViewBag.LangType = this.lang_type;

            FirstViewModel = _serviceProvider.GetService<FirstViewModel>();
            FirstViewModel.SetData(this.Lang);
            ViewBag.FirstViewModel = FirstViewModel;
        }

        public String Site { set; get; }
        public String Lang { set; get; }

        public int news_start_id { set; get; }
        public int prodnew_start_id { set; get; }

        public int lang_type { set; get; }

        public int LangType { set; get; }

        private Profile _profile { get; set; }

        public FirstViewModel FirstViewModel { get; set; }

        //public MymvcController(IOptionsSnapshot<Profile> profile, 
        //    FirstViewModel firstviewmodel)
        //{
        //    _profile = profile.Value;
        //    Site = _profile.Site;
        //    FirstViewModel = firstviewmodel;
        //    FirstViewModel.SetData(this.Lang);
        //    //ViewBag.FirstViewModel = FirstViewModel;
        //    //actionContextAccessor.ActionContext.HttpContext.Request.Cookies;
        //    //ViewBag.Lang=LangConverter.ChangeLanguage(Request.Cookies);
        //}

        private IServiceProvider _serviceProvider;

        public MymvcController(IServiceProvider serviceProvider)
        {
            var profile = serviceProvider.GetService<IOptionsSnapshot<Profile>>();
            _serviceProvider = serviceProvider;
            _profile = profile.Value;
            Site = _profile.Site;

            
        }
    }


    public class MymvcAdmController : MymvcController
    {
        public bool CanLogin { set; get; }
        public string UserName { set; get; }
        public MymvcAdmController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            CanLogin = CheckAuth();

        }

        public ActionResult CallBaseView(Func<ActionResult> func)
        {

            if (!CheckAuth())
            {
                return RedirectLogin();
            }
            else
            {
                ViewBag.UserName = User.Identity.Name;
            }
            return func();
        }

        protected ActionResult RedirectLogin()
        {
            return RedirectToAction("Login", "Admin");
        }

        private bool CheckAuth()
        {

            if (User == null)
            {
                return false;
            }
            else
            {
                UserName = User.Identity.Name;
                return User.Identity.IsAuthenticated;

            }

        }
    }
}
