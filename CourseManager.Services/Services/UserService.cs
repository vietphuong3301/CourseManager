using AutoMapper;
using CourseManager.Data.Repositories;
using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;
using CourseManager.DTO.DTOs;
using CourseManager.Services.Interfaces;
using System.Linq.Expressions;

namespace CourseManager.Services.Services
{
    public class UserService : BaseService<User, UserDto>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IMapper mapper)
            : base(userRepository, mapper)
        {
            _userRepository = userRepository;
        }
    
    }
}
