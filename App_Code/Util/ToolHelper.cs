using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///ToolHelper 的摘要说明
/// </summary>
public class ToolHelper
{
	public ToolHelper()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public static string GetOrderStatus(string statusCode) {
        string status = "";

        if (statusCode == "1") {

            status = "新订单";
        }
        else if (statusCode == "2") {
            status = "已付款";
        }
        else if (statusCode == "3")
        {
            status = "配货中";
        }
        else if (statusCode == "4")
        {
            status = "已收货";
        }
        else if (statusCode == "5")
        {
            status = "已审核";
        }

        return status;
    }

}