using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ByX.Model;
using ByX.Repository;
using ByX.Repository.Common;


namespace ByX.Repository
{
   public class RoleRepository:GenericRepository<Role>,IRoleRepository
   {
    
       public RoleRepository(DbContext context):base(context)
       {
           
       }

   
   }
}
