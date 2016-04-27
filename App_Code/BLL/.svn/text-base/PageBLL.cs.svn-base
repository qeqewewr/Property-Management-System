using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Util.Page;
using CEMIS.Model.Employe;
  /// <summary>
    ///PageBLL 的摘要说明
    /// </summary>
    public class PageBLL
    {
        //每页显示的行数，可在此手动改变
        public readonly static int pageSize = 10;
        //当前页号
        private int pageNo;
        //跳转信息的标志 0:删除1:修改2:插入
        private List<string> redirectList = new List<string>();
        private int redirectPage = 0;
        private string shortInfo = "点击查看详情";
        public PageBLL()
        {
            redirectList.Add("删除");
            redirectList.Add("修改");
            redirectList.Add("插入");
        }

        public string GetShrotInfo()
        {
            return shortInfo;
        }
        /// <summary>
        /// 由页号和记录数获得pageForm
        /// </summary>
        /// <param name="pageno">页号</param>
        /// <param name="recordNum">表记录数</param>
        /// <returns></returns>
        public pageForm GetPageByPagenoAndRecordNum(int pageno, int recordNum)
        {
            pageForm page = new pageForm();
            //总行数
            page.RowCount = recordNum;
            //每页显示的行数
            page.PageSize = pageSize;
            //当前页号
            page.PageNo = pageno;
            //可分成的页数
            int pageNum = page.RowCount % page.PageSize;
            if (pageNum == 0)
            {
                if (page.RowCount == 0)
                    page.PageCount = 1;//总页数
                else
                    page.PageCount = page.RowCount / page.PageSize;
            }
            else
                page.PageCount = page.RowCount / page.PageSize + 1;
            return page;
        }



        /// <summary>
        /// 将一个Boolean转换成中文的"是"与"否"
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public string TransformBooleanToChinese(Boolean b)
        {
            return (b == true) ? "是" : "否";

        }

        /// <summary>
        /// 组合框删除一条记录
        /// </summary>
        /// <param name="pageSize">每页显示的行数</param>
        /// <param name="pageNo">当前页号</param>
        /// /// <param name="recordNum">表的记录数量</param>
        /// <returns>当前页号</returns>
        public int CheckBoxDeleteOneRecord(int pageSize, int pageNo, int recordNum)
        {
            //页数
            int a = recordNum % pageSize;
            int pageNum;
            if (a == 0)
            {
                if (recordNum == 0)
                    pageNum = 1;
                else
                    pageNum = recordNum / pageSize;
            }
            else
                pageNum = recordNum / pageSize + 1;
            //当删除的是最后一页，且最后一页只有一个数据
            if (pageNum == pageNo && pageNum == 1)
            {
                if (pageNo != 1)
                    pageNo--;
            }

            return pageNo;
        }

        /// <summary>
        ///  组合框删除多条记录
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <param name="ids">多选框</param>
        /// <param name="recordNum">表的记录数</param>
        /// <param name="idArray">多选框选中的个数</param>
        /// <returns>当前页号</returns>
        public int CheckBoxDeleteRecord(int pageSize, int pageNo, int recordNum, int idArrayLen)
        {
            int a = recordNum % pageSize;
            int pageNum;
            if (a == 0)
            {
                if (recordNum == 0)
                    pageNum = 1;
                else
                    pageNum = recordNum / pageSize;
            }
            else
                pageNum = recordNum / pageSize + 1;
            //当删除的是最后一页，且最后一页只有一个数据
            if (pageNum == pageNo && (idArrayLen == a || idArrayLen == pageSize))
            {
                if (pageNo != 1)
                    pageNo--;
            }
            return pageNo;
        }

        /// <summary>
        /// 跳转页面
        /// </summary>
        /// <param name="page">Page对象</param>
        /// <param name="flag">跳转标志</param>
        /// <param name="pageUrl"></param>
        /// <param name="pageNo"></param>
        /// <param name="rflag">跳转信息的标志 0:删除1:修改2:插入</param>
        /// <returns></returns>
        public void RedirectPage(Page page, string pageUrl, int flag, int pageNo, int rflag)
        {
            if (pageNo > 0)
            {
                if (flag > 0)
                    page.ClientScript.RegisterClientScriptBlock(page.GetType(), "", "<script>alert('" + redirectList[rflag] + "成功!');location.href='" + pageUrl + "?pageno=" + pageNo + "';</script>");
                else
                    page.ClientScript.RegisterClientScriptBlock(page.GetType(), "", "<script>alert('" + redirectList[rflag] + "失败!');history.go(-1);</script>");
            }
            else
            {
                if (flag > 0)
                    page.ClientScript.RegisterClientScriptBlock(page.GetType(), "", "<script>alert('" + redirectList[rflag] + "成功!');location.href='" + pageUrl + "';</script>");
                else
                    page.ClientScript.RegisterClientScriptBlock(page.GetType(), "", "<script>alert('" + redirectList[rflag] + "失败!');history.go(-1);</script>");
            }

        }

        public string GetFileName(string attachUrl)
        {
            return System.IO.Path.GetFileName(attachUrl);
        }
    }
