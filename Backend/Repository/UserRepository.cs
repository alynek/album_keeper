using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Model;

namespace Backend.Repository
{
    public class UserRepository : IRepository<User>
    {
        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(User item)
        {
            throw new NotImplementedException();
        }

        public Task Save(User item)
        {
            throw new NotImplementedException();
        }

        public Task Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}