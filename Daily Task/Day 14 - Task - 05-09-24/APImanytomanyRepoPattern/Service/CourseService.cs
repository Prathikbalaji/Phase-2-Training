using APImanytomanyRepoPattern.Interface;
using APImanytomanyRepoPattern.Models;

namespace APImanytomanyRepoPattern.Service
{
    public class CourseService
    {
        private readonly ICourse _courseRepository;

        public CourseService(ICourse repo)
        {
            _courseRepository = repo;
        }
        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllCourses();
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            return await _courseRepository.GetCourseById(courseId);
        }

        public async Task AddCourseAsync(Course course)
        {
            await _courseRepository.AddCourse(course);
        }

        public async Task UpdateCourseAsync(Course course)
        {
            await _courseRepository.UpdateCourse(course);
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            await _courseRepository.DeleteCourse
                (courseId);
        }
    }
}
