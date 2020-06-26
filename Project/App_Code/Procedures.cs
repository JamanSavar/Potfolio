using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProcedureNames
/// </summary>
public class Procedures
{
    private Procedures()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public class Accounts
    {
        private Accounts() { }
        public const string Proc_Standard_Voucher_Type_StandardVoucherType_Select = "proc_Standard_Voucher_Type_standardVoucherType_select";
        public const string Insert_Update_Delete_Select_Independent_Tables1 = "proc_Insert_Update_Delete_Select_Independent_Tables1";
        public const string Proc_Insert_Update_Delete_Select_Independent_Tables = "proc_Insert_Update_Delete_Select_Independent_Tables";
        public const string Proc_Insert_Update_Delete_Select_Independent_Tables1 = "proc_Insert_Update_Delete_Select_Independent_Tables1";
        public const string Proc_Acc_frm_voucherConfiguration_Select_initialValue_GridView = "proc_Acc_frm_voucherConfiguration_Select_initialValue_GridView";
        public const string proc_currencyExchangeRate_select = "proc_currencyExchangeRate_select";
        public const string Proc_Acc_frm_Ledger_Select_ChartOfAccountsGrid = "[proc_Acc_frm_Ledger_Select_ChartOfAccountsGrid]";
        public const string Proc_Insert_Update_Delete_Select = "[proc_Insert_Update_Delete_Select]";
        public const string Proc_Acc_frm_LedgerInfo_Select = "[proc_Acc_frm_LedgerInfo_Select]";
        public const string Proc_Acc_frm_LedgerTreeView_Select_ChieldNodeFromNodeKey = "[proc_Acc_frm_LedgerTreeView_Select_ChieldNodeFromNodeKey]";
        public const string Proc_Acc_frm_CostCenterTreeView_ChieldNodeFromNodeKey = "[proc_Acc_frm_CostCenterTreeView_ChieldNodeFromNodeKey]";
        public const string Proc_Acc_frm_voucherEntry_Select_LedgerHead_With_COAAutoId = "[proc_Acc_frm_voucherEntry_Select_LedgerHead_With_COAAutoId]";
        public const string Proc_Acc_frm_ledgerInfo_Select_Currency_Without_DefaultCurrency = "[proc_Acc_frm_ledgerInfo_Select_Currency_Without_DefaultCurrency]";

        public const string Proc_Acc_frm_VoucherEntry_Select_Branch = "[proc_Acc_frm_VoucherEntry_Select_Branch]";
        public const string Proc_Acc_frm_VoucherEntry_Select_CostCenter = "[proc_Acc_frm_VoucherEntry_Select_CostCenter]";

        //Name: frm_journalView
        public const string Proc_Acc_JournalView_Select = "proc_Acc_frm_journalView_Select";
        public const string Proc_Acc_Frm_JournalView_Select_For_LeadgerheadAlias = "proc_Acc_frm_journalView_Select_for_leadgerheadAlias";

        //form Name: frm_voucherEntry.aspx
        public const string Proc_Acc_frm_voucherEntry_Insert_JournalInfo_Master = "[proc_Acc_frm_voucherEntry_Insert_JournalInfo_Master]";
        public const string Proc_Acc_frm_voucherEntry_Update_JournalInfo_Master = "[proc_Acc_frm_voucherEntry_Update_JournalInfo_Master]";
        public const string proc_Acc_frm_voucherEntry_Delete_JournalInfoByJournalInfoAutoId = "[proc_Acc_frm_voucherEntry_Delete_JournalInfoByJournalInfoAutoId]";
        public const string Proc_Acc_frm_voucherEntry_Insert_JournalEntries_Details = "[proc_Acc_frm_voucherEntry_Insert_JournalEntries_Details]";
        public const string Proc_Acc_frm_voucherEntry_Insert_JournalEntries_CostCenter = "[proc_Acc_frm_voucherEntry_Insert_JournalEntries_CostCenter]";
        public const string Proc_Acc_frm_voucherEntry_Select_BillWise_AgainstReference = "[proc_Acc_frm_voucherEntry_Select_BillWise_AgainstReference]";

        public const string Proc_Acc_frm_voucherEntry_Select_VoucherInfoByVoucherNo = "[proc_Acc_frm_voucherEntry_Select_VoucherInfoByVoucherNo]";
        public const string Proc_Acc_frm_voucherEntry_Select_JournalEntriesInfoByJournalInfo = "[proc_Acc_frm_voucherEntry_Select_JournalEntriesInfoByJournalInfo]";
        public const string Proc_Acc_frm_voucherEntry_Select_BillWiseInfoByJournalEntries = "[proc_Acc_frm_voucherEntry_Select_BillWiseInfoByJournalEntries]";
        public const string Proc_Acc_frm_voucherEntry_Select_CostCenterInfoByJournalEntries = "[proc_Acc_frm_voucherEntry_Select_CostCenterInfoByJournalEntries]";

        public const string Proc_Acc_frm_voucherEntry_Update_JournalEntries_BillWise = "[proc_Acc_frm_voucherEntry_Update_JournalEntries_BillWise]";
        public const string Proc_Acc_frm_LedgerInfo_Select_BillWise = "[proc_Acc_frm_LedgerInfo_Select_BillWise]";

        public const string Proc_Acc_frm_voucherEntry_Select_CompanyDefaultCurrencyAndSymbol = "[proc_Acc_frm_voucherEntry_Select_CompanyDefaultCurrencyAndSymbol]";
        public const string Proc_Acc_frm_voucherEntry_Select_VoucherConfigurationInfoByStandardVoucherType = "[proc_Acc_frm_voucherEntry_Select_VoucherConfigurationInfoByStandardVoucherType]";

        //Name: frm_journalView
        //public const string Proc_Acc_JournalView_Select = "proc_Acc_frm_journalView_Select";
        //public const string Proc_Acc_Frm_JournalView_Select_For_LeadgerheadAlias = "proc_Acc_frm_journalView_Select_for_leadgerheadAlias";

        public const string Proc_Acc_frm_LedgerInfo_Insert_T_Acc_Chart_Of_Accounts = "[proc_Acc_frm_LedgerInfo_Insert_T_Acc_Chart_Of_Accounts]";


        //Name: frm_frm_ledgerHeadAllocation.aspx
        public const string Proc_Acc_frm_LedgerHeadAllocation_Select_AccountHead = "[proc_Acc_frm_LedgerHeadAllocation_Select_AccountHead]";
        public const string Proc_Acc_frm_LedgerHeadAllocation_Select_AccountHead1 = "[proc_Acc_frm_LedgerHeadAllocation_Select_AccountHead1]";

        //Name: frm_LedgerInfo, T_Acc_Cost_Center_Branch_Allocation
        public const string Proc_Acc_frm_voucherEntry_Insert_CostCenter_Branch_Allocation = "[proc_Acc_frm_voucherEntry_Insert_CostCenter_Branch_Allocation]";
        public const string Proc_Acc_frm_LedgerInfo_Insert_T_Acc_Ledger = "[proc_Acc_frm_LedgerInfo_Insert_T_Acc_Ledger]";
        public const string Proc_Acc_frm_LedgerInfo_Delete_LedgerHead_SubHead_Check = "[proc_Acc_frm_LedgerInfo_Delete_LedgerHead_SubHead_Check]";
        public const string Proc_Acc_frm_LedgerInfo_Update_T_Acc_OpeningBalance = "[proc_Acc_frm_LedgerInfo_Update_T_Acc_OpeningBalance]";
        //update chartOfAccounts
        public const string Proc_Acc_frm_LedgerInfo_Update_ChartOfAccounts = "[proc_Acc_frm_LedgerInfo_Update_ChartOfAccounts]";
        //update costCenter Branch Allocation
        public const string Proc_Acc_frm_LedgerInfo_Insert_Cost_Center_Branch_Allocation = "[proc_Acc_frm_LedgerInfo_Insert_Cost_Center_Branch_Allocation]";
        public const string Proc_Acc_frm_VoucherEntry_Select_LedgerHead_By_LedgerHeadAllocation = "[proc_Acc_frm_VoucherEntry_Select_LedgerHead_By_LedgerHeadAllocation]";

        //Delete Ledger Head Reference Check
        public const string Proc_Acc_frm_LedgerInfo_Delete_Ledger_Head_Reference_Check = "[proc_Acc_frm_LedgerInfo_Delete_Ledger_Head_Reference_Check]";
        public const string Proc_Acc_frm_VoucherEntry_Select_LedgerHead_CrDrType_By_LedgerHeadAllocation = "[proc_Acc_frm_VoucherEntry_Select_LedgerHead_CrDrType_By_LedgerHeadAllocation]";
        public const string Proc_Acc_frm_VoucherEntry_Select_VoucherType = "[proc_Acc_frm_VoucherEntry_Select_VoucherType]";

        //Search By Ledger Head and Alias
        public const string Proc_Acc_frm_LedgerInfo_Select_Search_By_Alias_AccountHead = "[proc_Acc_frm_LedgerInfo_Select_Search_By_Alias_AccountHead]";

        //
        public const string Proc_Acc_frm_billwiseTemplate_Insert_T_Acc_LoanSchedule = "[proc_Acc_frm_billwiseTemplate_Insert_T_Acc_LoanSchedule]";

        public const string Proc_frm_voucherEntry_selectVoucherType = "proc_frm_voucherEntry_selectVoucherType";
        public const string Proc_Acc_frm_T_Item_Configuration_Select = "[proc_Acc_frm_T_Item_Configuration_Select]";
        public const string Proc_Acc_frm_billwiseTemplate_Select_All_LedgerHead = "[proc_Acc_frm_billwiseTemplate_Select_All_LedgerHead]";
        public const string Proc_Acc_frm_billwiseTemplate_Select_CashBank_LedgerHead = "[proc_Acc_frm_billwiseTemplate_Select_CashBank_LedgerHead]";

        //Billwise Entry from frm_voucherEntry.aspx Procedure
        public const string Proc_Acc_frm_voucherEntry_Insert_JournalEntries_BillWise = "[proc_Acc_frm_voucherEntry_Insert_JournalEntries_BillWise]";
        //Billwise Entry from frm_LedgerInfo.aspx Procedure
        public const string Proc_Acc_frm_voucherEntry_Insert_JournalEntries_BillWise1 = "[proc_Acc_frm_voucherEntry_Insert_JournalEntries_BillWise1]";

        //select OpeningBalanceAutoId by COAautoId,company and branch
        public const string Proc_acc_frm_billwiseInstallmentReceive_select_openingBalanceAutoId_By_COAAutoId_And_Branch = "[proc_acc_frm_billwiseInstallmentReceive_select_openingBalanceAutoId_By_COAAutoId_And_Branch]";
        public const string Proc_frm_loanReciept_selectInstallmentInfo = "proc_frm_loanReciept_selectInstallmentInfo";
        public const string Proc_Acc_frm_voucherEntry_Select_BillWise_AgainstReference_By_OpeningBalance = "proc_Acc_frm_voucherEntry_Select_BillWise_AgainstReference_By_OpeningBalance";

        #region Report Procedures
        //frm_ProfitANDLoss
        public const string proc_Acc_frmRptIncomeStatement = "[proc_Acc_frmRptIncomeStatement]";

        //frm_trailBalance
        public const string Proc_Acc_frmRptTrialBalance = "proc_Acc_frmRptTrialBalance";


        public const string Proc_Acc_frmRptBalanceSheet = "proc_Acc_frmRptBalanceSheet";

        //rpt_receivePayemnt
        public const string Proc_Acc_frmRptReceiptPayment = "proc_Acc_frmRptReceiptPayment";
        //rpt_notes
        public const string Proc_Acc_frmRptNotes = "proc_Acc_frmRptNotes";

        #endregion End Report Procedures

    }
    public class Common
    {
        private Common() { }
        public const string Proc_Delete_Any_Tables_With_Reference_Checking = "[proc_Delete_Any_Tables_With_Reference_Checking]";

