using APImanytomanyRepoPattern.Models;

namespace APImanytomanyRepoPattern.Interface
{
    public interface IStudent
    {
        Task<IEnumerable<Student>> getAllStudents();

        Task<Student> getStudentById(int id);

        Task AddStudent(Student student);

        Task UpdateStudent(int id,Student student);

        Task DeleteStudent(int id);

    }
}
