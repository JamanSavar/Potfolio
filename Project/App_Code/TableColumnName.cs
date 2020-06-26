using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TableColumnName
/// </summary>
public class TableColumnName
{
    #region Repeated Table Field
    public const string Id = "id";
    public const string AutoId = "autoId";
    public const string ReferenceValue = "referenceValue";
    public const string ReferenceId = "referenceId";
    public const string Company_autoId = "companyAutoId";
    public const string Company_Id = "Company_Id";
    public const string Company_autoId1 = "company_autoId";
    public const string Edited = "edited";
    public const string Exported = "exported";
    public const string InsertDate = "insertDate";
    public const string UserLogBook_autoId = "userLogBook_autoId";
    public const string EmpDivision = "empDivision";
    #endregion
    private TableColumnName()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region T_Acc_ChartOfAccounts Table Column Names
    public class T_Acc_ChartOfAccounts
    {
        /// <summary>
        /// Created By: Md. Jahirul Islam
        /// Creation Date:25/06/2010
        /// Last Modification Date: 
        /// Modified By:
        /// 
        /// 
        /// Form Name: frm_ledgerInfo.aspx
        /// Dependent Table: T_Acc_Ledger,T_Acc_Cost_Center_Branch_Allocation,T_Acc_Opening_Balance
        /// </summary>
        /// 
        private T_Acc_ChartOfAccounts() { }
        public const string TableName = "T_Acc_Chart_Of_Accounts";
        public const string Id = "Id";
        public const string AutoID = "autoId";
        public const string ParentKey = "parentKey";
        public const string NodeKey = "nodeKey";
        public const string AccountHead = "accountHead";
        public const string Level = "level";
        public const string SubHead = "subHead";
        public const string CreationDate = "creationDate";
        public const string LedgerAutoId = "ledgerAutoId";
        public const string OpeningBalanceAutoId = "openingBalanceAutoId";
        public static string[] DependentTable = new string[] {T_Acc_Ledger.TableName,T_Acc_Ledger.ChartOfAccountAutoId,
                                                       T_Acc_Cost_Center_Branch_Allocation.TableName,T_Acc_Cost_Center_Branch_Allocation.ChartOfAccountsAutoId,
                                                       T_Acc_Opening_Balance.TableName,T_Acc_Opening_Balance.ChartOfAccounts_autoId};


        //public const string ReferenceValue = "referenceValue";
        //public const string ReferenceId = "referenceId";
        //public const string Company_autoId = "company_autoId";
        //public const string Edited = "edited";
        //public const string Exported = "exported";

    }
    #endregion
    #region T_Acc_LedgerTable Column Name

    public class T_Acc_Ledger
    {
        private T_Acc_Ledger() { }
        public const string AutoId = "autoId";
        public const string ChartOfAccountAutoId = "chartOfAccounts_autoId";
        public const string TableName = "T_Acc_Leadger";
        //public const string Name = "name";
        public const string Alias = "alias";
        public const string BillWise = "billWise";
        public const string CreditLimit = "creditLimit";
        public const string MultiCurrency = "multiCurrency";
        public const string OpeningBalance = "openingBalance";
        public const string AccountHead = "accountHead";
        //public const string Rate = "rate";
        //public const string Installment = "installment";
        //public const string Advance = "advance";
        public const string MailingAddress = "mailingAddress";
        public const string Address = "address";
        public const string Phone = "phone";
        public const string Fax = "fax";
        public const string Mobile = "mobile";
        public const string Email = "email";
        public const string City = "city";
        public const string Zip = "zip";
        public const string Currency_autoId = "currency_autoId";

        public const string CostCenter = "costCenter";
        public const string GrossProfit = "grossProfit";
        public const string Branch = "branch";
        public const string CashFlowType = "cashFlowType";
    }
    #endregion
    #region T_Acc_Journal_Info Table Column Names
    public class T_Acc_Journal_Info
    {

        /// <summary>
        /// Created By: Md. Jahirul Islam
        /// Creation Date:15/07/2010
        /// Last Modification Date: 
        /// Modified By:
        /// 
        /// 
        /// Form Name: 
        /// Dependent Table:
        /// </summary>
        /// 
        private T_Acc_Journal_Info() { }
        public const string AutoId = "autoId";
        public const string TableName = "T_Acc_Journal_Info";
        public const string VoId = "voId";
        public const string VoucherNo = "voucherNo";
        public const string Narration = "narration";
        public const string ChequeNo = "chequeNo";
        public const string TransactionDate = "transactionDate";
        public const string Post = "post";
        public const string VoucherType_autoId = "voucherType_autoId";
        public const string Prefix = "prefix";
        public const string Suffix = "suffix";
        public const string DummyVoNo = "dummyVoNo";
        public const string ChequeDate = "chequeDate";
    }
    #endregion
    #region T_Acc_Journal_Entries_Bill_Wise Table Column Names
    public class


        T_Acc_Journal_Entries_Bill_Wise
    {

        /// <summary>
        /// Created By: Md. Jahirul Islam
        /// Creation Date:15/07/2010
        /// Last Modification Date: 
        /// Modified By:
        /// 
        /// 
        /// Form Name: 
        /// Dependent Table:
        /// </summary>
        /// 
        private T_Acc_Journal_Entries_Bill_Wise() { }
        public const string AutoId = "autoId";
        public const string TableName = "T_Acc_Journal_Entries_Bill_Wise";
        public const string JournalEntries_autoId = "journalEntries_autoId";
        public const string OpeningBalance_autoId = "openingBalance_autoId";
        public const string Date = "date";
        public const string ReferenceType = "referenceType";
        public const string ReferenceNumber = "referenceNumber";
        public const string Amount = "amount";
        public const string Own_autoId = "own_autoId";
        public const string ReferenceValue = "referenceValue";
        public const string IsLock = "Lock";

        public const string Currency_autoId = "currency_autoId";
        public const string ExchangeRate = "exchangeRate";
        public const string Currency_amount = "currency_amount";
    }
    #endregion
    #region T_Acc_Journal_Entries Table Column Names
    public class T_Acc_Journal_Entries
    {

        /// <summary>
        /// Created By: Md. Jahirul Islam
        /// Creation Date:15/07/2010
        /// Last Modification Date: 
        /// Modified By:
        /// 
        /// 
        /// Form Name: 
        /// Dependent Table:
        /// </summary>
        /// 
        private T_Acc_Journal_Entries() { }
        public const string AutoId = "autoId";
        public const string TableName = "T_Acc_Journal_Entries";
        public const string JournalInfo_autoId = "journalInfo_autoId";
        public const string OpeningBalance_autoId = "openingBalance_autoId";
        public const string TransactionType = "transactionType";
        public const string DebitAmount = "debitAmount";
        public const string CreditAmount = "creditAmount";
        public const string Description = "description";
        public const string Currency_autoId = "currency_autoId";
        public const string ExchangeRate = "exchangeRate";
        public const string CurrencyAmount = "currencyAmount";
    }
    #endregion
    #region T_Acc_Opening_Balance Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:25/06/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_ledgerInfo.aspx
    /// Dependent Table : T_Acc_Journal_Entries, T_Acc_Journal_Entries_Bill_Wise, T_Acc_UsingLedger_InJournalEntries
    /// </summary>


    public class T_Acc_Opening_Balance
    {
        private T_Acc_Opening_Balance() { }
        public const string TableName = "T_Acc_Opening_Balance";
        public const string Id = "Id";
        public const string AutoId = "autoId";
        public const string ChartOfAccounts_autoId = "chartOfAccounts_autoId";
        public const string OpeningBalance = "openingBalance";
        public const string TransactionType = "transactionType";
        public const string CostCenter_autoId = "costCenter_autoId";
        public const string Branch_autoId = "branch_autoId";
        public const string Status = "status";
        public const string TransactionDate = "transactionDate";
        //public const string InsertDate = "insertDate";
        //public const string UserLogBook_autoId = "userLogBook_autoId";
        //public const string Address = "address";
        //public const string Phone = "phone";
        //public const string Fax = "fax";
        //public const string Mobile = "mobile";
        //public const string Email = "email";
        //public const string City = "city";
        //public const string Zip = "zip";
    }
    #endregion
    #region T_Acc_Journal_Entries_Cost_Center Table Column Names
    public class T_Acc_Journal_Entries_Cost_Center
    {

        /// <summary>
        /// Created By: Md. Jahirul Islam
        /// Creation Date:15/07/2010
        /// Last Modification Date: 
        /// Modified By:
        /// 
        /// 
        /// Form Name: 
        /// Dependent Table:
        /// </summary>
        /// 
        private T_Acc_Journal_Entries_Cost_Center() { }
        public const string AutoId = "autoId";
        public const string TableName = "T_Acc_Journal_Entries_Cost_Center";
        public const string JournalEntries_autoId = "journalEntries_autoId";
        public const string CostCenter_autoId = "costCenter_autoId";
        public const string Amount = "amount";
        public const string Currency_autoId = "currency_autoId";
        public const string ExchangeRate = "exchangeRate";
        public const string Currency_amount = "currency_amount";
    }
    #endregion
    #region T_Acc_Cost_Center Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:25/06/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_costCenterTreeView.aspx
    /// Dependent Table:T_Acc_Cost_Center_Branch_Allocation
    /// </summary>
    public class T_Acc_Cost_Center
    {
        private T_Acc_Cost_Center() { }
        public const string TableName = "T_Acc_Cost_Center";
        public const string Id = "Id";
        public const string AutoID = "autoId";
        public const string ParentKey = "parentKey";
        public const string NodeKey = "nodeKey";
        public const string AccountHead = "costCenter";
        public const string Level = "level";
        public const string SubHead = "subHead";
        public const string CreationDate = "creationDate";

