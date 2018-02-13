using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PKS.Home.Models
{
    /// <summary>
    /// 管理所有Token的服务类,必须为单例
    /// </summary>
    public class TokenService
    {
        private ConcurrentDictionary<string, TokenInfo> _refreshTokens = new ConcurrentDictionary<string, TokenInfo>();
        private DateTime LastClearTime = DateTime.Now;

        public virtual TokenInfo GetToken(string sessionId)
        {
            TokenInfo tokenInfo = null;
            _refreshTokens.TryGetValue(sessionId, out tokenInfo);
            return tokenInfo;
        }

        public virtual TokenInfo AddToken(string sessionId, string name, string token)
        {
            _refreshTokens[sessionId] = new TokenInfo
            {
                SessionId = sessionId,
                Token = token,
                Time = DateTime.Now,
                UserName = name,
            };

            //定期清理过期的token
            if (_refreshTokens.Count > 10000 || (DateTime.Now - LastClearTime).TotalMinutes > 5)
            {
                ClearAbsoluteTokens();
            }
            return GetToken(sessionId);
        }

        public virtual TokenInfo RemoveToken(string currentSessionId)
        {
            TokenInfo temp = null;
            _refreshTokens.TryRemove(currentSessionId, out temp);
            return temp;
        }

        private void ClearAbsoluteTokens()
        {
            foreach (var tokenInfo in _refreshTokens.ToList())
            {
                if (tokenInfo.Value.Time < LastClearTime)
                {
                    RemoveToken(tokenInfo.Key);
                }
            }
        }
    }

    public class TokenInfo
    {
        public string SessionId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }

        public DateTime Time { get; set; }
    }
}