using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using PlotHooks.Models;

namespace PlotHooks
{
	public static class AuthConfig
	{
		public static void RegisterAuth()
		{
			// To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
			// you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

			//OAuthWebSecurity.RegisterMicrosoftClient(
			//    clientId: "",
			//    clientSecret: "");

			//OAuthWebSecurity.RegisterTwitterClient(
			//    consumerKey: "",
			//    consumerSecret: "");

			OAuthWebSecurity.RegisterFacebookClient(
				appId: "312047959006526",
				appSecret: "680c346176f3deb321ef94f28cbb2ff5");

			//OAuthWebSecurity.RegisterGoogleClient();
		}
	}
}
