using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Diary.Extensions
{
    public class ModelValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var modelState = context.ModelState;
           if (!modelState.IsValid)
            {
                string error = string.Empty;
                foreach (var key in modelState.Keys)
                {
                    var state = modelState[key];
                    if (state.Errors.Any())
                    {
                        var errorInfo = state.Errors.First();
                        string ex = (errorInfo.Exception == null ? "" : errorInfo.Exception.ToString());
                        error = string.IsNullOrEmpty(errorInfo.ErrorMessage) ? ex : errorInfo.ErrorMessage;

                        break;
                    }
                }

                if (!string.IsNullOrEmpty(error))
                    context.Result = new ErrorObjectResult(error, null);
            }
        }
    }

    public class ErrorObjectResult : ObjectResult
    {
        public string Msg { get; set; }
        public ErrorObjectResult(string msg, object value) : base(value)
        {
            Msg = msg;
        }
    }
}
