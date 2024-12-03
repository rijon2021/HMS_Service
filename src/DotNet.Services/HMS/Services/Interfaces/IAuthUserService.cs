using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Services.HMS.Services.Interfaces
{
    public interface IAuthUserService
    {
        int GetUserId(HttpContext context);
    }
}
