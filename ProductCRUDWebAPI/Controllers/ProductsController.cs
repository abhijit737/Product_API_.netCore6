using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCRUDWebAPI.Data;
using ProductCRUDWebAPI.Models;
using Microsoft.IdentityModel.Tokens;


namespace ProductCRUDWebAPI.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : Controller
    {
        public readonly ProductDBContext _dbcontext;
        public ProductsController(ProductDBContext productDBContext)
        {
            _dbcontext = productDBContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
           var product  =  await _dbcontext.Products.ToListAsync();
            return Ok(product);
        }



        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product productRequest)
        {
            productRequest.Id = Guid.NewGuid();
            await _dbcontext.Products.AddAsync(productRequest);
            await _dbcontext.SaveChangesAsync();
            return Ok(productRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetProduct([FromBody]Guid id)

        {
           var product = await _dbcontext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, Product updateProduct )
        {
            var product = await _dbcontext.Products.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            product.Name = updateProduct.Name;
            product.Quanity = updateProduct.Quanity;
            product.Description = updateProduct.Description;
            
            await _dbcontext.SaveChangesAsync();
            return(Ok(product));
        }



        [HttpDelete]
        [Route("{id:Guid}")]


        public async Task<IActionResult> DeleteProduct([FromBody]Guid id)
        {
            var product = await _dbcontext.Products.FindAsync(id);
            if(product ==null)
            {
                return NotFound();
            }

             _dbcontext.Products.Remove(product);
            await _dbcontext.SaveChangesAsync();
            return Ok(product);
        
        }


    }

}
