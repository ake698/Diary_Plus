using Diary.Bussiness.Dtos.User;
using Diary.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diary.IBLL
{
    public interface ICurrentUser
    {
        UserDto GetCurrentUser();
    }
}
