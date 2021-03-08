using System.Collections.Generic;
using Shop.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using System;
using Microsoft.EntityFrameworkCore;

namespace Shop.Controllers
{
    [Route("api/v1/categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAll([FromServices] DataContext context)
        {
            return Ok(await context.Category.AsNoTracking<Category>().ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Category>> GetById(int id, [FromServices] DataContext context)
        {
            return Ok(await context.Category.AsNoTracking<Category>().FirstOrDefaultAsync(category => category.Id == id));
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category category, [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Category.Add(category);
                await context.SaveChangesAsync();

                return Ok(category);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível adicionar uma categoria." });
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Category>> Put(int id, [FromBody] Category category, [FromServices] DataContext context)
        {
            if (category.Id != id)
                return NotFound(new { messege = "Categoria não engcontrada." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Category>(category).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return Ok(category);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar a categoria." });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id, [FromServices] DataContext context)
        {
            var category = await context.Category.FirstOrDefaultAsync(category => category.Id == id);

            if (category == null)
            {
                return NotFound(new { message = $"Não foi possível localizar a categoria de id {id}." });
            }

            try
            {
                context.Category.Remove(category);
                await context.SaveChangesAsync();
                return Ok(category);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível deletar a categoria." });
            }
        }
    }
}