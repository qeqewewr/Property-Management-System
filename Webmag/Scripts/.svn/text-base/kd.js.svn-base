KE.show({
		id : 'kdContent',
		imageUploadJson : '../../jsp/upload_json.jsp',
		fileManagerJson : '../../jsp/file_manager_json.jsp',
		width : '100%',
		allowFileManager : true,
		afterCreate : function(id) {
			KE.event.ctrl(document, 13, function() {
				KE.util.setData(id);
				document.forms['form'].submit();
			});
			KE.event.ctrl(KE.g[id].iframeDoc, 13, function() {
				KE.util.setData(id);
				document.forms['form'].submit();
			});
		}
	});