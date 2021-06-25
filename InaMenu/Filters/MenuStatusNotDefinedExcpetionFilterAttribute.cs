using InaMenu.Controllers.Menu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InaMenu.Filters
{
    public class MenuStatusNotDefinedExcpetionFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            if (context.Exception is MenuStatusNotDefinedException)
            {
                context.Result = new BadRequestObjectResult(new ExceptionResponse()
                {
                    Message = exception.Message
                });

                context.ExceptionHandled = true;
            }
        }
    }
}
