using System;

namespace Diary.Bussiness.Exceptions
{
    public class BussinessException : Exception
    {
        public BussinessException(string message) : base(message)
        {
        }
    }
}