        public const string ReferenceValue = "referenceValue";
        public const string ReferenceId = "referenceId";
        public const string Company_autoId = "company_autoId";
        public const string Edited = "edited";
        public const string Exported = "exported";

    }
    #endregion
    #region T_Acc_Branch Column Name

    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:25/06/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_branchTreeView.aspx
    /// Dependent Table:T_Acc_Cost_Center_Branch_Allocation
    /// </summary>
    public class T_Acc_Branch
    {
        private T_Acc_Branch() { }
        public const string TableName = "T_Acc_Branch";
        public const string Id = "Id";
        public const string AutoID = "autoId";
        public const string ParentKey = "parentKey";
        public const string NodeKey = "nodeKey";
        public const string AccountHead = "branch";
        public const string Level = "level";
        public const string SubHead = "subHead";
        public const string CreationDate = "creationDate";

        public const string ReferenceValue = "referenceValue";
        public const string ReferenceId = "referenceId";
        public const string Company_autoId = "company_autoId";
        public const string Edited = "edited";
        public const string Exported = "exported";

    }
    #endregion
    #region T_Com_Company Column Name
    public class T_Com_Company
    {
        private T_Com_Company() { }
        public const string TableName = "T_Com_Company";
        public const string AutoId = "autoId";
        public const string CompanyName = "companyName";
        public const string CompanyCode = "companyCode";
        public const string Address = "address";
        public const string City = "city";
        public const string Zip = "zip";
        public const string Country = "country";
        public const string Fax = "fax";
        public const string OtherNo = "otherNo";
        public const string EMail = "eMail";
        public const string FinancialYearFrom = "financialYearFrom";
        public const string FinancialYearTo = "financialYearTo";
        public const string Remarks = "remarks";
        public const string ReferenceValue = "referenceValue";
        public const string DefaultCurrency = "currency_autoId";
    }

    #endregion
    #region T_Acc_Standard_Voucher_Type
    /// <summary>
    /// Reference Table: "T_Acc_Voucher_Configuration"
    /// </summary>
    public class
        T_Acc_Standard_Voucher_Type
    {
        private T_Acc_Standard_Voucher_Type() { }
        public const string TableName = "T_Acc_Standard_Voucher_Type";
        public const string AutoID = "autoId";
        public const string OwnAutoId = "own_autoId";
        public const string StandardVoucherType = "standardVoucherType";
        public const string VoucherType = "voucherType";
        public const string VoucherName = "voucherName";
        public const string ReferenceValue = "referenceValue";
        public const string InsertBy = "insertBy";
    }

    #endregion
    #region T_Acc_Exchange_Rate Column Name
    /// <summary>
    /// Created By: Md.Ziaur Rahman Khan    
    /// Creation Date:15/06/2010
    /// Last Modification Date: 20/06/2010
    /// Modified By:Md.Ziaur Rahman Khan  
    /// 
    /// 
    /// Form Name: Currency Exchange Rate
    /// Dependent Table:
    /// </summary>
    public class T_Acc_Exchange_Rate
    {
        private T_Acc_Exchange_Rate() { }
        public const string TableName = "T_Acc_Exchange_Rate";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string CurrencyAutoId = "currency_autoId";
        public const string CompanyCurrencyAutoId = "companyCurrency_autoId";
        public const string StandardRate = "standardRate";
        public const string SellRate = "sellRate";
        public const string BuyRate = "buyRate";
        //public const string ReferenceValue = "referenceValue";
        //public const string ReferenceId = "referenceId";
        //public const string  Edited = "edited";
        //public const string Exported = "exported";
        //public const string InsertDate = "insertDate";
        //public const string userLogBook_autoId = "useLogBook_autoId";
        public const string Company_autoId = "company_autoId";
    }
    #endregion
    #region T_Acc_Currency Column Name

    ///<summary>
    /// Created By: Md.Ziaur Rahman Khan    
    /// Creation Date:15/06/2010
    /// Last Modification Date: 20/06/2010
    /// Modified By:Md.Ziaur Rahman Khan  
    /// 
    /// 
    /// Form Name: Currency
    /// Dependent Table:T_Acc_Exchange_Rate,T_Com_Company
    /// </summary>
    public class T_Acc_Currency
    {
        private T_Acc_Currency() { }
        public const string TableName = "T_Acc_Currency";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string Currency = "currency";
        public const string Symbol = "symbol";
        //public const string ReferenceValue = "referenceValue";
        //public const string ReferenceId = "referenceId";
        //public const string Edited = "edited";
        //public const string Exported = "exported";
        //public const string InsertDate = "insertDate";
        //public const string userLogBook_autoId = "useLogBook_autoId";
        //public const string Company_autoId = "company_autoId";
    }
    #endregion
    #region T_Acc_Voucher_Type
    public class T_Acc_Voucher_Type
    {
        private T_Acc_Voucher_Type()
        {

        }

        public const string TableName = "T_Acc_Voucher_Type";
        public const string AutoID = "autoId";
        public const string VoucherType = "voucherType";
        public const string VoucherName = "voucherName";
        public const string Code = "code";
        public const string ReferenceValue = "referenceValue";

    }

    #endregion
    #region T_Com_Duration_Type

    public class T_Com_Duration_Type
    {
        private T_Com_Duration_Type() { }
        public const string TableName = "T_Com_Duration_Type";
        public const string AutoID = "autoId";
        public const string Duration_Type = "durationType";
    }

    #endregion
    #region T_Voucher_Configuration
    /// <summary>
    /// 
    /// </summary>

    public class T_Acc_Voucher_Configuration
    {
        private T_Acc_Voucher_Configuration()
        {

        }

        public const string TableName = "T_Acc_Voucher_Configuration";
        public const string AutoID = "autoId";
        public const string StandardVoucherType_AutoId = "standardVoucherType_autoId";
        public const string Numbering_Method = "numberingMethod";
        public const string Starting_Number = "startingNumber";
        public const string ResetDurationType_AutoId = "resetDurationType_autoId";
        public const string Reset_Duration = "resetDuration";
        public const string Reset_Duration_Type = "resetDurationType";
        public const string Prefix = "prefix";
        public const string Sufix = "suffix";
        public const string Padding = "padding";
    }
    #endregion
    #region T_Acc_Cost_Center_Branch_Allocation Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:25/06/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_ledgerInfo.aspx
    /// Dependent Table:
    /// </summary>
    public class T_Acc_Cost_Center_Branch_Allocation
    {
        private T_Acc_Cost_Center_Branch_Allocation() { }
        public const string TableName = "T_Acc_Cost_Center_Branch_Allocation";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string BranchAutoId = "branch_autoId";
        public const string CostCenterAutoId = "costCenter_auotId";
        public const string Amount = "amount";
        public const string ChartOfAccountsAutoId = "chartOfAccounts_autoId";
    }
    #endregion
    #region T_Com_Form_Name Table Column Names
    public class T_Com_Form_Name
    {
        /// <summary>
        /// Created By: Dewan Razib Hasan
        /// Creation Date:29/06/2010
        /// Last Modification Date: 
        /// Modified By:
        /// 
        /// 
        /// Form Name: frm_FormName.aspx
        /// Dependent Table: T_Com_User_Group_Permission, T_Com_User_Permission
        /// </summary>
        /// 
        private T_Com_Form_Name() { }
        public const string TableName = "T_Com_Form_Name";
        public const string Id = "id";
        public const string AutoID = "autoId";
        public const string FormName = "formName";
        public const string MenuLebel = "menuLebel";
        public const string ModuleName_autoId = "moduleName_autoId";
        public const string Visible = "visible";
    }
    #endregion
    #region T_Com_Module_Name Table Column Names

    public class T_Com_Module_Name
    {
        /// <summary>
        /// Created By: Dewan Razib Hasan
        /// Creation Date:29/06/2010
        /// Last Modification Date: 
        /// Modified By:
        /// 
        /// 
        /// Form Name: frm_ModuleName.aspx
        /// Dependent Table: T_Com_Form_Name, T_Com_User_Group_Permission
        /// </summary>
        /// 
        private T_Com_Module_Name() { }
        public const string TableName = "T_Com_Module_Name";
        public const string Id = "id";
        public const string AutoID = "autoId";
        public const string ModuleName = "moduleName";
        public const string Visible = "visible";
    }
    #endregion
    #region T_Com_User Table Column Names

    public class T_Com_User
    {
        /// <summary>
        /// Created By: Dewan Razib Hasan
        /// Creation Date:29/06/2010
        /// Last Modification Date: 
        /// Modified By:
        /// 
        /// 
        /// Form Name: frm_User.aspx
        /// Dependent Table: T_Com_User_Permission
        /// </summary>
        /// 
        private T_Com_User() { }
        public const string TableName = "T_Com_User";
        public const string Id = "id";
        public const string AutoID = "autoId";
        public const string UserGroup_autoId = "userGroup_autoId";
        public const string UserName = "userName";
        public const string Password = "password";
        public const string Visible = "visible";
        public const string Active = "active";
        public const string AllCompanyPermission = "allCompanyPermission";
    }
    #endregion
    #region T_Com_User_Group_Name Table Column Names
    public class T_Com_User_Group_Name
    {
        /// <summary>
        /// Created By: Dewan Razib Hasan
        /// Creation Date:29/06/2010
        /// Last Modification Date: 
        /// Modified By:
        /// 
        /// 
        /// Form Name: frm_UserGroupName.aspx
        /// Dependent Table: T_Com_User, T_Com_User_Group_Permission
        /// </summary>
        /// 
        private T_Com_User_Group_Name() { }
        public const string TableName = "T_Com_User_Group_Name";
        public const string Id = "id";
        public const string AutoID = "autoId";
        public const string UserGroupName = "userGroupName";
        public const string SystemAdmin = "systemAdmin";
    }
    #endregion
    #region T_Com_User_Group_Permission Table Column Names
    public class T_Com_User_Group_Permission
    {
        /// <summary>
        /// Created By: Dewan Razib Hasan
        /// Creation Date:29/06/2010
        /// Last Modification Date: 
        /// Modified By:
        /// 
        /// 
        /// Form Name: frm_UserGroupPermision.aspx
        /// Dependent Table: 
        /// </summary>
        /// 
        private T_Com_User_Group_Permission() { }
        public const string TableName = "T_Com_User_Group_Permission";
        public const string Id = "id";
        public const string AutoID = "autoId";
        public const string UserGroup_autoId = "userGroup_autoId";
        public const string FormName_autoId = "formName_autoId";
        public const string ModuleName_autoId = "moduleName_autoId";
        public const string Visible = "visible";
        public const string Access = "access";
        public const string Insert = "insert";
        public const string Update = "update";
        public const string Delete = "delete";
    }
    #endregion
    #region T_Com_User_Permission Table Column Names
    public class T_Com_User_Permission
    {
        /// <summary>
        /// Created By: Dewan Razib Hasan
        /// Creation Date:29/06/2010
        /// Last Modification Date: 
        /// Modified By:
        /// 
        /// 
        /// Form Name: frm_UserPermision.aspx
        /// Dependent Table: 
        /// </summary>
        /// 
        private T_Com_User_Permission() { }
        public const string TableName = "T_Com_User_Permission";
        public const string Id = "id";
        public const string AutoID = "autoId";
        public const string User_autoId = "user_autoId";
        public const string FormName_autoId = "formName_autoId";
        public const string Visible = "visible";
        public const string Access = "access";
        public const string Insert = "insert";
        public const string Update = "update";
        public const string Delete = "delete";
    }
    #endregion
    #region T_Com_UserLog_Book Table Column Names
    public class T_Com_UserLog_Book
    {

