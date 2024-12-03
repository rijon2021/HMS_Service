using DotNet.Services.HMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Services.HMS.Services.Implementations
{
    public class AuthUserService : IAuthUserService
    {
        public int GetUserId(HttpContext context)
        {
            if (context.User.Identity != null && context.User.Identity.IsAuthenticated)
            {
                // Extract User ID from Claims
                var userIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == "UserAutoID");
                if (userIdClaim != null)
                {
                    if (int.TryParse(userIdClaim.Value, out var userId))
                    {
                        return userId;
                    }
                }
            }
            return 0; // Default if not found or unauthenticated
        }
    }
}
