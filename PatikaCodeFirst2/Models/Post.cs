using System.ComponentModel.DataAnnotations;

namespace PatikaCodeFirst2.Models;

public class Post
{
    public int Id { get; set; }

    [Required, MaxLength(150)]
    public string Title { get; set; } = null!;

    [Required]
    public string Content { get; set; } = null!;

    // FK
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
