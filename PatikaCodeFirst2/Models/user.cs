using System.ComponentModel.DataAnnotations;

namespace PatikaCodeFirst2.Models;

public class User
{
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Username { get; set; } = null!;

    [Required, EmailAddress, MaxLength(100)]
    public string Email { get; set; } = null!;

    // 1 → N ilişki (bir kullanıcının birden çok gönderisi)
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}
