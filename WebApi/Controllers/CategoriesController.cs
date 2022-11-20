using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml.Linq;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var Product = await _context.Products.FindAsync(id);
            if (Product != null)
                return new OkObjectResult(new CategoryResponse
                {
                    Category = Product.Category,
                    ProductName = Product.ProductName,
                    ArticleNumber = Product.ArticleNumber
                });

            return new NotFoundResult();
        }

    }
}
