using Microsoft.AspNetCore.Mvc;
using LønTransportberegner.Models;
using LønTransportberegner.Services;
using Microsoft.Extensions.Logging; 

namespace LønTransportberegner.Controllers
{
    public class TransportController : Controller
    {
        private readonly ITransportStrategy _carTransport;
        private readonly ITransportStrategy _electricBike;
        private readonly ITransportStrategy _publicTransport;
        private readonly TransportContext _transportContext;
        private readonly ILogger<TransportController> _logger; 

        // Constructor injection af afhængigheder
        public TransportController(
            //ITransportStrategy carTransport,
            //ITransportStrategy electricBike,
            //ITransportStrategy publicTransport,
            TransportContext transportContext,
            ILogger<TransportController> logger) 
        {
            _carTransport = new CarTransport();
            _electricBike = new ElectricBike();
            _publicTransport = new publicTransport();
            _transportContext = transportContext;
            _logger = logger; 

            logger.LogInformation("CarTransport: {CarTransport}, ElectricBike: {ElectricBike}, PublicTransport: {PublicTransport}",
              _carTransport?.GetType().Name,
              _electricBike?.GetType().Name,
              _publicTransport?.GetType().Name);
        }

        public IActionResult Index(TransportModel model)
        {
            try
            {
               
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


            catch (Exception ex)
            {
              
                _logger.LogError(ex, "Error setting transport strategy.");

                throw;
            }
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

    }


}
