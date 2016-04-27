// JScript 文件
//验证email
function isEmail(mail,obj){
    var pattern = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
    if(pattern.test(mail)){
        return true;
    }else{
       //alert("对不起，请输入正确格式的E-mail！");
       $(obj).val("");   
       return false;
    }
 

}

//验证电话号码
function isTelephone(phone,obj){
    //var pattern = /^([0-9]{3,4}\-[1-9]{1}[0-9]{6,7})+(\-[0-9]{1,4})?$/;
    var pattern = /^([1-9]{1}[0-9]{6,7})+(\-[0-9]{1,4})?$/;
    if(pattern.test(phone)){
        return true;
    }else{
       //alert("对不起，请输入正确格式的电话号码！");
       //$(obj).val("");  
        
       return false;
    }
}

//验证手机号码
function isMobilePhone(phone,obj){
    var pattern = /^(1[3,5,8]{1}[0-9]{9})|([0-9]{3,4}\-[2-9]{1}[0-9]{6,7})$/;
     
    if(pattern.test(phone)){
        return true;
    }else{
       // alert("对不起，请输入正确格式的手机号码！");
        //$(obj).val("");  
        return false;
    }
}

//数字验证
function isNum(param){
    var pattern = /^[0-9]*$/;
    if(pattern.test(param)){
        return true;
    }else{
        return false;
    }
}

//浮点数字验证
function isFloatNum(param){
    var pattern = /^(-?\d+)(\.\d+)?/;
    if(pattern.test(param)){
        return true;
    }else{
        return false;
    }
}

//身份证号验证
function isIDNum(param){
    var pattern = /^(\d{15}|\d{18}|\d{17}[xX])$/;
    if(pattern.test(param)){
        return true;
    }else{
        return false;
    }
}

//数字或者字母一起验证
function isNumOrLetter(param){
    var pattern = /(^[A-Za-z0-9]{3,20}$)/;
    if(pattern.test(param)){
        return true;
    }else{
        return false;
    }
}

//打开新窗口
function OW(URL,TYPE,SC,iW,iH,TOP,LEFT,R,S,T,TB)
{
	var sF="dependent=yes,resizable=no,toolbar=no,status=no,directories=no,menubar=no,";
	

	sF+="scrollbars="+(SC?SC:"NO")+",";
	
	if (TYPE=="full"){
		sF+=" Width=1010,";
		sF+=" Height=750,";
		sF+=" Top=0,";
		sF+=" Left=0,";
		window.open(URL, "_blank", sF, false);
		return;
	}
	
	
	if (TYPE=="modal"){
		sF ="resizable:no; status:no; scroll:yes;";
		if(iW!=undefined && iH!=undefined){
			sF+=" dialogWidth="+iW+"px;";
			sF+=" dialogHeight="+iH+"px;";
		}
		else{
			sF+=" dialogWidth=800px;";
			sF+=" dialogHeight=570px;";
		}
	
			if(parent.length<2){
				sF+="dialogTop:"+(parseInt(parent.dialogTop)+25)+"px;";					
				sF+="dialogLeft:"+(parseInt(parent.dialogLeft)+25)+"px;";
				}
		
		var alpha = '?';
		var _URL = URL;
		var unique = (new Date()).getTime();
		//如果没有参数		
		if (_URL.indexOf(alpha) == -1){
			_URL+= "?time="+unique;
		}
		else
		{
		//如果带有参数，含有‘?’
			_URL+= "&time="+unique;
		}
		//alert(_URL.indexOf(alpha));alert(_URL);
		return window.showModalDialog(_URL,window,sF);
	}
	else if (TYPE=="modeless"){
		
		sF ="resizable:no; status:no; scroll:yes;";
		sF+=" dialogWidth:800px;";
		sF+=" dialogHeight:570px;";
			if(parent.length<2){
				sF+="dialogTop:"+(parseInt(parent.dialogTop)+25)+"px;";					
				sF+="dialogLeft:"+(parseInt(parent.dialogLeft)+25)+"px;";
				}
		
		var alpha = '?';
		var _URL = URL;
		var unique = (new Date()).getTime();
		//如果没有参数		
		if (_URL.indexOf(alpha) == -1){
			_URL+= "?time="+unique;
		}
		else
		{
		//如果带有参数，含有??
			_URL+= "&time="+unique;
		}
		//alert(_URL.indexOf(alpha));alert(_URL);
		return window.showModelessDialog(_URL,window,sF);
	}	
	else
	{
		if(iW!=undefined && iH!=undefined){
			sF+=" Width="+iW+",";
			sF+=" Height="+iH+",";
		}
		else{
			sF+=" Width=800,";
			sF+=" Height=570,";
		}
		if(window.opener==null || window.opener==undefined){
		    if(TOP==undefined){
		     sF+=" Top=0px,";
		    }else{
		     sF+=" Top=50px,";
		    }
			
			sF+=" Left=50px,";
		}else{
			sF+="Top="+(parseInt(window.screenTop)+20)+"px,";					
			sF+="Left="+(parseInt(window.screenLeft)+30)+"px,";
		}		
		sF+=" scrollbars=yes,"
		window.open(URL, "_blank", sF, false);
	
	}
}

