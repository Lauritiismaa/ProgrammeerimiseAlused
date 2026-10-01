using System.ComponentModel.DataAnnotations;
namespace TodoApi.Models;

public class TodoItemDTO
{
    public long Id { get; set; }
    [Required, StringLength(200)]
    public string Name { get; set; } = "";
    public bool IsComplete { get; set; }
}
