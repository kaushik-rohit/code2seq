public static async Task<GetForeverMpNewsResult> GetForeverMpNewsAsync(string accessTokenOrAppKey, int agentId, string mediaId)
        {
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url =
                string.Format(
                    "https://qyapi.weixin.qq.com/cgi-bin/material/get?access_token={0}&media_id={1}&agentid={2}",
                    accessToken.AsUrlData(), mediaId.AsUrlData(), agentId);

                return await Senparc.Weixin.CommonAPIs.CommonJsonSend.SendAsync<GetForeverMpNewsResult>(null, url, null, CommonJsonSendType.GET);
            }, accessTokenOrAppKey);

        }