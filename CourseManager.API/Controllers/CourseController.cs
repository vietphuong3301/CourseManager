using Microsoft.AspNetCore.Mvc;
using CourseManager.DTO.DTOs;
using CourseManager.Services.Services;
using System.Threading.Tasks;

namespace CourseManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAllAsync();
            return Ok(courses);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdCourse = await _courseService.CreateAsync(courseDto);
            return CreatedAtAction(nameof(GetById), new { id = createdCourse.Id }, createdCourse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CourseDto courseDto)
        {
            if (id != courseDto.Id)
            {
                return BadRequest();
            }
            var result = await _courseService.UpdateAsync(courseDto);
            if (!result)
            {
                return NotFound();
            }
            var updateCourse = await _courseService.GetByIdAsync(id);
            return Ok(updateCourse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _courseService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok(new {message = "Remove item Successfuly"});
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(int pageIndex, int pageSize)
        {
            var (items, totalCount) = await _courseService.GetPagedAsync(pageIndex, pageSize);
            return Ok(new { Items = items, TotalCount = totalCount });
        }


        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var courses = await _courseService.GetByCategoryAsync(categoryId);
            return Ok(courses);
        }

        [HttpGet("coursetype/{courseTypeId}")]
        public async Task<IActionResult> GetByCourseType(int courseTypeId)
        {
            var courses = await _courseService.GetByCourseTypeAsync(courseTypeId);
            return Ok(courses);
        }
    }
}
