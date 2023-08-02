using Microsoft.AspNetCore.Mvc;

namespace NewsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        [HttpGet(Name = "GetCategories")]
        public IActionResult GetCategories()
        {
            return Ok("Got Categories");
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            return Ok("Got Category by Id " + id);
        }

        [HttpPost(Name = "PostCategory")]
        public IActionResult PostCategory()
        {
            return Ok("Posted Category");
        }

        [HttpDelete("{id}", Name = "DeleteCategory")]
        public IActionResult DeleteCategory(int id)
        {
            return Ok("Deleted Category " + id);
        }
    }
}
