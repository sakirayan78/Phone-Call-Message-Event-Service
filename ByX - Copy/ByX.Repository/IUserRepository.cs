using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByX.Model;
using ByX.Repository.Common;


namespace ByX.Repository
{


    public interface IUserRepository : IGenericRepository<User>
    {

        IPagedList<User> GetAllUserPaged(int pageIndex, int pageSize);

        //List<UserDto> GetUserByTerm(string term);

        //UserDto GetUserInfoByUserId(int id);

        string GetRoleByUser(User usr);


        bool IsRegisteredUserHaveUniqueGuidAndExceedQuota(Guid UniqueGuid);

        bool IsRegisteredUser(User usrUser);
    }
}
