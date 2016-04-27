using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///RoomRent 的摘要说明
/// </summary>
/// 

namespace CEMIS.Model.Employe
{
    public class RoomRent
    {
        public RoomRent()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }


        private int roomID;
        public int RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }

        //租住公司
        private string lessee;
        public string Lessee
        {
            get { return lessee; }
            set { lessee = value; }
        }

        //入住时间
        private DateTime? rentStart;
        public DateTime? RentStart
        {
            get { return rentStart; }
            set { rentStart = value; }
        }

        //截止时间
        private DateTime? rentEnd;
        public DateTime? RentEnd
        {
            get { return rentEnd; }
            set { rentEnd = value; }
        }

    }
}