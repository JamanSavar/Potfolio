using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GlobalVariables
/// </summary>
public class GlobalVariables
{
    private GlobalVariables()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    //Login pageURL
    public const string g_s_URL_loginPage = "~/UI/frmHome.aspx";
    //public const string g_s_URL_loginPage = "~/Common/frm_login.aspx";


    public const string g_s_URL_homePage = "~/Forms/frm_HomePage.aspx";
    public const string g_s_URL_permissionDenied = "~/Common/frm_permissionDenied.aspx";


    //ReportViewer
    public const string g_s_URL_reportViewer = "~/Common/ReportViewer/frm_ReportViewer.aspx";
    public const string g_s_URL_reportViewerWithSubreport = "~/Common/ReportViewer/frm_ReportViewer_SubReport.aspx";


    //Global Variables for Validation Type
    public const string g_s_MustFieldValdation = "_MFVTxt";
    public const string g_s_DecimalValdation = "_DV";
    public const string g_s_DecimalValdation_AllowMinus = "_DV_AM";
    public const string g_s_IntegerValdation = "_IV";
    public const string g_s_IntegerValdation_AllowMinus = "_IV_AM";
    public const string g_s_DateValidation = "_DateV";
   
    //Browser name declaration
    public const string g_s_Browser_InternetExplorer = "IE";
    public const string g_s_Browser_MozillaFirefox = "Firefox";
    public const string g_s_Browser_AppleMac_Safari = "AppleMac-Safari";
    public const string g_s_Browser_Opera = "Opera";
    public const string g_s_ConnectionStringName = "HR";

    public const string g_s_procedureDuplicateReturnValue = "D";
    
    public const string numericValidation = @"^(-)?\d+(\.\d\d)?$";
    public const string g_s_stringToReplace = "'";
    public const string g_s_stringByReplace = "''''";
    public const string g_s_stringByReplaceFrontEnd = "''";

    public const string g_s_serverValidationErrorControlId = "g_s_serverValidationErrorControlId";

    public const int g_s_referenceId = 0;

    public const string g_s_No = "N";
    public const string g_s_Yes = "Y";
    public const string g_s_exported = "N";
   
    //Voucher Entry Form
    public const string g_s_updateAlertKey = "onclick";
    public const string g_s_updateAlertValue = "return showConfirmDialog(this.id);";

    public const string g_s_insertOperationSuccessfull = "Successfully Inserted";
    public const string g_s_insertOperationFailed = "Insertion Failed";
    public const string g_s_updateOperationFailed = "Update Failed";
    public const string g_s_updateOperationSuccessfull = "Successfully Updated";
    public const string g_s_deleteOperationFailed = "Data Already Exists in ";
    public const string g_s_deleteOperationSuccessfull = "Successfully Deleted";
    public const string g_s_duplicateCheckWarningMessage = "Data Already Exist";
    public const string g_s_validationErrorMessage = "Error in Control ";

    public const string g_s_encryptionKey = "~@#$^%@!";
    public const string g_s_performanceTypeSupervisor = "S";
    public const string g_s_performanceTypeEmployee = "E";



    public const string g_s_hrEamilAddress = "testhr99@yahoo.com";
    public const string g_s_fromEamilAddress = "hr.bd@mondialorg.com";

   
    public const string g_s_style_onmouseout = "this.style.textdecoration='none';this.style.color='Black';";
    public const string g_s_style_onmouseover = "this.style.cursor='hand';this.style.cursor='pointer';this.style.color='DarkGreen';";

    //for security implementation
    public const string g_s_insertSecurityMessage = "You are not permitted to save";
    public const string g_s_updateSecurityMessage = "You are not permitted to update";
    public const string g_s_deleteSecurityMessage = "You are not permitted to delete";
    //catch sql error
    public const string g_s_connectionErrorReturnValue = "Error";

    //report footer signature formula field
    public const string g_s_signature1 = "Receivers Signature:";
    public const string g_s_signature2 = "Authorised Signatory:";
    public const string g_s_signature3 = "Chairman Signature";
    public const string g_s_signature4 = "Director Signature";
    public const string g_s_signature5 = "Accountant Signature";

    //attribute ratings check
    public const string g_s_attributeRatingCheck = "No need to insert attribute";

    //validation expression
    public const string g_vldExp_positiveIntrgerNotZero = @"^[1-9]([0-9]+)?";
    public const string g_vldExp_decimalValue = @"^(-)?\d+(\.\d\d)?$";


    //common Variables for ISUD string format
    public const string g_s_TableName = "g_s_TableName";
    public const string g_s_Parameter = "g_s_Parameter";
    public const string g_s_ColumnName = "g_s_ColumnName";
    public const string g_s_DuplicateChecking = "g_s_DuplicateChecking";
    public const string g_s_deletedColumnName = "g_s_deletedColumnName";
    public const string g_s_deleteValue = "g_s_deleteValue";
    public const string g_s_procedureReturnType = "g_s_procedureReturnType";

    public const string g_s_ModuleAutoId = "g_s_ModuleAutoId";
    public const string g_s_financialYearFrom = "financialYearFrom";

    public const string g_s_insertMode = "g_s_insertMode";//check for insert or update mode
    public const string g_s_autoId = "g_s_autoId";//station 1 database identification    
    public const string Addmode = "Addmode";//station 1 database identification    
    
    //trace user
    public const string g_s_userAutoId = "g_s_userAutoId";
    public const string g_s_userPassword = "g_s_userPassword";
    public const string g_s_userName = "g_s_userName";
    public const string g_s_userPresentEmail = "g_s_userPresentEmail";
    public const string g_s_userEmergencyEmail = "g_s_userEmergencyEmail";
    public const string g_s_userStatus = "g_s_userStatus";
    public const string g_s_userEmail = "g_s_userEmail";
    public const string g_s_userLevel = "g_s_userLevel";

    public const string g_s_userLogBookAutoId = "g_s_userLogBookAutoId";

    //Company Information
    public const string g_s_companyDefaultCurrencyAutoId = "g_s_companyDefaultCurrencyAutoId";
    public const string g_s_companyDefaultCurrencySymbol = "g_s_companyDefaultCurrencySymbol";


    //new update
    public const string g_s_CompanyAutoId = "g_s_CompanyAutoId";
    public const string g_s_GroupName = "g_s_GroupName";
    public const string g_s_companyName = "g_s_companyName";
    public const string g_s_Address = "g_s_Address";
    public const string g_s_City = "g_s_City";
    public const string g_s_Zip = "g_s_Zip";
    public const string g_s_Country = "g_s_Country";
    public const string g_s_Phone = "g_s_Phone";
    public const string g_s_Fax = "g_s_Fax";
    public const string g_s_Email = "g_s_Email";
    public const string g_s_Code = "g_s_Code";
    public const string g_s_Web = "g_s_Web";


    //Month Year
    public static Dictionary<int, string> Months = new Dictionary<int, string>() 
                                     { 
                                        { 
                                            1, "January"
                                        }, 
                                        { 
                                            2, "February"
                                        }, 
                                        { 
                                            3, "March"
                                        }, 
                                        { 
                                            4, "April"
                                        }, 
                                        { 
                                            5, "May"
                                        }, 
                                        { 
                                            6, "June"
                                        }, 
                                        { 
                                            7, "July"
                                        }, 
                                        { 
                                            8, "August"
                                        }, 
                                        { 
                                            9, "September"
                                        }, 
                                        { 
                                            10, "October"
                                        }, 
                                        { 
                                            11, "November"
                                        }, 
                                        { 
                                            12, "Decemeber"
                                        }
                                    };
}
