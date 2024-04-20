using Infrastructure.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Filters;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
//[UseApiKey]
[Authorize]
public class CoursesController(ApiContext context) : ControllerBase
{

    private readonly ApiContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 10)
    {

        #region query filters
        var query = _context.Courses.Include(i => i.Category).AsQueryable();

        if (!string.IsNullOrWhiteSpace(category) && category != "all")
            query = query.Where(x => x.Category!.CategoryName == category);

        if (!string.IsNullOrEmpty(searchQuery))
            query = query.Where(x => x.Title.Contains(searchQuery) || x.Author.Contains(searchQuery));



        query = query.OrderByDescending(o => o.LastUpdated);

        var courses = await query.ToListAsync();

        #endregion

        var response = new CourseResult
        {
            Succeeded = true,
            TotalItems = await query.CountAsync(),
        };
        response.TotalPages = (int)Math.Ceiling(response.TotalItems / (double)pageSize);
        response.Courses = CourseFactory.Create(await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync());

        return Ok(response);
    }
}
