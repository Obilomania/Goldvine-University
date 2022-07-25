using Goldvine_University.Data;
using Goldvine_University.Models;
using Goldvine_University.Repositiory.IRepository;

namespace Goldvine_University.Repositiory
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context) 
        {
            _context = context;
            //Lecturer = new LecturerRepository(_context);
            //Student = new StudentRepository(_context);
            Post = new PostRepository(_context);
           
        }
        //public ILecturerRepository Lecturer{get; private set;}
        //public IStudentRepository Student{get; private set;}
        public IPostRepository Post{get; private set;}

        public void Save()
        {
            _context.SaveChanges(); 
        }
    }
}
