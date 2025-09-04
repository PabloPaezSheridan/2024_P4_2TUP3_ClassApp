using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        protected TUP3Context _context;

        public List<T?> Get()
        {  
            return new List<T?>(); 
        }
    }
}
