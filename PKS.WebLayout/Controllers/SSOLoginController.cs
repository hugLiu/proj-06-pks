using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Jurassic.Com.Tools;
using System.Net.Http;
using System.Threading.Tasks;

namespace PKS.WebLayout.Controllers
{
    /// <summary>
    /// SSO单点登录控制器
    /// </summary>
    public class SSOLoginController : Controller
    {
        /// <summary>
        /// SSO单点登录入口，用于验证token，并通过后跳转到当前站点首页
        /// </summary>
        /// <param name="u">用户名</param>
        /// <param name="t">token</param>
        /// <param name="s">SessionID</param>
        /// <param name="r">重定向到首页的地址</param>
        /// <returns></returns>
        public ActionResult Index(string u, string s, string t, string r)
        {
            if (r.IsEmpty() || u.IsEmpty() || t.IsEmpty())
            {
                throw new ArgumentNullException("rust");
            }
            if (VerifyToken(u, s, t))
            {
                FormsAuthentication.SetAuthCookie(u, false);
                return Redirect(r);
            }
            else
            {
                throw new UnauthorizedAccessException("Access Denied");
            }
        }

        string _verifyUrl = "http://localhost:5313/api/SSOVerify?s={0}&u={1}&t={2}";
        private bool VerifyToken(string userName, string session, string token)
        {
            using (HttpClient client =new HttpClient())
            {
                var url = String.Format(_verifyUrl, session, userName, token);
                var response = client.GetAsync(url).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                var r =  response.Content.ReadAsStringAsync().Result;
                return CommOp.ToBool(r);
            }
        }
    }
}