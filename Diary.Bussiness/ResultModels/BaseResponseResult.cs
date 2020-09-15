namespace Diary.Bussiness.ResultModels
{
    public class BaseResponseResult
    {
        public BaseResponseResult(bool state, string msg, object data)
        {
            IsSuccess = state;
            Msg = msg;
            Data = data;
        }

        public static BaseResponseResult Success(string msg, object data)
        {
            return new BaseResponseResult(true, msg, data);
        }

        public static BaseResponseResult Success(object data)
        {
            //return new BaseResponseResult(true, "Success", data);
            return Success("Success", data);
        }

        public static BaseResponseResult Success()
        {
            return Success(null);
        }


        public static BaseResponseResult Failed(object data)
        {
            return new BaseResponseResult(false, "Failed", data);
        }

        public static BaseResponseResult Failed(string msg = "Failed")
        {
            return new BaseResponseResult(false, msg, null);
        }

        public static BaseResponseResult NotFound()
        {
            return new BaseResponseResult(false, "Not Found!", null);
        }

        public bool IsSuccess { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }

   
}
