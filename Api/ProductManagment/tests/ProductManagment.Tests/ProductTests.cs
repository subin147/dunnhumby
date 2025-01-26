using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using ProductManagment.Api;
using ProductManagment.Api.Data.Context;
using ProductManagment.Api.Data.Entities;
using ProductManagment.Api.Data.Repositories;
using ProductManagment.Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagment.Tests
{
    [TestFixture]
    public class ProductTests
    {
        private ProductDbContext _productDbContext;
        private IProductRepository _productRepository;
        private Mock<ILogger<ProductRepository>> _mockLogger;
        private bool _isDisposed;

        [SetUp]
        public void SetUp()
        {
            // Use InMemoryDatabase to avoid mocking the actual DbContext
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;
            _productDbContext = new ProductDbContext(options);

            // Ensure the database schema is created
            _productDbContext.Database.OpenConnection();
            _productDbContext.Database.EnsureCreated();

            _productDbContext.Categories.RemoveRange(_productDbContext.Categories);
            _productDbContext.Products.RemoveRange(_productDbContext.Products);
            _productDbContext.SaveChanges();
            // Create a mock DbSet with some test data
            var categories = new List<Category>
            {
            new() { Id = 1, Description = "Food" },
            new() { Id = 2, Description = "Electronics" },
            new() { Id = 3, Description = "Cloths" }
            }.AsQueryable();
            var products = new List<Product>
            {
            new() { Id = 1, CategoryId=1, Name="Apple", Code="F001", Price=1.5M, SKU="12345", StockQuantity=100, DateAdded=DateTime.Now     },
            new() { Id = 2, CategoryId=2, Name="Blender", Code="E001", Price=50M, SKU="52345", StockQuantity=10, DateAdded=DateTime.Now     },
            new() { Id = 3, CategoryId=3, Name="Shirt", Code="C001", Price=40M, SKU="62346", StockQuantity=25, DateAdded=DateTime.Now     }
            }.AsQueryable();

            _productDbContext.Categories.AddRange(categories);
            _productDbContext.Products.AddRange(products);
            _productDbContext.SaveChanges();

            _mockLogger = new Mock<ILogger<ProductRepository>>();

            _productRepository = new ProductRepository(_productDbContext, _mockLogger.Object);
        }

        [TearDown]
        public void Teardown()
        {
            if (!_isDisposed)
            {
                _productDbContext.Database.CloseConnection();
                _productDbContext.Dispose();
            }

        }

        [Test]
        public async Task GetProducts_Should_Return_All_Products()
        {
            
            var result = await _productRepository.GetAll();
            Assert.Multiple(() =>
            {
                Assert.That(result.Count(), Is.EqualTo(3));
                Assert.That(result.FirstOrDefault()?.Name,Is.EqualTo( "Apple"));
            });
            
        }

        [Test]
        public async Task GetProducts_Should_Return_Null_If_Exception_Occurs()
        {
            _productDbContext.Dispose();
            _isDisposed = true;
            var result = await _productRepository.GetAll();
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task AddProduct_Should_Add_Product_To_Db()
        {
            var productDto = new ProductDto
            {
                CategoryId = 1,
                Code = "F003",
                Name = "Banana",
                Price = 1.2M,
                SKU = "12347",
                StockQuantity = 150
            };

            var result = await _productRepository.Add(productDto);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                var addedProduct = _productDbContext.Products.FirstOrDefault(p => p.Code == "F003");
                Assert.That(addedProduct, Is.Not.Null);
                Assert.That(addedProduct?.Name, Is.EqualTo("Banana"));
            });
        }

         [Test]
        public async Task AddProduct_Should_Return_False_When_Exception_Occurs()
        {
            var productDto = new ProductDto
            {
                CategoryId = 999, 
                Code = "F004",
                Name = "Grapes",
                Price = 2.0M,
                SKU = "12348",
                StockQuantity = 50
            };

            var result = await _productRepository.Add(productDto);

            Assert.That(result, Is.False);
        }
    }
}
