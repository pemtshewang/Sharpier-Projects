using System.ComponentModel.DataAnnotations;

public record class TodoDTO
{
    [Key]
    public int Id { get; set; }

    [MinLength(5)]
    public required string Title { get; set; }

    [MinLength(5)]
    public string? description { get; set; }

    public DateTime createdAt { get; set; }
}
