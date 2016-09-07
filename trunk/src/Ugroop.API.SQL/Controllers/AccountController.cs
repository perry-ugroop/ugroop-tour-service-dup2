using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Web.Http;
using Ugroop.API.SQL.Helper.Json;
using UGroopData.Sql.Repository.Data;
using UGroopData.Sql.Service.UGroopWeb.Interface;

namespace Ugroop.API.SQL.Controllers {
    public class AccountController : SecurityController {

        public AccountController(IAccountService accountService, IUserService userService) : base(accountService, userService) { }

        #region ACCOUNT INFO                .

        ///<summary>
        ///POST : Add AccountInfo
        ///</summary>
        ///<remarks>
        ///Add new AccountInfo in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Add_AccountInfo(JObject jsonData) {
            var accountInfo = JEntity<Account_Info>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Add(accountInfo).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Update AccountInfo
        ///</summary>
        ///<remarks>
        ///Update AccountInfo in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Update_AccountInfo(JObject jsonData) {
            var accountInfo = JEntity<Account_Info>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Update(accountInfo).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get AccountInfo by Id
        ///</summary>
        ///<remarks>
        ///Find AccountInfo record by Id.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_AccountInfoById(JObject jsonData) {
            var idAccount = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Get_AccountByAccountId(idAccount).JsonSerialize())
            };
        }

        #endregion

        #region ACCOUNT SCHOOL                .

        ///<summary>
        ///POST : Add AccountSchool
        ///</summary>
        ///<remarks>
        ///Add new AccountSchool in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Add_AccountSchool(JObject jsonData) {
            var accountSchool = JEntity<Account_School>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Add(accountSchool).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Update AccountSchool
        ///</summary>
        ///<remarks>
        ///Update AccountSchool in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Update_AccountSchool(JObject jsonData) {
            var accountSchool = JEntity<Account_School>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Update(accountSchool).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_AccountSchoolByAccountId (id)
        ///</summary>
        ///<remarks>
        ///Retrieve AccountSchool By AccountId in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_AccountSchoolByAccountId(JObject jsonData) {
            int accountId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Get_AccountSchoolByAccountId(accountId).JsonSerialize())
            };
        }




        #endregion

        #region ACCOUNT MEDICAL                .

        ///<summary>
        ///POST : Add AccountMedical
        ///</summary>
        ///<remarks>
        ///Add new AccountMedical in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Add_AccountMedical(JObject jsonData) {
            var accountMedical = JEntity<Account_Medical>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Add(accountMedical).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Update AccountMedical
        ///</summary>
        ///<remarks>
        ///Update AccountMedical in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Update_AccountMedical(JObject jsonData) {
            var accountMedical = JEntity<Account_Medical>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Update(accountMedical).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_AccountMedicalByAccountId (id)
        ///</summary>
        ///<remarks>
        ///Retrieve AccountMedical By AccountId in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_AccountMedicalByAccountId(JObject jsonData) {
            int accountId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Get_AccountMedicalByAccountId(accountId).JsonSerialize())
            };
        }

        #endregion

        #region ACCOUNT MEDICAL NOTES               .

        ///<summary>
        ///POST : Add AccountMedicalNotes
        ///</summary>
        ///<remarks>
        ///Add new AccountMedicalNotes in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Add_AccountMedicalNotes(JObject jsonData) {
            var accountMedicalNotes = JEntity<Account_MedicalNotes>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Add(accountMedicalNotes).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Update AccountMedicalNotes
        ///</summary>
        ///<remarks>
        ///Update AccountMedicalNotes in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Update_AccountMedicalNotes(JObject jsonData) {
            var accountMedicalNotes = JEntity<Account_Medical>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Update(accountMedicalNotes).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_AccountMedicalNotesByAccountId (id)
        ///</summary>
        ///<remarks>
        ///Find AccountMedical Note By AccountId in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_AccountMedicalNotesByAccountId(JObject jsonData) {
            int accountId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Get_AccountMedicalNotesByAccountId(accountId).JsonSerialize())
            };
        }

        #endregion

        #region TRAVEL DOCUMENTS                   .

        ///<summary>
        ///POST : Add TravelDocument
        ///</summary>
        ///<remarks>
        ///Add new TravelDocument in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Add_TravelDocument(JObject jsonData) {
            var travelDocument = JEntity<Travel_Document>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Add(travelDocument).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Update TravelDocument
        ///</summary>
        ///<remarks>
        ///Update TravelDocument in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Update_TravelDocument(JObject jsonData) {
            var travelDocument = JEntity<Travel_Document>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Update(travelDocument).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_AccountTravelDocumentsByAccountId (id)
        ///</summary>
        ///<remarks>
        ///Get TravelDocument By AccountId in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_AccountTravelDocumentsByAccountId(JObject jsonData) {
            int accountId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Get_AccountTravelDocumentsByAccountId(accountId).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_TravelDocumentModelByAccountId (id)
        ///</summary>
        ///<remarks>
        ///Get TravelDocument ViewModel By AccountId in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_TravelDocumentModelByAccountId(JObject jsonData) {
            int accountId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Get_TravelDocumentModelByAccountId(accountId).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_TravelDocumentByAccountIdAndDocType (id,doctype)
        ///</summary>
        ///<remarks>
        ///Get Get TravelDocument By AccountId/DocType in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_TravelDocumentByAccountIdAndDocType(JObject jsonData) {
            int accountId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            int doctype = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("doctype"));
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Get_TravelDocumentByAccountIdAndDocType(accountId, doctype).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_TravelDocumentByDocumentId (id)
        ///</summary>
        ///<remarks>
        ///Get TravelDocument By DocumentId in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_TravelDocumentByDocumentId(JObject jsonData) {
            int documentId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Get_TravelDocumentByDocumentId(documentId).JsonSerialize())
            };
        }

        #endregion

        #region ACCOUNT RELATIVE                    .

        ///<summary>
        ///POST : Add AccountRelative
        ///</summary>
        ///<remarks>
        ///Add new AccountRelative in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Add_AccountRelative(JObject jsonData) {
            var relative = JEntity<Account_Relative>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Add(relative).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Update AccountRelative
        ///</summary>
        ///<remarks>
        ///Update AccountRelative in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Update_AccountRelative(JObject jsonData) {
            var relative = JEntity<Account_Relative>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Update(relative).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_AllAccountRelativeByAccountId (id)
        ///</summary>
        ///<remarks>
        ///Returns List<Account_Relative> By AccountId.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_AllAccountRelativeByAccountId(JObject jsonData) {
            int accountId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Get_AllAccountRelativeByAccountId(accountId).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_AccountRelativeModelByAccountId (id)
        ///</summary>
        ///<remarks>
        ///Returns List<AccountRelativeListViewModel> By AccountId.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_AccountRelativeModelByAccountId(JObject jsonData) {
            int accountId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Get_AccountRelativeModelByAccountId(accountId).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_AccountRelativeByRelativeId (id,id2)
        ///</summary>
        ///<remarks>
        ///Returns AccountRelative By AccountId and RelativeId.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_AccountRelativeByRelativeId(JObject jsonData) {
            int accountId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            int relativeId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id2"));
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Get_AccountRelativeByRelativeId(accountId, relativeId).JsonSerialize())
            };
        }

        #endregion

        #region ORGANIZATION                    .

        ///<summary>
        ///POST : Add Organization
        ///</summary>
        ///<remarks>
        ///Add new Organization in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Add_Organization(JObject jsonData) {
            var organization = JEntity<Organization>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Add(organization).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Update Organization
        ///</summary>
        ///<remarks>
        ///Update Organization in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Update_Organization(JObject jsonData) {
            var organization = JEntity<Organization>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Update(organization).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_AllOrganization
        ///</summary>
        ///<remarks>
        ///Returns all List<Organization>.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_AllOrganization(JObject jsonData) {
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Get_AllOrganization().JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_OrganizationByAccountId (id)
        ///</summary>
        ///<remarks>
        ///Returns Account_Relative By AccountId.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_OrganizationByAccountId(JObject jsonData) {
            int accountId = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Get_OrganizationByAccountId(accountId).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_OrganizationById (id)
        ///</summary>
        ///<remarks>
        ///Returns Organization By Id.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_OrganizationById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(AccountService.Get_OrganizationById(id).JsonSerialize())
            };
        }




        #endregion


    }
}
