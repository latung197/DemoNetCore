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


        public IActionResult GetList()
        {
            return Ok("ListOj");
        }



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

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok($"GetById Ok{id} ");

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _categoryService.GetCategories();

            return Ok(result);
        }

        //public IActionResult CreateById()
        //{
        //    return Ok();
        //}

        //public IActionResult Update

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
