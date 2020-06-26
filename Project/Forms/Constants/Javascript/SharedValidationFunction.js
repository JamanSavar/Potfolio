function IntegerValidation(s_controlId) {
    var strValidChars = "0123456789";
    var strChar;
    var blnResult = true;

    var strString = $get(GetClientId(s_controlId));  //$get(s_controlId).value;
    if (strString.value.length == 0) {
        return false;
    }

    //  test strString consists of valid characters listed above
    for (i = 0; i < strString.value.length; i++) {
        strChar = strString.value.charAt(i);
        if (strValidChars.indexOf(strChar) == -1) {
            alert("Invalid value");
            strString.value = "";
            strString.focus();
            blnResult = false;
        }
    }
    return blnResult;
}

function MustFieldValidation(s_controlId) {
    var strChar;
    var blnResult = true;

    var strString = $get(GetClientId(s_controlId));  //$get(s_controlId).value;
    if (strString.value.length == 0) {
        alert("Cann't be empty");
        blnResult = false;
    }
    return blnResult;
}

function NumericValidation(s_controlId) {
    var strValidChars = "0123456789.";
    var strChar;
    var blnResult = true;

    var strString = $get(GetClientId(s_controlId));  //$get(s_controlId).value;
    if (strString.value.length == 0) {
        return false;
    }

    //  test strString consists of valid characters listed above
    for (i = 0; i < strString.value.length; i++) {
        strChar = strString.value.charAt(i);
        if (strValidChars.indexOf(strChar) == -1) {
            alert("Invalid value");
            strString.value = "";
            blnResult = false;
        }
    }
    return blnResult;
}

/////Added by Basher For Message box 
///title: "FB FOOTWEAR (Message Box)",

function Showmsgbox(msg) {
    $(function() {
        $("#dialog").html(msg);
        $("#dialog").dialog({
        title: "EXCOM FASHIONS LTD.",
            buttons: {
                Close: function() {
                    $(this).dialog('close');
                }
            },
            modal: true
        });
    });
};


/////Added by Basher For Message box



function disableautocompletion(id) {
    var passwordControl = document.getElementById(id);
    passwordControl.setAttribute("autocomplete", "off");
}