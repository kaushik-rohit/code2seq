public static async Task<UploadimgMediaResult> UploadimgMediaAsync(string accessTokenOrAppKey, string media, int timeOut = Config.TIME_OUT)
        {
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/media/uploadimg?access_token={0}",
                accessToken.AsUrlData());

                var data = new
                {
                    media = media
                };

                return await Senparc.Weixin.CommonAPIs.CommonJsonSend.SendAsync<UploadimgMediaResult>(null, url, data, CommonJsonSendType.POST, timeOut);
            }, accessTokenOrAppKey);


        }