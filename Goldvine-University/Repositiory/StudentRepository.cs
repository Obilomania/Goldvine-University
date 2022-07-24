using Goldvine_University.Data;
using Goldvine_University.Models;
using Goldvine_University.Repositiory.IRepository;

namespace Goldvine_University.Repositiory
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
         }
    }
}
