using Microsoft.AspNetCore.Mvc;

namespace TestWebApi.Controllers
{
    [Route("api/cities")]
    public class CItyController : ControllerBase
    {

        [HttpGet]
        public JsonResult GetCities()
        {
            return new JsonResult(CitiesDataStore.current.cities);
        }

        [HttpGet("{id}")]
        public JsonResult GetCity(int id)
        {
            return new JsonResult(CitiesDataStore.current.cities.FirstOrDefault((city) => city.Id == id));
        }
    }
}
