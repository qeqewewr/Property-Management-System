using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.Linq;
using System.Web;
namespace EQWYB.Model{
	 	//Company
	public class Company
	{
   		     
      	/// <summary>
		/// id
        /// </summary>		
		private int _id;
        public int id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// orderList
        /// </summary>		
		private int _orderlist;
        public int orderList
        {
            get{ return _orderlist; }
            set{ _orderlist = value; }
        }        
		/// <summary>
		/// companyName
        /// </summary>		
		private string _companyname;
        public string companyName
        {
            get{ return _companyname; }
            set{ _companyname = value; }
        }        
		/// <summary>
		/// describe
        /// </summary>		
		private string _describe;
        public string describe
        {
            get{ return _describe; }
            set{ _describe = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _block;
        public string block
        {
            set { _block = value; }
            get { return _block; }
        }
		   
	}
}

