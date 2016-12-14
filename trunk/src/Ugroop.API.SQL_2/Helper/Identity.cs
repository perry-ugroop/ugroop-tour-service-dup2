using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Ugroop.API.SQL_2.Helper {
    public class Identity {
        public static string Role() {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            return claims.FirstOrDefault(x => x.Type == identity.RoleClaimType).Value;
        }

        public static int RoleId() {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var rolename = claims.FirstOrDefault(x => x.Type == identity.RoleClaimType).Value;
            return (int)(RoleName)Enum.Parse(typeof(RoleName), rolename);
        }
    }

    public enum RoleName {
        Administrator = 1,
        Organiser = 2,
        Participant = 3,
        Viewer = 4
    }

}