        public const string Proc_Insert_Update_Delete_Select_Independent_Tables = "[proc_Insert_Update_Delete_Select_Independent_Tables]";
        public const string Proc_Insert_Update_Delete_Select_Independent_Tables1 = "[proc_Insert_Update_Delete_Select_Independent_Tables1]";
        public const string Proc_Com_ForFrm_UserPermission_Select_WithParam1 = "[proc_Com_forFrm_UserPermission_Select_WithParam1]";
        public const string Proc_Com_ForFrm_ModuleName_FormName_Select_WithParam = "[proc_Com_forFrm_moduleName_formName_Select_WithParam]";
        public const string Proc_Com_ForFrm_UserGroupPermission_Select_With_Param = "[proc_Com_forFrm_UserGroupPermission_Select_With_Param]";
        public const string Proc_Com_ForFrm_UserGroupPermission_Select_Without_Param = "[proc_Com_forFrm_UserGroupPermission_Select_Without_Param]";
        public const string Proc_Com_ForFrm_UserPermission_Select_WithParam2 = "[proc_Com_forFrm_UserPermission_Select_WithParam2]";
        public const string Proc_Insert_Update_Select_Independent_Tables5 = "[proc_Insert_Update_Select_Independent_Tables5]";
        //Name:frm_login
        public const string Proc_Com_Frm_Login_Select_ValidUser = "proc_Com_frm_login_Select_validUser";

