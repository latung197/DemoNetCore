using Coasia.WebApiRestful.Service;
using Microsoft.AspNetCore.Mvc;

namespace Coasia.WebApiRestful.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _categoryService.GetCategories());
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
