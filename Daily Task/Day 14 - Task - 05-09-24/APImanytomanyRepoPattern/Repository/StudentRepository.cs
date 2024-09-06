using APImanytomanyRepoPattern.Interface;
using APImanytomanyRepoPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace APImanytomanyRepoPattern.Repository
{
    public class StudentRepository : IStudent
    {
        private readonly StudCourseDbContext _context;

        public StudentRepository(StudCourseDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> getAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> getStudentById(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(a => a.StudentId == id) ?? new Student();
        }

        public async Task AddStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudent(int id, Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(int id)
        {
            Student stu = await _context.Students.FindAsync(id) ?? new Student();
            _context.Students.Remove(stu);
            await _context.SaveChangesAsync();
        }

    }
}
