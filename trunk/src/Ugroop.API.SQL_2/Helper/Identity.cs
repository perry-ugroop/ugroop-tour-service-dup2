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
    }

    public enum RoleName {
        UGGroup_SuperAdmin = 1,
        UGGroup_OrgAdmin = 2,
        UGGroup_Participant = 3,
        UGGroup_Viewer = 4
    }

}