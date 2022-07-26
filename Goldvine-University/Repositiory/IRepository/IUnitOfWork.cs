namespace Goldvine_University.Repositiory.IRepository
{
    public interface IUnitOfWork
    {
        //ILecturerRepository Lecturer{ get; }
        IPhotoRepository Photo { get; }
        IPostRepository Post{ get; }

        void Save();
    }
}
