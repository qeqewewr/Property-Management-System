using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Notice 的摘要说明
/// </summary>
public class Notice
{
	public Notice()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    //标识符
    private string id;
    //发布通知日期
    private string publishDate;
    //发布者
    private string publisher;
    //发布内容
    private string noticeContent;
    //发布内容类型
    private string noticeType;

    private string noticeTypeID;
    //已通知房间号
    private string rooms;
    //未通知房间号
    private string uncheckedRooms;

    public string ID
    {
        get {return id;}
        set {id = value;}
    }

    public string PublishDate
    {
        get { return publishDate; }
        set { publishDate = value; }
    }

    public string Publisher
    {
        get { return publisher; }
        set { publisher = value; }
    }

    public string NoticeContent
    {
        get { return noticeContent; }
        set { noticeContent = value; }
    }

    public string NoticeType
    {
        get { return noticeType; }
        set { noticeType = value; }
    }
    public string NoticeTypeID
    {
        get { return noticeTypeID; }
        set { noticeTypeID = value; }
    }
    public string Rooms
    {
        get { return rooms; }
        set { rooms = value; }
    }

    public string UncheckedRooms
    {
        get { return uncheckedRooms; }
        set { uncheckedRooms = value; }
    }
}