        //Name:frm_MasterPage.master        
        public const string Proc_Com_Frm_Masterpage_Update_Loginfo = "proc_Com_frm_masterpage_update_loginfo";
        public const string Proc_Com_frm_masterpage_select_logedon_companyInfo = "proc_Com_frm_masterpage_select_logedon_companyInfo";
        //for security implementation
        public const string Proc_findOutPermisionOfAFormByUser = "proc_findOutPermisionOfAFormByUser";
        public const string Proc_com_frm_MasterPage_Select_Permission_By_FormName_LeftMenu = "proc_com_frm_MasterPage_Select_Permission_By_FormName_LeftMenu";

        //graphic people common procedure for update
        public const string Proc_Insert_Update_Select_Independent_Tables5_GraphicPeople = "proc_Insert_Update_Select_Independent_Tables5_GraphicPeople";
        public const string Proc_web_frm_empLeaveApplication_select_Applicant_AND_Boss_Name_Designation_By_Application_AutoId = "[proc_web_frm_empLeaveApplication_select_Applicant_AND_Boss_Name_Designation_By_Application_AutoId]";
        

        public const string Proc_Web_Update_UserLogBook = "[proc_Web_Update_UserLogBook]";
        public const string Proc_frm_company_logo_insert = "[proc_frm_company_logo_insert]";

    }
    public class Inventory
    {
        private Inventory()
        {
        }
        public const string Proc_frm_Item_selectItemconfigurationInfo = "Proc_frm_Item_selectItemconfigurationInfo";
    }
    public class humanResource
    {
        private humanResource()
        {
        }
        public const string Proc_rpt_emp_documents_select = "Proc_rpt_emp_documents_select";
        public const string Proc_frm_frm_Acknowledgement_insert_forAcknowledgementEmployee = "proc_frm_frm_Acknowledgement_insert_forAcknowledgementEmployee";
        public const string Proc_frm_frm_Acknowledgement_insert_forDocuments = "proc_frm_frm_Acknowledgement_insert_forDocuments";
        public const string Proc_frm_ConfirmReceiveDocuments_insert_forDocuments = "proc_frm_ConfirmReceiveDocuments_insert_forDocuments";
        public const string Proc_frm_ConfirmReceiveDocuments_checkUpdate = "proc_frm_ConfirmReceiveDocuments_checkUpdate";
        public const string Proc_frm_frm_Acknowledgement_insert_update_delete = "proc_frm_frm_Acknowledgement_insert_update_delete";
        public const string Proc_frm_ConfirmReceiveDocuments_select = "proc_frm_ConfirmReceiveDocuments_select";
        public const string Proc_frmResignTermination_select_managerForExpCertificate = "Proc_frmResignTermination_select_managerForExpCertificate";
        public const string Proc_frmResignTermination_select_supervisor = "proc_frmResignTermination_select_supervisor";
        public const string Proc_web_selectForFrm_empRegionalResourceAllocation1 = "[Proc_web_selectForFrm_empRegionalResourceAllocation1]";
        public const string Proc_frm_empRegionalResourceAllocation_insert_update_delete = "[Proc_frm_empRegionalResourceAllocation_insert_update_delete]";
        public const string Proc_web_frm_empFeedbackForm_Insert_T_Web_LastFeedbackLetter = "[proc_web_frm_empFeedbackForm_Insert_T_Web_LastFeedbackLetter]";
        public const string Proc_web_frm_empFeedbackForm_Delete_T_Web_LastFeedbackLetter = "[Proc_web_frm_empFeedbackForm_Delete_T_Web_LastFeedbackLetter]";
        public const string Proc_web_frm_leaveApproval_select_LeaveCancel = "[proc_web_frm_leaveApproval_select_LeaveCancel]";
        public const string Proc_web_frm_performance_Update_T_Web_LeaveApplicationCancel = "[proc_web_frm_performance_Update_T_Web_LeaveApplicationCancel]";
        public const string Proc_Web_frm_LeaveCancel_Select_EmployeeApplicationDetails_DateRange = "[proc_Web_frm_LeaveCancel_Select_EmployeeApplicationDetails_DateRange]";        
        public const string proc_web_frm_performance_Insert_T_Web_LeaveDeclineCancel = "[proc_web_frm_performance_Insert_T_Web_LeaveDeclineCancel]";
        public const string Proc_web_frm_performance_Insert_T_Web_LeaveApplicationCancel = "[proc_web_frm_performance_Insert_T_Web_LeaveApplicationCancel]";
        public const string Proc_web_frm_performance_delete_previewData = "[proc_web_frm_performance_delete_previewData]";
        public const string Proc_web_frm_pendingPerformanceList_ListOfPendingPerformanceForSupervisor = "[proc_web_frm_pendingPerformanceList_ListOfPendingPerformanceForSupervisor]";
        public const string Proc_web_frm_performace_select_PerformanceFilledUp = "[proc_web_frm_performace_select_PerformanceFilledUp]";
        public const string Proc_web_frm_rpt_leave_select_employee_by_company = "[proc_web_frm_rpt_leave_select_employee_by_company]";
        public const string Proc_frm_resignTermination_select_department_signatory = "Proc_frm_resignTermination_select_department_signatory";
        public const string Proc_frm_resignTermination_select_empSex = "proc_frm_resignTermination_select_empSex";
        public const string Proc_frm_proceedClearence_select_hr_empAutoId = "proc_frm_proceedClearence_select_hr_empAutoId";
        public const string Proc_web_rpt_empPerformance_selectSupervisor = "proc_web_rpt_empPerformance_selectSupervisor";
        public const string Proc_web_rpt_frm_performance_skillAssessment = "proc_web_rpt_frm_performance_skillAssessment";
        public const string Proc_web_frm_performance_select_tab_description = "proc_web_frm_performance_select_tab_description";
        public const string Proc_Insert_Update_Select_Independent_Tables5 = "proc_Insert_Update_Select_Independent_Tables5";
        public const string Proc_Frm_ContactInfo_select = "proc_Frm_ContactInfo_select";
        public const string Proc_web_frm_changePassword_update = "proc_web_frm_changePassword_update";
        public const string Proc_web_frm_mailingList_UN_PW = "proc_web_frm_mailingList_UN_PW";
        //Employee Level Assignment Select ---------------Jahir---------------
        public const string Proc_Web_frm_login_Select_CompanyInformation = "[proc_Web_frm_login_Select_CompanyInformation]";
        public const string Proc_web_frm_empLevelAssign_select_EmployeeListWithLevelAssingedList = "[proc_web_frm_empLevelAssign_select_EmployeeListWithLevelAssingedList]";
        public const string Proc_web_frm_empLeaveApplication_select_EmployeeList_By_Level = "[proc_web_frm_empLeaveApplication_select_EmployeeList_By_Level]";
        public const string Proc_web_frm_empLeaveApplication_select_Applicant_AND_Boss_Name_Designation_By_Application_AutoId = "[proc_web_frm_empLeaveApplication_select_Applicant_AND_Boss_Name_Designation_By_Application_AutoId]";
        public const string Proc_web_frm_empLeaveApproval_select_ApprovedByName_AND_Remarks_By_ApplicationAutoId = "[proc_web_frm_empLeaveApproval_select_ApprovedByName_AND_Remarks_By_ApplicationAutoId]";
        public const string Proc_web_frm_mailingList_select_all_Employee_MailAddress = "[proc_web_frm_mailingList_select_all_Employee_MailAddress]";
        public const string Proc_web_frm_mailingList_select_Employee_MailAddress_For_Evaluation = "[proc_web_frm_mailingList_select_Employee_MailAddress_For_Evaluation]";
        public const string Proc_web_frm_mailingList_select_Current_MailAddress_List = "[proc_web_frm_mailingList_select_Current_MailAddress_List]";
        public const string Proc_insertForfrmLeaveWithPay = "[proc_insertForfrmLeaveWithPay]";
        public const string Proc_Web_frm_login_Select_validUser = "[proc_Web_frm_login_Select_validUser]";
        public const string Proc_web_frm_empPerformance_select_facilities_By_facilitiesGroupAutoId = "[proc_web_frm_empPerformance_select_facilities_By_facilitiesGroupAutoId]";
        public const string Proc_Acc_frm_employeeFeedBack_Insert_EmployeeFeedBackOpinion = "[proc_Acc_frm_employeeFeedBack_Insert_EmployeeFeedBackOpinion]";
        public const string Proc_Web_InfoForfrmRptLeave_GP1 = "[proc_InfoForfrmRptLeave_GP1]";
        public const string Proc_Web_frm_empLeaveApproval_select_emp_emailList_LeaveDeny = "[proc_Web_frm_empLeaveApproval_select_emp_emailList_LeaveDeny]";
        public const string Proc_web_select_for_frm_LetterIssueForOwnPerformance_skillset = "[proc_web_select_for_frm_LetterIssueForOwnPerformance_skillset]";
        public const string Proc_Web_frm_empLeaveApproval_select_emp_emailList_LeaveApprove = "[proc_Web_frm_empLeaveApproval_select_emp_emailList_LeaveApprove]";
        public const string Proc_Web_frm_empLeaveDecline_Select_Employee_Approved_LeaveDetails = "[proc_Web_frm_empLeaveDecline_Select_Employee_Approved_LeaveDetails]";
        public const string Proc_web_frm_empLeaveDeclineDetail_select_ApplicationInfo_by_DeclineId = "[proc_web_frm_empLeaveDeclineDetail_select_ApplicationInfo_by_DeclineId]";
        public const string Proc_insert_T_Web_ApprovedLeaveWithLetterIssue = "[proc_insert_T_Web_ApprovedLeaveWithLetterIssue]";
        public const string Proc_web_frm_empLeaveDeclineDetail_select_ApprovedByName_AND_Remarks_By_DeclineAutoId = "[proc_web_frm_empLeaveDeclineDetail_select_ApprovedByName_AND_Remarks_By_DeclineAutoId]";
        public const string Proc_web_frm_empLeaveDeclineDetail_Delete_T_LeaveWithPay = "[proc_web_frm_empLeaveDeclineDetail_Delete_T_LeaveWithPay]";
        public const string Proc_Web_frm_empLeaveDeclineApproval_select_emailList_LeaveDeclineApprove = "[proc_Web_frm_empLeaveDeclineApproval_select_emailList_LeaveDeclineApprove]";
        public const string Proc_frm_empPerformanceByLeader_Select_SelectedRecomendationType1 = "[proc_frm_empPerformanceByLeader_Select_SelectedRecomendationType1]";
        public const string Proc_frm_empPerformanceByLeader_Select_SelectedRecomendationType2 = "[proc_frm_empPerformanceByLeader_Select_SelectedRecomendationType2]";
        public const string Proc_web_frm_leaveApproval_leaveCount = "[proc_web_frm_leaveApproval_leaveCount]";
        public const string Proc_Web_frm_empLeaveDecline_delete_approvedLeave = "[proc_Web_frm_empLeaveDecline_delete_approvedLeave]";
        public const string Proc_frmLeaveApplication_select_empLeaveInfo_Decline = "[proc_frmLeaveApplication_select_empLeaveInfo_Decline]";
        public const string Proc_frmLeaveApplication_select_empLeaveInfo_Application = "[proc_frmLeaveApplication_select_empLeaveInfo_Application]";
        public const string Proc_web_select_all_employee_by_company = "[proc_web_select_all_employee_by_company]";
        public const string Proc_AllInfoForfrmRptLeave_GP = "[proc_AllInfoForfrmRptLeave_GP]";
        public const string Proc_InfoForfrmRptLeave_GP = "[proc_InfoForfrmRptLeave_GP]";
        public const string Proc_web_insert_T_Web_LeaveApplicationDays = "[proc_web_insert_T_Web_LeaveApplicationDays]";
        public const string Proc_web_select_leaveDays_By_ApplicationId = "[proc_web_select_leaveDays_By_ApplicationId]";
        public const string Proc_Web_frm_currentLeaveRequest_Select_ApplicationDetails_DateRange = "[proc_Web_frm_currentLeaveRequest_Select_ApplicationDetails_DateRange]";
        public const string Proc_web_frmRptLeaveStatus_AllInfo = "[proc_web_frmRptLeaveStatus_AllInfo]";
        public const string Proc_web_frm_EmployeeDocument_Select_By_EmployeeID = "[proc_web_frm_EmployeeDocument_Select_By_EmployeeID]";
        public const string Proc_web_frm_employeeLeaveAssign_NotLevelAssignedEmployee = "[proc_web_frm_employeeLeaveAssign_NotLevelAssignedEmployee]";
        public const string Proc_web_frm_LetterIssue_For_Voting_selectTopicsInformation_By_AutoId = "[proc_web_frm_LetterIssue_For_Voting_selectTopicsInformation_By_AutoId]";
        public const string Proc_web_frm_letterIssueForPerformance_Insert_T_Web_MailIssueForEmpPerformance = "[proc_web_frm_letterIssueForPerformance_Insert_T_Web_MailIssueForEmpPerformance]";
        public const string Proc_web_frm_mailIssueForPerformance_T_Web_MailingListForEmpPerformance = "[proc_web_frm_mailIssueForPerformance_T_Web_MailingListForEmpPerformance]";
        public const string Proc_web_frm_supervisor_insert_T_Web_Supervisor = "[proc_web_frm_supervisor_insert_T_Web_Supervisor]";
        public const string Proc_web_frm_Supervisor_Delete_Supservisor_By_empAutoId = "[proc_web_frm_Supervisor_Delete_Supservisor_By_empAutoId]";
        public const string Proc_web_frm_leaveApplication_select_supervisorForEmployee = "[proc_web_frm_leaveApplication_select_supervisorForEmployee]";
        public const string Proc_web_frm_leaveApplication_select_supervisorForEmployee_withSearch = "[proc_web_frm_leaveApplication_select_supervisorForEmployee_withSearch]";
        public const string Proc_web_frm_leaveApproval_select_status_by_supervisor = "[proc_web_frm_leaveApproval_select_status_by_supervisor]";
        public const string Proc_web_frm_leaveDeclineDetail_select_status_by_supervisor = "[proc_web_frm_leaveDeclineDetail_select_status_by_supervisor]";
        public const string Proc_web_frmRptLeaveStatus_AllInfo_OR_Single = "[proc_web_frmRptLeaveStatus_AllInfo_OR_Single]";
        public const string Proc_web_frm_feedBackForm_select_Opinion_By_FacilitiesAutoIdAndEmployee = "[proc_web_frm_feedBackForm_select_Opinion_By_FacilitiesAutoIdAndEmployee]";
        public const string Proc_web_frm_feedBackForm_delete_Opinion_By_EmployeeAndLetterIssue = "[proc_web_frm_feedBackForm_delete_Opinion_By_EmployeeAndLetterIssue]";
        public const string Proc_web_frm_mailingList_UN_PW_ResetPassowrd = "[proc_web_frm_mailingList_UN_PW_ResetPassowrd]";
        public const string Proc_web_frm_mailIssueForOwnPerformance_Update_UnsentEmployeeList = "[proc_web_frm_mailIssueForOwnPerformance_Update_UnsentEmployeeList]";
        public const string Proc_web_frm_LetterIssueForOwnPerformance_Select = "[proc_web_frm_LetterIssueForOwnPerformance_Select]";
        public const string Proc_frm_comingYearGoals_Select_PreviousData_GridView = "[proc_frm_comingYearGoals_Select_PreviousData_GridView]";
        public const string Proc_web_frm_employeePerformance_insert_pastYearGoals = "[proc_web_frm_employeePerformance_insert_pastYearGoals]";
        public const string Proc_Web_frmEmployeePerformance_Insert_comingYearGoals = "[proc_Web_frmEmployeePerformance_Insert_comingYearGoals]";
        public const string Proc_web_frm_employeePerformance_ratingDescription = "[proc_web_frm_employeePerformance_ratingDescription]";
        public const string Prco_web_frm_performanceByLeader_insert_T_Web_MailIssuedBySupervisorForEmpPerformance = "[prco_web_frm_performanceByLeader_insert_T_Web_MailIssuedBySupervisorForEmpPerformance]";
        public const string Proc_web_frm_performance_delete_empGradeBySupervisor = "[proc_web_frm_performance_delete_empGradeBySupervisor]";
        public const string Proc_web_frm_letterIssueForPerformance_Insert_T_Web_AppraisalNotification = "[proc_web_frm_letterIssueForPerformance_Insert_T_Web_AppraisalNotification]";
        public const string Proc_web_frm_performance_insert_customComments = "[proc_web_frm_performance_insert_customComments]";
        public const string Proc_frm_performance_Select_PreviousData_For_GridView_Comments = "[proc_frm_performance_Select_PreviousData_For_GridView_Comments]";
        public const string Proc_web_frm_performance_insert_RecommnendationType1 = "[proc_web_frm_performance_insert_RecommnendationType1]";
        public const string Proc_web_frm_performance_delete_RecommnendationType1 = "[proc_web_frm_performance_delete_RecommnendationType1]";
        public const string Proc_web_frm_performance_insert_RecommnendationType2 = "[proc_web_frm_performance_insert_RecommnendationType2]";
        public const string Proc_web_frm_performance_delete_RecommnendationType2 = "[proc_web_frm_performance_delete_RecommnendationType2]";
        public const string Proc_web_frm_finalRecommendation_select_Employee_FilledUpPerformance = "[proc_web_frm_finalRecommendation_select_Employee_FilledUpPerformance]";
        public const string Proc_web_frm_performance_Insert_ManagingDirectorApproval = "[proc_web_frm_performance_Insert_ManagingDirectorApproval]";
        public const string Proc_web_frm_performanceFinalRecommendation_Select_BasicSalary_By_EmpAutoId = "[proc_web_frm_performanceFinalRecommendation_Select_BasicSalary_By_EmpAutoId]";
        public const string Proc_web_frm_finalRecommendation_Insert = "[proc_web_frm_finalRecommendation_Insert]";
        public const string Proc_web_frm_finalRecommendation_Update = "[proc_web_frm_finalRecommendation_Update]";
        public const string Proc_web_frm_performance_ManagingDirectorDecision = "[proc_web_frm_performance_ManagingDirectorDecision]";
        public const string Proc_web_frm_empLastLeaveAppStatus_Select = "[proc_web_frm_empLastLeaveAppStatus_Select]";
        public const string Proc_web_frm_mailingList_select_Employee_MailAddress_For_Evaluation_SP = "[proc_web_frm_mailingList_select_Employee_MailAddress_For_Evaluation_SP]";

