using APImanytomanyRepoPattern.Interface;
using APImanytomanyRepoPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace APImanytomanyRepoPattern.Repository
{
    public class CourseRepository : ICourse
    {
        private readonly StudCourseDbContext _context;

        public CourseRepository(StudCourseDbContext context)
        {
            _context = context;
        }
        public async Task AddCourse(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourse(int courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync() ?? throw new NullReferenceException();
        }

        public async Task<Course> GetCourseById(int courseId)
        {
            return await _context.Courses
            .FirstOrDefaultAsync(c => c.CourseId == courseId) ?? throw new NullReferenceException();
        }

        public async Task UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }
    }
}