        /// <summary>
        /// Created By: Dewan Razib Hasan
        /// Creation Date:29/06/2010
        /// Last Modification Date: 
        /// Modified By:
        /// 
        /// 
        /// Form Name: 
        /// Dependent Table: T_Com_Form_Name, T_Com_Module_Name, T_Com_User, T_Com_User_Group_Permission
        ///                  T_Com_User_Group_Name, T_Com_User_Permission
        /// </summary>
        /// 
        private T_Com_UserLog_Book() { }
        public const string TableName = "T_Com_UserLog_Book";
        public const string Id = "id";
        public const string AutoID = "autoId";
        public const string User_autoId = "user_autoId";
        public const string InTime = "inTime";
        public const string InDate = "inDate";
        public const string OutTime = "outTime";
        public const string Outdate = "outdate";
    }
    #endregion
    #region T_Acc_UsingLedger_InJournalEntries Table Column
    public class T_Acc_UsingLedger_InJournalEntries
    {

        /// <summary>
        /// Created By: Dewan Razib Hasan
        /// Creation Date:08/05/2010
        /// Last Modification Date: 
        /// Modified By:
        /// 
        /// 
        /// Form Name: frm_ledgerHeadAllocation.aspx
        /// Dependent Table: T_Acc_Standard_Voucher_Type, T_Acc_Chart_Of_Accounts, T_Acc_Opening_Balance
        ///                 
        /// </summary>
        /// 
        private T_Acc_UsingLedger_InJournalEntries() { }

        public const string TableName = "T_Acc_UsingLedger_InJournalEntries";
        public const string Id = "id";
        public const string AutoID = "autoId";
        public const string StandardVoucherType_AutoId = "standardVoucherType_autoId";
        public const string OpeningBalance_AutoId = "openingBalance_autoId";
    }
    #endregion
    #region Tbl_IncomeExpenditure Table Column
    public class Tbl_IncomeExpenditure
    {

        /// <summary>
        /// Created By: Dewan Razib Hasan
        /// Creation Date:08/05/2010
        /// Last Modification Date: 
        /// Modified By:
        /// 
        /// 
        /// Form Name: frm_ledgerHeadAllocation.aspx
        /// Dependent Table: T_Acc_Standard_Voucher_Type, T_Acc_Chart_Of_Accounts, T_Acc_Opening_Balance
        ///                 
        /// </summary>
        /// 
        private Tbl_IncomeExpenditure() { }

        public const string TableName = "Tbl_IncomeExpenditure";
    }
    #endregion
    #region Tbl_BalanceSheet Table Column
    public class Tbl_BalanceSheet
    {

        /// <summary>
        /// Created By: Dewan Razib Hasan
        /// Creation Date:08/05/2010
        /// Last Modification Date: 
        /// Modified By:
        /// 
        /// 
        /// Form Name: frm_ledgerHeadAllocation.aspx
        /// Dependent Table: T_Acc_Standard_Voucher_Type, T_Acc_Chart_Of_Accounts, T_Acc_Opening_Balance
        ///                 
        /// </summary>
        /// 
        private Tbl_BalanceSheet() { }

        public const string TableName = "Tbl_BalanceSheet";
    }
    #endregion
    #region T_Com_Company_Group_Name Column Name
    public class T_Com_Company_Group_Name
    {
        private T_Com_Company_Group_Name() { }
        public const string TableName = "T_Com_Company_Group_Name";
        public const string GroupName = "groupName";
        public const string GroupDescription = "groupDescription";
        public const string GroupAddress = "groupAddress";
    }

    #endregion
    #region T_Com_Company_Group_Name_Details Column Name
    public class T_Com_Company_Group_Name_Details
    {
        private T_Com_Company_Group_Name_Details() { }
        public const string TableName = "T_Com_Company_Group_Name_Details";
        public const string CompanyGroup_autoId = "companyGroup_autoId";
    }

    #endregion
    #region T_Acc_LoanInfo Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:03/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>


    public class T_Acc_LoanInfo
    {
        private T_Acc_LoanInfo() { }
        public const string TableName = "T_Acc_LoanInfo";
        public const string LoanId = "loanId";
        public const string OpeningBalance_autoId = "openingBalance_autoId";

        public const string IssueDate = "issueDate";
        public const string Purpose = "purpose";
        public const string LoanAmount = "loanAmount";
        public const string InterestRate = "interestRate";
        public const string TotalInterest = "totalInterest";

        public const string InstallmentAmount = "installmentAmount";
        public const string NoOfInstallment = "noOfInstallment";
        public const string InstallmentStartDate = "installmentStartDate";
        public const string Comment = "comment";
        public const string LoanType = "loanType";
        //public const string Fax = "fax";
        //public const string Mobile = "mobile";
        //public const string Email = "email";
        //public const string City = "city";
        //public const string Zip = "zip";
    }
    #endregion
    #region T_Item_Configuration Table Column
    public class T_Item_Configuration
    {

        /// <summary>
        /// Created By: Dewan Razib Hasan
        /// Creation Date:08/05/2010
        /// Last Modification Date: 
        /// Modified By:
        /// 
        /// 
        /// Form Name: frm_ledgerHeadAllocation.aspx
        /// Dependent Table: T_Acc_Standard_Voucher_Type, T_Acc_Chart_Of_Accounts, T_Acc_Opening_Balance
        ///                 
        /// </summary>
        /// 
        private T_Item_Configuration() { }

        public const string TableName = "T_Item_Configuration";
        public const string Id = "id";
        public const string AutoID = "autoId";
        public const string ActualName = "actualName";
        public const string VisibleName = "visibleName";
        public const string Type = "type";
        public const string Visible = "visible";
        public const string Active = "active";
        public const string SerialNo = "serialNo";
    }
    #endregion
    #region T_Com_FlotingMenu3

    public class T_Com_FlotingMenu3
    {
        private T_Com_FlotingMenu3() { }
        public const string TableName = "T_Com_FlotingMenu";
        public const string AutoID = "autoId";
        public const string FormName = "formName";
        public const string LabelName = "labelName";
        public const string KeyShortKut = "keyShortKut";
        public const string FormInex = "formInex";
        public const string LormName = "labelIndex";
        public const string LoginTableFieldName = "loginTableFieldName";
        public const string NextFormIndex = "nextFormIndex";
        public const string PreviousFormIndex = "previousFormIndex";
        public const string NodeKey = "nodeKey";
        public const string ParentKey = "parentKey";
    }

    #endregion
    #region T_Com_FloatingMenu Table Column Names
    public class T_Com_FloatingMenu
    {
        /// <summary>
        /// Created By: Md. Jahirul Islam
        /// Creation Date:25/06/2010
        /// Last Modification Date: 
        /// Modified By:
        /// 
        /// 
        /// Form Name: frm_ledgerInfo.aspx
        /// Dependent Table: T_Acc_Ledger,T_Acc_Cost_Center_Branch_Allocation,T_Acc_Opening_Balance
        /// </summary>
        /// 
        private T_Com_FloatingMenu() { }
        public const string TableName = "T_Com_FloatingMenu";
        public const string Id = "Id";
        public const string AutoID = "autoId";
        public const string ParentKey = "parentKey";
        public const string NodeKey = "nodeKey";
        public const string MenuLabel = "menuLabel";
        public const string URL = "url";
        public const string Level = "level";
        public const string SubHead = "subHead";
        public const string CreationDate = "creationDate";
        public const string LedgerAutoId = "ledgerAutoId";
        public const string OpeningBalanceAutoId = "openingBalanceAutoId";
        public const string FormName = "formName";
        public static string[] DependentTable = new string[] {T_Acc_Ledger.TableName,T_Acc_Ledger.ChartOfAccountAutoId,
                                                       T_Acc_Cost_Center_Branch_Allocation.TableName,T_Acc_Cost_Center_Branch_Allocation.ChartOfAccountsAutoId,
                                                       T_Acc_Opening_Balance.TableName,T_Acc_Opening_Balance.ChartOfAccounts_autoId};


        //public const string ReferenceValue = "referenceValue";
        //public const string ReferenceId = "referenceId";
        //public const string Company_autoId = "company_autoId";
        //public const string Edited = "edited";
        //public const string Exported = "exported";

    }
    #endregion
    #region T_Acc_LoanReceive Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>


