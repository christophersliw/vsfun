using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace api2
{
    public class ApiAuthorizeAttrbute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Contains("Authorization"))
            {
                var hvalues = actionContext.Request.Headers.GetValues("Authorization");
            }
            else
            {
                throw new HttpException(403, "Forbidden");
            }
        }
    
    }
}