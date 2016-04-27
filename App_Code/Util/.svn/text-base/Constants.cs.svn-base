using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Constants 的摘要说明
/// </summary>
public class Constants
{
	public Constants()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public static string CARTORDER = "0"; //购物车

    public static string WAITCHECK = "1";//提交订单后等待确认
    public static string CHECKED = "2";//已经确认订单（准备发货）
    public static string SENDED = "3";//已发货
    public static string CANCEL = "4";//取消订单（余额不足等）
    public static string DEALFAIL = "5";//交易不成功（退款等）
    public static string DEALSUCCEED = "6";//交易成功
    public static float goodsNum = 0;


    //public static  string NEWORDER = "1"; //新订单

    //public static  string SETTLEORDER = "2"; //结算订单,已经付款

    //public static  string PROCESSORDER = "3";//订单处理中

    //public static  string RECEIVEORDER = "4";//收货订单

    //public static  string AUDITORDER = "5"; //已审核订单

    public static string CUSTOMRTYPE = "2";

    public static string ENTERPRISETYPE = "1";

    public static string orderStatus(string status)
    {
        if (status == "1")
            return "等待确认";
        else if (status == "2")
            return "已经确认订单（准备发货）";
        else if (status == "3")
            return "已发货";
        else if (status == "4")
            return "取消订单";
        else if (status == "5")
            return "交易不成功";
        else if (status == "6")
            return "交易成功";
        else
            return "用户购物车";
    }

    public static string payType(int type)
    {
        if (type == 1)
            return "预付款";
        else if (type == 2)
            return "货到付款";
        else
            return "";
    }


}