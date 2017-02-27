using System.Collections.Generic;
using AionHR.Services.Messaging;

public class DayBreaksListRequest:ListRequest
{
    public string ScheduleId { get; set; }
    
    public string DayOfWeek { get; set; }
    private Dictionary<string, string> parameters;

    public override Dictionary<string, string> Parameters
    {
        get
        {
            parameters = new Dictionary<string, string>();
            parameters.Add("_scId", ScheduleId);
            parameters.Add("_dow", DayOfWeek);
            
            return parameters;
        }
    }
}

public class AttendanceScheduleRecordRequest:RecordRequest
{
    public string ScheduleId { get; set; }
    public Dictionary<string, string> parameters;
    public override Dictionary<string, string> Parameters
    {
        get
        {
            parameters = new Dictionary<string, string>();
            parameters.Add("_scId", ScheduleId);
            return parameters;
        }
    }
}
public class AttendanceScheduleDayRecordRequest : RecordRequest
{
    public string ScheduleId { get; set; }
    public string DayOfWeek { get; set; }
    public Dictionary<string, string> parameters;
    public override Dictionary<string, string> Parameters
    {
        get
        {
            parameters = new Dictionary<string, string>();
            parameters.Add("_scId", ScheduleId);
            parameters.Add("_dow", DayOfWeek);
            return parameters;
        }
    }
}

public class AttendanceScheduleDayListRequest:ListRequest
{
    public string ScheduleId { get; set; }
    public Dictionary<string, string> parameters;
    public override Dictionary<string, string> Parameters
    {
        get
        {
            parameters = new Dictionary<string, string>();
            parameters.Add("_scId", ScheduleId);
           
            return parameters;
        }
    }
}
public class AttendanceDayBreaksListRequest : ListRequest
{
    public string ScheduleId { get; set; }
    public string DayOfWeek { get; set; }
    public Dictionary<string, string> parameters;
    public override Dictionary<string, string> Parameters
    {
        get
        {
            parameters = new Dictionary<string, string>();
            parameters.Add("_scId", ScheduleId);
            parameters.Add("_dow", DayOfWeek);
            return parameters;
        }
    }
}
public class DeleteDayBreaksRequest : RequestBase

{
    public string ScheduleId
    { get; set; }
    public string Dow
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
            parameters.Add("_scId", ScheduleId);
            parameters.Add("_dow", Dow);
            parameters.Add("_seqNo", "0");

            return parameters;
        }
    }
}