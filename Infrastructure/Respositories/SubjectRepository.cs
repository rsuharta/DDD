namespace Infrastructure.Data
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Domain;

    using Infrastructure.DbContext;

    public interface ISubjectRepository
    {
        Task<Subject> GetAsync(string code, CancellationToken cancellationToken);

        Task SaveAsync(Subject subject);
    }

    public class SubjectRepository : ISubjectRepository
    {
        public async Task<Subject> GetAsync(string subjectCode, CancellationToken cancellationToken)
        {
            var dbSession = InMemorySessionFactoryProvider.Instance.DbSession();
            return await Task.Run(() =>  dbSession.Query<Subject>().SingleOrDefault(s => s.SubjectCode == subjectCode), cancellationToken);
        }

        public Task SaveAsync(Subject subject)
        {
            throw new System.NotImplementedException();
        }
    }
}
