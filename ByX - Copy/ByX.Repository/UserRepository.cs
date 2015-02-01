using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using ByX.Model;
using ByX.Model.PhoneDetail;
using ByX.Repository;
using ByX.Repository.Common;


namespace ByX.Repository
{
  public  class UserRepository:GenericRepository<User>,IUserRepository
  {
      public UserRepository(DbContext context):base(context)
      {
      }


      public IPagedList<User> GetAllUserPaged(int pageIndex, int pageSize)
      {
              var users = new PagedList<User>(
                  _entities.Set<User>().AsQueryable().OrderBy(m => m.Id)
                 , pageIndex, pageSize);
            

              return users;
          
      } 

      public string GetRoleByUser(User usr)
      {
          string userroleName="";

          var firstOrDefault = _entities.Set<User>().FirstOrDefault(m => m.Username == usr.Username&& 
              m.Password==usr.Password);
          if (firstOrDefault != null)
          {
               userroleName = firstOrDefault.Role.Rolename;
          }
          return userroleName;
      }

      //for android wcf services
      public bool IsRegisteredUserHaveUniqueGuidAndExceedQuota(Guid UniqueGuid)
      {
          var ff = _entities.Set<User>().FirstOrDefault(m => m.UserUniqueId == UniqueGuid &&
              m.IsActive && m.UserPhoneQuota >= m.PhoneDetail.Count);
          return ff != null;
      }




      public bool IsRegisteredUser(User usrUser)
      {
          var firstOrDefault = _entities.Set<User>().FirstOrDefault(m => m.Username == usrUser.Username && m.Password == usrUser.Password);
          return firstOrDefault != null;
      }
  }
}
