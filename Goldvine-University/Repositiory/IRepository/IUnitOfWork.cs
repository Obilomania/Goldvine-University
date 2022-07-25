namespace Goldvine_University.Repositiory.IRepository
{
    public interface IUnitOfWork
    {
        //ILecturerRepository Lecturer{ get; }
        //IStudentRepository Student{ get; }
        IPostRepository Post{ get; }

        void Save();
    }
}
