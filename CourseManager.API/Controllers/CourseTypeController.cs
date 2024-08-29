using AutoMapper;
using CourseManager.DTO.DTOs;
using CourseManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseTypeController : ControllerBase
    {
        private readonly ICourseTypeService _courseTypeService;
        private readonly IMapper _mapper;

        public CourseTypeController(ICourseTypeService courseTypeService, IMapper mapper)
        {
            _courseTypeService = courseTypeService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseTypeDto>> GetById(int id)
        {
            var courseType = await _courseTypeService.GetByIdAsync(id);
            if (courseType == null)
                return NotFound();

            return Ok(courseType);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseTypeDto>>> GetAll()
        {
            var courseTypes = await _courseTypeService.GetAllAsync();
            return Ok(courseTypes);
        }

        [HttpPost]
        public async Task<ActionResult<CourseTypeDto>> Create([FromBody] CourseTypeDto courseTypeDto)
        {
            var createdCourseType = await _courseTypeService.CreateAsync(courseTypeDto);
            return CreatedAtAction(nameof(GetById), new { id = createdCourseType.Id }, createdCourseType);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CourseTypeDto courseTypeDto)
        {
            var result = await _courseTypeService.UpdateAsync(courseTypeDto);
            if (!result)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _courseTypeService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("paged")]
        public async Task<ActionResult<IEnumerable<CourseTypeDto>>> GetPaged(int pageIndex, int pageSize)
        {
            var (courseTypes, totalCount) = await _courseTypeService.GetPagedAsync(pageIndex, pageSize);
            Response.Headers.Add("X-Total-Count", totalCount.ToString());
            return Ok(courseTypes);
        }
    }
}
