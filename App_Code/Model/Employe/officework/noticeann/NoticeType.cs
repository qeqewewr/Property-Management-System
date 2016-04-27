using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///NoticeType 的摘要说明
/// </summary>
public class NoticeType
{
    public NoticeType()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    private string _id;
    private string _name;

    public string ID
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
}