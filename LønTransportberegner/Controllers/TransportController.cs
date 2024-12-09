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
        private readonly ConnectDbContext _dbContext;
        private readonly IRepository<CityModel> _cityRepository;


        public TransportController(IRepository<CityModel> cityRepository, ConnectDbContext dbContext, TransportContext transportContext) 
        {
            _carTransport = new CarTransport();
            _electricBike = new ElectricBike();
            _publicTransport = new publicTransport();
            _transportContext = transportContext;
            _dbContext = dbContext;
            _cityRepository = cityRepository;

            
        }

        public async Task<IActionResult> Index(TransportModel transportmodel, string city)
        {
            var newCity = new CityModel
            {
                CityName = city
            };

            await _cityRepository.AddAsync(newCity);



            ITransportStrategy selectedTransportMethod = transportmodel.Transportmetode switch
            {
                    "CarTransport" => _carTransport,
                    "ElectricBike" => _electricBike,
                    "PublicTransport" => _publicTransport,               
            };

                _transportContext.SetTransportStrategy(selectedTransportMethod);
                transportmodel.TransportCost = _transportContext.CalculateTransportCost(transportmodel.Distance);
                return View("Index", transportmodel);
            
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

    }


}
