public static async Task<QyJsonResult> DeleteForeverMaterialAsync(string accessTokenOrAppKey, int agentId, string mediaId)
        {
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url =
                string.Format(
                    "https://qyapi.weixin.qq.com/cgi-bin/material/del?access_token={0}&agentid={1}&media_id={2}",
                    accessToken.AsUrlData(), agentId, mediaId.AsUrlData());

                return await Senparc.Weixin.CommonAPIs.CommonJsonSend.SendAsync<QyJsonResult>(null, url, null, CommonJsonSendType.GET);
            }, accessTokenOrAppKey);


        }