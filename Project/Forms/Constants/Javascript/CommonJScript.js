var BrowserDetect = {
    init: function()
    {
        this.browser = this.searchString(this.dataBrowser) || "An unknown browser";
        this.version = this.searchVersion(navigator.userAgent)
			|| this.searchVersion(navigator.appVersion)
			|| "an unknown version";
        this.OS = this.searchString(this.dataOS) || "an unknown OS";
    },
    searchString: function(data)
    {
        for (var i = 0; i < data.length; i++)
        {
            var dataString = data[i].string;
            var dataProp = data[i].prop;
            this.versionSearchString = data[i].versionSearch || data[i].identity;
            if (dataString)
            {
                if (dataString.indexOf(data[i].subString) != -1)
                    return data[i].identity;
            }
            else if (dataProp)
                return data[i].identity;
        }
    },
    searchVersion: function(dataString)
    {
        var index = dataString.indexOf(this.versionSearchString);
        if (index == -1) return;
        return parseFloat(dataString.substring(index + this.versionSearchString.length + 1));
    },
    dataBrowser: [
		{
		    string: navigator.userAgent,
		    subString: "Chrome",
		    identity: "Chrome"
		},
		{ string: navigator.userAgent,
		    subString: "OmniWeb",
		    versionSearch: "OmniWeb/",
		    identity: "OmniWeb"
		},
		{
		    string: navigator.vendor,
		    subString: "Apple",
		    identity: "Safari",
		    versionSearch: "Version"
		},
		{
		    prop: window.opera,
		    identity: "Opera"
		},
		{
		    string: navigator.vendor,
		    subString: "iCab",
		    identity: "iCab"
		},
		{
		    string: navigator.vendor,
		    subString: "KDE",
		    identity: "Konqueror"
		},
		{
		    string: navigator.userAgent,
		    subString: "Firefox",
		    identity: "Firefox"
		},
		{
		    string: navigator.vendor,
		    subString: "Camino",
		    identity: "Camino"
		},
		{		// for newer Netscapes (6+)
		    string: navigator.userAgent,
		    subString: "Netscape",
		    identity: "Netscape"
		},
		{
		    string: navigator.userAgent,
		    subString: "MSIE",
		    identity: "Explorer",
		    versionSearch: "MSIE"
		},
		{
		    string: navigator.userAgent,
		    subString: "Gecko",
		    identity: "Mozilla",
		    versionSearch: "rv"
		},
		{ 		// for older Netscapes (4-)
		    string: navigator.userAgent,
		    subString: "Mozilla",
		    identity: "Netscape",
		    versionSearch: "Mozilla"
		}
	],
    dataOS: [
		{
		    string: navigator.platform,
		    subString: "Win",
		    identity: "Windows"
		},
		{
		    string: navigator.platform,
		    subString: "Mac",
		    identity: "Mac"
		},
		{
		    string: navigator.userAgent,
		    subString: "iPhone",
		    identity: "iPhone/iPod"
		},
		{
		    string: navigator.platform,
		    subString: "Linux",
		    identity: "Linux"
		}
	]

};

function ModifyEnterKeyPressAsTab1() {
    if (window.event && window.event.keyCode == 13) {
        if (window.event.srcElement.type == "submit") {
            return true;
        }
        else {
            event.keyCode = 9;
        }
        //window.event.ctrlKey = true;
        //window.event.keyCode = 64;
        //return false;
    }
    if ((event.keyCode == 83 || event.keyCode == 85) && event.ctrlKey == true && event.shiftKey == true) {
        document.getElementById(GetClientId('btn_save')).click();
    }
    if (event.keyCode == 82 && event.ctrlKey == true && event.shiftKey == true) {
        document.getElementById(GetClientId('btn_remove')).click();
    }
    if (event.keyCode == 69 && event.ctrlKey == true && event.shiftKey == true) {
        document.getElementById(GetClientId('btn_Search')).click();
    }
}

