using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///FirmAdvertise 的摘要说明
/// </summary>
public class FirmAdvertise
{
	public FirmAdvertise()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    private string id;
    //租户
    private string lessee;
    //企业宣传的图片路径
    private string picturePath;
    //企业描述
    private string describe;
    //是否确认
    private Boolean isSure;
    //建议
    private string remarks;

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

    public string PicturePath
    {
        get { return picturePath; }
        set { picturePath = value; }
    }

    public string Describe
    {
        get { return describe; }
        set { describe = value; }
    }

    public Boolean IsSure
    {
        get { return isSure; }
        set { isSure = value; }
    }

    public string Remarks
    {
        get { return remarks; }
        set { remarks = value; }
    }
}