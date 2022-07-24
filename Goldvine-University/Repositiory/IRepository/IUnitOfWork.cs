namespace Goldvine_University.Repositiory.IRepository
{
    public interface IUnitOfWork
    {
        ILecturerRepository Lecturer { get; }
        void Save();
    }
}
