using System;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MirleOfficial.Common;
using MirleOfficial.Models;
using MirleOfficial.ViewModel;
using OfficialDAL.Meta;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.AspNetCore.Localization;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace MirleOfficial.Controllers
{
    public class ImageResult : ActionResult
    {
        public ImageResult(Stream imageStream, string contentType)
        {
            if (imageStream == null)
                throw new ArgumentNullException("imageStream");
            if (contentType == null)
                throw new ArgumentNullException("contentType");

            this.ImageStream = imageStream;
            this.ContentType = contentType;
        }

        public Stream ImageStream { get; set; }
        public string ContentType { get; set; }

        

        public async override Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            var response = context.HttpContext.Response;

            response.ContentType = this.ContentType;

            byte[] buffer = new byte[4096];
            while (true)
            {
                int read = this.ImageStream.Read(buffer, 0, buffer.Length);
                if (read == 0)
                    break;

                await response.Body.WriteAsync(buffer, 0, read);
                //response.OutputStream.Write(buffer, 0, read);
            }          
            //return context.HttpContext.Abort();
            //response.End();
        }
    }

    public class HomeController : MymvcController
    {
        private readonly ILogger<HomeController> _logger;
        private object hostingEnv;

        //public HomeController(IOptionsSnapshot<Profile> profile,
        //    FirstViewModel firstviewmodel) :base(profile,firstviewmodel)
        //{
        //    //_logger = logger;
        //}

        private IWebHostEnvironment _hostingEnvironment;
        //private IHttpContextAccessor _accessor;
        public HomeController(IServiceProvider serviceProvider, 
            IWebHostEnvironment hostingEnvironment
            ) :base(serviceProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            
            //_accessor = accessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[OutputCache(Duration = 300)]
        public ActionResult Thumbnail(string filename, int width, int height)
        {
            var root = this._hostingEnvironment.WebRootPath;
            root = Path.Combine(root, filename);
            var stream = new System.IO.MemoryStream();
            filename = root.Replace("~/", "").Replace("/", "\\");
            //// Image.Load(string path) is a shortcut for our default type. 
            //// Other pixel formats use Image.Load<TPixel>(string path))
            //using (Image image = Image.Load(filename))
            //{

            //    image.Mutate(x => x
            //         .Resize(width, height)
            //         .Grayscale());
            //    // image.Save($"bar_{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ms")}.jpg"); // Automatic encoder selected based on extension.

            //    image.Save(stream, JpegFormat.Instance);
            //}

            var image = System.IO.File.OpenRead(filename);
            
            return File(image, "image/jpeg");


            //return new ImageResult(stream, "binary/octet-stream");


            //return null;
            /*
            WebImage img = null;
            try
            {
                img = new WebImage(filename)
                   .Resize(width, height, false, false);
            }
            catch (Exception ex)
            {
                img = new WebImage(Server.MapPath("~/Images/control.jpeg"))
                    .Resize(width, height, false, false);
            }

            MemoryStream mem = new MemoryStream(img.GetBytes());
            return new ImageResult(mem, "binary/octet-stream");*/


        }

        [HttpPost]
        public ActionResult Upload(IFormFile upload)

        {

            //var fileName = System.IO.Path.GetFileName(upload.FileName);

            //var filePhysicalPath = Server.MapPath("~/Upload/common/" + fileName);


            //upload.SaveAs(filePhysicalPath);


            //var url = "/Upload/common/" + fileName;

            //var CKEditorFuncNum = HttpContext.Current.Request["CKEditorFuncNum"];

            //return Content("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\");</script>");
            return null;
        }
        
        //public ActionResult ChangeLang(String lang)
        //{
        //    var option = new CookieOptions();
        //    option.Expires = DateTime.Now.AddYears(1);
        //    /*
        //    HttpCookie cookie = new HttpCookie("Lang");
        //    cookie.Value = lang;
        //    cookie.Expires = DateTime.Now.AddYears(1);*/

        //    Response.Cookies.Append("Lang",lang,option);
        //    return RedirectToAction("Index");
        //}

        public IActionResult ChangeLang(string Lang)
        {
            
            string lang = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(Lang));
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, lang);
            return RedirectToAction("Index", "Home");//重新導向至Index Action
        }
        public ActionResult ChangeLangForAdmin(String lang)
        {
            var option = new CookieOptions();
            option.Expires = DateTime.Now.AddYears(1);
            /*
            HttpCookie cookie = new HttpCookie("Lang");
            cookie.Value = lang;
            cookie.Expires = DateTime.Now.AddYears(1);*/

            Response.Cookies.Append("Lang", lang, option);
            return RedirectToAction("Dashboard", "Admin");
        }

        public ActionResult SiteMap()
        {
            return View("SiteMap");

        }

        public ActionResult FileDownload()
        {
            return View("FileDownload");

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
