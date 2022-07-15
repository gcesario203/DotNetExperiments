using Catalog.API.Data;
using Catalog.API.Data.Interfaces;
using Catalog.API.Entities;
using Catalog.API.Utils.Utility;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Catalog.API.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class TesteController : ControllerBase
    {
        private IUnitOfWork _catalog;
        public TesteController(IUnitOfWork catalog)
        {
            _catalog = catalog;
        }

        [HttpGet]
        public IActionResult Teste()
        {
            var teste = _catalog.Database.GetCollection<Product>(StringUtils.GetCollectionName<Product>()).Find(x => true).ToList();
            return Ok(teste);
        }
    }
}