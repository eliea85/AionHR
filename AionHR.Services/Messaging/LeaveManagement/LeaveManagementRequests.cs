using AionHR.Services.Messaging;
using System.Collections.Generic;

public class DeleteVacationPeriodsRequest : RequestBase

{
    public string ScheduleId
    { get; set; }

    public Dictionary<string, string> parameters;

    /// <summary>
    /// parameter list shipped with the web request
    /// </summary>
    public override Dictionary<string, string> Parameters
    {

        get
        {
            parameters = new Dictionary<string, string>();
            parameters.Add("_vsId", ScheduleId);
            parameters.Add("_seqNo", "0");

            return parameters;
        }
    }
}

public class VacationPeriodsListRequest:ListRequest
{
    public string VacationScheduleId { get; set; }
    private Dictionary<string, string> parameters;

    public override Dictionary<string, string> Parameters
    {
        get
        {
            parameters = new Dictionary<string, string>();
            parameters.Add("_vsId", VacationScheduleId);
           

            return parameters;
        }
    }
}