using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ApplicationCore.DTOs.Common
{
    public class GenerateToken
    {
        public string name { get; set; }
        public GenerateTokenRequest param { get; set; }
    }

    public class GenerateTokenRequest
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string ApplicationTypeID { get; set; }
        public string ApplicationUserName { get; set; }
        public string ApplicationUserEmail { get; set; }
        public string ApplicationUserPhone { get; set; }
        public string ApplicationUserCDAID { get; set; }
    }

}
