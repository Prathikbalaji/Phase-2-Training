using APImanytomanyRepoPattern.Interface;
using APImanytomanyRepoPattern.Models;

namespace APImanytomanyRepoPattern.Service
{
    public class StudentService
    {
        private readonly IStudent stu;

        public StudentService(IStudent stu)
        {
            this.stu = stu;
        }

        public async Task<IEnumerable<Student>> getAllStudents()
        {
            return await stu.getAllStudents();
        }

        public async Task<Student> getStudentById(int id)
        {
            return await stu.getStudentById(id);
        }

        public async Task AddStudent(Student student)
        {
            await stu.AddStudent(student);
        }

        public async Task UpdateStudent(int id ,Student student)
        {
            await stu.UpdateStudent(id, student);
        }

        public async Task DeleteStudent(int id)
        {
            await stu.DeleteStudent(id);
        }

    }
}
