using Dapper.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.DAL.Entity
{
    public interface IDataAccess
    {
        List<User> list();
        bool Delete(User model);
        bool Insert(User model);
        bool Update(User model);
     }
}
