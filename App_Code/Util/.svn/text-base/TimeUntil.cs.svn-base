using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///DateUntil 的摘要说明
/// </summary>
public class TimeUntil
{
    private string[] month = new string[13];
    private int []year = new int[200];
    private char[] separtor = { '-' };

	public TimeUntil()
	{
        month[0] = "一月";
        month[1] = "一月";
        month[2] = "二月";    
        month[3] = "三月";
        month[4] = "四月";
        month[5] = "五月";
        month[6] = "六月";
        month[7] = "七月";
        month[8] = "八月";
        month[9] = "九月";
        month[10] = "十月";
        month[11] = "十一月";
        month[12] = "十二月";

        year[0] = 2010;
        for (int i = 1; i < 200; i++)
        {
            year[i] = year[0] + i;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int[] GetYearArray()
    {
        return year;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public int GetYearNumber(int i)
    {
        return year[i];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string[] GetMonthArray()
    {
        return month;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="m"></param>
    /// <returns></returns>
    public int GetMonthNumber(string m)
    {
        switch (m)
        {
            case "一月": return 1;
            case "二月": return 2;
            case "三月": return 3;
            case "四月": return 4;
            case "五月": return 5;
            case "六月": return 6;
            case "七月": return 7;
            case "八月": return 8;
            case "九月": return 9;
            case "十月": return 10;
            case "十一月": return 11;
            case "十二月": return 12;
        }
        return 0;
    }

    /// <summary>
    /// 对费用月份(如2011-11-12)进行分割获得年份
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string GetYearByDividFeeMonth(string str)
    {
        string[] arr = str.Split(separtor);
        string y = arr[0];
        return y;
    }

    /// <summary>
    /// 对费用月份(如2011-11-12)进行分割获得月份
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string GetMonthByDividFeeMonth(string str)
    {
        string[] arr = str.Split(separtor);
        string m = arr[1];
        return m;
    }
}