2017/6/14
1. PKS.Home和PKS.KnowledgeBank都通过路由配置了首页登录后直接进
2. 因为同域名下cookie相同，所以PKS.KnowledgeBank使用IIS的127.0.0.1访问以和localhost区别开来。
3. 使用IIS进行调试需要VS2015以管理员身份运行