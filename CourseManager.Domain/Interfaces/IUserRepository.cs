using CourseManager.Domain.Entities;

namespace CourseManager.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindSingleAsync(Func<User, bool> predicate);

        Task<IEnumerable<User>> GetPagedAsync(int pageNumber, int pageSize);
    }
}