function ModifyEnterKeyPressAsTab() {
    if (window.event && window.event.keyCode == 13) {
        if (window.event.srcElement.type == "submit") {
            return true;
        }
        else if (event.keyCode == 83 && event.ctrlKey == true && event.shifKey == true) {
            document.getElementById(GetClientId('btn_save')).click();
        }
        else {
            event.keyCode = 9;
        }
        //window.event.ctrlKey = true;
        //window.event.keyCode = 64;
        //return false;
    }
}
function func_registerJavascript() {
    BrowserDetect.init();
    //alert(BrowserDetect.browser);
    if (BrowserDetect.browser == 'Explorer') {
        document.body.onkeydown = function ModifyEnterKeyPressAsTab() {
            if (window.event && window.event.keyCode == 13) {
                if (window.event.srcElement.type == "submit") {
                    return true;
                }
                else
                    window.event.keyCode = 9;
                //window.event.ctrlKey = true;
                //window.event.keyCode = 64;
                //return false;
            }
        }
    }
    else if (BrowserDetect.browser == 'Firefox' || BrowserDetect.browser == 'Opera') {
        document.body.onkeypress = function test(evt) {
            var e = (window.event) ? window.event : evt;
            var hiddenElementId = "";
            //var controllType = e.target.type;
            //alert(e.target.type);
            ////does not work in firefox
            ////if (e.which == 13) {
            //// e.keyCode = 9;
            ////}
            if (e.which == 13 && e.target.type != "submit") {
                if (document.getElementById(GetClientId('hidControlToFocus')) != null) {
                    hiddenElementId = GetClientId('hidControlToFocus');
                    var focusControlId = document.getElementById(hiddenElementId).value;
                    if (focusControlId != "A") {
                        document.getElementById(hiddenElementId).value = "A";
                        if (document.getElementById(hiddenElementId).type == "select-one") {
                            document.getElementById(document.getElementById(hiddenElementId).value).select();
                        }
                        document.getElementById(focusControlId).focus();
                    }
                    else {
                        GetFocusFirefox(e.target.id);
                    }
                }
                else {
                    GetFocusFirefox(e.target.id);
                }
                return false;
            }
            else
                return true;
        }
    }   
}

//function onSubmitform($char, $mozChar, $srcElementType,$srcElementId) {
//    //alert('test');
//    //var events = window.event;
//    var controllType = "";
//    try {
//        if ($srcElementType == "submit") {
//            controllType = "submit"
//        }
//    }
//    catch (e) {

//    }
//    if ($char == 13 && controllType != "submit") {
//        //var clientId = window.event.srcElement.id;
//        GetFocus($srcElementId)
//        return false;
//    }
//    else
//        return true;
//}
function test($which, $srcId, $srcType) {
    //var events = window.event ? event : e;
    //alert($which+$srcId);

    var controllType = $srcType;
    try {
        if ($srcType == "submit") {
            controllType = "submit"
        }
    }
    catch (e) {

    }
    if ($which == 13 && controllType != "submit") {
        GetFocus($srcId)
        return false;
    }
    else
        return true;
}

function onSubmitform() {
    var events = window.event;
    var controllType = "";
    try {
        if (window.event.srcElement.type == "submit") {
            controllType = "submit"
        }
    }
    catch (e) {

    }
    if (events.keyCode == 13 && controllType != "submit") {
        var clientId = window.event.srcElement.id;
        GetFocus(clientId)
        return false;
    }
    else
        return true;
}

