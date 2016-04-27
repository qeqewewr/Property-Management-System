<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLeft.aspx.cs" Inherits="AdminLeft" %> 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
   
   
<script language="javascript" src="Scripts/jquery-1.4.min.js"></script>
<script type="text/javascript">
    var LastLeftID = "";
    function menuFix() {

        var obj1 = document.getElementById("nav");
        
        var obj = obj1.getElementsByTagName("li");

        for (var i = 0; i < obj.length; i++) {
            obj[i].onmouseover = function () {
                this.className += (this.className.length > 0 ? " " : "") + "sfhover";
            }
            obj[i].onMouseDown = function () {
                this.className += (this.className.length > 0 ? " " : "") + "sfhover";
            }
            obj[i].onMouseUp = function () {
                this.className += (this.className.length > 0 ? " " : "") + "sfhover";
            }
            obj[i].onmouseout = function () {
                this.className = this.className.replace(new RegExp("( ?|^)sfhover\\b"), "");
            }
        }
    }
    function DoMenu(emid) {
        var obj = document.getElementById(emid);
        obj.className = (obj.className.toLowerCase() == "expanded" ? "collapsed" : "expanded");
        if ((LastLeftID != "") && (emid != LastLeftID)) //关闭上一个Menu
        {
            document.getElementById(LastLeftID).className = "collapsed";
        }
        LastLeftID = emid;
    }
    function GetMenuID() {
        var MenuID = "";
        var _paramStr = new String(window.location.href);
        var _sharpPos = _paramStr.indexOf("#");

        if (_sharpPos >= 0 && _sharpPos < _paramStr.length - 1) {
            _paramStr = _paramStr.substring(_sharpPos + 1, _paramStr.length);
        }
        else {
            _paramStr = "";
        }

        if (_paramStr.length > 0) {
            var _paramArr = _paramStr.split("&");
            if (_paramArr.length > 0) {
                var _paramKeyVal = _paramArr[0].split("=");
                if (_paramKeyVal.length > 0) {
                    MenuID = _paramKeyVal[1];
                }
            }
        }

        if (MenuID != "") {
            DoMenu(MenuID)
        }
    }
    $(function () {
        GetMenuID(); //*function顺序要注意，否则在Firefox里GetMenuID()不起效果。
        menuFix();
        $("#nav li a").click(function () {
           // alert(this);
            $("#nav li a").removeClass('hover');
            $(this).addClass('hover');
        });
    });
</script>
       

<style type="text/css">

*{margin:0;padding:0;border:0;}
body {
 font-size:12px;
}
#nav {
 width:166px;
 line-height: 20px;
 list-style-type: none;
 text-align:left;
}
#nav a {
 width: 121px;
 display: block;
 padding-left:45px;
 /*Width(一定要)，否则下面的Li会变形*/
}
#nav li {

 background-image:url(images/out.gif);
 float:left;
 BORDER-RIGHT: #8c8c8c 1px solid;
 BORDER-TOP: #dbfe99 1px solid;
 FONT-WEIGHT: bold;
 FONT-SIZE: 12px;
 PADDING-BOTTOM: 2px;
 BORDER-LEFT: #dbfe99 1px solid;
 CURSOR: hand;
 COLOR: black;
 PADDING-TOP: 4px;
 BORDER-BOTTOM: #8c8c8c 1px solid;
 
 /*float：left,本不应该设置，但由于在Firefox不能正常显示
 继承Nav的width,限制宽度，li自动向下延伸*/
}
#nav li a:hover{
 background-image:url(images/hover.gif); /*一级目录onMouseOver显示的背景色*/
}
#nav li a.hover{
 background-image:url(images/hover.gif); /*一级目录onMouseOver显示的背景色*/
}
#nav a:link  {
 color:#fff; text-decoration:none;
}
#nav a:visited  {
 color:#fff;text-decoration:none;
}
#nav a:hover  {
 background-image:url(images/hover.gif) no-repeat; /*一级目录onMouseOver显示的背景色*/
}
/*=========二级目录=========*/
#nav li ul {
 list-style:none;
 text-align:left;
 
}
#nav li ul li{ 
 BORDER-RIGHT: #cccccc 1px solid;
 BORDER-TOP: white 1px solid;
 FONT-SIZE: 12px;
 PADDING-BOTTOM: 2px;
 BORDER-LEFT: white 1px solid;
 CURSOR: hand;
 PADDING-TOP: 2px;
 BORDER-BOTTOM: #cccccc 1px solid;
 BACKGROUND-COLOR: #eeeeee; /*二级目录的背景色*/
 background-image:url();
}
#nav li ul a{
         padding-left:45px;
         width:119px;
		 background-image:url(images/submenu.gif);
 /* padding-left二级目录中文字向右移动，但Width必须重新设置=(总宽度-padding-left)*/
}
/*下面是二级目录的链接样式*/
#nav li ul a:link  {
 color:#666; text-decoration:none;
}
#nav li ul a:visited  {
color:#666;text-decoration:none;
}
#nav li ul li a:hover {
 
 text-decoration:none;
 font-weight:normal;
}
/* www.codefans.net */
#nav li:hover ul {
 left: auto;
}
#nav li.sfhover ul {
 left: auto;
}
#content {
 clear: left;
}
#nav ul.collapsed {
 display: none;
}
-->
#PARENT{
 width:165px; 
}
 