        //Employee Information Select ---------------Mannan---------------
        public const string Proc_web_frm_masterPage_select_EmployeeDeatils_By_EmployeeId = "[proc_web_frm_masterPage_select_EmployeeDeatils_By_EmployeeId]";
        public const string Proc_Web_Insert_UserLogBook = "[proc_Web_Insert_UserLogBook]";
        public const string Proc_frm_pastYearGoals_Select_PreviousData_GridView = "[proc_frm_pastYearGoals_Select_PreviousData_GridView]";

        //Employee Information Select ---------------Bulbul Vai---------------
        public const string Proc_web_selectForFrm_Performance_SkillsAssesment_For_Update = "[proc_web_selectForFrm_Performance_SkillsAssesment_For_Update]";
        public const string Proc_web_selectForFrm_Performance_SkillsAssesment_For_Update1 = "[proc_web_selectForFrm_Performance_SkillsAssesment_For_Update1]";


        //-----------------------------Razib------------------------------------
        public const string PROC_Select_Emp_Name_Email = "PROC_Select_Emp_Name_Email";
        public const string PROC_Select_Emp_Name_Email1 = "PROC_Select_Emp_Name_Email1";
        public const string proc_Insert_Update_Select_Independent_Tables5_GraphicPeople = "proc_Insert_Update_Select_Independent_Tables5_GraphicPeople";
        public const string Proc_SelectForfrm_Acknowledgement_Documents = "proc_selectForfrm_Acknowledgement_Documents";
        public const string PROC_Select_AcknowledgementDocuments = "PROC_Select_AcknowledgementDocuments";
        public const string Proc_selectForfrm_Acknowledgement_Documents1 = "proc_selectForfrm_Acknowledgement_Documents1";
        public const string Proc_Web_SelectForFrm_EmpPerformance = "proc_web_selectForFrm_empPerformance";
        public const string Proc_Delete_Any_Tables_With_Reference_Checking = "proc_Delete_Any_Tables_With_Reference_Checking";
        public const string Proc_SelectForfrm_Acknowledgement_Documents_By_acknowledgementInfo_autoId = "proc_selectForfrm_Acknowledgement_Documents_By_acknowledgementInfo_autoId";
        public const string Proc_Select_AcknowledgementInfo = "proc_select_acknowledgementInfo";
        public const string Proc_web_update_web_user = "proc_web_update_web_user";
        public const string Proc_frm_mailingList_voting_select_employee = "proc_frm_mailingList_voting_select_employee";
        public const string Proc_frm_mailingList_UN_PW_select_employee = "proc_frm_mailingList_UN_PW_select_employee";
        
