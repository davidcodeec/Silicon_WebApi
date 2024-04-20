using Infrastructure.Entities;

namespace Infrastructure.Models;

public class Course
{
    public int Id { get; set; }
    public bool IsBestseller { get; set; }
    public string Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string Price { get; set; } = null!;
    public string? DiscountPrice { get; set; }
    public string Hours { get; set; } = null!;
    public string LikeInProcent { get; set; } = null!;
    public string LikeInNumbers { get; set; } = null!;
    public bool? IsDigital { get; set; }
    public string Category { get; set; } = null!;
}
