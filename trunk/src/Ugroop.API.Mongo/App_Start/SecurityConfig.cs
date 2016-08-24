using Microsoft.AspNet.Identity;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ugroop.API.App_Start {
    public class SecurityConfig {

        public static void Configure(IAppBuilder app) {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = DefaultAuthenticationTypes.ExternalCookie
            });

            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            //// Configure google authentication
            //var options = new GoogleOAuth2AuthenticationOptions() {
            //    ClientId = "714769234949-dsrgrsvnhnomlj2l0vk4mr0m8s4ra6hj.apps.googleusercontent.com",
            //    ClientSecret = "wnLCPABZFdelTUgTMN3ULbF4"
            //};

            //app.UseGoogleAuthentication(options);
        }

    }
}