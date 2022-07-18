using Programming.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ProgramminAPI.Security
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var actionRoles = Roles;
            var userName = HttpContext.Current.User.Identity.Name;
            UsersDAL userDal = new UsersDAL();
            var user = userDal.GetUserByName(userName);
            if (user != null && actionRoles.Contains(user.Roles) )
            {
                
            }
            else
                {
               actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
                }
    }
}