function showConfirmDialog(controlId) {
    try {
        if (typeof (Page_ClientValidate) == 'function')Page_ClientValidate();
        if (Page_IsValid) {
            if (controlId == GetClientId('btn_save') &&
    document.getElementById(GetClientId('hidIsInsertMode')).value == "False") {
                if (confirm("Are you sure to Update?")) {
                    return true;
                }
                else {
                    return false;
                }
            }
            if (controlId == GetClientId('btn_remove') &&
    document.getElementById(GetClientId('hidIsInsertMode')).value == "False") {
                if (confirm("Are you sure to Delete?")) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        else {
            return false;
        }
    }
    catch (e) {
        return false;
    }
//    if (mustFieldValidation('txt_companyName'))
//        return true;
//        
//    return false;
}

function mustFieldValidation(controlId) {
    if (document.getElementById(GetClientId(controlId)).value != "") {
        return true;
    }
    return false;
}

function numericValidation(s_str, dftMsg) {
    var b_isTrue = false;
    var i_length = s_str.length;

    try {
        for (var i = 0; i < i_length; i++) {
            if ((s_str.substring(i, i+1) == "1") || (s_str.substring(i, i+1) == "2") || (s_str.substring(i, i+1) == "3") || (s_str.substring(i, i+1) == "4") ||
                        (s_str.substring(i, i+1) == "5") || (s_str.substring(i, i+1) == "6") || (s_str.substring(i, i+1) == "7") || (s_str.substring(i, i+1) == "8") ||
                        (s_str.substring(i, i+1) == "9") || (s_str.substring(i, i+1) == "0")) {
                b_isTrue = true;
            }
            else {
                if (dftMsg == 0) {
                    return false;
                }
                b_isTrue = false;
                s_str = "";
                i_length = 0;
            }
        }
    }
    catch (ex) {
        alert("Invalid Value");
    }
    finally {
        //nothing;
    }
    return b_isTrue;
}

function numericValidationDecimal(s_str, dftMsg) {
 var b_isTrue = false;
            var i_length = s_str.length;
            var j = 0;

            try
            {
                for (var i = 0; i < i_length; i++)
                {
                     if ((s_str.substring(i, i+1) == "1") || (s_str.substring(i, i+1) == "2") || (s_str.substring(i, i+1) == "3") || (s_str.substring(i, i+1) == "4") ||
                        (s_str.substring(i, i+1) == "5") || (s_str.substring(i, i+1) == "6") || (s_str.substring(i, i+1) == "7") || (s_str.substring(i, i+1) == "8") ||
                        (s_str.substring(i, i+1) == "9") || (s_str.substring(i, i+1) == "0") || (s_str.substring(i,  i+1) == "."))
                    {
                        b_isTrue = true;

                        if (s_str.substring(i, i+1) == ".")
                        {
                            j += 1;

                            if (j > 1)
                            {
                                if (dftMsg == 0)
                                {
                                    alert("Invalid Data."); return false;
                                }
                                b_isTrue = false;
                                s_str = "";
                                i_length = 0;
                            }
                        }
                    }
                    else
                    {
                        if (dftMsg == 0)
                        {
                            alert("Invalid Data."); return false;
                        }
                        b_isTrue = false;
                        s_str = "";
                        i_length = 0;
                    }
                }
            }
            catch (ex)
            {
                alert("Invalid Data");
            }
            finally
            {
                //nothing;
            }
            return b_isTrue;
        }


        function numeric_Validation_Decimal_Allow_Minus(s_str, dftMsg) {
            var b_isTrue = false;
            var i_length = s_str.length;
            var j = 0;

            try {
                for (var i = 0; i < i_length; i++) {
                    if ((s_str.substring(i, i + 1) == "1") || (s_str.substring(i, i + 1) == "2") || (s_str.substring(i, i + 1) == "3") || (s_str.substring(i, i + 1) == "4") ||
                        (s_str.substring(i, i + 1) == "5") || (s_str.substring(i, i + 1) == "6") || (s_str.substring(i, i + 1) == "7") || (s_str.substring(i, i + 1) == "8") ||
                        (s_str.substring(i, i + 1) == "9") || (s_str.substring(i, i + 1) == "0") || (s_str.substring(i, i + 1) == ".") || (s_str.substring(i, 1) == "-")) {
                        b_isTrue = true;

                        if (s_str.substring(i, i + 1) == "-") {
                            if (i > 0) {
                                if (dftMsg == 0) {
                                    alert("Invalid Data."); return false;
                                }
                                b_isTrue = false;
                                s_str = "";
                                i_length = 0;
                            }
                        }

                        if (s_str.substring(i, i + 1) == ".") {
                            j += 1;

                            if (j > 1) {
                                if (dftMsg == 0) {
                                    alert("Invalid Data."); return false;
                                }
                                b_isTrue = false;
                                s_str = "";
                                i_length = 0;
                            }
                        }
                    }
                    else {
                        if (dftMsg == 0) {
                            alert("Invalid Data."); return false;
                        }
                        b_isTrue = false;
                        s_str = "";
                        i_length = 0;
                    }
                }
            }
            catch (ex) {
                alert("Invalid Data."); return false;
            }
            finally {
                //nothing;
            }
            return b_isTrue;
        }
        