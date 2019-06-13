namespace Infrastructure.Data
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Domain;

    using Infrastructure.DbContext;

    public interface IStudentRepository
    {
        Task<Student> GetAsync(string studentNumber, CancellationToken cancellationToken);

        Task SaveAsync(Student student, CancellationToken cancellationToken);
    }

    public class StudentRepository : IStudentRepository
    {
        public async Task<Student> GetAsync(string studentNumber, CancellationToken cancellationToken)
        {
            var dbSession = InMemorySessionFactoryProvider.Instance.DbSession();
            return await Task.Run(() => dbSession.Query<Student>().SingleOrDefault(s => s.StudentNumber == studentNumber), cancellationToken);
        }

        public async Task SaveAsync(Student student, CancellationToken cancellationToken)
        {
            var dbSession = InMemorySessionFactoryProvider.Instance.DbSession();
            await dbSession.SaveAsync(student);
            await dbSession.FlushAsync(cancellationToken);
        }
    }
}
