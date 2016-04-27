using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.Linq;
using System.Web;
namespace EQWYB.Model{
	 	//employement
		public class Employement
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
		/// company
        /// </summary>		
		private string _company;
        public string company
        {
            get{ return _company; }
            set{ _company = value; }
        }        
		/// <summary>
		/// staff
        /// </summary>		
		private string _staff;
        public string staff
        {
            get{ return _staff; }
            set{ _staff = value; }
        }        
		/// <summary>
		/// title
        /// </summary>		
		private string _title;
        public string title
        {
            get{ return _title; }
            set{ _title = value; }
        }        
		/// <summary>
		/// endDate
        /// </summary>		
		private DateTime _enddate;
        public DateTime endDate
        {
            get{ return _enddate; }
            set{ _enddate = value; }
        }        
		/// <summary>
		/// startDate
        /// </summary>		
		private DateTime _startdate;
        public DateTime startDate
        {
            get{ return _startdate; }
            set{ _startdate = value; }
        }        
		/// <summary>
		/// detail
        /// </summary>		
		private string _detail;
        public string detail
        {
            get{ return _detail; }
            set{ _detail = value; }
        }        
		/// <summary>
		/// number
        /// </summary>		
		private int _number;
        public int number
        {
            get{ return _number; }
            set{ _number = value; }
        }        
		   
	}
}