//控制文本狂只能输入数字
function numEnter(obj){
    var pattern = /^\d+(\.?\d*)?$/;
    var org = $(obj).val();
    
    if(!pattern.test($(obj).val())){
        alert('输入框中含有非法字符');
        $(obj).val("");
        return false;
    }else{
       if(org.substring(0,1)=="0" && org.substring(1,2) != "."){
             $(obj).val(org.substring(1));
       }
    }
 }

 //检查时间格式是否为yyyy/mm/dd
 function isdateOne(strDate) {
     var strSeparator = "-"; //日期分隔符
     var strDateArray;
     var intYear;
     var intMonth;
     var intDay;
     var time;
     var boolLeapYear;
     //firefox, firebug
     strDateArray = strDate.split(strSeparator);
     if (strDateArray.length != 3) return false;

     intYear = parseInt(strDateArray[0], 10);
     intMonth = parseInt(strDateArray[1], 10);
     intDay = parseInt(strDateArray[2], 10);

     if (isNaN(intYear) || isNaN(intMonth) || isNaN(intDay)) return false;
     if (intMonth > 12 || intMonth < 1) return false;
     if ((intMonth == 1 || intMonth == 3 || intMonth == 5 || intMonth == 7 || intMonth == 8 || intMonth == 10 || intMonth == 12) && (intDay > 31 || intDay < 1)) return false;
     if ((intMonth == 4 || intMonth == 6 || intMonth == 9 || intMonth == 11) && (intDay > 30 || intDay < 1)) return false;

     if (intMonth == 2) {
         if (intDay < 1) return false;
         boolLeapYear = false;
         if ((intYear % 100) == 0) {
             if ((intYear % 400) == 0) boolLeapYear = true;
         }
         else {
             if ((intYear % 4) == 0) boolLeapYear = true;
         }

         if (boolLeapYear) {
             if (intDay > 29) return false;
         }
         else {
             if (intDay > 28) return false;
         }
     }

     strSeparator = " ";
     strDateArray = strDate.split(strSeparator);
     if (strDateArray.length >= 3 || strDateArray.length <= 0) return false;
     if (strDateArray.length == 2) {
         time = strDateArray[1];
         // alert(time);
         if (!isTime(time))
             return false;
     }
     return true;
 }

//检测时间格式 ----LYB
function isdate(strDate) {
    var strSeparator = "/"; //日期分隔符
    var strDateArray;
    var intYear;
    var intMonth;
    var intDay;
    var time;
    var boolLeapYear;
    //firefox, firebug
    strDateArray = strDate.split(strSeparator);
    if (strDateArray.length != 3) return false;

    intYear = parseInt(strDateArray[0], 10);
    intMonth = parseInt(strDateArray[1], 10);
    intDay = parseInt(strDateArray[2], 10);
  
    if (isNaN(intYear) || isNaN(intMonth) || isNaN(intDay)) return false;
    if (intMonth > 12 || intMonth < 1) return false;
    if ((intMonth == 1 || intMonth == 3 || intMonth == 5 || intMonth == 7 || intMonth == 8 || intMonth == 10 || intMonth == 12) && (intDay > 31 || intDay < 1)) return false;
    if ((intMonth == 4 || intMonth == 6 || intMonth == 9 || intMonth == 11) && (intDay > 30 || intDay < 1)) return false;

    if (intMonth == 2) {
        if (intDay < 1) return false;
        boolLeapYear = false;
        if ((intYear % 100) == 0) {
            if ((intYear % 400) == 0) boolLeapYear = true;
        }
        else {
            if ((intYear % 4) == 0) boolLeapYear = true;
        }

        if (boolLeapYear) {
            if (intDay > 29) return false;
        }
        else {
            if (intDay > 28) return false;
        }
    }

    strSeparator = " ";
    strDateArray = strDate.split(strSeparator);
    if (strDateArray.length >= 3 || strDateArray.length <= 0) return false;
    if (strDateArray.length == 2) {
        time = strDateArray[1];
       // alert(time);
        if (!isTime(time))
            return false;
    }
    return true;
}

//验证时间格式 如 13:04:06----LYB
function isTime(str)
{
    var a =str.match(/^(\d{1,2})(:)?(\d{1,2})\2(\d{1,2})$/);
    if (a == null) {
        return false;
    }
    if (a[1] > 24 || a[3] > 60 || a[4] > 60) {
        return false
    }
    return true;
}
