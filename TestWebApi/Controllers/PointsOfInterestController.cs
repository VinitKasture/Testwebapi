using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestWebApi.Models;
using TestWebApi.Services;

namespace TestWebApi.Controllers
{


    [Route("/api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly ILogger<PointsOfInterestController> _logger;
        private readonly IMailService _localMailService;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger, IMailService localMailService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _localMailService = localMailService ?? throw new ArgumentNullException(nameof(localMailService));
        }

        [HttpGet("{poiId}", Name = "GetPointsofinterest")]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsofinterest(int cityId, int poiId)
        {
            var city = CitiesDataStore.current.cities.FirstOrDefault((c) => c.Id == cityId);
            if (city == null)
            {
                _logger.LogInformation($@"City with id {cityId} was not found");
                return NotFound();
            };

            var poi = city.PointOfInterest.FirstOrDefault(p => p.Id == poiId);
            if (poi == null) return NotFound();
            return Ok(poi);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsofinterest(int cityId)
        {
            var city = CitiesDataStore.current.cities.FirstOrDefault((c) => c.Id == cityId);
            if (city == null) return NotFound();
            PointOfInterestDto[] list = city.PointOfInterest.ToArray<PointOfInterestDto>();
            return Ok(list);
        }


        [HttpPost]
        public ActionResult<IEnumerable<PointOfInterestDto>> CreatePointsofinterest(int cityId, PointOfInterestForCreation poi)
        {
            var city = CitiesDataStore.current.cities.FirstOrDefault((c) => c.Id == cityId);
            if (city == null) return NotFound();

            var maxPoiId = CitiesDataStore.current.cities.
                SelectMany(c => c.PointOfInterest).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPoiId,
                Name = poi.Name,
                Description = poi.Description
            };
            city.PointOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("Getpointsofinterest", new
            {
                cityId,
                PoiId = finalPointOfInterest.Id
            },finalPointOfInterest);
        }

        [HttpPut("{poiId}")]
        public ActionResult UpdatePointOfInterest(int cityId, int poiId, PointOfInterestForUpdate newPointOfInterestData)
        {
            var city = CitiesDataStore.current.cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null) return NotFound();

            var pointOfInterest = city.PointOfInterest.FirstOrDefault(p => p.Id == poiId);
            if (pointOfInterest == null) return NotFound();

            pointOfInterest.Name = newPointOfInterestData.Name;
            pointOfInterest.Description = newPointOfInterestData.Description;

            return NoContent();
        }

        [HttpPatch("{pointOfInterestId}")]
        public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId,
            JsonPatchDocument<PointOfInterestForUpdate> patchDocument)
        {
            var city = CitiesDataStore.current.cities.FirstOrDefault(c => c.Id == cityId);
            if(city == null) return NotFound();

            var pointOfInterestFromStore = city.PointOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);
            if(pointOfInterestFromStore == null) return NotFound();

            var pointOfInterestForPatch = new PointOfInterestForUpdate()
            {
                Name = pointOfInterestFromStore.Name,
                Description = pointOfInterestFromStore.Description,
            };

            patchDocument.ApplyTo(pointOfInterestForPatch, ModelState);

            if (!ModelState.IsValid || !TryValidateModel(pointOfInterestForPatch)) return BadRequest(ModelState);

            pointOfInterestFromStore.Name = pointOfInterestForPatch.Name;
            pointOfInterestFromStore.Description = pointOfInterestForPatch.Description;

            return NoContent(); 
        }

        [HttpDelete("{pointOfInterestId}")]
        public ActionResult DeletePointOfInterest(int cityId, int pointOfInterestId)
        {
            var city = CitiesDataStore.current.cities.FirstOrDefault(c => c.Id == cityId);
            if(city == null) return NotFound();

            var pointOfInterestToDelete = city.PointOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);
            if(pointOfInterestToDelete == null) return NotFound();
           
            city.PointOfInterest.Remove(pointOfInterestToDelete);

            _localMailService.Send("Deleting point of interest", $@"The point of interest with id {pointOfInterestId} was successfully deleted");
            return Ok("Point of interest deleted!");
        }
    }
}
