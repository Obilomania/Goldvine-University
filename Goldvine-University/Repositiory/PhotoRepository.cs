using Goldvine_University.Data;
using Goldvine_University.Models;
using Goldvine_University.Repositiory.IRepository;

namespace Goldvine_University.Repositiory
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        private ApplicationDbContext _context;
        public PhotoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Photo photo)
        {
            _context.Photos.Update(photo);
        }
    }
}
