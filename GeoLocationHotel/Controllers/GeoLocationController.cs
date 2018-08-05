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
            var result = new WebClient().DownloadString("https://maps.googleapis.com/maps/api/place/autocomplete/json?input=" + location + "&types=geocode&language=en&key=AIzaSyBOjs6ak3PinIYUN-ZbV-2YrZSrAyUk6ns");
            var Jsonobject = JsonConvert.DeserializeObject<FirstObject>(result);
            List<AutoComplete> autocomplete = Jsonobject.predictions;
            string place = autocomplete[0].description;
            var result2 = new WebClient().DownloadString("https://maps.googleapis.com/maps/api/place/textsearch/json?query=hotels+in+" + place + "&radius=10000&key=AIzaSyBOjs6ak3PinIYUN-ZbV-2YrZSrAyUk6ns");
            var Jsonobject1 = JsonConvert.DeserializeObject<SecondObject>(result2);
            List<City> HotelList = Jsonobject1.Results;

            return Json(HotelList);
        }
    }
}