using TestWebApi.Models;

namespace TestWebApi
{
    public class CitiesDataStore
    {
        public List<CityDto> cities;

        public static CitiesDataStore current { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            cities = new List<CityDto>() 
            {
                new CityDto(){
                    Id = 1, Name = "Nagpur", Description = "Test Nagpur",
                    PointOfInterest = new List<PointOfInterestDto>(){
                        new PointOfInterestDto(){
                            Id = 1,
                            Name = "Test",
                            Description = "Test",
                        },
                        new PointOfInterestDto(){
                            Id = 2,
                            Name = "Test",
                            Description = "Test",
                        }
                    }
                },
                new CityDto(){Id = 2, Name = "Bombay", Description = "Test Bombay",
                    PointOfInterest = new List<PointOfInterestDto>(){
                        new PointOfInterestDto(){
                            Id = 1,
                            Name = "Test",
                            Description = "Test",
                        },
                        new PointOfInterestDto(){
                            Id = 2,
                            Name = "Test",
                            Description = "Test",
                        }
                    }},
                new CityDto(){Id = 3, Name = "Banglore", Description = "Test Banglore",
                    PointOfInterest = new List<PointOfInterestDto>(){
                        new PointOfInterestDto(){
                            Id = 1,
                            Name = "Test",
                            Description = "Test",
                        },
                        new PointOfInterestDto(){
                            Id = 2,
                            Name = "Test",
                            Description = "Test",
                        }
                    }},
            };
        }
    }
}
