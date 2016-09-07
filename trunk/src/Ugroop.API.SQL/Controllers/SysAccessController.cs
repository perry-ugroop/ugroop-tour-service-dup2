using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ugroop.API.SQL.Helper.Json;
using UGroopData.Sql.Repository.Data;
using UGroopData.Sql.Service.UGroopWeb.Interface;

namespace Ugroop.API.SQL.Controllers
{
    public class SysAccessController : SecurityController {

        public SysAccessController(IUserService userService, ISysAccessService sysAccessService) : base(userService, sysAccessService) { }

        #region SYS PAGE                   .

        ///<summary>
        ///POST : Add Sys_Page
        ///</summary>
        ///<remarks>
        ///Add new Sys_Page in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Add_AccountInfo(JObject jsonData) {
            var sysPage = JEntity<Sys_Page>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(SysAccessService.Add(sysPage).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Update Sys_Page
        ///</summary>
        ///<remarks>
        ///Update Sys_Page in database.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Update_AccountInfo(JObject jsonData) {
            var sysPage = JEntity<Sys_Page>.Instance().Get_Entity(jsonData);
            return new HttpResponseMessage {
                Content = new StringContent(SysAccessService.Update(sysPage).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_AllSysPages
        ///</summary>
        ///<remarks>
        ///Returns all List<Sys_Page>.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_AllSysPages(JObject jsonData) {
            return new HttpResponseMessage {
                Content = new StringContent(SysAccessService.Get_AllSysPages().JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_SysPageById (id)
        ///</summary>
        ///<remarks>
        ///Returns Sys_Page By Id.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_SysPageById(JObject jsonData) {
            int id = Convert.ToInt32(JsonData.Instance(jsonData).Get_JsonObject("id"));
            return new HttpResponseMessage {
                Content = new StringContent(SysAccessService.Get_SysPageById(id).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_SysPageByNameAndGroup (name,group)
        ///</summary>
        ///<remarks>
        ///Returns Sys_Page By Name and Group.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_SysPageByNameAndGroup(JObject jsonData) {
            string name = JsonData.Instance(jsonData).Get_JsonObject("name").ToString();
            string group = JsonData.Instance(jsonData).Get_JsonObject("group").ToString();
            return new HttpResponseMessage {
                Content = new StringContent(SysAccessService.Get_SysPageByNameAndGroup(name,group).JsonSerialize())
            };
        }

        ///<summary>
        ///POST : Get_SysPageByGroup (group)
        ///</summary>
        ///<remarks>
        ///Returns Sys_Page By Group.
        ///</remarks>
        [HttpPost]
        public HttpResponseMessage Get_SysPageByGroup(JObject jsonData) {
            string group = JsonData.Instance(jsonData).Get_JsonObject("group").ToString();
            return new HttpResponseMessage {
                Content = new StringContent(SysAccessService.Get_SysPageByGroup(group).JsonSerialize())
            };
        }

        #endregion


        #region SYS PERMISSION                   .




        #endregion

    }
}