</style>



  </head>
  
  <body style="background-image:url(images/bg.gif);background-repeat:repeat-x;background-color: #BFE8EE; width:165px;">
   <div id="PARENT">
<ul id="nav">







<%if (show)
  {	  int j = 0;
      for (int i = 0; i < bigFunctionList.Count; i++)
      {%>
    <li>
        <a href="#Menu=<%=bigFunctionList[i].Code%>"  onclick="DoMenu('<%=bigFunctionList[i].Code%>')"><%=bigFunctionList[i].FullName%></a>
        <ul id="<%=bigFunctionList[i].Code%>" class="collapsed">
        <%for (; j < functionList.Count; j++)
          {
              if (functionList[j].ParentID == bigFunctionList[i].ID)
              {%>
                  <li><a href="<%=functionList[j].NavigateUrl%>" target="mainFrame"><%=functionList[j].FullName%></a></li>
             <% }
			  else
				break;
          }%>
        </ul> 
     </li>
   <% }
       if (adminDAO.GetAdmin(Session["PropertyID"].ToString()))
       { %>
       <li><a href="#Menu=changePSW"  onclick="DoMenu('changePSW')">密码修改</a>
        <ul id="Ul1" class="collapsed"> 
        <li><a href="Employe/changePSW/ChangePassword.aspx" target="mainFrame">密码修改</a></li>
        </ul>
       </li>
      
 <%
       }
  }
  else
  {%>
 <li><a href="#Menu=earlypre"  onclick="DoMenu('earlypre')">入驻前期</a>
<ul id="earlypre" class="collapsed"> 
 <li><a href="Employe/earlypre/fitmonitor/ViewFitMonitor.aspx?pageno=1" target="mainFrame">装修申请</a></li>
 <li><a href="Employe/earlypre/orderremove/ViewOrderRemove.aspx?pageno=1" target="mainFrame">搬入预约</a></li>
</ul>
</li>

<li><a href="#Menu=offwork"  onclick="DoMenu('offwork')">正式办公</a>
<ul id="offwork" class="collapsed"> 
 <li><a href="Employe/officework/repairtable/ViewRepairTable.aspx?pageno=1" target="mainFrame">报修申请</a></li>
 <li><a href="Employe/officework/tenementcost/ViewTenementCost.aspx?pageno=1" target="mainFrame">费用</a></li>
 <li><a href="Employe/officework/noticeann/ViewNotice.aspx?pageno=1" target="mainFrame">通知</a></li>
 <li><a href="Employe/officework/answercomplain/ViewComplainFeedback.aspx?pageno=1" target="mainFrame">投诉管理</a></li> 
 <li><a href="Employe/officework/orderwork/ViewOrderWork.aspx?pageno=1" target="mainFrame">加班预约</a></li>  
 <!--<li><a href="" target="mainFrame">问询调查</a></li>--> 
</ul>
</li>

<li><a href="#Menu=quitorder"  onclick="DoMenu('quitorder')">退租预约</a>
<ul id="quitorder" class="collapsed"> 
 <li><a href="Employe/quitorder/ViewQuitOrder.aspx?pageno=1" target="mainFrame">退租预约</a></li>
</ul>
</li>

<li><a href="#Menu=businadver"  onclick="DoMenu('businadver')">企业展示</a>
<ul id="businadver" class="collapsed"> 
<li><a href="Employe/businadver/ViewFirmAdvertise.aspx?pageno=1" target="mainFrame">企业展示</a></li>
</ul>
</li>



<li><a href="#Menu=tabledoc"  onclick="DoMenu('tabledoc')">表单文档</a>
<ul id="tabledoc" class="collapsed"> 
  <li><a href="Employe/tabledoc/docmang/documentView.aspx" target="mainFrame">文档下载</a></li>
</ul>
</li>

<li><a href="#Menu=changePSW"  onclick="DoMenu('changePSW')">密码修改</a>
<ul id="Ul2" class="collapsed"> 
  <li><a href="Employe/changePSW/ChangePassword.aspx" target="mainFrame">密码修改</a></li>
</ul>
</li>
<%} %>



</ul>
</div>
  </body>
</html>
