using Goldvine_University.Models;

namespace Goldvine_University.Repositiory.IRepository
{
    public interface IPostRepository : IRepository<Post>
    {
        void Update(Post post);
        void Save();
    }
}
