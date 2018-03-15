using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeekBurger.Production.Contract;
using AutoMapper;
using GeekBurger.Production.Repository;

namespace GeekBurger.Production.Controllers
{
    [Produces("application/json")]
    [Route("api/production")]
    public class ProductionAreasController : Controller
    {
        private IProductionAreaRepository _productionAreaRepository;
        private IMapper _mapper;

        public ProductionAreasController(IProductionAreaRepository productionAreaRepository, IMapper mapper)
        {
            _productionAreaRepository = productionAreaRepository;
            _mapper = mapper;
        }


        internal void WaitForProduction()
        {
            Random waitTime = new Random();
            int seconds = waitTime.Next(5 * 1000, 21 * 1000);

            System.Threading.Thread.Sleep(seconds);
        }


        [HttpGet("areas")]
        public IActionResult GetAreas()
        {
            var availableProductionAreas = _productionAreaRepository.GetAvailableProductionAreas().ToList();

            if (availableProductionAreas.Count <= 0)
                return NotFound();

            var availableProductionAreasReturn = _mapper.Map<IEnumerable<ProductionAreaTO>>(availableProductionAreas);

            return Ok(availableProductionAreasReturn);
        }

    }
}