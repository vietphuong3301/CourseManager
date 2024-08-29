using AutoMapper;
using CourseManager.Domain.Entities;
using CourseManager.DTO.DTOs;


namespace CourseManager.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapping configurations between entities and DTOs
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<CourseType, CourseTypeDto>().ReverseMap();
            CreateMap<Instructor, InstructorDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserCourse, UserCourseDto>().ReverseMap();
        }
    }
}