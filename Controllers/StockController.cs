using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Stock.Models;
using System.Linq;
using Stock.Models;
using Stock.Models.Dtos;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _dbcontext.Products.ToListAsync();

            var productDtos = products.Select(product => new productdto()
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



        [HttpGet ]
        [Route("{IdProduct:int}")]
        public async Task<IActionResult> GetById([FromRoute] int IdProduct)
        {

            var product = await _dbcontext.Products.SingleOrDefaultAsync (x => x.IdProduct == IdProduct); 

            if (product == null)
                return NotFound();


            var productDtos = new productdto
            {
                IdProduct = product.IdProduct,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                AmountProduct = product.AmountProduct,
                IdCategory = product.IdCategory,

            };




            return  Ok(new { Message =  "enviado "  , Data = productDtos });


        }



        [HttpPost("CreateCategory") ]
        public async Task<IActionResult> CreateCategory([FromBody] createdcategorydto createdcategorydto)
        {
            var category = new Category
            {
              
                Name = createdcategorydto.Name
            };

            _dbcontext.Categories.Add(category);
            await _dbcontext.SaveChangesAsync();


            var createdcategorydtoS = new createdcategorydto
            {
              IdCategory = category.IdCategory,
                Name = category.Name,
            };



            return CreatedAtAction(nameof(CreateCategory), new { id = category.IdCategory }, category);
        }



        [HttpPost("CreatedProduct")]
        public async Task<IActionResult> CreatedProduct([FromBody] createdproductdto insertproductdto )
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
            _dbcontext.SaveChanges();


            var productDtos = new productdto
            {
                IdProduct = Product.IdProduct,
                Name = Product.Name,
                Description = Product.Description,
                Price = Product.Price,
                AmountProduct = Product.AmountProduct,
                IdCategory = Product.IdCategory,

            };



            return Created(  "/api/Stock/"  + Product.IdProduct ,new { Message = "enviado ", Data = productDtos });


        }


      







    }







}

