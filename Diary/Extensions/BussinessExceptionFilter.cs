using Diary.Bussiness.Exceptions;
using Diary.Bussiness.ResultModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Diary.Extensions
{
    public class BussinessExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            // 如果异常没有被处理则进行处理
            if (context.ExceptionHandled == false)
            {
                // 定义返回类型
                var result = BaseResponseResult.Failed(context.Exception.Message);

                if (context.Exception is BussinessException)
                {
                    context.Result = new ContentResult
                    {
                        StatusCode = StatusCodes.Status200OK,
                        // 设置返回格式
                        ContentType = "application/json;charset=utf-8",
                        Content = JsonConvert.SerializeObject(result)
                    };
                }
                // 为了方便开发，暂时关闭
                //else
                //{
                //    result.Msg = "500InternalServerError";
                //    context.Result = new ContentResult
                //    {
                //        StatusCode = StatusCodes.Status500InternalServerError,
                //        ContentType = "application/json;charset=utf-8",
                //        Content = JsonConvert.SerializeObject(result)
                //    };
                //}
            }
            // 设置为true，表示异常已经被处理了
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}
