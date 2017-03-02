﻿using System.Collections.Generic;
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
public class CalendarYearsListRequest : ListRequest
{
    public string CalendarId { get; set; }
    
    public Dictionary<string, string> parameters;
    public override Dictionary<string, string> Parameters
    {
        get
        {
            parameters = new Dictionary<string, string>();
            parameters.Add("_caId", CalendarId);
            
            return parameters;
        }
    }
}

public class CalendarDayListRequest : ListRequest
{
    public string CalendarId { get; set; }
    public string Year { get; set; }

    public Dictionary<string, string> parameters;
    public override Dictionary<string, string> Parameters
    {
        get
        {
            parameters = new Dictionary<string, string>();
            parameters.Add("_caId", CalendarId);
            parameters.Add("_year", Year);

            return parameters;
        }
    }
}


public class CalendarDayRecordRequest:RecordRequest
{
    public string CaId { get; set; }
    
    public string year { get; set; }

    public string DayId { get; set; }

   

    public override Dictionary<string, string> Parameters
    {

        get
        {
            parameters = new Dictionary<string, string>();
            parameters.Add("_caId",CaId );
            parameters.Add("_dayId", DayId);
            parameters.Add("_year", year);
         

            return parameters;
        }
    }
}
public class AttendnanceDayListRequest:ListRequest
{
    public string EmployeeId { get; set; }
    public string DayId { get; set; }
    public string Month { get; set; }
    public string Year { get; set; }

    public string BranchId { get; set; }
    public string DepartmentId { get; set; }

    public string SortBy { get; set; }

    public override Dictionary<string, string> Parameters
    {

        get
        {
            parameters = new Dictionary<string, string>();
            parameters.Add("_employeeId", EmployeeId);
            parameters.Add("_dayId", DayId);
            parameters.Add("_month", Month);
            parameters.Add("_year", Year);
            parameters.Add("_branchId", BranchId);
            parameters.Add("_departmentId", DepartmentId);
            parameters.Add("_size", Size);
            parameters.Add("_sortBy", SortBy);
            parameters.Add("_startAt", StartAt);


            return parameters;
        }
    }
}