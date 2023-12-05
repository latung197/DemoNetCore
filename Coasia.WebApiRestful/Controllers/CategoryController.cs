using Coasia.WebApiRestful.Domain.Entitys;
using Coasia.WebApiRestful.Service;
using Microsoft.AspNetCore.Mvc;

namespace Coasia.WebApiRestful.Controllers
{
    [Route("api/[controller]")]  //api/category
    [ApiController]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("get-name-category-by-id")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _categoryService.GetCategories());
        }

        [HttpPost("addCategory")]
        public async Task InsertCategory(Categories categories)
        {
            await _categoryService.Insert(categories);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
