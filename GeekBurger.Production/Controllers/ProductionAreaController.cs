using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeekBurger.Production.Repository;
using AutoMapper;
using GeekBurger.Production.Contract;
using GeekBurger.Production.Model;
using GeekBurger.Production.Helper;

namespace GeekBurger.Production.Controllers
{
    [Produces("application/json")]
    [Route("api/productionareas")]
    public class ProductionAreaController : Controller
    {
        private IProductionAreaRepository _productionAreaRepository;
        private IMapper _mapper;

        public ProductionAreaController(IProductionAreaRepository productionAreaRepository, IMapper mapper)
        {
            _productionAreaRepository = productionAreaRepository;
            _mapper = mapper;
        }


        [HttpGet("{productionAreaId}", Name = "GetProductionArea")]
        public IActionResult GetProductionArea(Guid productionAreaId)
        {
            if (productionAreaId == null || productionAreaId == Guid.Empty)
                return BadRequest();


            var productionArea = _productionAreaRepository.GetProductionAreaById(productionAreaId);

            if (EqualityComparer<ProductionArea>.Default.Equals(productionArea, default(ProductionArea)))
                return NotFound();

            var productionAreaTO = _mapper.Map<ProductionAreaTO>(productionArea);

            return Ok(productionAreaTO);
        }

        [HttpPost()]
        public IActionResult CreateProductionArea([FromBody] ProductionAreaCRUD newProductionArea)
        {
            if (newProductionArea == null || EqualityComparer<ProductionAreaCRUD>.Default.Equals(newProductionArea, default(ProductionAreaCRUD)))
                return BadRequest();


            var _productionArea = _mapper.Map<ProductionArea>(newProductionArea);

            if (_productionArea.ProductionAreaRestrictions?.ToList().Where(par => par.RestrictionId == Guid.Empty).Count() > 0)
                return new UnprocessableEntityResult(ModelState);


            var resultProductionAreaCreated = _productionAreaRepository.CreateProductionArea(_productionArea);

            if (!resultProductionAreaCreated)
                return NotFound();


            _productionAreaRepository.Save();

            var productionAreaTO = _mapper.Map<ProductionAreaTO>(_productionArea);

            return CreatedAtRoute(  "GetProductionArea"
                                    , new { idProductionArea = productionAreaTO.ProductionAreaId }
                                    , productionAreaTO
                                 );
        }

        [HttpPut("{productionAreaId}", Name = "UpdateProductionArea")]
        public IActionResult UpdateProductionArea(Guid productionAreaId, [FromBody] ProductionAreaCRUD updatedProductionArea)
        {
            if (    productionAreaId == null 
                    || productionAreaId == Guid.Empty 
                    || EqualityComparer<ProductionAreaCRUD>.Default.Equals(updatedProductionArea, default(ProductionAreaCRUD))
               )
                return BadRequest();


            var _updatedProductionArea = _mapper.Map<ProductionArea>(updatedProductionArea);
            var resultProductionAreaUpdated = _productionAreaRepository.UpdateProductionArea(productionAreaId, _updatedProductionArea);

            if (!resultProductionAreaUpdated)
                return NotFound();


            _productionAreaRepository.Save();


            var productionAreaTO = _mapper.Map<ProductionAreaTO>(_updatedProductionArea);

            return CreatedAtRoute("GetProductionArea"
                                    , new { idProductionArea = productionAreaTO.ProductionAreaId }
                                    , productionAreaTO
                                 );
        }

        [HttpDelete("{productionAreaId}", Name = "RemoveProductionArea")]
        public IActionResult RemoveProductionArea(Guid productionAreaId)
        {
            if (productionAreaId == null || productionAreaId == Guid.Empty)
                return BadRequest();

            var resultProductionAreaRemoved = _productionAreaRepository.RemoveProductionArea(productionAreaId);

            if (!resultProductionAreaRemoved)
                return NotFound();


            _productionAreaRepository.Save();

            return Ok();
        }
    }
}