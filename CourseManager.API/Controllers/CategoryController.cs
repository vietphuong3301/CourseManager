using AutoMapper;
using CourseManager.DTO.DTOs;
using CourseManager.Services.Interfaces;
using CourseManager.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CategoryDto categoryDto)
        {
            var createdCategory = await _categoryService.CreateAsync(categoryDto);
            return CreatedAtAction(nameof(GetById), new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            var existingCourse = await _categoryService.GetByIdAsync(id);
            if (existingCourse == null)
            {
                return NotFound();
            }

            var result = await _categoryService.UpdateAsync(categoryDto);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("paged")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetPaged(int pageIndex, int pageSize)
        {
            var (categories, totalCount) = await _categoryService.GetPagedAsync(pageIndex, pageSize);
            Response.Headers.Add("X-Total-Count", totalCount.ToString());
            return Ok(categories);
        }
    }
}
