using Goldvine_University.Models;

namespace Goldvine_University.Repositiory.IRepository
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        void Update(Photo photo);
        //void Save(); 
    }
}
