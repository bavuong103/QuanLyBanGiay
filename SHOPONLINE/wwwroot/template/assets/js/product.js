$(document).ready(function(){
    /* Ảnh sản phẩm*/
    $('.list-thumb a').click(function(){
        $('.list-thumb a').removeClass('selected');
        $(this).addClass('selected');
        $('#product-image').attr('src', $(this).children('img').attr('src').replace('/tiny/', '/medium/'));
    });
    /* Tabs */
    $("#pro-tabs ul").idTabs();
    /* Lấy tin liên quan */
    $.ajax({
		type : 'POST',
		url : '/index.php?module=ajax&view=ajax&raw=1&task=loadRelatedNews',
		dataType : 'html',
		data: 'keyword='+$('#related-keyword').val(),
		success : function(data){
            $('#related-news').html(data);
        },
		error : function(XMLHttpRequest, textStatus, errorThrown){
            $('#related-news').html('');
        }
	});
});
function validateComment(){
    if ($('#txtName').val()=='Họ và tên...') {
        Boxy.alert('Xin hãy nhập Họ và Tên.',function(){ $('#txtName').focus();},{title:'Thông báo.',afterShow: function() {$('#boxy_button_OK').focus();}});
      	return false;
   	}
	if(!isEmail($('#txtMail').val())){
		Boxy.alert('Nhập địa chỉ email.',function(){$('#txtMail').focus();},{title:'Thông báo.',afterShow: function() { $('#boxy_button_OK').focus();} });
		return false;
	}
	if ($('#txtCode').val()=='') {Boxy.alert('Nhập mật mã bảo vệ.',function(){ $('#txtCode').focus();},{title:'Thông báo.',afterShow: function() {$('#boxy_button_OK').focus();}});
      	return false;
   	}
	var $data = $('form#frmComment').serialize();
	$('#waitting').addClass('show');
	$.ajax({
		type : 'POST',
		url : '/index.php?module=ajax&view=ajax&task=commentProduct',
		dataType : 'json',
		data: $data,
		success : function(data){Boxy.alert(data.message,function(){$('#waitting').removeClass('show'); if (data.error==false) {location.reload(true)}},{title:'Thông báo.',afterShow: function() { $('#boxy_button_OK').focus();} });},
		error : function(XMLHttpRequest, textStatus, errorThrown) {Boxy.alert('Có lỗi trong qua trình đưa dữ liệu lên server. Xin hãy kiểm tra lại kết nối!',function(){$('div#waitting').css('display','none');},{title:'Thông báo.',afterShow: function() { $('#boxy_button_OK').focus();} });
		}
	});
	return false;
}