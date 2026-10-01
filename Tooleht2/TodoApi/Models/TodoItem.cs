namespace TodoApi.Models;

public class TodoItem
{
    public long Id { get; set; }
    public string Name { get; set; } = "";
    public bool IsComplete { get; set; }
    // Seda välja ei väljastata ega muudeta API kaudu (DTO kaitse).
    public string? Secret { get; set; }
}
