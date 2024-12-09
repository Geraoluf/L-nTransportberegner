using LønTransportberegner.Models.Domæne;
using LønTransportberegner.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LønTransportberegner.Controllers
{
    public class CityController : Controller
    {
        private readonly Repository<CityModel> _repository;


        public CityController(ConnectDbContext context)
        {
            _repository = new Repository<CityModel>(context);
        }


        public ActionResult Index()
        {

            var citiesStartingWithOdense = _repository.GetFiltered(c => c.CityName != null && c.CityName.StartsWith("Odense"))
                                                      .Select(c => c.CityName)
                                                      .ToList();

     
            int odenseCount = citiesStartingWithOdense.Count(c => c == "Odense");

            
            ViewBag.OdenseCount = odenseCount;

           
            return View(citiesStartingWithOdense);


            
        }
    }
}
