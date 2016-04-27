using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using CEMIS.Model.Image;
using CEMIS.Util;
using System.Data.Sql;
using System.Data.SqlClient;




/// <summary>
///ImgAttachmentDAO 的摘要说明
/// </summary>
/// 

namespace CEMIS.Model.Image
{
    public class ImgAttachmentDAO
    {
        public ImgAttachmentDAO()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 图片信息添加
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public int AddImgAttachment(ImgAttachment image)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@AttachType", SqlDbType.Int),
                    new SqlParameter("@AttachUrl", SqlDbType.NVarChar),
                    new SqlParameter("@AttachName", SqlDbType.NVarChar),
                    new SqlParameter("@ModuleID", SqlDbType.NVarChar),
                    new SqlParameter("@AddDate", SqlDbType.DateTime)};
            if (image.AttachType == 0)
                parameters[0].Value = DBNull.Value;
            else
                parameters[0].Value = image.AttachType;

            parameters[1].Value = image.AttachUrl;
            parameters[2].Value = image.AttachName;
            parameters[3].Value = image.ModuleID;

            if (image.AddDate == null)
                parameters[4].Value = DBNull.Value;


            string sql = "insert into ImgAttachment(AttachType,AttachUrl,AttachName,ModuleID,AddDate) values(@AttachType,@AttachUrl,@AttachName,@ModuleID,@AddDate)";
            object obj = DBHelperSQL.GetSingle(sql, parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }

        }

        /// <summary>
        /// 图片信息编辑更新
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public int UpdateImgAttachment(ImgAttachment image)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int),
                    new SqlParameter("@AttachType", SqlDbType.Int),
                    new SqlParameter("@AttachUrl", SqlDbType.NVarChar),
                    new SqlParameter("@AttachName", SqlDbType.NVarChar),
                    new SqlParameter("@ModuleID", SqlDbType.NVarChar),
                    new SqlParameter("@AddDate", SqlDbType.DateTime)};
            parameters[0].Value = image.ID;
            if (image.AttachType == 0)
                parameters[1].Value = DBNull.Value;
            else
                parameters[1].Value = image.AttachType;

            parameters[2].Value = image.AttachUrl;
            parameters[3].Value = image.AttachName;
            parameters[4].Value = image.ModuleID;

            if (image.AddDate == null)
                parameters[4].Value = DBNull.Value;

            string sql = "update ImgAttachment set AttachType=@AttachType,AttachUrl=@AttachUrl,AttachName=@AttachName,ModuleID=@ModuleID,AddDate=@AddDate where ID=@ID ";

            return DBHelperSQL.ExecuteSql(sql, parameters);

        }



        /// <summary>
        ///获得当前页面的图片信息列表
        /// </summary>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<ImgAttachment> ListPageImgAttachment(int pageno, int pagesize, int type)
        {
            int rowcount = this.GetTotalRecordNum(type);

            string sql;

            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID) as rownum ,* from ImgAttachment where AttachType=" + type + " ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID) as rownum, * from ImgAttachment where AttachType=" + type + " )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            DataSet ds = DBHelperSQL.Query(sql);

            return DataTableToList(ds.Tables[0]);
        }



        /// <summary>
        ///获得所有的图片信息列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<ImgAttachment> ListImgAttachment(int type)
        {
            string sql = "select * from ImgAttachment where AttachType=" + type;

            DataSet ds = DBHelperSQL.Query(sql);

            return DataTableToList(ds.Tables[0]);
        }


        /// <summary>
        /// 通过ID删除图片信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int deleteImgAttachmentByID(int id)
        {
            string sql = "delete from ImgAttachment where ID=@ID";

            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int)};
            parameters[0].Value = id;

            return DBHelperSQL.ExecuteSql(sql, parameters);
        }

        /// <summary>
        /// 通过图片类型获得图片列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<ImgAttachment> GetImgAttachmentByType(int type)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@attachType", SqlDbType.Int)
                    };
            parameters[0].Value = type;
            string sql = "select * from ImgAttachment where AttachType=@attachType";

            DataSet ds = DBHelperSQL.Query(sql, parameters);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 通过图片类型和模块ID获得图片列表url
        /// </summary>
        /// <param name="attachType"></param>
        /// <param name="moduleID"></param>
        /// <returns></returns>
        public string GetAttachUrlByByAttachTypeAndModuleID(int attachType, string moduleID)
        {
            string path = "";
            SqlParameter[] parameters = {
                    new SqlParameter("@attachType", SqlDbType.Int),
                    new SqlParameter("@moduleID", SqlDbType.NVarChar)
                    };
            parameters[0].Value = attachType;
            parameters[1].Value = moduleID;
            string sql = "select attachUrl from ImgAttachment where attachType=@attachType And moduleID=@moduleID";
            DataSet ds = DBHelperSQL.Query(sql, parameters);
            DataTable dt = ds.Tables[0];
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
                path = dt.Rows[0]["attachUrl"].ToString();
            return path;
        }

        /// <summary>
        /// 通过图片所属的模块以及在模块中的ID删除图片记录
        /// </summary>
        /// <param name="attachType">图片类型 1：房型图，2：大楼图，3：装修监督 4：维修单 5：反馈单 6：企业宣传</param>
        /// <param name="moduleID"></param>
        /// <returns></returns>
        public int DeleteImgAttachmentByAttachTypeAndModuleID(int attachType, string moduleID)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@attachType", SqlDbType.Int),
                    new SqlParameter("@moduleID", SqlDbType.NVarChar)};
            parameters[0].Value = attachType;
            parameters[1].Value = moduleID;
            string sql = "delete from ImgAttachment where attachType=@attachType And moduleID=@moduleID";
            return DBHelperSQL.ExecuteSql(sql, parameters);
        }

        /// <summary>
        /// 通过图片类型和模块id获得图片列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public List<ImgAttachment> GetImgAttachmentByTypeAndID(int type, string typeid)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@attachType", SqlDbType.Int),
                    new SqlParameter("@moduleID", SqlDbType.NVarChar)};
            parameters[0].Value = type;
            parameters[1].Value = typeid;
            string sql = "select * from ImgAttachment where AttachType=@AttachType and ModuleID=@ModuleID ";

            DataSet ds = DBHelperSQL.Query(sql, parameters);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 通过图片类型、模块id获取图片数量
        /// </summary>
        /// <param name="type"></param>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public int HasImgAttachmentByTypeAndID(int type, string typeid)
        {

            SqlParameter[] parameters = {
                    new SqlParameter("@attachType", SqlDbType.Int),
                    new SqlParameter("@moduleID", SqlDbType.NVarChar)};
            parameters[0].Value = type;
            parameters[1].Value = typeid;
            string sql = "select * from ImgAttachment where AttachType=@AttachType and ModuleID=@ModuleID ";

            DataSet ds = DBHelperSQL.Query(sql, parameters);
            return ds.Tables[0].Rows.Count;
        }



        /// <summary>
        /// 通过ID获得图片信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ImgAttachment GetImgAttachmentByID(int id)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int)};
            parameters[0].Value = id;

            string sql = "select * from ImgAttachment where ID=@ID ";

            DataSet ds = DBHelperSQL.Query(sql, parameters);
            List<ImgAttachment> image = DataTableToList(ds.Tables[0]);
            if (image.Count == 0)
                return null;
            else
                return image[0];
        }

        /// <summary>
        /// 获得某一类型总的图片信息数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetTotalRecordNum(int type)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@attachType", SqlDbType.Int)
                    };
            parameters[0].Value = type;
            string sql = "select count(*) as a from ImgAttachment where AttachType=@AttachType";

            DataSet ds = DBHelperSQL.Query(sql, parameters);
            DataTable dt = ds.Tables[0];
            int count = 0;
            if (dt.Rows.Count > 0)
                count = int.Parse(dt.Rows[0]["a"].ToString());

            return count;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<ImgAttachment> DataTableToList(DataTable dt)
        {
            List<ImgAttachment> modelList = new List<ImgAttachment>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ImgAttachment model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ImgAttachment();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    if (dt.Rows[n]["AttachType"] != null && dt.Rows[n]["AttachType"].ToString() != "")
                        model.AttachType = int.Parse(dt.Rows[n]["AttachType"].ToString());
                    if (dt.Rows[n]["AttachUrl"] != null && dt.Rows[n]["AttachUrl"].ToString() != "")
                        model.AttachUrl = dt.Rows[n]["AttachUrl"].ToString();
                    if (dt.Rows[n]["AttachName"] != null && dt.Rows[n]["AttachName"].ToString() != "")
                        model.AttachName = dt.Rows[n]["AttachName"].ToString();
                    if (dt.Rows[n]["ModuleID"] != null && dt.Rows[n]["ModuleID"].ToString() != "")
                        model.ModuleID = dt.Rows[n]["ModuleID"].ToString();
                    if (dt.Rows[n]["AddDate"] != null && dt.Rows[n]["AddDate"].ToString() != "")
                        model.AddDate = DateTime.Parse(dt.Rows[n]["AddDate"].ToString());
                    else
                        model.AddDate = null;

                    modelList.Add(model);
                }
            }
            return modelList;
        }

    }
}
