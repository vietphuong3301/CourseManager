using Microsoft.AspNetCore.Mvc;
using CourseManager.DTO.DTOs;
using CourseManager.Services.Services;
using System.Threading.Tasks;

namespace CourseManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdCategory = await _categoryService.CreateAsync(categoryDto);
            return CreatedAtAction(nameof(GetById), new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return BadRequest();
            }
            var result = await _categoryService.UpdateAsync(categoryDto);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(int pageIndex, int pageSize)
        {
            var (items, totalCount) = await _categoryService.GetPagedAsync(pageIndex, pageSize);
            return Ok(new { Items = items, TotalCount = totalCount });
        }

        [HttpGet("single")]
        public async Task<IActionResult> GetSingle([FromQuery] string predicate)
        {
            // Assuming predicate is passed as a query string and needs to be parsed
            // This is a simplified example, in real scenarios, you might need to handle this differently
            var category = await _categoryService.GetSingleAsync(c => c.Name.Contains(predicate));
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
    }
}