    public class T_Acc_LoanReceive
    {
        private T_Acc_LoanReceive() { }
        public const string TableName = "T_Acc_LoanReceive";
        public const string LoanInfo_autoId = "loanInfo_autoId";
        public const string InDate = "inDate";

        public const string OpeningBalance_autoId = "openingBalance_autoId";
        public const string ReceivedAmount = "receivedAmount";
        public const string JournalInfo_autoId = "journalInfo_autoId";
        public const string RashidNo = "rashidNo";
        public const string Principal = "principal";

        public const string Interest = "interest";
        public const string DueInterest = "dueInterest";
        //public const string Fax = "fax";
        //public const string Mobile = "mobile";
        //public const string Email = "email";
        //public const string City = "city";
        //public const string Zip = "zip";
    }
    #endregion
    #region T_Web_LevelAssign Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Web_LevelAssign
    {
        private T_Web_LevelAssign() { }
        public const string TableName = "T_Web_LevelAssign";
        public const string EmpAutoId = "empAutoId";
        public const string LevelId = "levelId";
    }
    #endregion
    #region T_Web_LevelName Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Web_LevelName
    {
        private T_Web_LevelName() { }
        public const string TableName = "T_Web_LevelName";
        public const string LevelName = "levelName";
        public const string Serial_no = "serial_no";
    }
    #endregion
    #region T_PersonalInformation Column Name
    /// <summary>
    /// Created By: Md. Fahim Bhuyan
    /// Creation Date:21/10/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_PersonalInformation
    {
        private T_PersonalInformation() { }
        public const string TableName = "T_PersonalInformation";
        public const string PIN = "PIN";
        public const string CardId = "CardId";
        public const string Salutation = "Salutation";
        public const string FirstName = "FirstName";
        public const string MiddleName = "MiddleName";
        public const string LastName = "LastName";
        public const string NickName = "NickName";
        public const string FatherName = "FatherName";
        public const string MotherName = "MotherName";
        public const string BirthDate = "BirthDate";
        public const string BirthPlace = "BirthPlace";
        public const string SpouseName = "SpouseName";
        public const string Son = "Son";
        public const string Daughter = "Daughter";
        public const string TIN = "TIN";
        public const string PassportNo = "PassportNo";
        public const string DrivingLicense = "DrivingLicense";
        public const string NationalIdNo = "NationalIdNo";
        public const string ExtraCurricularActivities = "ExtraCurricularActivities";
        public const string Remark = "Remark";
        public const string GenderAutoId = "GenderAutoId";
        public const string NationalityAutoId = "NationalityAutoId";
        public const string ReligionAutoId = "ReligionAutoId";
        public const string BloodGroupAutoId = "BloodGroupAutoId";
        public const string MaritalStatusAutoId = "MaritalStatusAutoId";


    }
    #endregion
    #region T_AcademicDegree
    /// <summary>
    /// Created By: Md. Fahim Bhuyan
    /// Creation Date:21/10/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_AcademicDegree
    {
        private T_AcademicDegree() { }
        public const string TableName = "T_AcademicDegree";
        public const string Degree = "Degree";
        public const string Code = "Code";
        public const string date = "date";

    }
    #endregion
    #region T_LeaveType Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_LeaveType
    {
        private T_LeaveType() { }
        public const string TableName = "T_LeaveType";
        public const string LeaveType = "leaveType";
        public const string TotalDay = "totalDay";
        public const string IsCaryOver = "isCaryOver";
    }
    #endregion
    #region T_Web_LeaveApplication Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Web_LeaveApplication
    {
        private T_Web_LeaveApplication() { }
        public const string TableName = "T_Web_LeaveApplication";
        public const string LeaveTypeAutoId = "leaveTypeAutoId";
        public const string LevelAutoId = "levelAutoId";
        public const string ApplicantEmpAutoId = "applicantEmpAutoId";
        public const string BossEmpAutoId = "bossEmpAutoId";
        public const string EndDate = "endDate";
        public const string StartDate = "startDate";
        public const string Reason = "reason";
        public const string IsApproved = "isApproved";
        public const string HalfDay = "halfDay";
        public const string FirstOrSecondHalf = "firstOrSecondHalf";
    }
    #endregion
    #region T_Web_ReplacedLeaveApplication Column Name
    /// <summary>
    /// Created By: Md. Abdul Mannan
    /// Creation Date:12/08/2012
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Web_ReplacedLeaveApplication
    {
        private T_Web_ReplacedLeaveApplication() { }
        public const string TableName = "T_Web_ReplacedLeaveApplication";
        public const string LeaveTypeAutoId = "leaveTypeAutoId";
        public const string LevelAutoId = "levelAutoId";
        public const string ApplicantEmpAutoId = "applicantEmpAutoId";
        public const string BossEmpAutoId = "bossEmpAutoId";
        public const string EndDate = "endDate";
        public const string StartDate = "startDate";
        public const string Reason = "reason";
        public const string IsApproved = "isApproved";
        public const string HalfDay = "halfDay";
        public const string FirstOrSecondHalf = "firstOrSecondHalf";
    }
    #endregion
    #region T_Web_DomesticTravelRequestApplication Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Web_DomesticTravelRequestApplication
    {
        private T_Web_DomesticTravelRequestApplication() { }
        public const string TableName = "T_Web_DomesticTravelRequestApplication";

        public const string ApplicantEmpAutoId = "applicantEmpAutoId";
        public const string BossEmpAutoId = "bossEmpAutoId";
        public const string EndDate = "endDate";
        public const string StartDate = "startDate";
        public const string Reason = "reason";
        public const string IsApproved = "isApproved";

    }
    #endregion
    #region T_Web_DomesticTravelRequestApproval Column Name
    /// <summary>
    /// Created By: Md. Abdul Mannan
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Web_DomesticTravelRequestApproval
    {
        private T_Web_DomesticTravelRequestApproval() { }
        public const string TableName = "T_Web_DomesticTravelRequestApproval";
        public const string LeaveApplicationAutoId = "leaveApplicationAutoId";
        public const string EmpAutoId = "empAutoId";
        public const string IsApproved = "isApproved";
        public const string Remarks = "remarks";
    }
    #endregion
    #region T_Web_LeaveApproval Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Web_LeaveApproval
    {
        private T_Web_LeaveApproval() { }
        public const string TableName = "T_Web_LeaveApproval";
        public const string LeaveApplicationAutoId = "leaveApplicationAutoId";
        public const string EmpAutoId = "empAutoId";
        public const string IsApproved = "isApproved";
        public const string Remarks = "remarks";
    }
    #endregion
    #region T_Web_ReplacedLeaveApproval Column Name
    /// <summary>
    /// Created By: Md. Abdul Mannan
    /// Creation Date:12/08/2012
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Web_ReplacedLeaveApproval
    {
        private T_Web_ReplacedLeaveApproval() { }
        public const string TableName = "T_Web_ReplacedLeaveApproval";
        public const string LeaveApplicationAutoId = "leaveApplicationAutoId";
        public const string EmpAutoId = "empAutoId";
        public const string IsApproved = "isApproved";
        public const string Remarks = "remarks";
    }
    #endregion
    #region T_Web_LeaveDecline Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Web_LeaveDecline
    {
        private T_Web_LeaveDecline() { }
        public const string TableName = "T_Web_LeaveDecline";
        public const string LeaveApplicationAutoId = "leaveApplicationAutoId";
        public const string ApplicantEmpAutoId = "applicantEmpAutoId";
        public const string BossEmpAutoId = "bossEmpAutoId";
        public const string Reason = "reason";
        public const string IsApproved = "isApproved";
    }
    #endregion
    #region T_Web_LeaveDeclineDetail Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Web_LeaveDeclineDetail
    {
        private T_Web_LeaveDeclineDetail() { }
        public const string TableName = "T_Web_LeaveDeclineDetail";
        public const string LeaveDeclineAutoId = "leaveDeclineAutoId";
        public const string EmpAutoId = "empAutoId";
        public const string IsApproved = "isApproved";
        public const string Remarks = "remarks";
    }
    #endregion
    #region T_Web_MailingList Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_MailingList.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Web_MailingList
    {
        private T_Web_MailingList() { }
        public const string TableName = "T_Web_MailingList";
        public const string EmpAutoId = "empAutoId";
        public const string PresentEmailAddress = "presentEmailAddress";
        public const string EmergencyEmailAddress = "emergencyEmailAddress";
        public const string Active = "active";
    }
    #endregion
    #region T_LeaveWithPay Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_MailingList.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_LeaveWithPay
    {
        private T_LeaveWithPay() { }
        public const string TableName = "T_LeaveWithPay";
        public const string EmpAutoId = "empAutoId";
        public const string LeaveTypeAutoId = "leaveTypeAutoId";
        public const string CalType = "calType";
        public const string FromDate = "fromDate";
        public const string ToDate = "toDate";
        public const string HrsDays = "hrsDays";
        public const string Remarks = "remarks";
        public const string Date = "date";
        public const string FromTime = "fromTime";
        public const string ToTime = "toTime";
        public const string UserLogBookAutoId = "userLogBookAutoId";
    }
    #endregion
    #region T_Web_Documents Column Name
    /// <summary>
    /// Created By: Dewan Razib Hasan
    /// Creation Date:10/10/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: 
    /// Dependent Table : 
    /// </summary>

    public class T_Web_Documents
    {
        private T_Web_Documents() { }
        public const string TableName = "T_Web_Documents";
        public const string Documents = "Documents";
        public const string AutoId = "autoId";
    }
    #endregion
    #region T_Web_AcknowledgementDocuments Column Name
    /// <summary>
    /// Created By: Dewan Razib Hasan
    /// Creation Date:10/10/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: 
    /// Dependent Table : 
    /// </summary>

