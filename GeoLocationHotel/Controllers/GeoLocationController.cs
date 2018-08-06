using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using GeoLocationHotel.Models;

namespace GeoLocationHotel.Controllers
{
    public class GeoLocationController : ApiController
    {
        [HttpGet]

        public JsonResult<List<City>> GET([FromUri]string location)

        {
            var collect = new WebClient().DownloadString("https://maps.googleapis.com/maps/api/place/autocomplete/json?input=" + location + "&types=geocode&language=en&key=AIzaSyBOjs6ak3PinIYUN-ZbV-2YrZSrAyUk6ns");
            var collection_Jason = JsonConvert.DeserializeObject<FirstObject>(collect);
            List<AutoComplete> placeName = collection_Jason.predictions;
            string output = placeName[0].description;
            var Hotels = new WebClient().DownloadString("https://maps.googleapis.com/maps/api/place/textsearch/json?query=hotels+in+" + place + "&radius=10000&key=AIzaSyBOjs6ak3PinIYUN-ZbV-2YrZSrAyUk6ns");
            var collection_Jason2 = JsonConvert.DeserializeObject<SecondObject>(result2);
            List<City> HotelList = collection_Jason2.Results;

            return Json(HotelList);
        }
    }
}
