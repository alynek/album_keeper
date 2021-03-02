using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Model;

namespace Backend.Repository
{
    public class AlbumRepository : BaseRepository<Album>, IRepository<Album>
    {
       public AlbumRepository(Context context) : base(context)
       {
           
       }
    }
}