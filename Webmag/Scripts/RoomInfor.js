/* 复选框全选代码 */
//form:表单名字，chkName:checkBox的name,sltAllName：全选按钮name
function selectAllRoomInfor(mform, chkName, sltAllName) {
    for (var i = 0; i < document.forms[mform].elements.length; i++) {
        if (document.forms[mform].elements[i].name == chkName) {
            document.forms[mform].elements[i].checked = document.getElementById(sltAllName).checked;
        }
    }
}
/**删除全选提示**/
function checkSubmitRoomInfor(mform) {
    var obj = document.forms[mform].elements;
    var selectCounter = 0;

    for (var i = 0; i < obj.length; i++) {
        if (obj[i].type == "checkbox") {
            if (obj[i].checked == true) {
                selectCounter = 1;
            }
        }
    }

    if (selectCounter == 0) {
        alert("请选择要删除的内容！");
        return false;
    }
    if (confirm("确定要删除房源信息吗？")) {

        return true;
    }
    else
        return false;
}
function isAllRoomInforSelected(e, sltAllName, mform) {
    var selectAllState = document.getElementById(sltAllName).checked;

    //选中 
    if (selectAllState == true) {
        if (e.checked == false) {
            document.getElementById(sltAllName).checked = false;
        }
    }

    //未选中 
    if (selectAllState == false) {
        var counter = 0;
        var checked = 0;
        for (var i = 0; i < document.forms[mform].elements.length; i++) {
            if (document.forms[mform].elements[i].name == e.name) {
                if (document.forms[mform].elements[i].checked == true) {
                    checked++;
                }
                counter++;
            }
        }

        if (counter == checked) {
            document.getElementById(sltAllName).checked = true;
        }
    }
}
/* end */


  
 