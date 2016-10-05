using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Web.Http;
using Ugroop.API.SQL.Helper.Json;
using UGroopData.Sql.Repository.Data;
using UGroopData.Sql.Service.UGroopWeb.Interface;

namespace Ugroop.API.SQL.Controllers {
    public class SettingController : SecurityController {

        public SettingController(IUserService userService, ISettingService settingService) : base(userService, settingService) { }

        #region ABOUT YOU                    .

        [HttpPost]
        public HttpResponseMessage Add_SettingAboutYou(JObject jsonData) {
            var aboutyou = JEntity<Setting_Aboutyou>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Add(aboutyou).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_SettingAboutYou(JObject jsonData) {
            var aboutyou = JEntity<Setting_Aboutyou>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Update(aboutyou).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AboutyouById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Get_AboutyouById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_AboutyouByAccountId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Get_AboutyouByAccountId(id).JsonSerialize())
            };
        }

        #endregion

        #region PUBLISHING                    .

        [HttpPost]
        public HttpResponseMessage Add_SettingPublishing(JObject jsonData) {
            var publishing = JEntity<Setting_Publishing>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Add(publishing).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_SettingPublishing(JObject jsonData) {
            var publishing = JEntity<Setting_Publishing>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Update(publishing).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_SettingPublishingById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Get_SettingPublishingById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_SettingPublishingByAccountId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Get_SettingPublishingByAccountId(id).JsonSerialize())
            };
        }




        #endregion

        #region EMAIL                    .

        [HttpPost]
        public HttpResponseMessage Add_SettingEmail(JObject jsonData) {
            var email = JEntity<Setting_Email>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Add(email).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_SettingEmail(JObject jsonData) {
            var email = JEntity<Setting_Email>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Update(email).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_SettingEmailById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Get_SettingEmailById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_SettingEmailByAccountId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Get_SettingEmailByAccountId(id).JsonSerialize())
            };
        }

        #endregion

        #region OTHER EMAIL                    .

        [HttpPost]
        public HttpResponseMessage Add_OtherEmail(JObject jsonData) {
            var otherEmail = JEntity<Other_Email>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Add(otherEmail).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_OtherEmail(JObject jsonData) {
            var otherEmail = JEntity<Other_Email>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Update(otherEmail).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_OtherEmailById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Get_OtherEmailById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_OtherEmailByAccountId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Get_OtherEmailByAccountId(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_OtherEmailByAccountId_First(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Get_OtherEmailByAccountId_First(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_OtherEmailByEmail(JObject jsonData) {
            string email = JsonData.Instance(jsonData).Get_JsonObject("id").ToString();
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Get_OtherEmailByEmail(email).JsonSerialize())
            };
        }




        #endregion

        #region YOUR PROFILE                    .

        [HttpPost]
        public HttpResponseMessage Add_SettingYourProfile(JObject jsonData) {
            var profile = JEntity<Setting_YourProfile>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Add(profile).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_SettingYourProfile(JObject jsonData) {
            var profile = JEntity<Setting_YourProfile>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Update(profile).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_SettingProfileById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Get_SettingProfileById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_SettingProfileByAccountId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Get_SettingProfileByAccountId(id).JsonSerialize())
            };
        }

        #endregion

        #region BILLING                    .

        [HttpPost]
        public HttpResponseMessage Add_SettingBilling(JObject jsonData) {
            var billing = JEntity<Setting_Billing>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Add(billing).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Update_SettingBilling(JObject jsonData) {
            var billing = JEntity<Setting_Billing>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Update(billing).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_SettingBillingById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Get_SettingBillingById(id).JsonSerialize())
            };
        }

        [HttpPost]
        public HttpResponseMessage Get_SettingBillinByAccountId(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(SettingService.Get_SettingBillinByAccountId(id).JsonSerialize())
            };
        }

        #endregion

    }
}
