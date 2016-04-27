function gotoPage(pagenum){ 
		var el=document.createElement("input"); 
		el.type="hidden"; 
		el.name="pageno";
		el.value=pagenum;
		document.pageControlForm.appendChild(el);
		document.pageControlForm.submit();
} 

function testAndGotoPage(pagenum,pageno,pagecount){ 
		var p =/^\d+$/;   
		if(!p.test(pagenum)){
			alert(pagenum+" 不是数字，请输入正整数"); 
			return;
		}else if(pagenum==pageno){
			return;
		}else{
			if(pagenum>pagecount){
				pagenum=pagecount; 
			}else if(pagenum==0){
				pagenum=1;
			} 
			gotoPage(pagenum);
			return;
		}
		return;
	} 