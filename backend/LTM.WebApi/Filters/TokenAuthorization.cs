using LTM.WebApi.Models;
using LTM.WebApi.Security;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace LTM.WebApi.Filters
{
    public class TokenAuthorization : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authToken = actionContext.Request.Headers.Authorization.Parameter;
                var userProfile = ValidateToken(authToken);
                if (userProfile != null && userProfile.Id > 0 && actionContext.Request.Headers.Authorization.Scheme == "Bearer")
                {
                    HttpContext.Current.User = new GenericPrincipal(new ApiIdentity(userProfile.Id, userProfile.Login), new string[] { });
                    base.OnActionExecuting(actionContext);
                }
                else
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
            }
        }

        private UserProfileModel ValidateToken(string token)
        {

            var simplePrinciple = JwtManager.GetPrincipal(token);
            if (simplePrinciple == null) return null;

            var identity = simplePrinciple.Identity as ClaimsIdentity;
            if (identity == null && !identity.IsAuthenticated)
                return null;

            var userId = identity.FindFirst(ClaimTypes.PrimarySid);
            var name = identity.FindFirst(ClaimTypes.Name);

            if (!string.IsNullOrWhiteSpace(userId.Value))
                return new UserProfileModel() { Id = Convert.ToInt32(userId.Value), Login = name.Value };

            return null;
        }
    }
}