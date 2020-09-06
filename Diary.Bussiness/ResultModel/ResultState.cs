using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Bussiness.ResultModel
{
    public enum ResultState
    {
        Success = 200,
        Fail = 400,
        Error = 500,
        NotFound = 404
    }
}