    public class T_Web_AcknowledgementDocuments
    {
        private T_Web_AcknowledgementDocuments() { }
        public const string TableName = "T_Web_AcknowledgementDocuments";
        public const string AutoId = "autoId";
        public const string AcknowledgementInfo_autoId = "acknowledgementInfo_autoId";
        public const string Reference_no = "reference_no";
        public const string Documents_autoId = "documents_autoId";

    }
    #endregion
    #region T_Web_AcknowledgementEmployee Column Name
    /// <summary>
    /// Created By: Dewan Razib Hasan
    /// Creation Date:10/10/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: 
    /// Dependent Table : 
    /// </summary>

    public class T_Web_AcknowledgementEmployee
    {
        private T_Web_AcknowledgementEmployee() { }
        public const string TableName = "T_Web_AcknowledgementEmployee";
        public const string AutoId = "autoId";
        public const string AcknowledgementInfo_autoId = "acknowledgementInfo_autoId";
        public const string Employee_autoId = "employee_autoId";
    }
    #endregion
    #region T_Web_AcknowledgementInfo Column Name
    /// <summary>
    /// Created By: Dewan Razib Hasan
    /// Creation Date:10/10/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: 
    /// Dependent Table : 
    /// </summary>

    public class T_Web_AcknowledgementInfo
    {
        private T_Web_AcknowledgementInfo() { }
        public const string TableName = "T_Web_AcknowledgementInfo";
        public const string AutoId = "autoId";
        public const string Subject = "subject";
        public const string Reference_No = "reference_no";
        public const string Remarks = "remarks";
        public const string Date = "date";
    }
    #endregion
    #region T_Web_HolidayInfo Column Name
    /// <summary>
    /// Created By: Dewan Razib Hasan
    /// Creation Date:10/23/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: 
    /// Dependent Table : 
    /// </summary>

    public class T_Web_HolidayInfo
    {
        private T_Web_HolidayInfo() { }
        public const string TableName = "T_Web_HolidayInfo";

        public const string HolidayNo = "holiday_no";
        public const string HolidayName = "holidayName";
        public const string HolidayDate = "holidayDate";
        public const string Remarks = "remarks";
    }
    #endregion
    #region T_CompanyInfo Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_MailingList.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_CompanyInfo
    {
        private T_CompanyInfo() { }
        public const string TableName = "T_CompanyInfo";
        public const string CompName = "compName";
        public const string AutoId = "autoId";
        public const string Address = "address";
        public const string City = "city";
        public const string Zip = "zip";
    }
    #endregion
    #region T_Web_Group Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Web_Group
    {
        private T_Web_Group() { }
        public const string TableName = "T_Web_Group";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string GroupName = "groupName";
        public const string Serial_No = "serial_no";
        public const string Active = "active";
        public const string ReferenceValue = "referenceValue";
        public const string ReferenceId = "referenceId";
        public const string CompanyAutoId = "company_autoId";
        public const string Edited = "edited";
        public const string Exported = "exported";
        public const string Insert_date = "insert_date";
        public const string UserLogBookAutoId = "userLogBookAutoId";
    }
    #endregion
    #region T_Web_Project Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Web_Project
    {
        private T_Web_Project() { }
        public const string TableName = "T_Web_Project";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string ProjectName = "projectName";
        public const string Serial_No = "serial_no";
        public const string Active = "active";
        public const string ReferenceValue = "referenceValue";
        public const string ReferenceId = "referenceId";
        public const string CompanyAutoId = "company_autoId";
        public const string Edited = "edited";
        public const string Exported = "exported";
        public const string Insert_date = "insert_date";
        public const string UserLogBookAutoId = "userLogBookAutoId";
    }
    #endregion
    #region T_Web_Region Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Web_Region
    {
        private T_Web_Region() { }
        public const string TableName = "T_Web_Region";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string RegionName = "Region";
        public const string Serial_No = "serial_no";
        public const string Active = "active";
        public const string ReferenceValue = "referenceValue";
        public const string ReferenceId = "referenceId";
        public const string CompanyAutoId = "company_autoId";
        public const string Edited = "edited";
        public const string Exported = "exported";
        public const string Insert_date = "insert_date";
        public const string UserLogBookAutoId = "userLogBookAutoId";
    }
    #endregion
    #region T_Designation Column Name
    /// <summary>
    /// Created By: Md. Fahim Bhuyan
    /// Creation Date:01/12/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: rpt_empRegionalResourceAllocation.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Designation
    {
        private T_Designation() { }
        public const string TableName = "T_Designation";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string designation = "Designation";

    }
    #endregion
    #region T_Web_Country Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Web_Country
    {
        private T_Web_Country() { }
        public const string TableName = "T_Web_Country";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string CountryName = "countryName";
        public const string Serial_No = "serial_no";
        public const string Active = "active";
        public const string ReferenceValue = "referenceValue";
        public const string ReferenceId = "referenceId";
        public const string CompanyAutoId = "company_autoId";
        public const string Edited = "edited";
        public const string Exported = "exported";
        public const string Insert_date = "insert_date";
        public const string UserLogBookAutoId = "userLogBookAutoId";
    }
    #endregion
    #region T_Web_empResourceAllocation Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Web_empResourceAllocation
    {
        private T_Web_empResourceAllocation() { }
        public const string TableName = "T_Web_empResourceAllocation";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string FromDate = "from_date";
        public const string EmpAutoId = "empAutoId";
        public const string RegionAutoId = "regionAutoId";
        public const string CountryAutoId = "countryAutoId";
        public const string GroupAutoId = "groupAutoId";
        public const string ReferenceValue = "referenceValue";
        public const string ReferenceId = "referenceId";
        public const string CompanyAutoId = "company_autoId";
        public const string Edited = "edited";
        public const string Exported = "exported";
        public const string Insert_date = "insert_date";
        public const string UserLogBookAutoId = "userLogBookAutoId";
    }
    #endregion
    #region T_Web_FacilitiesGroupName Column Name


    public class T_Web_FacilitiesGroupName
    {
        private T_Web_FacilitiesGroupName() { }
        public const string TableName = "T_Web_FacilitiesGroupName";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string FacilitiesName = "facilitiesName";
        public const string Serial_No = "serial_no";
        public const string Active = "active";
        public const string ReferenceValue = "referenceValue";
        public const string ReferenceId = "referenceId";
        public const string CompanyAutoId = "company_autoId";
        public const string Edited = "edited";
        public const string Exported = "exported";
        public const string Insert_date = "insert_date";
        public const string UserLogBookAutoId = "userLogBookAutoId";
    }
    #endregion
    #region T_Web_Facilities Column Name


    public class T_Web_Facilities
    {
        private T_Web_Facilities() { }
        public const string TableName = "T_Web_Facilities";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string FacilitiesGroupAutoId = "facilitiesGroupAutoId";
        public const string FacilitiesName = "facilitiesName";
        public const string ReferenceValue = "referenceValue";
        public const string ReferenceId = "referenceId";
        public const string CompanyAutoId = "company_autoId";
        public const string Edited = "edited";
        public const string Exported = "exported";
        public const string Insert_date = "insert_date";
        public const string UserLogBookAutoId = "userLogBookAutoId";
    }
    #endregion
    #region T_Web_AttributesRaitings Column Name


    public class T_Web_AttributesRaitings
    {
        private T_Web_AttributesRaitings() { }
        public const string TableName = "T_Web_AttributesRaitings";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string Rating = "rating";
        public const string Rating_no = "rating_no";
        public const string Active = "active";
        public const string ReferenceValue = "referenceValue";
        public const string ReferenceId = "referenceId";
        public const string CompanyAutoId = "company_autoId";
        public const string Edited = "edited";
        public const string Exported = "exported";
        public const string Insert_date = "insert_date";
        public const string UserLogBookAutoId = "userLogBookAutoId";
    }
    #endregion
    #region T_Web_MailIssueForEmpPerformance


    public class T_Web_MailIssueForEmpPerformance
    {
        private T_Web_MailIssueForEmpPerformance() { }
        public const string TableName = "T_Web_MailIssueForEmpPerformance";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string IssueDate = "issueDate";
        //public const string AttributeGroupNameAutoId = "attributeGroupNameAutoId";
        public const string skillSetAutoId = "skillsetAutoId";
        public const string emailSubject = "emailSubject";
        public const string emailDescription = "emailDescriptiont";
        public const string ReferenceValue = "referenceValue";
        public const string ReferenceId = "referenceId";
        public const string CompanyAutoId = "company_autoId";
        public const string Edited = "edited";
        public const string Exported = "exported";
        public const string Insert_date = "insert_date";
        public const string UserLogBookAutoId = "userLogBookAutoId";
    }
    #endregion
    #region T_Web_MailingListForEmpPerformance


