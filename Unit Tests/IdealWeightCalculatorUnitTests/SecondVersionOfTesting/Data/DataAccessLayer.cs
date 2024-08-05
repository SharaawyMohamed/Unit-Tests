using SecondVersionOfTesting.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondVersionOfTesting.Data
{
    public class DataAccessLayer
    {
        private readonly UserDbContext _context;
        public DataAccessLayer(UserDbContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
          int x=_context.SaveChanges();
        }
        public User GetUserByName(string name)
        {
           return _context.Users.FirstOrDefault(n=>n.Name==name);
        }
    }
}
