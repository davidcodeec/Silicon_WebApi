using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class CourseFactory
{
    public static Course Create(CourseEntity entity)
    {
        try
        {
            return new Course
            {
                Id = entity.Id,
                Title = entity.Title,
                Author = entity.Author,
                Price = entity.Price,
                DiscountPrice = entity.DiscountPrice,
                Hours = entity.Hours,
                IsDigital = entity.IsDigital,
                IsBestseller = entity.IsBestseller,
                LikeInNumbers = entity.LikeInNumbers,
                LikeInProcent = entity.LikeInProcent,
                Image = entity.Image,
                Category = entity.Category!.CategoryName
            };
        }
        catch { }
        return null!;
    }


    public static IEnumerable<Course> Create(List<CourseEntity> entities)
    {

        List<Course> courses = [];

        try
        {
            foreach (var entity in entities)
                courses.Add(Create(entity));

        }
        catch { }
        return courses;
    }
}
