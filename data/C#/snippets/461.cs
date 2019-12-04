public static UploadimgMediaResult UploadimgMedia(string accessTokenOrAppKey, string media, int timeOut = Config.TIME_OUT)
        {
            return ApiHandlerWapper.TryCommonApi(accessToken =>
            {
                var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/media/uploadimg?access_token={0}",
                accessToken.AsUrlData());

                var data = new
                {
                    media = media
                };

                return CommonJsonSend.Send<UploadimgMediaResult>(null, url, data, CommonJsonSendType.POST, timeOut);
            }, accessTokenOrAppKey);


        }