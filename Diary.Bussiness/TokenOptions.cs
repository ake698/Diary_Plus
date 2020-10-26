using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Bussiness
{
    public class TokenOptions
    {
        public const string Options = "TokenOptions";

        public string Issurer { get; set; }
        public string Audience { get; set; }
        public string Sign { get; set; }
        public int AccessExpiration { get; set; }
    }
}
