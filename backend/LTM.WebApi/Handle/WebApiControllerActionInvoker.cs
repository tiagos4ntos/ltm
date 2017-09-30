using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;

namespace LTM.WebApi.Handle
{
    public class WebApiControllerActionInvoker : ApiControllerActionInvoker
    {
        public override Task<HttpResponseMessage> InvokeActionAsync(HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {
            var result = base.InvokeActionAsync(actionContext, cancellationToken);

            if (result.Exception != null && result.Exception.GetBaseException() != null)
            {
                var baseException = result.Exception.GetBaseException();

                if (baseException is ArgumentException)
                {
                    return Task.Run<HttpResponseMessage>(() => new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        Content = new StringContent(baseException.Message),
                        ReasonPhrase = "Error",

                    });
                }
                else
                {
                    //Log critical error
                    Debug.WriteLine(baseException);

                    return Task.Run<HttpResponseMessage>(() => new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        Content = new StringContent("An unexpected error has occurred, please contact the system administrator."),
                        ReasonPhrase = "Critical Error"
                    });
                }
            }

            return result;
        }
    }
}