using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MirleOfficial.Common;
using MirleOfficial.ViewModel;

namespace MirleOfficial.Controllers
{

    public class QAResult
    {
        public string request { set; get; }
        public string response { set; get; }
    }

    [Route("api/menus")]
    public class AProductController : ControllerBase
    {
        private FirstViewModel _firstvm;

        public AProductController(FirstViewModel firstvm) : base()
        {
            _firstvm = firstvm;
        }

        [HttpGet("all/{lang}")]
        //[OutputCache(Duration = 300)]
        //[ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]

        public ActionResult<FirstViewModel> GetMenuCategory(int langtype)
        {
            string lang=LangConverter.DeConvert(langtype);
            
            _firstvm.SetData(lang);
            return _firstvm;

        }



        //[HttpGet("findkey/{term}")]
        //public IEnumerable<String> Find(string term)
        //{
        //    CarouselService service = new CarouselService(this.Site);

        //    return service.AutoComplete(term);
        //}
    }

}