using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Model;

namespace Backend.Repository
{
    public class UserRepository : BaseRepository<User>, IRepository<User>
    {
        public UserRepository(Context context) : base(context)
        {
            
        }
    }
}