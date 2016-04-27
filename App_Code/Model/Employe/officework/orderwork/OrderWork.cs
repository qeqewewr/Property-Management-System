using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///OrderWork 的摘要说明
/// </summary>
public class OrderWork
{
	public OrderWork()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    private string id;
    private string buildingName;
    private string room;
    private string lessee;
    //加班开始日期
    private string dayStart;
    //加班结束日期
    private string dayEnd;
    //加班开始时间
    private string timeStart;
    //加班结束时间
    private string timeEnd;
    //加班人数
    private int num;
    //所需服务
    private string service;
    //备注
    private string remark;
    //加班费用
    private decimal fee;
    //用户是否确认
    private Boolean isSure;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public string BuildingName
    {
        get { return buildingName; }
        set { buildingName = value; }
    }

    public string Room
    {
        get { return room; }
        set { room = value; }
    }

    public string Lessee
    {
        get { return lessee; }
        set { lessee = value; }
    }

    public string DayStart
    {
        get { return dayStart; }
        set { dayStart = value; }
    }

    public string DayEnd
    {
        get { return dayEnd; }
        set { dayEnd = value; }
    }

    public string TimeStart
    {
        get { return timeStart; }
        set { timeStart = value; }
    }

    public string TimeEnd
    {
        get { return timeEnd; }
        set { timeEnd = value; }
    }

    public int Num
    {
        get { return num; }
        set { num = value; }
    }

    public string Service
    {
        get { return service; }
        set { service = value; }
    }

    public string Remark
    {
        get { return remark; }
        set { remark = value; }
    }

    public decimal Fee
    {
        get { return fee; }
        set {  fee = value; }
    }

    public Boolean IsSure
    {
        get { return isSure; }
        set { isSure = value; }
    }
}