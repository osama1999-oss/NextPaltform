using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Next.Platform.Web.Validation
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelsState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(Kvp => Kvp.Key, Kvp => Kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();
                var errorResponse =new ErrorResponse();
                foreach (var error in errorsInModelsState)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new ErrorModel
                        {
                            FieldName = error.Key,
                            Message = subError
                        };
                        errorResponse.Errors.Add((errorModel));
                    }
                }
                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }

            await next();
        }
    }
}
