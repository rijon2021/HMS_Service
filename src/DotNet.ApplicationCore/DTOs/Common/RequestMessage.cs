using DotNet.ApplicationCore.DTOs.Common;

namespace DotNet.ApplicationCore.DTOs
{
    public class RequestMessage
    {
        public object RequestObj { get; set; }
        public string Token { get; set; }
        public QueryObject QueryObject { get; set; }



        //pageIndex: number;
        //pageSize: number;
        //sortBy: string;
        //sortOrder: string;
        //filterBy: string;
        //branchID: number;
        //userID: string;
        //unitID: number;
        //organizationID?:number;
        //workingUnitID?:number;
        //UserAutoID?:number;
    }
}
