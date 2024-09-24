using Microsoft.AspNetCore.Mvc;
using CourseManager.DTO.DTOs;
using CourseManager.Services.Services;
using System.Threading.Tasks;

namespace CourseManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseTypesController : ControllerBase
    {
        private readonly ICourseTypeService _courseTypeService;

        public CourseTypesController(ICourseTypeService courseTypeService)
        {
            _courseTypeService = courseTypeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var courseType = await _courseTypeService.GetByIdAsync(id);
            if (courseType == null)
            {
                return NotFound();
            }
            return Ok(courseType);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courseTypes = await _courseTypeService.GetAllAsync();
            return Ok(courseTypes);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseTypeDto courseTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdCourseType = await _courseTypeService.CreateAsync(courseTypeDto);
            return CreatedAtAction(nameof(GetById), new { id = createdCourseType.Id }, createdCourseType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CourseTypeDto courseTypeDto)
        {
            if (id != courseTypeDto.Id)
            {
                return BadRequest();
            }
            var result = await _courseTypeService.UpdateAsync(courseTypeDto);
            if(result == null)
            {
                return NotFound();
            }
            var updateCourseType = await _courseTypeService.GetByIdAsync(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _courseTypeService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok(new { message = "Remove Item Successfuly" });
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(int pageIndex, int pageSize)
        {
            var (items, totalCount) = await _courseTypeService.GetPagedAsync(pageIndex, pageSize);
            return Ok(new { Items = items, TotalCount = totalCount });
        }
    }
}
