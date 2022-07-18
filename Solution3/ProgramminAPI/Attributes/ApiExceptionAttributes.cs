using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace ProgramminAPI.Attributes
{
    public class ApiExceptionAttributes:ExceptionFilterAttribute

    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseMessage errorResPonse = new HttpResponseMessage(System.Net.HttpStatusCode.NotImplemented);
            errorResPonse.ReasonPhrase = actionExecutedContext.Exception.Message;
            actionExecutedContext.Response = errorResPonse;
            base.OnException(actionExecutedContext);
        }
    }
}