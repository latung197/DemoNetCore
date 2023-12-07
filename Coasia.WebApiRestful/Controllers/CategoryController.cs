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

        [HttpGet("{id:int}")]
        public IActionResult GetById1(int id)//api/category?name=abc&descrip=cne
        {
            return Ok($"GetById Ok{id} ");
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _categoryService.GetCategories();

            return Ok(result);
        }

        public IActionResult GetByName(string name)
        {
            List<string> items = null;
            if(items==null)
            {
                return NotFound();// 404 khoong cos duw lieeuj
            }
            else
            {
                return Ok();
            }
        }

        public IActionResult Create([FromBody] Categories categories)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok();
                }
            }
            catch(System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);// 500
            }

        }

        public IActionResult Update([FromBody] Categories categories)
        {
            return NoContent();// 204
        }

        [HttpGet]
        [Route("get-report-csv")]
        public IActionResult GetReportCSV()
        {
            byte[] data = null;
            var fileName = $"testExcel.xlsx";
            var mimetype = "application/vnd.opnexmlformatss-officedocument.spreadsheet.sheet";
            return File(data, mimetype, fileName);


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

        // Status Code
    }
}
