public static async Task<GetCountResult> GetCountAsync(string accessTokenOrAppKey, int agentId)
        {
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/material/get_count?access_token={0}&agentid={1}",
                accessToken.AsUrlData(), agentId);

                return await Senparc.Weixin.CommonAPIs.CommonJsonSend.SendAsync<GetCountResult>(null, url, null, CommonJsonSendType.GET);
            }, accessTokenOrAppKey);

        }