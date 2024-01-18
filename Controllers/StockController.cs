using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
using Sevices_Stock;
using Stock.Models;
=======
using Stock.Models;
using Sevices_Stock;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
>>>>>>> ed517083de3ce8178df845625da8ce3d31afa789

namespace Stock.Controllers
{
    [Route("api/[controller]")]
<<<<<<< HEAD
    [ApiController] 
=======
    [ApiController]
>>>>>>> ed517083de3ce8178df845625da8ce3d31afa789
    public class StockController : ControllerBase
    {

        private readonly StocktakingJkContext _dbcontext;

        public StockController(StocktakingJkContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


<<<<<<< HEAD
        public IActionResult Index()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            IConfiguration cofiguration = builder.Build();
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            String Constring = cofiguration.GetConnectionString("ConnectionStrings: StockContext");


            return Ok();
        }

=======
        public  IActionResult Index()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
                IConfiguration cofiguration = builder.Build();
            String Constring = cofiguration.GetConnectionString("ConnectionStrings: StockContext");

            return Ok();

        }
>>>>>>> ed517083de3ce8178df845625da8ce3d31afa789



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
<<<<<<< HEAD

=======
              
>>>>>>> ed517083de3ce8178df845625da8ce3d31afa789
            }).ToList();

            return Ok(new { Message = "Success from controller", Data = productDtos });
        }



<<<<<<< HEAD
        
        [HttpGet("{IdProduct:int}")] 
        public async Task<IActionResult> GetById([FromRoute] int IdProduct)
        {

            var product = await _dbcontext.Products.SingleOrDefaultAsync(x => x.IdProduct == IdProduct);
=======
        [HttpGet ]
        [Route("{IdProduct:int}")]
        public async Task<IActionResult> GetById([FromRoute] int IdProduct)
        {

            var product = await _dbcontext.Products.SingleOrDefaultAsync (x => x.IdProduct == IdProduct); 
>>>>>>> ed517083de3ce8178df845625da8ce3d31afa789

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



<<<<<<< HEAD
            return Ok(new { Message = "enviado ", Data = productDtos });
=======

            return  Ok(new { Message =  "enviado "  , Data = productDtos });
>>>>>>> ed517083de3ce8178df845625da8ce3d31afa789


        }



<<<<<<< HEAD
        [HttpPost("Category")]
=======
        [HttpPost("CreateCategory") ]
>>>>>>> ed517083de3ce8178df845625da8ce3d31afa789
        public async Task<IActionResult> CreateCategory([FromBody] CreatedCategoryDto createdcategorydto)
        {
            var category = new Category
            {
<<<<<<< HEAD

=======
              
>>>>>>> ed517083de3ce8178df845625da8ce3d31afa789
                Name = createdcategorydto.Name
            };

            _dbcontext.Categories.Add(category);
            await _dbcontext.SaveChangesAsync();


            var createdcategorydtoS = new CreatedCategoryDto
            {
<<<<<<< HEAD
                IdCategory = category.IdCategory,
=======
              IdCategory = category.IdCategory,
>>>>>>> ed517083de3ce8178df845625da8ce3d31afa789
                Name = category.Name,
            };



            return CreatedAtAction(nameof(CreateCategory), new { id = category.IdCategory }, category);
        }



<<<<<<< HEAD

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
=======
      [HttpPost("CreatedProduct")]
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
>>>>>>> ed517083de3ce8178df845625da8ce3d31afa789
        }



    }







}

