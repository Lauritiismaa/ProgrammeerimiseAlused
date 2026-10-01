using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoItemsController(TodoContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
    {
        return await context.TodoItems.AsNoTracking()
            .Select(item => new TodoItemDTO
            {
                Id = item.Id, Name = item.Name, IsComplete = item.IsComplete
            }).ToListAsync();
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
    {
        var item = await context.TodoItems.FindAsync(id);
        if (item == null) return NotFound();
        return ToDTO(item);
    }

    [HttpPost]
    public async Task<ActionResult<TodoItemDTO>> PostTodoItem(TodoItemDTO dto)
    {
        // Id luuakse serveris; sisendist kopeeritakse ainult lubatud väljad.
        var item = new TodoItem { Name = dto.Name, IsComplete = dto.IsComplete };
        context.TodoItems.Add(item);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, ToDTO(item));
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> PutTodoItem(long id, TodoItemDTO dto)
    {
        if (id != dto.Id) return BadRequest();
        var item = await context.TodoItems.FindAsync(id);
        if (item == null) return NotFound();
        item.Name = dto.Name;
        item.IsComplete = dto.IsComplete;
        try { await context.SaveChangesAsync(); }
        catch (DbUpdateConcurrencyException)
        {
            if (!await context.TodoItems.AnyAsync(t => t.Id == id)) return NotFound();
            throw;
        }
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteTodoItem(long id)
    {
        var item = await context.TodoItems.FindAsync(id);
        if (item == null) return NotFound();
        context.TodoItems.Remove(item);
        await context.SaveChangesAsync();
        return NoContent();
    }

    private static TodoItemDTO ToDTO(TodoItem item) => new()
    {
        Id = item.Id, Name = item.Name, IsComplete = item.IsComplete
    };
}
