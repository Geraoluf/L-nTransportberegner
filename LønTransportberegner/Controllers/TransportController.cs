using Microsoft.AspNetCore.Mvc;
using LønTransportberegner.Models;
using LønTransportberegner.Services;

namespace LønTransportberegner.Controllers
{
    public class TransportController : Controller
    {
        private readonly TransportContext _transportContext;
        private readonly ITransportStrategy _carTransport;
        private readonly ITransportStrategy _electricBike;
        private readonly ITransportStrategy _publicTransport;

        public TransportController(
            TransportContext transportContext,
            ITransportStrategy carTransport,
            ITransportStrategy electricBike,
            ITransportStrategy publicTransport)
        {
            _transportContext = transportContext;
            _carTransport = carTransport;
            _electricBike = electricBike;
            _publicTransport = publicTransport;
        }

        [HttpPost]
        public IActionResult Index(TransportModel model, string Transportmetode)
        {
            // Vælg transportmetode baseret på brugerens valg
            ITransportStrategy selectedTransportMethod = Transportmetode switch
            {
                "CarTransport" => _carTransport,
                "ElectricBike" => _electricBike,
                "PublicTransport" => _publicTransport,
                _ => throw new ArgumentException("Invalid transport method")
            };

            // Sæt den valgte transportmetode i konteksten
            _transportContext.SetTransportStrategy(selectedTransportMethod);

            // Beregn transportomkostningen baseret på afstanden
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