        //--------------------12/12/2010---------------//
        public const string Proc_web_frm_TopicsEvents_T_Web_Topics_Update = "[proc_web_frm_TopicsEvents_T_Web_Topics_Update]";
        public const string Proc_web_frm_TopicsEvents_T_Web_Topics_Insert = "[proc_web_frm_TopicsEvents_T_Web_Topics_Insert]";

        public const string Proc_web_frm_TopicsEvents_T_Web_TopicOptions_Insert = "proc_web_frm_TopicsEvents_T_Web_TopicOptions_Insert";
        public const string Proc_web_frm_TopicsEvents_T_Web_TopicOptions_Update = "proc_web_frm_TopicsEvents_T_Web_TopicOptions_Update";

        public const string Proc_web_frm_TopicsEvents_T_Web_TopicOptions_Select = "[proc_web_frm_TopicsEvents_T_Web_TopicOptions_Select]";
        public const string Proc_web_frm_TopicsEvents_SelectOptions_T_Web_TopicOptions = "[proc_web_frm_TopicsEvents_SelectOptions_T_Web_TopicOptions]";
        public const string Proc_Web_TopicEvents_frm_TopicsVotingsByTopicID = "[proc_Web_TopicEvents_frm_TopicsVotingsByTopicID]";
        public const string Proc_web_TopicEvents_frm_TopicsVotings_selectByID = "[proc_web_TopicEvents_frm_TopicsVotings_selectByID]";
        public const string Proc_web_frm_TopicsEvents_T_Web_Topics_Select = "[proc_web_frm_TopicsEvents_T_Web_Topics_Select]";
        public const string Proc_Web_frm_topics_voting_Select_Count_Votes_Against_Topics = "[proc_Web_frm_topics_voting_Select_Count_Votes_Against_Topics]";
        public const string Proc_web_TopicsVoting_select_voting_By_empID_topicID = "[proc_web_TopicsVoting_select_voting_By_empID_topicID]";
        public const string Proc_Web_LetterIssue_For_Voting_Detail_Insert = "[proc_Web_LetterIssue_For_Voting_Detail_Insert]";
        public const string Proc_Web_LetterIssue_For_Voting_Insert = "[proc_Web_LetterIssue_For_Voting_Insert]";

