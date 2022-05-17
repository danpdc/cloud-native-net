﻿namespace ContractManagement.WebApi.Filters;

public class ConsistencyExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is ConsistencyException exception)
        {
            var data = new
            {
                Message = exception.Message,
                Details = new List<string>(exception.Details)
            };
            context.Result = new ObjectResult(data)
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };

            context.ExceptionHandled = true;
        }
    }
}