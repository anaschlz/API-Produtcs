using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.MapControllers();

app.Run();

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 19.99m },
        new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 29.99m }
    };

    // GET: api/products
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        return Ok(products);
    }

    // GET: api/products/1
    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = products.Find(p => p.Id == id);

        if (product == null)
        {
            return NotFound(); 
        }

        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public ActionResult<Product> CreateProduct(Product product)
    {
        product.Id = products.Count + 1;
        products.Add(product);

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    // PUT: api/products/1
    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, Product updatedProduct)
    {
        var existingProduct = products.Find(p => p.Id == id);

        if (existingProduct == null)
        {
            return NotFound();
        }

        existingProduct.Name = updatedProduct.Name;
        existingProduct.Description = updatedProduct.Description;
        existingProduct.Price = updatedProduct.Price;

        return NoContent();
    }

    // DELETE: api/products/1
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = products.Find(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        products.Remove(product);

        return NoContent();
    }
}
