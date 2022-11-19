using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest req)
        {
            try
            {
                var Product = new Product
                {
                    ArticleNumber = req.ArticleNumber,
                    ProductName = req.ProductName,
                    Price = req.Price,
                    Description = req.Description,
                    Category = req.Category,
                    TechDescription = req.TechDescription,
                };

                _context.Add(Product);
                await _context.SaveChangesAsync();

                return new OkResult();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = new List<ProductResponse>();
                foreach (var p in await _context.Products.ToListAsync())
                    products.Add(new ProductResponse
                    {
                        Id = p.Id,
                        ArticleNumber = p.ArticleNumber,
                        ProductName = p.ProductName,
                        Price = p.Price,
                        Description = p.Description,
                        Category = p.Category,
                        TechDescription = p.TechDescription
                    });

                return new OkObjectResult(products);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return new OkObjectResult(await _context.Products.FirstOrDefaultAsync(x => x.Id == id));
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ProductUpdateRequest req)
        {
            try
            {
                var _product = await _context.Products.FindAsync(id);
                if (_product != null)
                {
                    _product.ArticleNumber = req.ArticleNumber;
                    _product.ProductName = req.ProductName;
                    _product.Price = req.Price;
                    _product.Description = req.Description;

                    _context.Update(_product);
                    await _context.SaveChangesAsync();
                    return new OkResult();
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new NotFoundResult();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var _product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (_product != null)
                {
                    _context.Remove(_product);
                    await _context.SaveChangesAsync();
                    return new OkResult();
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }


        [HttpGet("{CategoryName}")]
        public async Task<IActionResult> GetByCat(string CategoryName)
        {
            try
            {
                var products = new List<CategoryResponse>();
                foreach (var p in _context.Products.Where(x => x.Category.CategoryName == CategoryName))
                    products.Add(new CategoryResponse
                    {
                        ProductName = p.ProductName,
                        Category = p.Category,
                        ArticleNumber = p.ArticleNumber
                    });

                return new OkObjectResult(products);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }


    }
}