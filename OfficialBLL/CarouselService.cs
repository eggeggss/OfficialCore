using OfficialDAL;
using OfficialDAL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficialBLL
{
    public class CarouselService
    {
        public string Location { set; get; }

        public CarouselDAL _carouseldal;


        public CarouselDAL CarouselDAL
        {
            get
            {
                return this._carouseldal;
            }
        }

        public CarouselService(CarouselDAL carousedal)
        {
            Location = carousedal.Location;
            this._carouseldal = carousedal;
        }

        public IEnumerable<carousel_present> GetCarouselAllForExpire(int lang_type)
        {
            return this.CarouselDAL.GetAllForExpire(lang_type);
        }

        public IEnumerable<carousel_present> GetCarouselAll(int lang_type)
        {
            return this.CarouselDAL.GetAll(lang_type);
        }

        public IList<String> AutoComplete(string content)
        {
            return this.CarouselDAL.AutoComplete(content);
        }

        public IEnumerable<zp_page_search_Result> SearchPage(int lang_type, string content, int type)
        {
            return this.CarouselDAL.SearchPage(lang_type, content, type);
        }

    }
}
