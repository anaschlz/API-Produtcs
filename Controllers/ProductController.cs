using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Encodings.Web;


[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/products
    [HttpGet]
    public async Task <ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _context.Product.ToListAsync();
    }

    // GET: api/products/1
   [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
       var product = await _context.Product.FindAsync(id);

       if (product == null)
        {
            return NotFound(); 
        }

        return Ok(product);
    }


    // POST: api/products
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        _context.Product.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new { id = product.Id }, product);
    }

    // PUT: api/products/1
 [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Product updatedItem)
    {
        Console.WriteLine($"Recebendo solicitação PUT para o produto com ID: {id}");
        var existingItem = _context.Product.FirstOrDefault(item => item.Id == id);

        if (existingItem == null)
        {
            return NotFound();
        }

        existingItem.Description = updatedItem.Description;
        existingItem.Name = updatedItem.Name;
        existingItem.Price = updatedItem.Price;
        

        _context.SaveChanges(); 

        return Ok(existingItem);
    }

    

    // DELETE: api/products/1
     [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Product.FindAsync(id);

        if (product == null)
        {
            return NotFound(); 
        }

        _context.Product.Remove(product);

        await _context.SaveChangesAsync();

        return Ok(product);
    }
        
    private bool ProductExists(int id)
    {
        return _context.Product.Any(p => p.Id == id);
    }

}