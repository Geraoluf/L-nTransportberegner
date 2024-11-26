using Microsoft.AspNetCore.Mvc;
using LønTransportberegner.Models;
using LønTransportberegner.Services;
using Microsoft.Extensions.Logging;
using LønTransportberegner.Models.Domæne;
using LønTransportberegner.Repositories;

namespace LønTransportberegner.Controllers
{
    public class TransportController : Controller
    {
        private readonly ITransportStrategy _carTransport;
        private readonly ITransportStrategy _electricBike;
        private readonly ITransportStrategy _publicTransport;
        private readonly TransportContext _transportContext;
        private readonly ILogger<TransportController> _logger;
        private readonly ConnectDbContext _dbContext;
        private readonly IRepository<CityModel> _cityRepository;


        public TransportController(IRepository<CityModel> cityRepository, ConnectDbContext dbContext, TransportContext transportContext, ILogger<TransportController> logger) 
        {
            _carTransport = new CarTransport();
            _electricBike = new ElectricBike();
            _publicTransport = new publicTransport();
            _transportContext = transportContext;
            _logger = logger; 
            _dbContext = dbContext;
            _cityRepository = cityRepository;

            logger.LogInformation("CarTransport: {CarTransport}, ElectricBike: {ElectricBike}, PublicTransport: {PublicTransport}",
              _carTransport?.GetType().Name,
              _electricBike?.GetType().Name,
              _publicTransport?.GetType().Name);
        }

        public async Task<IActionResult> Index(TransportModel model, string city)
        {
            var newCity = new CityModel
            {
                CityName = city
            };

            await _cityRepository.AddAsync(newCity);



            ITransportStrategy selectedTransportMethod = model.Transportmetode switch
                {
                    "CarTransport" => _carTransport,
                    "ElectricBike" => _electricBike,
                    "PublicTransport" => _publicTransport,
                   
                };

                _transportContext.SetTransportStrategy(selectedTransportMethod);
                model.TransportCost = _transportContext.CalculateTransportCost(model.Distance);
                return View("Index", model);
            
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

    }


}