    public class T_Web_MailingListForEmpPerformance
    {
        private T_Web_MailingListForEmpPerformance() { }
        public const string TableName = "T_Web_MailingListForEmpPerformance";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string MailIssueForEmpPerformanceAutoId = "mailIssueForEmpPerformanceAutoId";
        public const string EmpAutoId = "empAutoId";
        public const string ReferenceValue = "referenceValue";
        public const string ReferenceId = "referenceId";
        public const string CompanyAutoId = "company_autoId";
        public const string Edited = "edited";
        public const string Exported = "exported";
        public const string Insert_date = "insert_date";
        public const string UserLogBookAutoId = "userLogBookAutoId";
    }
    #endregion
    //------------12/12/2010-----------//
    #region T_Web_Topics
    public class T_Web_Topics
    {
        private T_Web_Topics() { }
        public const string TableName = "T_Web_Topics";
        public const string TopicsName = "topicsName";
        public const string StartDate = "startDate";
        public const string EndtDate = "endtDate";
        public const string TopicsStatus = "topicsStatus";
        public const string Multiple_Select = "Multiple_Select";
        public const string DayWiseVote = "dayWiseVote";
        public const string Description = "description";
    }
    #endregion
    #region T_Web_TopicOptions
    public class T_Web_TopicOptions
    {
        private T_Web_TopicOptions() { }
        public const string TableName = "T_Web_TopicOptions";
        public const string Topics_autoId = "topics_autoId";
        public const string TopicOptionsName = "topicOptionsName";
        public const string StartDate = "startDate";
        public const string EndtDate = "endtDate";
        public const string TopicsStatus = "topicsStatus";

    }
    #endregion
    #region T_Web_TopicsVoting
    public class T_Web_TopicsVoting
    {
        private T_Web_TopicsVoting() { }
        public const string TableName = "T_Web_TopicsVoting";
        public const string Topics_autoId = "topics_autoId";
        public const string TopicOptions_autoId = "topicOptions_autoId";
        public const string Employee_autoId = "employee_autoId";
        public const string VotingDate = "votingDate";
    }
    #endregion
    #region T_Company_Info Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_MailingList.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Company_Info
    {
        private T_Company_Info() { }
        public const string TableName = "T_Company_Info";
        public const string CompName = "comp_Name";
        public const string AutoId = "Company_Id";
        public const string Address = "address";
        public const string City = "city";
        public const string Zip = "zip";
    }
    #endregion
    //#region T_Web_ReferenceInfo
    ///// <summary>
    ///// Created By: Md. Fahim Bhuyan
    ///// Creation Date:11/10/2010
    ///// Last Modification Date: 
    ///// Modified By:
    ///// 
    ///// 
    ///// Form Name: frm_ReferenceInfo.aspx
    ///// Dependent Table : 
    ///// </summary>

    //public class T_Web_ReferenceInfo
    //{
    //    private T_Web_ReferenceInfo() { }
    //    public const string TableName = "T_Web_ReferenceInfo";
    //    public const string EmpAutoId = "empAutoId";
    //    public const string Name = "name";
    //    public const string Organization = "organization";
    //    public const string Designation = "designation";
    //    public const string Address = "Address";
    //    public const string Phone = "phone";
    //    public const string Mobile = "mobile";
    //    public const string Fax = "fax";
    //    public const string Email = "email";
    //    public const string FromDate = "fromDate";
    //    public const string ToDate = "toDate";
    //    public const string Relation = "relation";

    //}
    //#endregion
    #region T_Web_FinalRecommendattionAndApproval

    public class T_Web_FinalRecommendattionAndApproval
    {
        private T_Web_FinalRecommendattionAndApproval()
        { }
        public const string TableName = "T_Web_FinalRecommendattionAndApproval";
        public const string EmpAutoId = "empAutoId";
        public const string RecommendationForAutoId = "recommendationForAutoId";
        public const string RecommendedPosition = "recommendedPosition";
        public const string SalaryToBeAutoId = "salaryToBeAutoId";
        public const string PreviousSalary = "previousSalary";
        public const string PresentSalry = "presentSalry";
        public const string MobileAllowance = "mobileAllowance";
        public const string OtherAllowance = "otherAllowance";
        public const string AllowanceForCarMaintenance = "allowanceForCarMaintenance";
        public const string SpecialOtherBenefit = "specialOtherBenefit";
        public const string TotalOtherBenefit = "totalOtherBenefit";
        public const string TotalMonthlyPaymentSalary = "totalMonthlyPaymentSalary";
        public const string ExpectedSalary = "expectedSalary";

        public const string IncrementedFrom = "incrementedFrom";
        public const string IncrementedTo = "incrementedTo";
        public const string IncrementedAmount = "incrementedAmount";
        public const string ParcentageIncreased = "parcentageIncreased";
        public const string ToBeEffectiveFrom = "toBeEffectiveFrom";

        public const string ApprovalAutoId = "approvalAutoId";
        public const string Date = "date";
        public const string Remarks = "remarks";
        public const string Comments = "comments";
        public const string Hrcomments = "hrComments";
        public const string MailIssuedEmployeeLetterAutoId = "mailIssuedEmployeeLetterAutoId";
        public const string IsConfirm = "isConfirm";
    }
    #endregion
    //#region T_Web_WorkExperienceInfo
    ///// <summary>
    ///// Created By: Md. Fahim Bhuyan
    ///// Creation Date:11/10/2010
    ///// Last Modification Date: 
    ///// Modified By:
    ///// 
    ///// 
    ///// Form Name: frm_WorkExpreience.aspx
    ///// Dependent Table : 
    ///// </summary>

    //public class T_Web_WorkExperienceInfo
    //{
    //    private T_Web_WorkExperienceInfo() { }
    //    public const string TableName = "T_Web_WorkExperienceInfo";
    //    public const string EmpAutoId = "empAutoId";
    //    public const string CompanyName = "companyName";
    //    public const string CompanyBusiness = "companyBusiness";
    //    public const string CompanyAddress = "companyAddress";
    //    public const string Designation = "designation";

    //    public const string Department = "department";
    //    public const string JobNature = "jobNature";
    //    public const string JobResponsibilities = "jobResponsibilities";
    //    public const string LastSalary = "lastSalary";
    //    public const string FromDate = "fromDate";
    //    public const string ToDate = "toDate";
    //    public const string Continuing = "continuing";
    //    public const string Remark = "remark";
    //}
    //#endregion

    //#region T_ContactInfo Column Name
    ///// <summary>
    ///// Created By: Md. Jahirul Islam
    ///// Creation Date:30/09/2010
    ///// Last Modification Date: 
    ///// Modified By:
    ///// 
    ///// 
    ///// Form Name: frm_billWiseTemplate.aspx
    ///// Dependent Table : 
    ///// </summary>

    //public class T_ContactInfo
    //{
    //    private T_ContactInfo() { }
    //    public const string TableName = "T_ContactInfo";
    //    public const string EmpAutoId = "empAutoId";
    //    public const string PresentEmail = "presentEmail";
    //    public const string EmergencyEmail = "emergencyEmail";

    //    //public const string TableName = "T_ContactInfo";
    //    //public const string EmpAutoId = "empAutoId";
    //    public const string PresentAddress = "presentAddress";
    //    public const string PresentCity = "presentCity";
    //    public const string PresentFax = "presentFax";
    //    public const string PresentZip = "presentZip";
    //    public const string PresentPhone = "presentPhone";
    //    public const string presentMobile = "presentMobile";
    //    //public const string PresentEmail = "presentEmail";
    //    public const string ParmanentAddress = "parmanentAddress";
    //    public const string ParmanentUpazila = "parmanentUpazila";
    //    public const string ParmanentDistrict = "parmanentDistrict";

    //    public const string ParmanentPhone = "parmanentPhone";
    //    public const string EmergencyRelation = "emergencyRelation";
    //    public const string EmergencyRelation1 = "emergencyRelation1";
    //    public const string EmergencyName = "emergencyName";
    //    public const string EmergencyAddress = "emergencyAddress";
    //    public const string EmergencyPhone = "emergencyPhone";
    //    public const string EmergencyMobile = "emergencyMobile";
    //    //public const string EmergencyEmail = "emergencyEmail";
    //    public const string EmergencyName1 = "emergencyName1";
    //    public const string EmergencyAddress1 = "emergencyAddress1";
    //    public const string EmergencyPhone1 = "emergencyPhone1";
    //    public const string EmergencyMobile1 = "emergencyMobile";
    //    public const string EmergencyFax = "EmergencyFax";
    //    public const string EmergencyFax1 = "emergencyFax1";

    //    public const string EmergencyEmail1 = "emergencyEmail1";
    //    public const string Date = "date";
    //}
    //#endregion

    //#region T_AcademicInfo

    //public class T_AcademicInfo
    //{
    //    private T_AcademicInfo()
    //    { }
    //    public const string TableName = "T_AccademicInfo";
    //    public const string EmpAutoId = "empAutoId";
    //    public const string academicDegreeAutoId = "academicDegreeAutoId";
    //    public const string examTitle = "examTitle";
    //    public const string institution = "institution";
    //    public const string board = "board";
    //    public const string major = "major";
    //    public const string result = "result";
    //    public const string cgpa = "cgpa";
    //    public const string scale = "scale";
    //    public const string passingYear = "passingYear";
    //    public const string duration = "duration";
    //    public const string achievement = "achievement";
    //    public const string remarks = "remarks";






    //}
    //#endregion

    //#region T_Skill_Info

    //public class T_Web_SkillInfo
    //{
    //    private T_Web_SkillInfo()
    //    { }
    //    public const string TableName = "T_Web_SkillInfo";
    //    public const string EmpAutoId = "empAutoId";
    //    public const string indate = "indate ";
    //    public const string skillTypeAutoId = "skillTypeAutoId";
    //    public const string skillCategory = "skillCategory";
    //    public const string skillLevelAutoId = "skillLevelAutoId";
    //    public const string remark = "remark";


    //}
    //#endregion
    #region T_Web_AttributeDetails Column Name


    public class T_Web_AttributeDetails
    {
        private T_Web_AttributeDetails() { }
        public const string TableName = "T_Web_AttributeDetails";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string AttributeGroupAutoId = "attributeGroupAutoId";
        public const string AttributeName = "attributeName";
        public const string ReferenceValue = "referenceValue";
        public const string ReferenceId = "referenceId";
        public const string CompanyAutoId = "company_autoId";
        public const string Edited = "edited";
        public const string Exported = "exported";
        public const string Insert_date = "insert_date";
        public const string UserLogBookAutoId = "userLogBookAutoId";
        public const string AttributeDescription = "attributeDescription";
    }
    #endregion
    #region T_Web_AttributeGroupName Column Name


