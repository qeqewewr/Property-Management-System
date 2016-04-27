using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///TenementCost 的摘要说明
/// </summary>
public class TenementCost
{
	public TenementCost()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    //记录ID
    private string id;
    //楼宇
    private string buildingName;
    //房间
    private string room;
    //租户
    private string lessee;
    //费用
    private decimal fee;
    //费用类型
    private string feeType;
    //费用月份
    private string startDate;
    //录入员工号
    private string inputEmployId;
    //录入时间
    private string inputDateTime;
    //截止时间
    private string deadline;
    //是否已支付
    private Boolean isPayed;
    
    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Lessee
    {
        get { return lessee; }
        set { lessee = value; }
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

    public decimal Fee
    {
        get { return fee; }
        set { fee = value; }
    }

    public string FeeType
    {
        get { return feeType; }
        set { feeType = value; }
    }

    public string StartDate
    {
        get { return startDate; }
        set { startDate = value; }
    }

    public string InputEmployId
    {
        get { return inputEmployId; }
        set { inputEmployId = value; }
    }

    public string InputDateTime
    {
        get { return inputDateTime; }
        set { inputDateTime = value; }
    }

    public string Deadline
    {
        get { return deadline; }
        set { deadline = value; }
    }

    public Boolean IsPayed
    {
        get { return isPayed; }
        set { isPayed = value; }
    }

  



}