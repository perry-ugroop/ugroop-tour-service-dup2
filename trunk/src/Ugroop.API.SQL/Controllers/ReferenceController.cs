using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Web.Http;
using Ugroop.API.SQL.Helper.Json;
using UGroopData.Sql.Repository.Data;
using UGroopData.Sql.Service.UGroopWeb.Interface;

namespace Ugroop.API.SQL.Controllers {
    public class ReferenceController : SecurityController {

        public ReferenceController(IUserService userService, IReferenceService referenceService) : base(userService, referenceService) { }

        #region TIMEZONE            .

        ///<summary>
        ///POST : Add TimeZone
        ///</summary>
        ///<remarks>
        ///Add new TimeZone in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Add_TimeZone(JObject jsonData) {
            var timezoneData = JEntity<UGroopData.Sql.Repository.Data.TimeZone>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Add(timezoneData).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Update TimeZone
        ///</summary>
        ///<remarks>
        ///Update TimeZone in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Update_SysPage(JObject jsonData) {
            var timezoneData = JEntity<UGroopData.Sql.Repository.Data.TimeZone>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Update(timezoneData).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_AllTimeZones
        ///</summary>
        ///<remarks>
        ///Returns list of TimeZones<Sys_Page>.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_AllSysPages(JObject jsonData) {
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AllTimeZones().JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_TimeZoneById (id)
        ///</summary>
        ///<remarks>
        ///Get TimeZone By Id.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_TimeZoneById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_TimeZoneById(id).JsonSerialize())
            };
        }


        #endregion

        #region MEETING ACTIVITY TYPE           .

        [HttpPost]
        public HttpResponseMessage Add_MeetingActivityType(JObject jsonData) {
            var activityType = JEntity<Tour_MeetingActivityType>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Add(activityType).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_MeetingActivityType(JObject jsonData) {
            var activityType = JEntity<Tour_MeetingActivityType>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Update(activityType).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AllMeetingActivityType(JObject jsonData) {
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AllMeetingActivityType().JsonSerialize())
            };
        }


        [HttpPost]
        public HttpResponseMessage Get_MeetingActivityTypeById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_MeetingActivityTypeById(id).JsonSerialize())
            };
        }

        #endregion

        #region TOUR DIRECTION TYPE                    .

        [HttpPost]
        public HttpResponseMessage Add_TourDirectionType(JObject jsonData) {
            var directionType = JEntity<Tour_DirectionType>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Add(directionType).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_TourDirectionType(JObject jsonData) {
            var directionType = JEntity<Tour_DirectionType>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Update(directionType).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AllTourDirectionType(JObject jsonData) {
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AllDirectionType().JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_TourDirectionTypeById(JObject jsonData) {
            string id = Convert.ToString(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_DirectionTypeById(id).JsonSerialize())
            };
        }

        #endregion

        #region DOCUMENT TYPE                    .

        [HttpPost]
        public HttpResponseMessage Add_DocumentType(JObject jsonData) {
            var documentType = JEntity<Document_Type>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Add(documentType).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_DocumentType(JObject jsonData) {
            var documentType = JEntity<Document_Type>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Update(documentType).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AllDocumentType(JObject jsonData) {
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AllDocumentType().JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_DocumentTypeById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_DocumentTypeById(id).JsonSerialize())
            };
        }

        #endregion

        #region COUNTRY                    .

        [HttpPost]
        public HttpResponseMessage Add_Country(JObject jsonData) {
            var country = JEntity<Country>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Add(country).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_Country(JObject jsonData) {
            var country = JEntity<Country>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Update(country).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AllCountry(JObject jsonData) {
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AllCountry().JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_CountryById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_CountryById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_CountryByName(JObject jsonData) {
            string name = JsonData.Instance(jsonData).Get_JsonObject("name").ToString();
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_CountryByName(name).JsonSerialize())
            };
        }

        #endregion

        #region GENDER                    .

        [HttpPost]
        public HttpResponseMessage Get_AllGender(JObject jsonData) {
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AllGender().JsonSerialize())
            };
        }

        #endregion

        #region ACCOUNT RELATIVE TYPE                    .

        [HttpPost]
        public HttpResponseMessage Get_AllAccountRelativeType(JObject jsonData) {
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AllAccountRelativeType().JsonSerialize())
            };
        }

        #endregion

        #region RELIGION                    .

        [HttpPost]
        public HttpResponseMessage Add_Religion(JObject jsonData) {
            var religion = JEntity<Religion>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Add(religion).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_Religion(JObject jsonData) {
            var religion = JEntity<Religion>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Update(religion).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AllReligion(JObject jsonData) {
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AllReligion().JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_ReligionById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_ReligionById(id).JsonSerialize())
            };
        }

        #endregion

        #region SCHOOL TYPE                    .

        [HttpPost]
        public HttpResponseMessage Add_AccountSchoolType(JObject jsonData) {
            var accountSchoolType = JEntity<Account_SchoolType>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Add(accountSchoolType).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_AccountSchoolType(JObject jsonData) {
            var accountSchoolType = JEntity<Account_SchoolType>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Update(accountSchoolType).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AllAccountSchoolType(JObject jsonData) {
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AllSchoolType().JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AccountSchoolTypeById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_SchoolTypeById(id).JsonSerialize())
            };
        }

        #endregion

        #region SCHOOL POSITION                    .

        [HttpPost]
        public HttpResponseMessage Add_SchoolPosition(JObject jsonData) {
            var position = JEntity<Account_SchoolType>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Add(position).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_SchoolPosition(JObject jsonData) {
            var position = JEntity<Account_SchoolType>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Update(position).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AllSchoolPosition(JObject jsonData) {
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AllSchoolPosition().JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_SchoolPositionById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_SchoolPositionById(id).JsonSerialize())
            };
        }

        #endregion

        #region ACCOUNT INFOTITLE                   .

        [HttpPost]
        public HttpResponseMessage Add_AccountInfoTitle(JObject jsonData) {
            var accountInfoTitle = JEntity<Account_InfoTitle>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Add(accountInfoTitle).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_AccountInfoTitle(JObject jsonData) {
            var accountInfoTitle = JEntity<Account_InfoTitle>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Update(accountInfoTitle).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AllAccountInfoTitle(JObject jsonData) {
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AllAccountInfoTitles().JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AccountInfoTitleById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AccountTitleById(id).JsonSerialize())
            };
        }

        #endregion

        #region AIRPORTS                    .

        [HttpPost]
        public HttpResponseMessage Get_AllAirport(JObject jsonData) {
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AllAirport().JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AirportById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AirportById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AirportByAITA(JObject jsonData) {
            string aita = JsonData.Instance(jsonData).Get_JsonObject("aita").ToString();
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AirportByAITA(aita).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AirportByCity(JObject jsonData) {
            string city = JsonData.Instance(jsonData).Get_JsonObject("city").ToString();
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AirportByCity(city).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AirportLATByName(JObject jsonData) {
            string name = JsonData.Instance(jsonData).Get_JsonObject("name").ToString();
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AirportLATByName(name).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AirportByCityCountry(JObject jsonData) {
            string city = JsonData.Instance(jsonData).Get_JsonObject("city").ToString();
            string country = JsonData.Instance(jsonData).Get_JsonObject("country").ToString();
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AirportByCityCountry(city, country).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AirportByName(JObject jsonData) {
            string name = JsonData.Instance(jsonData).Get_JsonObject("name").ToString();
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AirportByName(name).JsonSerialize())
            };
        }


        #endregion

        #region BILLING PLAN                        .

        [HttpPost]
        public HttpResponseMessage Add_SettingBillingPlan(JObject jsonData) {
            var billingPlan = JEntity<Setting_Billing_Plan>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Add(billingPlan).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_SettingBillingPlan(JObject jsonData) {
            var billingPlan = JEntity<Setting_Billing_Plan>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Update(billingPlan).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AllSettingBillingPlan(JObject jsonData) {
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AllBillingPlans().JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_SettingBillingPlanById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_BillingPlanById(id).JsonSerialize())
            };
        }

        #endregion

        #region BILLING RENEWWAL CHARGE                        .

        [HttpPost]
        public HttpResponseMessage Add_SettingBillingRenewalCharge(JObject jsonData) {
            var billingCharge = JEntity<Setting_Billing_RenewalCharge>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Add(billingCharge).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_SettingBillingRenewalCharge(JObject jsonData) {
            var billingCharge = JEntity<Setting_Billing_RenewalCharge>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Update(billingCharge).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AllSettingBillingRenewalCharge(JObject jsonData) {
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AllBillingRenewalCharge().JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_SettingBillingRenewalChargeById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_BillingRenewalChargeById(id).JsonSerialize())
            };
        }

        #endregion

        #region BILLING CREDIT CARD TYPE                       .

        [HttpPost]
        public HttpResponseMessage Add_SettingCreditCardType(JObject jsonData) {
            var ccType = JEntity<Setting_CreditCardType>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Add(ccType).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_SettingCreditCardType(JObject jsonData) {
            var ccType = JEntity<Setting_CreditCardType>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Update(ccType).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AllSettingCreditCardType(JObject jsonData) {
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_AllCreditCardType().JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_SettingCreditCardTypeById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.Get_CreditCardTypeById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage CreateXML_CreditCardTypes(JObject jsonData) {
            return new HttpResponseMessage {
                Content = new StringContent(ReferenceService.CreateXML_CreditCardTypes().JsonSerialize())
            };
        }


        #endregion

    }
}
