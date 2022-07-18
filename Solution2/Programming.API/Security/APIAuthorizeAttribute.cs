using ProgrammingDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Programming.API.Security
{
    public class APIAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var actionRoles = Roles;
            var userName = HttpContext.Current.User.Identity.Name;
            UsersDAL userDal = new UsersDAL();
            var user = userDal.GetUsersByName(userName);
            if (user != null && actionRoles.Contains(user.Roles))
            {

            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }

            //var actionRoles = Roles; // A
            //var userName = HttpContext.Current.User.Identity.Name;
            //UsersDAL userDal = new UsersDAL();
            //var user = userDal.GetUsersByName(userName);

            //if (user != null && actionRoles.Contains(user.Role))
            //{


            //}
            //else
            //{
            //    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            //}
        }
    }
}