    public class T_Web_AttributeGroupName
    {
        private T_Web_AttributeGroupName() { }
        public const string TableName = "T_Web_AttributeGroupName";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string GroupName = "groupName";
        public const string Serial_No = "serial_no";
        public const string Active = "active";
        public const string ReferenceValue = "referenceValue";
        public const string ReferenceId = "referenceId";
        public const string CompanyAutoId = "company_autoId";
        public const string Edited = "edited";
        public const string Exported = "exported";
        public const string Insert_date = "insert_date";
        public const string UserLogBookAutoId = "userLogBookAutoId";
    }
    #endregion
    #region T_Web_comingYearGoals Column Name


    public class T_Web_comingYearGoals
    {
        private T_Web_comingYearGoals() { }
        public const string TableName = "T_Web_comingYearGoals";
        //public const string Id = "id";
        public const string EmpAutoId = "empAutoId";
        public const string ComingYearWhat = "comingYearWhat";
        public const string ComingYearHow = "comingYearHow";
        public const string When = "[when]";
        public const string HrLetterIssueAutoId = "HRLetterIssueAutoId";
        public const string CompanyAutoId = "company_autoId";
        public const string PerformanceType = "performanceType";
        //public const string Edited = "edited";
        //public const string Exported = "exported";
        public const string Insert_date = "insert_date";
        public const string UserLogBookAutoId = "userLogBookAutoId";
    }
    #endregion
    #region T_Web_Grade Column Name
    //Md. Jahirul Islam

    public class T_Web_Grade
    {
        private T_Web_Grade() { }
        public const string TableName = "T_Web_Grade";
        public const string Grade = "grade";
        public const string GradeDescription = "gradeDescription";
    }
    #endregion
    #region T_Web_MailingListForEmpPerformance


    public class T_Web_MailingListForFeedBack
    {
        private T_Web_MailingListForFeedBack() { }
        public const string TableName = "T_Web_MailingListForFeedBack";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string MailIssueForEmpFeedBackAutoId = "mailIssueForEmpFeedBackAutoId";
        public const string EmpAutoId = "empAutoId";
        public const string ReferenceValue = "referenceValue";
        public const string ReferenceId = "referenceId";
        public const string CompanyAutoId = "company_autoId";
        public const string Edited = "edited";
        public const string Exported = "exported";
        public const string Insert_date = "insert_date";
        public const string UserLogBookAutoId = "userLogBookAutoId";
    }
    #endregion
    #region T_Web_MailIssueForFeedBack
    public class T_Web_MailIssueForFeedBack
    {
        private T_Web_MailIssueForFeedBack() { }
        public const string TableName = "T_Web_MailIssueForFeedBack";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string IssueDate = "issueDate";
        public const string AttributeGroupNameAutoId = "attributeGroupNameAutoId";
        public const string emailSubject = "emailSubject";
        public const string emailDescription = "emailDescriptiont";
        public const string ReferenceValue = "referenceValue";
        public const string ReferenceId = "referenceId";
        public const string CompanyAutoId = "company_autoId";
        public const string Edited = "edited";
        public const string Exported = "exported";
        public const string Insert_date = "insert_date";
        public const string UserLogBookAutoId = "userLogBookAutoId";
    }
    #endregion
    #region T_Web_pastYearGoals
    public class T_Web_pastYearGoals
    {
        private T_Web_pastYearGoals() { }
        public const string TableName = "T_Web_pastYearGoals";
        public const string EmpAutoId = "[empAutoId]";
        public const string PastYearWhat = "[pastYearWhat]";
        public const string PastYearWhy = "[pastYearWhy]";
        public const string RatingAutoId = "[ratingAutoId]";
        public const string HRLetterIssueAutoId = "[HRLetterIssueAutoId]";
        public const string performanceType = "[performanceType]";
    }
    #endregion
    #region T_Web_Confirmation Column Name
    /// <summary>
    /// Created By: Dewan Razib Hasan
    /// Creation Date:10/10/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: 
    /// Dependent Table : 
    /// </summary>

    public class T_Web_Confirmation
    {
        private T_Web_Confirmation() { }
        public const string TableName = "T_Web_Confirmation";
        public const string AcknowledgementInfo_autoId = "acknowledgementInfo_autoId";
        public const string Documents_autoId = "documents_autoId";
        public const string Employee_autoId = "employee_autoId";
    }
    #endregion
    #region T_Web_CommentsByDeptInCharge
    public class T_Web_CommentsByDeptInCharge
    {
        private T_Web_CommentsByDeptInCharge() { }
        public const string TableName = "T_Web_CommentsByDeptInCharge";
        public const string AutoId = "[autoId]";
        public const string EmpAutoId = "[empAutoId]";
        public const string Comments = "[Comments]";
        public const string LetterIssue_autoId = "[letterIssue_autoId]";
        public const string CompanyAutoId = "[companyAutoId]";

    }
    #endregion
    //24-10-2010---M.M Solyman
    #region T_Web_SkillsSet Column Name


    public class T_Web_SkillsSet
    {
        private T_Web_SkillsSet() { }
        public const string TableName = "T_Web_SkillsSet";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string SkillsName = "skillsName";
        public const string Serial_No = "serial_no";
        public const string Active = "active";
        public const string ReferenceValue = "referenceValue";
        public const string ReferenceId = "referenceId";
        public const string CompanyAutoId = "company_autoId";
        public const string Edited = "edited";
        public const string Exported = "exported";
        public const string Insert_date = "insert_date";
        public const string UserLogBookAutoId = "userLogBookAutoId";
    }
    #endregion
    #region T_Web_AttributeWithSkills Column Name


    public class T_Web_AttributeWithSkills
    {
        private T_Web_AttributeWithSkills() { }
        public const string TableName = "T_Web_AttributeWithSkills";
        public const string Id = "id";
        public const string AutoId = "autoId";
        public const string SkillsAutoId = "skillsAutoId";
        public const string AttributeAutoId = "attributeAutoId";
        public const string ReferenceValue = "referenceValue";
        public const string ReferenceId = "referenceId";
        public const string Company_autoId = "company_autoId";
        public const string Edited = "edited";
        public const string Exported = "exported";
        public const string Insert_date = "insert_date";
        public const string UserLogBookAutoId = "userLogBookAutoId";
    }
    #endregion
    #region T_Web_GradeByLeader
    public class T_Web_GradeByLeader
    {
        private T_Web_GradeByLeader() { }
        public const string TableName = "T_Web_GradeByLeader";
        //public const string AutoId = "[autoId]";
        public const string Employee_AutoId = "employee_autoId";
        public const string Grade_AutoId = "grade_autoId";
        public const string MailIssuedEmployeeLetterAutoId = "mailIssuedEmployeeLetterAutoId";
        public const string CompanyAutoId = "companyAutoId";
        public const string SupervisorAutoId = "supervisorAutoId";

    }
    #endregion
    #region T_Month
    public class T_Month
    {
        private T_Month() { }
        public const string TableName = "T_Month";
        public const string MonthName = "MonthName";
        public const string MonthNum = "MonthNum";
    }
    #endregion
    #region Rpt_ErpReport
    public class Rpt_ErpReport
    {
        private Rpt_ErpReport()
        {

        }
        //procedures for reportName.rpt files
        public const string Proc_RptGeneralLedger = "proc_RptGeneralLedger";
        public const string Proc_rpt_leadger_view_select_opening_balance_autoId = "proc_rpt_leadger_view_select_opening_balance_autoId";
        public const string Proc_rpt_web_selectForFrm_empRegionalResourceAllocation = "proc_rpt_web_selectForFrm_empRegionalResourceAllocation";
        public const string Rpt_proc_web_frm_mailingList_select_Employee_MailAddress_For_Evaluation = "rpt_proc_web_frm_mailingList_select_Employee_MailAddress_For_Evaluation";
        public const string Proc_web_rpt_employeeLeaveInfoFinallyApproved = "proc_web_rpt_employeeLeaveInfoFinallyApproved";
        public const string Proc_web_rpt_employeeLeaveInfoDeclinedOrApproved = "proc_web_rpt_employeeLeaveInfoDeclinedOrApproved";
        public const string Proc_Rpt_forFromPFBalance = "proc_Rpt_forFromPFBalance";
        public const string Proc_Rpt_forFromPayHeadBalance = "proc_Rpt_forFromPayHeadBalance";
        public const string Proc_web_frm_finalRecommendation_select_Employee_Supervisors = "proc_web_frm_finalRecommendation_select_Employee_Supervisors";
        public const string Proc_web_Rpt_EmployeeInfoOnAcademicInfo = "proc_web_Rpt_EmployeeInfoOnAcademicInfo";
        public const string Proc_web_Rpt_EmployeeInfoOnTrainingInfo = "proc_web_Rpt_EmployeeInfoOnTrainingInfo";
        //holds formola field information (name and value)
        public static Dictionary<string, string> dct_reportFormulaField = new Dictionary<string, string>();

        //for realative path of reportName.rpt files
        public static string g_s_rptFilePath = string.Empty;

        //rpt_files and sql_query
        public static Dictionary<string, string> dct_reportsName_sql_query = new Dictionary<string, string>();

        //for sql query
        public static string g_s_sql_query = string.Empty;
        public static string g_s_sub_sql_query = string.Empty;
        //public static DataSet ds = new DataSet();

        public const string Proc_web_frm_rpt_salaryInfoByEffectiveDate = "proc_web_frm_rpt_salaryInfoByEffectiveDate";
    }
    #endregion
    //----------12/2/2010-------------//
    #region T_Web_Login
    public class T_Web_Login
    {
        private T_Web_Login() { }
        public const string TableName = "T_Web_Login";
        //public const string AutoId = "[autoId]";
        public const string UserName = "userName";
        public const string Employee_AutoId = "empAutoId";

