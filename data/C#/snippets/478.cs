public static async Task<UploadForeverResultJson> UpdateMpNewsAsync(string accessTokenOrAppKey, string mediaId, int agentId, int timeOut = Config.TIME_OUT, params MpNewsArticle[] mpNewsArticles)
        {
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/material/update_mpnews?access_token={0}",
                accessToken.AsUrlData());

                var data = new
                {
                    agentid = agentId,
                    media_id = mediaId,
                    mpnews = new
                    {
                        articles = mpNewsArticles
                    }
                };

                return await Senparc.Weixin.CommonAPIs.CommonJsonSend.SendAsync<UploadForeverResultJson>(null, url, data, CommonJsonSendType.POST, timeOut);
            }, accessTokenOrAppKey);

        }