        //----------------------Personal Information by Fahim Bhuyan---------------------------
        //public const string Proc_Frm_ContactInfo_select = "proc_Frm_ContactInfo_select";
        public const string Proc_frm_proceed_clearence_update_resign_final_release = "proc_frm_proceed_clearence_update_resign_final_release";
        public const string Proc_Frm_AcademicInfo_select_academicInfo = "proc_Frm_AcademicInfo_select_academicInfo";
        public const string proc_frm_Degree_insert_degreeInfo = "proc_frm_Degree_insert_degreeInfo";
        public const string Proc_Frm_ContactInfo_select_EmpNamewithAutoId = "proc_Frm_ContactInfo_select_EmpNamewithAutoId";
        public const string Proc_Frm_ContactInfo_select_initial_EmpNamewithAutoId = "proc_Frm_ContactInfo_select_initial_EmpNamewithAutoId";
        public const string Proc_Frm_AcademicInfo_select_personalInfo = "proc_Frm_AcademicInfo_select_personalInfo";
        public const string Proc_Frm_AcademicInfo_select_skill_info = "proc_Frm_AcademicInfo_select_skill_info";
        public const string Proc_Frm_ReferenceInfo_select_empRerferenceInfo = "proc_Frm_ReferenceInfo_select_empRerferenceInfo";
        public const string Proc_Frm_FinalRecommendationAndApproval_select_recommendationInfo = "proc_Frm_FinalRecommendationAndApproval_select_recommendationInfo";
        public const string Proc_Frm_LeaveApplication_select_serialNo = "proc_Frm_LeaveApplication_select_serialNo";
        //24-10-2010
        public const string Proc_web_frm_letterIssueForFeedBack_searchLetter = "proc_web_frm_letterIssueForFeedBack_searchLetter";
        public const string Proc_web_frm_LetterIssueForOwnPerformance_searchLetter = "proc_web_frm_LetterIssueForOwnPerformance_searchLetter";
        //07-11-2010
        public const string Proc_frmLeaveApplication_select_empLeaveInfo = "proc_frmLeaveApplication_select_empLeaveInfo";        
        public const string Proc_Insert_Update_Select_Independent_Tables6 = "proc_Insert_Update_Select_Independent_Tables6";
        public const string Proc_frmContactInfo_checkEmployeeContactInfo = "proc_frmContactInfo_checkEmployeeContactInfo";
        public const string Proc_Frm_WorkExpericenceInfo_select_ExperienceInfo = "proc_Frm_WorkExpericenceInfo_select_ExperienceInfo";
        public const string Proc_Frm_ReferenceInfo_select_empReferenceCheckQuestion = "proc_Frm_ReferenceInfo_select_empReferenceCheckQuestion";
        public const string Proc_referenceInfo_update_emp_referenceCheckInfo = "proc_referenceInfo_update_emp_referenceCheckInfo";
        public const string Proc_Frm_ReferenceInfo_select_empReferenceCheckQuestionWithSelectReferenceName = "proc_Frm_ReferenceInfo_select_empReferenceCheckQuestionWithSelectReferenceName";
        public const string Proc_Web_frm_login_Select_validUserCompanyInformation = "proc_Web_frm_login_Select_validUserCompanyInformation";
        public const string Proc_rpt_web_providentFund_selectEmpSupervisor = "proc_rpt_web_providentFund_selectEmpSupervisor";
        public const string Proc_web_frm_referenceInfo_updateReferenceCheckInfo = "proc_web_frm_referenceInfo_updateReferenceCheckInfo";
        public const string Proc_web_frmEmployeeDocument_Insert = "proc_web_frmEmployeeDocument_Insert";
        public const string Proc_web_frmEmployeeDocument_update = "proc_web_frmEmployeeDocument_update";
        public const string Proc_web_frmEmployeeDocument_Delete = "[proc_web_frmEmployeeDocument_Delete]";
        public const string Proc_Frm_professionalQualification_select_professionalQualification = "proc_Frm_professionalQualification_select_professionalQualification";
        public const string Proc_Frm_NomineeInformation_select_nomineeInformaiton = "proc_Frm_NomineeInformation_select_nomineeInformaiton";
        public const string Proc_frm_proceedCleareence_select_resigned_emp = "proc_frm_proceedCleareence_select_resigned_emp";
        public const string Proc_frm_proceedClearence_select_employee = "proc_frm_proceedClearence_select_employee";
        public const string Proc_frm_resign_clearence_insert_resign_clearence = "proc_frm_resign_clearence_insert_resign_clearence";
        public const string Proc_frm_resign_insert = "proc_frm_resign_insert";
        public const string Proc_frm_resignUpdate = "proc_frm_resignUpdate";
        public const string Proc_frm_resign_selectForGridview = "proc_frm_resign_selectForGridview";
        public const string Proc_frm_resignDelete = "proc_frm_resignDelete";
        public const string Proc_frm_resign_select_managerEmailInfo = "proc_frm_resign_select_managerEmailInfo";
        public const string Proc_frm_resign_selectEmpLoginInfo = "proc_frm_resign_selectEmpLoginInfo";
        public const string Proc_frm_resign_select_empInlevel2 = "proc_frm_resign_select_empInlevel2";
        public const string Proc_frm_resignApproval_insert = "proc_frm_resignApproval_insert";
        public const string Proc_frm_resignMailConfiguration_forGridView = "proc_frm_resignMailConfiguration_forGridView";
        public const string Proc_frm_resignMailConfiguration_delete = "proc_frm_resignMailConfiguration_delete";
        public const string Proc_frm_resignApproval_selectEmpResignInfo = "proc_frm_resignApproval_selectEmpResignInfo";
        public const string Proc_frm_resign_finish_pending_emp = "proc_frm_resign_finish_pending_emp";        
        public const string Proc_frm_proceedCleareence_select_resigned_emp_pending = "proc_frm_proceedCleareence_select_resigned_emp_pending";
        public const string Proc_frm_proceedClearence_select_employee_hr_logedOn = "proc_frm_proceedClearence_select_employee_hr_logedOn";
        public const string Proc_frm_proceedClearence_select_managerLogonInfo = "proc_frm_proceedClearence_select_managerLogonInfo";
        public const string Proc_frm_proceedClearence_select_departname_clearence = "proc_frm_proceedClearence_select_departname_clearence";
        public const string Proc_frm_Acknowledgement_checkIfRecieved = "proc_frm_Acknowledgement_checkIfRecieved";
        //-----------------------------SolyMan------------------------------------
        //--------Solyman-----11/10/2010--------
        public const string proc_web_selectForFrm_empRegionalResourceAllocation = "proc_web_selectForFrm_empRegionalResourceAllocation";
        public const string proc_web_selectForFrm_facilities = "proc_web_selectForFrm_facilities";
        public const string proc_web_selectForFrm_empPerformance = "proc_web_selectForFrm_empPerformance";
        public const string proc_Web_insertForFrmFacilities = "proc_Web_insertForFrmFacilities";
        public const string Proc_Web_insertForFrmFacilities_comingYear = "proc_Web_insertForFrmFacilities_comingYear";

