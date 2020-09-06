using Diary.Bussiness.ResultModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Diary.Extensions
{
    public class ApiResultFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {

            if (context.Result is ErrorObjectResult)
            {
                var result = context.Result as ErrorObjectResult;
                context.Result = new ObjectResult(BaseResponseResult.Failed(result.Msg));
                return;
            }
            if (context.Result is ObjectResult)
            {
                var objectResult = context.Result as ObjectResult;
                int? code = objectResult.StatusCode;
                if(code.HasValue && code.Value != 200)
                {
                    context.Result = new ObjectResult(BaseResponseResult.Failed(objectResult.Value));
                }
                else
                {
                    context.Result = new ObjectResult(BaseResponseResult.Success(objectResult.Value));
                }
            }
            else if(context.Result is EmptyResult)
            {
                context.Result = new ObjectResult(BaseResponseResult.NotFound());
            }
            else if(context.Result is ContentResult)
            {
                context.Result = new ObjectResult(BaseResponseResult.Success((context.Result as ContentResult).Content));
            }
            else if(context.Result is StatusCodeResult)
            {
                var objectResult = context.Result as StatusCodeResult;
                context.Result = new ObjectResult(objectResult.StatusCode == 200 ? BaseResponseResult.Success() : BaseResponseResult.Failed());
            }
        }
    }
}
