using static DotNet.ApplicationCore.Utils.Enums.GlobalEnum;

namespace DotNet.ApplicationCore.DTOs
{
    public class ResponseMessage
    {
        public ReturnStatus StatusCode { get; set; }
        public string Message { get; set; }
        public object ResponseObj { get; set; }
        public string Token { get; set; }
        public string ApplicationUserCDAID { get; set; }
        public string Status {  get; set; }
    }
}
