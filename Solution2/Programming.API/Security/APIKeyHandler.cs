using ProgrammingDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Programming.API.Security
{
    public class APIKeyHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var queryString = request.RequestUri.ParseQueryString();
            var apiKey = queryString["apiKey"]; //Bu metotlar ile url de chrome yaparız 

           // var apiKey = request.Headers.GetValues("apiKey").FirstOrDefault(); 
            //YUKARIDAKİNDE İSE FİDDLER GİBİ PLATFORMLARDA İSTEK ATARIZ (HEADLER BOLUMUNDE)
            UsersDAL usersDAL = new UsersDAL();
            var user = usersDAL.GetUserByApiKey(apiKey);
            if (user!= null)
            {
                var principal = new ClaimsPrincipal(new GenericIdentity(user.Name, "APIKey"));
                HttpContext.Current.User = principal;
            }

            return base.SendAsync(request, cancellationToken);


        }

    }
}