 /* 复选框全选代码 */
 //form:表单名字，chkName:checkBox的name,sltAllName：全选按钮name
function selectAll(mform,chkName,sltAllName){ 
	for(var i=0;i<document.forms[mform].elements.length;i++){ 
		if(document.forms[mform].elements[i].name == chkName){
			document.forms[mform].elements[i].checked = document.getElementById(sltAllName).checked; 
		}
	}  
}
/**删除全选提示**/
function checkDeleteSubmit(mform){  
	var obj = document.forms[mform].elements;
	var selectCounter = 0;
	
	for(var i=0;i <obj.length;i++){ 
		if(obj[i].type == "checkbox"){
			if(obj[i].checked == true){
				selectCounter = 1;
			}
		}
	}
	 
	if(selectCounter == 0){
		alert("请选择要删除的内容！");
		return false;
	}
	if (confirm("确定要删除的选中的内容吗？")) {
	    
	    return true;
	}
	else
	    return false;	
}	
function isAllSelected(e,sltAllName,mform){
	var selectAllState = document.getElementById(sltAllName).checked;
	
	//选中 
	if(selectAllState == true){
		if(e.checked == false){
			document.getElementById(sltAllName).checked = false;
		}
	} 
	
	//未选中 
	if(selectAllState == false){
		var counter = 0;
		var checked = 0;
		for(var i=0;i<document.forms[mform].elements.length;i++){
			if(document.forms[mform].elements[i].name == e.name){
				if(document.forms[mform].elements[i].checked == true){
					 checked++;
				}
				counter++;
			}
		}
		 
		if(counter == checked){
			document.getElementById(sltAllName).checked = true;			
		}
	}
}
/* end */


/*删除单条内容的代码*/
 function checkDeleteSingleItem(url){
 	
 	if(confirm("确定要删除本条记录吗？")){
 		window.location.href=url;
 		return true;
 	}else{
 		return false;
 	}
 	
 }
 
 /*确认提交代码*/
 function verifySubmit(form){  
	var obj = document.forms[form].elements;
	var selectCounter = 0;
	
	for(var i=0;i <obj.length;i++){ 
		if(obj[i].type == "checkbox"){
			if(obj[i].checked == true){
				selectCounter = 1;
			}
		}
	}
	 
	if(selectCounter == 0){
		alert("请选择要选择的内容！");
		return false;
	}
	if(confirm("确定要提交的选中的内容吗？"))
		return true; 
	else
		return false;	
}	
 
 
/*验证文本框输入数字*/ 
function isNumValue(obj){
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

/*发布留言内容--lyb*/
function isPublishMessage(url) {
    if (confirm("确定要发布本条留言内容吗？")) {
        window.location.href = url;
        return true;
    } else {
        return false;
    }

}
 
  
 