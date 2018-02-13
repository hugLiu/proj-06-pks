using Jurassic.CommonModels;
using PKS.Home.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PKS.Home.Controllers
{
    /// <summary>
    /// API服务，用于验证来自子站点的token，确信不是假冒。
    /// </summary>
    public class SSOVerifyController : ApiController
    {
        public bool Get(string s, string u, string t)
        {
            var tokenSerivce = SiteManager.Get<TokenService>();
            TokenInfo tokenInfo = tokenSerivce.GetToken(s);
            return tokenInfo != null && tokenInfo.UserName.Equals(u) && tokenInfo.Token.Equals(t);
        }
    }
}
