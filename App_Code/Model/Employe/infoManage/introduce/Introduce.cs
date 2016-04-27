using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Introduce 的摘要说明
/// </summary>
/// 

namespace CEMIS.Model.Employe
{
    public class Introduce
    {
        public Introduce()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
			p2Url = "";
			p1Url = "";
        }
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        //物业介绍
        private string introduction;
        public string Introduction
        {
            get { return introduction; }
            set { introduction = value; }
        }

        //联系电话
        private string telephone;
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        //联系地址
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private int sum;
        public int Sum
        {
            get { return sum; }
            set { sum = value; }
        }

        //电子邮箱
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string rentProcedure;
        public string RentProcedure
        {
            get { return rentProcedure; }
            set { rentProcedure = value; }
        }

        private string feeAddress;
        public string FeeAddress
        {
            get { return feeAddress; }
            set { feeAddress = value; }
        }

        private string feeCompany;
        public string FeeCompany
        {
            get { return feeCompany; }
            set { feeCompany = value; }
        }

        private string feeAccount;
        public string FeeAccount
        {
            get { return feeAccount; }
            set { feeAccount = value; }
        }

		private string p1Url;
		private string p2Url;
		public string P1Url
		{
			get { return p1Url; }
			set { p1Url = value; }
		}

		public string P2Url
		{
			get { return p2Url; }
			set { p2Url = value; }
		}
    }
}

