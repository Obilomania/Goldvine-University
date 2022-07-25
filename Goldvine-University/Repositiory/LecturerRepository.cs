//using Goldvine_University.Data;
//using Goldvine_University.Models;
//using Goldvine_University.Repositiory.IRepository;

//namespace Goldvine_University.Repositiory
//{
//    public class LecturerRepository : Repository<Lecturer>, ILecturerRepository
//    {
//        private ApplicationDbContext _context;
//        public LecturerRepository(ApplicationDbContext context) : base(context)
//        {
//            _context = context;
//        }
//        public void Save()
//        {
//            _context.SaveChanges();
//        }

//        public void Update(Lecturer lecturer)
//        {
//            _context.Lecturers.Update(lecturer);
//         }
//    }
//}
