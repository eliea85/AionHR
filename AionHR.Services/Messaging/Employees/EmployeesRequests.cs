using AionHR.Services.Messaging;
using System.Collections.Generic;

public class EmployeeListRequest:ListRequest
{
    public string DepartmentId { get; set; }
    public string BranchId { get; set; }

    public bool IncludeIsInactive { get; set; }

    public string SortBy { get; set; }

    private Dictionary<string, string> parameters;

    
    /// <summary>
    /// /// parameter list shipped with the web request
    /// </summary>
    public override Dictionary<string, string> Parameters
    {

        get
        {
            parameters = new Dictionary<string, string>();
            parameters.Add("_filter", Filter);
            parameters.Add("_size", Size);
            parameters.Add("_startAt", StartAt);
            parameters.Add("_departmentId", DepartmentId);
            parameters.Add("_branchId", BranchId);
            parameters.Add("_includeInactive", IncludeIsInactive.ToString());
            parameters.Add("_sortBy", SortBy);
           
            return parameters;
        }
    }
}