using Dapper.DAL;
using Dapper.DAL.Entity;
using Dapper.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Business
{
    public class UserManager : IDataAccess
    {
        Connection con = new Connection();
        public bool Delete(User model)
        {
            con.conOpen();
            con.getConnect.Query<User>(@"DELETE FROM [dbo].[User] WHERE id=@id", model);
            con.conClose();
            return true;
        }

        public bool Insert(User model)
        {
            con.conOpen();
            con.getConnect.Query<User>(@"INSERT INTO [dbo].[User]([Name],[Surname]) VALUES(@Name,@Surname)", model);
            con.conClose();
            return true;
        }

        public List<User> list()
        {
            
             con.conOpen();
             List<User> liste = con.getConnect.Query<User>("SELECT * FROM [dbo].[User]").ToList();
             con.conClose();
             return liste;
          
        }

        public bool Update(User model)
        {
            con.conOpen();
            con.getConnect.Query<User>(@"UPDATE [dbo].[User] SET [Name] = @Name,
                                                               [Surname]=@Surname WHERE [id]=@id", model);
            con.conClose();
            return true;
        }

        public User Get(int id)
        {
           
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);
            User user = con.getConnect.QueryFirstOrDefault<User>("SELECT * FROM [dbo].[User] WHERE [id]=@id",param);
            return user;
        }
    }
}