        //--------Solyman-----12/10/2010--------
        public const string proc_web_selectForFrm_createAttribute = "proc_web_selectForFrm_createAttribute";

        //--------Solyman-----13/10/2010--------
        public const string Proc_web_DeleteForFrmPerformancComingYearGoals = "proc_web_DeleteForFrmPerformancComingYearGoals";
        public const string Proc_web_DeleteForFrmPerformancPastYearGoals = "proc_web_DeleteForFrmPerformancPastYearGoals";
        //--------Solyman-----14/10/2010--------
        public const string proc_web_selectForFrm_Performance_SkillsAssesment = "proc_web_selectForFrm_Performance_SkillsAssesment";
        public const string proc_Web_insertForFrmPerformance_SkillsAssesment = "proc_Web_insertForFrmPerformance_SkillsAssesment";
        public const string proc_Web_insertForFrmPerformance_SkillsAssesment1 = "[proc_Web_insertForFrmPerformance_SkillsAssesment1]";
        //public const string proc_Web_insertForFrmPerformance_SkillsAssesment = "proc_Web_insertForFrmPerformance_SkillsAssesment";
        public const string proc_web_DeleteForFrmPerformance_SkillAssesment = "proc_web_DeleteForFrmPerformance_SkillAssesment";
        public const string proc_web_frm_empLevelAssign_select_EmployeeListWithLevelAssingedList = "[proc_web_frm_empLevelAssign_select_EmployeeListWithLevelAssingedList]";
        //--------Solyman-----18/10/2010--------
        public const string Proc_web_selectForRecommendationType1 = "proc_web_selectForRecommendationType1";
        public const string Proc_web_selectForRecommendationType2 = "proc_web_selectForRecommendationType2";
        public const string Proc_Web_insertForFrmPerformance_recommendation = "proc_Web_insertForFrmPerformance_recommendation";
        public const string Proc_Web_insertForFrmPerformance_recommendation2 = "proc_Web_insertForFrmPerformance_recommendation2";
        public const string Proc_web_DeleteForFrmPerformance_Recommendation = "proc_web_DeleteForFrmPerformance_Recommendation";
        //--------Solyman-----24/10/2010--------
        public const string Proc_Web_selectForFrm_createSkills = "proc_Web_selectForFrm_createSkills";

        //------------22-11-2010-------------------//
        public const string proc_Frm_CommentsByDeptInCharge_Select_Comment = "proc_frm_CommentsByDeptInCharge_Select_Comment";
        public const string proc_web_DeleteForFrm_CommentsByDeptInCharge = "proc_web_DeleteForFrm_CommentsByDeptInCharge";

