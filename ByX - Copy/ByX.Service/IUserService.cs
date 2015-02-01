using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByX.Model;
using ByX.Repository.Common;


namespace ByX.Service
{
 public   interface IUserService
    {
     /// <summary>
     /// sayfalamalı kullanıcı getir
     /// </summary>
     /// <param name="pageIndex"></param>
     /// <param name="pageSize"></param>
     /// <param name="filter"></param>
     /// <returns></returns>
     IPagedList<User> GetAllUserPaged(int pageIndex, int pageSize);

     string GetRoleByUser(User usr);

     bool IsRegisteredUserHaveUniqueGuidAndExceedQuota(Guid UniqueGuid);
     bool IsRegisteredUser(User usrUser);
   
    }
}
