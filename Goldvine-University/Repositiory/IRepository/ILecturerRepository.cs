using Goldvine_University.Models;

namespace Goldvine_University.Repositiory.IRepository
{
    public interface ILecturerRepository : IRepository<Lecturer>
    {
        void Update(Lecturer lecturer);
        //void Save(); 
    }
}