        //---------------24-11-2010-------------------//
        public const string Proc_SelectForfrm_Acknowledgement_Documents2 = "proc_selectForfrm_Acknowledgement_Documents2";
        public const string Proc_SelectForfrm_Acknowledgement_Documents_By_acknowledgementDocumentsInfo_autoId = "proc_selectForfrm_Acknowledgement_Documents_By_acknowledgementDocumentsInfo_autoId";
        //--------------24-11-2010-----------------//
        public const string Proc_SelectForfrm_select_web_confirmation = "proc_selectForfrm_select_web_confirmation";
        //--------------29-11-2010-------------------//
        public const string Proc_T_Web_AttributesRaitings_By_Select_Count = "proc_T_Web_AttributesRaitings_By_Select_Count";
        public const string Proc_T_Web_AcknowledgementInfo_By_Select_EmpID = "proc_T_Web_AcknowledgementInfo_By_Select_EmpID";
        
        //---------------02/12/2010---------------------//
        public const string Proc_Forfrm_T_Web_Login_By_SelectEmpID = "proc_Forfrm_T_Web_Login_By_SelectEmpID";
        public const string Proc_frm_WebNominee_deleteNomineeInformation = "proc_frm_WebNominee_deleteNomineeInformation";

       
        public const string Proc_frm_rpt_topic_report_select = "proc_frm_rpt_topic_report_select";
        public const string Proc_frm_rpt_topic_report_select_optionInfo = "proc_frm_rpt_topic_report_select_optionInfo";

        public const string Proc_web_frm_department_mail_configuration = "proc_web_frm_department_mail_configuration";

        public const string Proc_web_frm_department_mail_configuration_select_autoId = "proc_web_frm_department_mail_configuration_select_autoId";
        public const string Proc_web_frm_mailConfiguration_select_hr_emp_name = "proc_web_frm_mailConfiguration_select_hr_emp_name";
        public const string Proc_web_frm_department_mail_configuration_insert = "proc_web_frm_department_mail_configuration_insert";
        public const string Proc_Web_frm_resignApproval_select_emp_emailList = "proc_Web_frm_resignApproval_select_emp_emailList";

        public const string Proc_web_frm_createAttributes_SelectAttirbutesByGroup = "proc_web_frm_createAttributes_SelectAttirbutesByGroup";

        public const string Proc_web_frm_hrComments_Insert_Update = "[Proc_web_frm_hrComments_Insert_Update]";
        public const string Proc_web_frm_hrComments_Delete = "[Proc_web_frm_hrComments_Delete]";
        public const string Proc_web_frm_hrComments_Select = "[Proc_web_frm_hrComments_Select]";

        public const string Proc_web_frm_performanceAsReport_select = "[proc_web_frm_performanceAsReport_select]";

        public const string Proc_web_frm_finalRecommendation_select_Employee_Supervisors = "[proc_web_frm_finalRecommendation_select_Employee_Supervisors]";

        public const string Proc_hr_frm_PollEmployee_save_update_delete = "proc_hr_frm_PollEmployee_save_update_delete";
        public const string Proc_web_frm_Poll_Employee_select = "proc_web_frm_Poll_Employee_select";
        public const string Proc_web_frm_poll_employee_select_all_employee_by_company = "proc_web_frm_poll_employee_select_all_employee_by_company";
    }
    public class Report
    {
        private Report() { }
        public const string Proc_web_rpt_frm_performance_customComments = "proc_web_rpt_frm_performance_customComments";
        public const string Proc_web_rpt_frm_performance_skillAssessment_Emp = "proc_web_rpt_frm_performance_skillAssessment_Emp";
        public const string Proc_rpt_web_selectForFrm_empRegionalResourceAllocation1 = "proc_rpt_web_selectForFrm_empRegionalResourceAllocation1";
        public const string proc_webRpt_voteForTopics_DateWise = "proc_webRpt_voteForTopics_DateWise";
        public const string Proc_RptGeneralLedger = "proc_RptGeneralLedger";
        public const string Proc_rpt_leadger_view_select_opening_balance_autoId = "proc_rpt_leadger_view_select_opening_balance_autoId";
        public const string Proc_rpt_web_selectForFrm_empRegionalResourceAllocation = "proc_rpt_web_selectForFrm_empRegionalResourceAllocation";
        public const string Rpt_proc_web_frm_mailingList_select_Employee_MailAddress_For_Evaluation = "rpt_proc_web_frm_mailingList_select_Employee_MailAddress_For_Evaluation ";
        public const string Proc_web_rpt_employeeLeaveInfoFinallyApproved = "proc_web_rpt_employeeLeaveInfoFinallyApproved";
        public const string Proc_web_rpt_employeeLeaveInfoDeclinedOrApproved = "proc_web_rpt_employeeLeaveInfoDeclinedOrApproved";
        public const string Proc_RptPersonal_Info_HTML = "proc_RptPersonal_Info_HTML";
        public const string Proc_RptContact = "proc_RptContact";
        public const string Proc_RptAcademicInfo = "proc_RptAcademicInfo";
        public const string Proc_RptReference = "proc_RptReference";
        public const string Proc_RptWorkExperience = "proc_RptWorkExperience";
        public const string Proc_web_RptContact = "proc_web_RptContact";
        public const string Proc_web_RptPersonal_Info_HTML = "proc_web_RptPersonal_Info_HTML";
        public const string Proc_webRpt_voteForTopics = "proc_webRpt_voteForTopics";
        public const string Proc_web_Rpt_ProfessionalQualification1 = "proc_web_Rpt_ProfessionalQualification1";
        public const string Proc_web_rptNomineeInformation = "proc_web_rptNomineeInformation";
        public const string Proc_web_rpt_FeedBack_by_emp = "proc_web_rpt_FeedBack_by_emp";
        public const string Proc_web_Voting_Result = "proc_web_Voting_Result";
        public const string Proc_Web_Employee_Satisfaction_Feedback = "proc_Web_Employee_Satisfaction_Feedback";
        public const string Proc_Web_Employee_Satisfaction_Feedback_Summary = "proc_Web_Employee_Satisfaction_Feedback_Summary";
        public const string Proc_web_rpt_frm_performance_KPI = "Proc_web_rpt_frm_performance_KPI";
        public const string Proc_web_rpt_frm_performance_hrComments = "[proc_web_rpt_frm_performance_hrComments]";
        public const string Proc_web_rpt_frm_performance_skillAssessment_Emp_Sup1 = "[proc_web_rpt_frm_performance_skillAssessment_Emp_Sup1]";
        public const string Proc_frm_resign_termination_select = "proc_frm_resign_termination_select";
        public const string Proc_Web_Graph_By_Feedback = "Proc_Web_Graph_By_Feedback";
    }
}
