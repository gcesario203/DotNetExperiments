namespace Catalog.UnitTests;

using Catalog.API.Controllers;
using Catalog.API.Entities;
using Catalog.API.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;
using Catalog.UnitTests.Utils;
using Catalog.UnitTests.Orderes.Attributes;

[TestCaseOrderer("Catalog.UnitTests.Orderes.Strategy.PriorityOrderer", "Catalog.UnitTests.Orderes.Attributes.TestPriorityAttribute")]
public class CatalogControllerTests
{
    [Fact, TestPriority(1)]
    public async void GetProductById_WithUnexistingItem_ReturnsNotFound()
    {

        var repoStub = new Mock<IProductRepository<Product>>();

        repoStub.Setup(_ => _.GetItem(It.IsAny<string>())).ReturnsAsync((Product)null);

        var loggerStub = new Mock<ILogger<CatalogController>>();

        var controller = new CatalogController(Constants.ProductRepository, loggerStub.Object);

        // var result = await controller.GetProductById(ObjectId.GenerateNewId().ToString());
        var result = await controller.GetProductById(ObjectId.GenerateNewId().ToString());

        // System.Console.WriteLine(result.Result);
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact, TestPriority(2)]
    public async void CreateProduct_WithExistingItem_ShouldntCreate()
    {

        var repoStub = new Mock<IProductRepository<Product>>();
        var productToInsert = Constants.GetMockProduct();
        repoStub.Setup(_ => _.CreateItem(It.IsAny<Product>())).Returns(Task.FromResult(productToInsert));

        var loggerStub = new Mock<ILogger<CatalogController>>();

        var controller = new CatalogController(Constants.ProductRepository, loggerStub.Object);

        // var result = await controller.GetProductById(ObjectId.GenerateNewId().ToString());
        var result = await controller.CreateProduct(productToInsert);

        // System.Console.WriteLine(result.Result);
        Assert.IsType<CreatedAtRouteResult>(result.Result as CreatedAtRouteResult);
    }

    [Fact, TestPriority(3)]
    public async void CreateProduct_WithUnexistingItem_ShouldCreate()
    {

        var repoStub = new Mock<IProductRepository<Product>>();
        var productToInsert = Constants.GetMockProduct();
        repoStub.Setup(_ => _.CreateItem(It.IsAny<Product>())).Returns(Task.FromResult((Product)null));

        var loggerStub = new Mock<ILogger<CatalogController>>();

        var controller = new CatalogController(Constants.ProductRepository, loggerStub.Object);

        // var result = await controller.GetProductById(ObjectId.GenerateNewId().ToString());
        var result = await controller.CreateProduct(productToInsert);

        // System.Console.WriteLine(result.Result);
        Assert.IsType<BadRequestResult>(result.Result as BadRequestResult);
    }

    [Fact, TestPriority(4)]
    public async void UpdateProduct_WithExistingItem_ShouldUpdate()
    {

        var repoStub = new Mock<IProductRepository<Product>>();

        var productTobeUpdated = Constants.GetChangedProduct();

        repoStub.Setup(_ => _.UpdateItem(It.IsAny<Product>())).Returns(Task.FromResult(true));

        var loggerStub = new Mock<ILogger<CatalogController>>();

        var controller = new CatalogController(Constants.ProductRepository, loggerStub.Object);

        // var result = await controller.GetProductById(ObjectId.GenerateNewId().ToString());
        var result = await controller.UpdateProduct(productTobeUpdated);

        // System.Console.WriteLine(result.Result);
        Assert.IsType<OkObjectResult>(result as OkObjectResult);
    }

    [Fact, TestPriority(5)]
    public async void UpdateProduct_WithUnexistingItem_ShouldntUpdate()
    {

        var repoStub = new Mock<IProductRepository<Product>>();

        var productTobeUpdated = Constants.GetChangedProduct();

        productTobeUpdated.Id = ObjectId.GenerateNewId().ToString();

        repoStub.Setup(_ => _.UpdateItem(It.IsAny<Product>())).Returns(Task.FromResult(false));

        var loggerStub = new Mock<ILogger<CatalogController>>();

        var controller = new CatalogController(Constants.ProductRepository, loggerStub.Object);

        // var result = await controller.GetProductById(ObjectId.GenerateNewId().ToString());
        var result = await controller.UpdateProduct(productTobeUpdated);

        // System.Console.WriteLine(result.Result);
        Assert.IsType<OkObjectResult>(result as OkObjectResult);
    }

    [Fact, TestPriority(6)]
    public async void DeleteProductById_WithExistingItem_ShouldDelete()
    {

        var repoStub = new Mock<IProductRepository<Product>>();

        var idOfExistingItem = Constants.MockId;

        repoStub.Setup(_ => _.DeleteItem(It.IsAny<string>())).Returns(Task.FromResult(true));

        var loggerStub = new Mock<ILogger<CatalogController>>();

        var controller = new CatalogController(Constants.ProductRepository, loggerStub.Object);

        // var result = await controller.GetProductById(ObjectId.GenerateNewId().ToString());
        var result = await controller.DeleteProductById(idOfExistingItem);

        // System.Console.WriteLine(result.Result);
        Assert.IsType<OkObjectResult>(result as OkObjectResult);
    }

    [Fact, TestPriority(7)]
    public async void DeleteProductById_WithUnexistingItem_ShouldntDelete()
    {

        var repoStub = new Mock<IProductRepository<Product>>();

        var idOfExistingItem = Constants.MockId;

        repoStub.Setup(_ => _.DeleteItem(It.IsAny<string>())).Returns(Task.FromResult(true));

        var loggerStub = new Mock<ILogger<CatalogController>>();

        var controller = new CatalogController(Constants.ProductRepository, loggerStub.Object);

        // var result = await controller.GetProductById(ObjectId.GenerateNewId().ToString());
        var result = await controller.DeleteProductById(idOfExistingItem);

        // System.Console.WriteLine(result.Result);
        Assert.IsType<OkObjectResult>(result as OkObjectResult);
    }
}