using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sevices_Stock;
using Stock.Models;

namespace Stock.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class StockController : ControllerBase
    {

        private readonly StocktakingJkContext _dbcontext;

        public StockController(StocktakingJkContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public IActionResult Index()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            IConfiguration cofiguration = builder.Build();
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            String Constring = cofiguration.GetConnectionString("ConnectionStrings: StockContext");


            return Ok();
        }




        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _dbcontext.Products.ToListAsync();

            var productDtos = products.Select(product => new ProductDto()
            {
                IdProduct = product.IdProduct,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                AmountProduct = product.AmountProduct,
                IdCategory = product.IdCategory,

            }).ToList();

            return Ok(new { Message = "Success from controller", Data = productDtos });
        }



        
        [HttpGet("{IdProduct:int}")] 
        public async Task<IActionResult> GetById([FromRoute] int IdProduct)
        {

            var product = await _dbcontext.Products.SingleOrDefaultAsync(x => x.IdProduct == IdProduct);

            if (product == null)
                return NotFound();


            var productDtos = new ProductDto
            {
                IdProduct = product.IdProduct,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                AmountProduct = product.AmountProduct,
                IdCategory = product.IdCategory,

            };



            return Ok(new { Message = "enviado ", Data = productDtos });


        }



        [HttpPost("Category")]
        public async Task<IActionResult> CreateCategory([FromBody] CreatedCategoryDto createdcategorydto)
        {
            var category = new Category
            {

                Name = createdcategorydto.Name
            };

            _dbcontext.Categories.Add(category);
            await _dbcontext.SaveChangesAsync();


            var createdcategorydtoS = new CreatedCategoryDto
            {
                IdCategory = category.IdCategory,
                Name = category.Name,
            };



            return CreatedAtAction(nameof(CreateCategory), new { id = category.IdCategory }, category);
        }




        [HttpPost("Product")]
        public async Task<IActionResult> CreatedProduct([FromBody] CreatedProductDto insertproductdto)
        {
            var Product = new Product
            {
                Name = insertproductdto.Name,
                Description = insertproductdto.Description,
                Price = insertproductdto.Price,
                AmountProduct = insertproductdto.AmountProduct,
                IdCategory = insertproductdto.IdCategory,
            };

            _dbcontext.Products.Add(Product);
            await _dbcontext.SaveChangesAsync();

            var productDtos = new ProductDto
            {
                IdProduct = Product.IdProduct,
                Name = Product.Name,
                Description = Product.Description,
                Price = Product.Price,
                AmountProduct = Product.AmountProduct,
                IdCategory = Product.IdCategory,
            };

            return Created("/api/Stock/" + Product.IdProduct, new { Message = "enviado ", Data = productDtos });
        }



    }







}

