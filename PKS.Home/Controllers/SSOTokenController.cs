using Jurassic.Com.Tools;
using Jurassic.WebFrame;
using PKS.Home.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PKS.Home.Controllers
{
    /// <summary>
    /// 在主站点进行TOKEN的分发到分站点控制器
    /// </summary>
    public class SSOTokenController : BaseController
    {
        private TokenService _tokenService;

        public SSOTokenController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }
        /// <summary>
        /// 形成包含用户名和token的数据，直接作为js发送到请求方，回避跨域问题
        /// 如果用户没有登录，则返回空串
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            TokenInfo tokenInfo = null;
            if (User.Identity.IsAuthenticated)
            {
                tokenInfo = _tokenService.GetToken(CurrentSessionId);
                if (tokenInfo == null)
                {
                    var token = CommOp.NewId();
                    tokenInfo = _tokenService.AddToken(this.CurrentSessionId, User.Identity.Name, token);
                }
            }
            else
            {
                tokenInfo = new TokenInfo();
                _tokenService.RemoveToken(CurrentSessionId);
            }
            return Content(String.Format(@"var _ssoToken = '{0}'; var _ssoSession='{1}'; var _ssoUser = '{2}';",
                tokenInfo.Token, tokenInfo.SessionId, tokenInfo.UserName), "text/javasript");
        }

    }
}