using Programming.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ProgramminAPI.Security
{
    public class APIKeyHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            var queryString = request.RequestUri.ParseQueryString(); // name ve value cinsinden cellation dödürecek
            var apiKey = queryString["apiKey"];
            //var apiKey = request.Headers.GetValues("apiKey").FirstOrDefault()
            UsersDAL userDAL = new UsersDAL();
            var user = userDAL.GetUserbyApiKey(apiKey);
            if (user != null)
            {
                var principal = new ClaimsPrincipal(new GenericIdentity(user.Name , "APIKey"));
                HttpContext.Current.User = principal;
            }
             return base.SendAsync(request, cancellationToken);
        }
    }
}