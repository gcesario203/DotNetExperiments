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
        private readonly IContext<Product> _catalog;
        public TesteController(IContext<Product> catalog)
        {
            _catalog = catalog;
        }

        [HttpGet]
        public IActionResult Teste() => Ok(_catalog._collection.Find(x => true).ToList());
    }
}