using APImanytomanyRepoPattern.Models;

namespace APImanytomanyRepoPattern.Interface
{
    public interface ICourse
    {
        Task<IEnumerable<Course>> GetAllCourses();
        Task<Course> GetCourseById(int courseId);
        Task AddCourse(Course course);
        Task UpdateCourse(Course course);
        Task DeleteCourse(int courseId);
    }
}
