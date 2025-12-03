using System.Linq;
using TechVerse.Data;   
using TechVerse.Models; 

namespace TechVerse.Services
{
    public interface IAuthService
    {
        bool Login(string email, string password);
        void Logout();
    }
    public class AuthService : IAuthService
    {
        // 1. FIXED: Changed 'AppDbContext' to 'ApplicationDbContext'
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Login(string email, string password)
        {
            // 2. Query the database
            var student = _context.Students.FirstOrDefault(s => s.Email == email);

            if (student == null) return false;

            // 3. Check password
            // NOTE: If this line is red, see Part 2 below
            if (student.Password == password) 
            {
                return true;
            }

            return false;
        }

        public void Logout()
        {
            // In MVC, we will clear the Session here later
        }
    }
}