        public const string Password = "password";
        public const string Active = "Active";
        public const string UserStatus = "userStatus";
        public const string CompanyAutoId = "companyAutoId";

    }
    #endregion
    //Fahim
    #region T_ReferenceInfo
    /// <summary>
    /// Created By: Md. Fahim Bhuyan
    /// Creation Date:11/10/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_ReferenceInfo.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_ReferenceInfo
    {
        private T_ReferenceInfo() { }
        public const string TableName = "T_ReferenceInfo";
        public const string EmpAutoId = "empAutoId";
        public const string Name = "name";
        public const string Organization = "organization";
        public const string Designation = "designation";
        public const string Address = "Address";
        public const string Phone = "phone";
        public const string Mobile = "mobile";
        public const string Fax = "fax";
        public const string Email = "email";
        public const string FromDate = "fromDate";
        public const string ToDate = "toDate";
        public const string Relation = "relation";

    }
    #endregion
    #region T_ReferenceCheck
    /// <summary>
    /// Created By: Md. Fahim Bhuyan
    /// Creation Date:11/10/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_ReferenceInfo.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_ReferenceCheck
    {
        private T_ReferenceCheck() { }
        public const string TableName = "T_ReferenceCheck";
        public const string QuestionAutoId = "questionAutoId";
        public const string Name = "name";
        public const string Answer = "answer";
        public const string ReferenceAutoId = "referenceAutoId";
    }
    #endregion
    #region T_WorkExperienceInfo
    /// <summary>
    /// Created By: Md. Fahim Bhuyan
    /// Creation Date:11/10/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_WorkExpreience.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_WorkExperienceInfo
    {
        private T_WorkExperienceInfo() { }
        public const string TableName = "T_WorkExperienceInfo";
        public const string EmpAutoId = "empAutoId";
        public const string CompanyName = "companyName";
        public const string CompanyBusiness = "companyBusiness";
        public const string CompanyAddress = "companyAddress";
        public const string Designation = "designation";

        public const string Department = "department";
        public const string JobNature = "jobNature";
        public const string JobResponsibilities = "jobResponsibilities";
        public const string LastSalary = "lastSalary";
        public const string FromDate = "fromDate";
        public const string ToDate = "toDate";
        public const string Continuing = "continuing";
        public const string Remark = "remark";
    }
    #endregion
    #region T_ContactInfo Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_ContactInfo
    {
        private T_ContactInfo() { }
        public const string TableName = "T_ContactInfo";
        public const string EmpAutoId = "empAutoId";
        public const string PresentEmail = "presentEmail";
        public const string EmergencyEmail = "emergencyEmail";

        //public const string TableName = "T_ContactInfo";
        //public const string EmpAutoId = "empAutoId";
        public const string PresentAddress = "presentAddress";
        public const string PresentCity = "presentCity";
        public const string PresentFax = "presentFax";
        public const string PresentZip = "presentZip";
        public const string PresentPhone = "presentPhone";
        public const string presentMobile = "presentMobile";
        //public const string PresentEmail = "presentEmail";
        public const string ParmanentAddress = "parmanentAddress";
        public const string ParmanentUpazila = "parmanentUpazila";
        public const string ParmanentDistrict = "parmanentDistrict";

        public const string ParmanentPhone = "parmanentPhone";
        public const string EmergencyRelation = "emergencyRelation";
        public const string EmergencyRelation1 = "emergencyRelation1";
        public const string EmergencyName = "emergencyName";
        public const string EmergencyAddress = "emergencyAddress";
        public const string EmergencyPhone = "emergencyPhone";
        public const string EmergencyMobile = "emergencyMobile";
        //public const string EmergencyEmail = "emergencyEmail";
        public const string EmergencyName1 = "emergencyName1";
        public const string EmergencyAddress1 = "emergencyAddress1";
        public const string EmergencyPhone1 = "emergencyPhone1";
        public const string EmergencyMobile1 = "emergencyMobile1";
        public const string EmergencyFax = "EmergencyFax";
        public const string EmergencyFax1 = "emergencyFax1";

        public const string EmergencyEmail1 = "emergencyEmail1";
        public const string Date = "date";
    }
    #endregion
    #region T_AcademicInfo

    public class T_AcademicInfo
    {
        private T_AcademicInfo()
        { }
        public const string TableName = "T_AcademicInfo";
        public const string EmpAutoId = "empAutoId";
        public const string academicDegreeAutoId = "academicDegreeAutoId";
        public const string examTitle = "examTitle";
        public const string institution = "institution";
        public const string board = "board";
        public const string major = "major";
        public const string result = "result";
        public const string cgpa = "cgpa";
        public const string scale = "scale";
        public const string passingYear = "passingYear";
        public const string duration = "duration";
        public const string achievement = "achievement";
        public const string remarks = "remarks";
        public const string userLogBookAutoId = "userLogBookAutoId";
    }
    #endregion
    #region T_Skill_Info

    public class T_SkillInfo
    {
        private T_SkillInfo()
        { }
        public const string TableName = "T_SkillInfo";
        public const string EmpAutoId = "empAutoId";
        public const string indate = "indate ";
        public const string skillTypeAutoId = "skillTypeAutoId";
        public const string skillCategory = "skillCategory";
        public const string skillLevelAutoId = "skillLevelAutoId";
        public const string remark = "remark";


    }
    #endregion
    #region T_Web_Professional_Qualification

    public class T_Web_Professional_Qualification
    {
        private T_Web_Professional_Qualification()
        { }
        public const string TableName = "T_Web_Professional_Qualification";
        public const string CourseTypeAutoId = "CourseTypeAutoId";
        public const string CourseTitle = "CourseTitle";
        public const string Institute = "Institute";
        public const string Duration = "Duration";
        public const string Address = "Address";
        public const string Result = "Result";
        public const string Achievement = "Achievement";
        public const string Year_ofCompletion = "Year_ofCompletion";


    }
    #endregion
    #region T_Web_ProfessionalCourseType

    public class T_Web_ProfessionalCourseType
    {
        private T_Web_ProfessionalCourseType()
        { }
        public const string TableName = "T_Web_ProfessionalCourseType";
        public const string Professional_courseType = "professional_courseType";

    }
    #endregion
    #region T_Web_NomineeType

    public class T_Web_NomineeType
    {
        private T_Web_NomineeType()
        { }
        public const string TableName = "T_Web_NomineeType";
        public const string NomineeType = "nomineeType";

    }
    #endregion T_Web_NomineeType
    #region T_Web_Nominee

    public class T_Web_Nominee
    {
        private T_Web_Nominee()
        { }
        public const string TableName = "T_Web_Nominee";
        public const string EmpAutoId = "nomineeType";
        public const string NomineeTypeAutoId = "nomineeTypeAutoId";
        public const string Name = "name";
        public const string PresentAddress = "presentAddress";
        public const string PermanentAddress = "permanentAddress";
        public const string Relationship = "relationship";
        public const string Share = "share";
        public const string UserLogBook_autoId = "useLogBook_autoId";
    }
    #endregion T_Web_Nominee
    #region T_Web_CustomTabLabel Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_performance.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Web_CustomTabLabel
    {
        private T_Web_CustomTabLabel() { }
        public const string TableName = "T_Web_CommentType";
        public const string LevelName = "commentTypeName";
        public const string Serial_no = "serial_no";
    }
    #endregion
    #region T_Web_PerformanceTabDescription Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:15/05/2011
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: 
    /// Dependent Table : 
    /// </summary>

    public class T_Web_PerformanceTabDescription
    {
        private T_Web_PerformanceTabDescription() { }
        public const string TableName = "T_Web_PerformanceTabDescription";
        public const string TabId = "tabId";
        public const string TabDescription = "tabDescription";
    }
    #endregion
    #region T_Web_Config_Dept_Resign_Clearence Table Column Name
    public class T_Web_Config_Dept_Resign_Clearence
    {
        private T_Web_Config_Dept_Resign_Clearence() { }
        public const string TableName = "T_Web_Config_Dept_Resign_Clearence";
        public const string DepartmentAutoId = "departmentAutoId";
        public const string Responsible_empAutoId = "responsible_empAutoId";
        public const string Remarks = "remarks";
    }
    #endregion
    #region T_Web_Resign
    public class T_Web_Resign
    {
        private T_Web_Resign() { }
        public const string TableName = "T_Web_Resign";
        public const string applicantEmpAutoId = "applicantEmpAutoId";
        public const string supervisorAutoId = "supervisorAutoId";
        public const string lastWorkingDate = "lastWorkingDate";
        public const string letterIssueDate = "letterIssueDate";
        public const string resignDate = "resignDate";
        public const string letter = "letter";
        public const string IsApproved = "isApproved";
    }
    #endregion
    #region T_Web_LeaveApproval Column Name
    /// <summary>
    /// Created By: Md. Jahirul Islam
    /// Creation Date:30/09/2010
    /// Last Modification Date: 
    /// Modified By:
    /// 
    /// 
    /// Form Name: frm_billWiseTemplate.aspx
    /// Dependent Table : 
    /// </summary>

    public class T_Web_ResignApproval
    {
        private T_Web_ResignApproval() { }
        public const string TableName = "T_Web_ResignApproval";
        public const string EmpResginAutoId = "empResginAutoId";
        public const string EmpAutoId = "empAutoId";
        public const string IsApproved = "isApproved";
        public const string Remarks = "remarks";
    }
    #endregion
    #region T_Department Table Column Name
    public class T_Department
    {
        private T_Department() { }
        public const string TableName = "T_Department";
        public const string Department = "Department";
    }
    #endregion
    #region T_Web_Performance_MDApproval Table Column Name
    public class T_Web_Performance_MDApproval
    {
        private T_Web_Performance_MDApproval() { }
        public const string TableName = "T_Web_Performance_MDApproval";
        public const string FinalRecommendationAutoId = "finalRecommendationAutoId";
    }
    #endregion
    #region T_Web_AppraisalNotification
    public class T_Web_AppraisalNotification
    {
        private T_Web_AppraisalNotification() { }
        public const string TableName = "T_Web_AppraisalNotification";
        public const string IsFilledUp = "isFilledUp";
        public const string Month = "Month";
        public const string Year = "Year";
    }
    #endregion
    
}
