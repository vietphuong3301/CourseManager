using AutoMapper;
using CourseManager.DTO.DTOs;
using CourseManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetById(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
                return NotFound();

            return Ok(course);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAll()
        {
            var courses = await _courseService.GetAllAsync();
            return Ok(courses);
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto>> Create([FromBody] CourseDto courseDto)
        {
            var createdCourse = await _courseService.CreateAsync(courseDto);
            return CreatedAtAction(nameof(GetById), new { id = createdCourse.Id }, createdCourse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CourseDto courseDto)
        {
            if (id != courseDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            var existingCourse = await _courseService.GetByIdAsync(id);
            if (existingCourse == null)
            {
                return NotFound();
            }

            var result = await _courseService.UpdateAsync(courseDto);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _courseService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("paged")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetPaged(int pageIndex, int pageSize)
        {
            var (courses, totalCount) = await _courseService.GetPagedAsync(pageIndex, pageSize);
            Response.Headers.Add("X-Total-Count", totalCount.ToString());
            return Ok(courses);
        }

        [HttpGet("bycategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetByCategory(int categoryId)
        {
            var courses = await _courseService.GetByCategoryAsync(categoryId);
            return Ok(courses);
        }

        [HttpGet("bycoursetype/{courseTypeId}")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetByCourseType(int courseTypeId)
        {
            var courses = await _courseService.GetByCourseTypeAsync(courseTypeId);
            return Ok(courses);
        }
    }
}
