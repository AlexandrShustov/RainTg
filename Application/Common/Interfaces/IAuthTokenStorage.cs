using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IAuthTokenStorage
    {
        Task<string> GetBy(long chatId);
        Task AssignTo(long chatId, string token);
    }
}
