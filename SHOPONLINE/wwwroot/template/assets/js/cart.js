function validateUpdateCart(){
    $('input.quantity-value').each(function(){
        if(!isInteger($(this).val())){
            alert('Quantity is number!');
            $(this).focus();
            return false; 
        }
    });
    var data = $('form#frmUpdateCart').serialize();
    $.ajax({
		type : 'POST',
		url : 'index.php?module=product&view=cart&raw=1&task=updateCart',
		dataType : 'json',
		data: data,
		success : function(data){
            Boxy.alert(data.message,function(){
                window.location.reload(true);
            },{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });},
		error : function(XMLHttpRequest, textStatus, errorThrown) {Boxy.alert('There are errors in the process of putting up a server. Please check the connection!',function(){},{title:'Notify.',afterShow: function() {$('#boxy_button_OK').focus();}});}
	});
	return false;
}
function checkSample(){
    if (document.getElementById("check_sample").checked){
        document.getElementById("recipients_name").value		= document.getElementById("sender_name").value;
        document.getElementById("recipients_telephone").value	= document.getElementById("sender_telephone").value;
        document.getElementById("recipients_email").value		= document.getElementById("sender_email").value;
        document.getElementById("recipients_address").value     = document.getElementById("sender_address").value;
    }else{
        document.getElementById("recipients_name").value		= '';
        document.getElementById("recipients_telephone").value	= '';
        document.getElementById("recipients_email").value		= '';
        document.getElementById("recipients_address").value     = '';
    }
}
function changeCity($city_id){
    $.ajax({
		type : 'POST',
		url : 'index.php?module=ajax&view=ajax&raw=1&task=loadDistricts',
		dataType : 'html',
		data: {city_id:$city_id},
		success : function(data){
            $('#sender_district').html(data);
        },
		error : function(XMLHttpRequest, textStatus, errorThrown) {Boxy.alert('There are errors in the process of putting up a server. Please check the connection!',function(){},{title:'Notify.',afterShow: function() {$('#boxy_button_OK').focus();}});}
	});
    return false;
}
function validatePayment(){
    if(!isEmpty('sender_name')){
        Boxy.alert('Please enter your first and last name.',function(){$('#sender_name').focus();},{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });
        return false;
    }
    if(!isPhone('sender_telephone')){
        Boxy.alert('Your telephone number is not correct.',function(){$('#sender_telephone').focus();},{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });
        return false;
    }
    if($('#sender_email').val() == ''){
        Boxy.alert('Please enter your email address.',function(){$('#sender_email').focus();},{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });
        return false;
    }
    if(!isEmail($('#sender_email').val())){
        Boxy.alert('Your email address is not correct.',function(){$('#sender_email').focus();},{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });
        return false;
    }
    if($('#sender_address').val() == ''){
        Boxy.alert('Please enter your email address.',function(){$('#sender_address').focus();},{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });
        return false;
    }
   /* if(!isEmpty('recipients_name')){
        Boxy.alert('Enter the full name of the recipient.',function(){$('#recipients_name').focus();},{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });
        return false;
    }
    if(!isPhone('recipients_telephone')){
        Boxy.alert('Recipient"s phone number is not correct.',function(){$('#recipients_telephone').focus();},{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });
        return false;
    }
    if($('#recipients_email').val() == ''){
        Boxy.alert('Please enter your email address.',function(){$('#recipients_email').focus();},{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });
        return false;
    }
    if(!isEmail($('#recipients_email').val())){
        Boxy.alert('Your email address is not correct.',function(){$('#recipients_email').focus();},{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });
        return false;
    }
    if($('#recipients_address').val() == ''){
        Boxy.alert('Please enter your email address.',function(){$('#recipients_address').focus();},{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });
        return false;
    }
    if(!isEmpty('capcha')){
        Boxy.alert('Please enter the security code.',function(){$('#capcha').focus();},{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });
        return false;
    }
    $.ajax({
		type : 'POST',
		url : 'index.php?module=ajax&view=ajax&raw=1&task=checkCapcha',
		dataType : 'json',
		data: {capcha:$('#capcha').val()},
		success : function(data){
            if(data.check == false){
                Boxy.alert('Security code is not correct.',function(){$('#capcha').focus();},{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });
            }else{
                document.forms['frmPayment'].submit();
            }
        },
		error : function(XMLHttpRequest, textStatus, errorThrown) {
		  Boxy.alert('Security code is not correct.',function(){$('#capcha').focus();},{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });
		}
	});
    if(checkCapcha() == '0'){
        Boxy.alert('Mã bảo mật không đúng.',function(){$('#capcha').focus();},{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });
        return false;
    }*/
    document.forms['frmPayment'].submit();
}
function checkCapcha(){
    $.ajax({
		type : 'POST',
		url : 'index.php?module=ajax&view=ajax&raw=1&task=checkCapcha',
		dataType : 'json',
		data: {capcha:$('#capcha').val()},
		success : function(data){
            if(data.check == false){
                return false;
            }else{
                return true;
            }
        },
		error : function(XMLHttpRequest, textStatus, errorThrown) {return false;}
	});
    return false;
}
function validatePaymentMethod(){
    if($('#payment_mothods_select').val() == 0){
        Boxy.alert('You must select a payment method.',function(){},{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });
        return false;
    }
    document.forms['frmPaymentMothods'].submit();
}
function validApplyDiscount(){
    if(!isEmpty('discount_code')){
        Boxy.alert('Please enter your discount code.',function(){$('#discount_code').focus();},{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });
        return false;
    }
    $.ajax({
		type : 'POST',
		url : 'index.php?module=ajax&view=ajax&raw=1&task=applyDiscount',
		dataType : 'json',
		data: {discount_code:$('#discount_code').val(), cart_total:$('#cart_total').val()},
		success : function(data){
            if(data.error == true){
                Boxy.alert(data.message, function(){$('#discount_code').focus();},{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });
            }else{
                Boxy.alert(data.message, function(){location.reload();},{title:'Notify.',afterShow: function() { $('#boxy_button_OK').focus();} });
            }
        },
		error : function(XMLHttpRequest, textStatus, errorThrown) {Boxy.alert('There are errors in the process of putting up a server. Please check the connection!',function(){},{title:'Notify.',afterShow: function() {$('#boxy_button_OK').focus();}});}
	});
    return false;
}
$(document).ready(function(){
    $('.payment_mothods').click(function(){
        $('#payment_mothods_select').val($(this).val());
    });
})