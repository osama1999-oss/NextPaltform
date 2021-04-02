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
                var ErrorsInModelsState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(Kvp => Kvp.Key, Kvp => Kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();
                var ErrorResponse =new ErrorResponse();
                foreach (var error in ErrorsInModelsState)
                {
                    foreach (var subError in error.Value)
                    {
                        var ErrorModel = new ErrorModel
                        {
                            FieldName = error.Key,
                            Message = subError
                        };
                        ErrorResponse.Errors.Add((ErrorModel));
                    }
                }
                context.Result = new BadRequestObjectResult(ErrorResponse);
                return;
            }

            await next();
        }
    }
}
