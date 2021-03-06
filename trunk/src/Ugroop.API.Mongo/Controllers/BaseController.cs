﻿using System.Web.Http;
using System.Web.Http.Cors;
using UGroopData.Mongo.Service.UGroopWeb.Interface;

namespace Ugroop.API.Mongo.Controllers {

    [EnableCors(origins: "http://localhost:46013", headers: " * ", methods: "*")]
    public class BaseController : ApiController {

        private IAccountService _accountService;
        private IReferenceService _referenceService;
        private ISettingService _settingService;

        public IAccountService AccountService {
            get { return _accountService; }
        }

        public IReferenceService ReferenceService {
            get { return _referenceService; }
        }

        public ISettingService SettingService {
            get { return _settingService; }
        }

        public BaseController(IAccountService accountService) {
            _accountService = accountService;
        }

        public BaseController(IAccountService accountService, IReferenceService referenceService) {
            _accountService = accountService;
            _referenceService = referenceService;
        }

        public BaseController(IAccountService accountService, IReferenceService referenceService, ISettingService settingService) {
            _accountService = accountService;
            _referenceService = referenceService;
            _settingService = settingService;
        }

    }

}
