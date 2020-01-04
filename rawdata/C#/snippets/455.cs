public static string Get(string accessTokenOrAppKey, string mediaId, string dir)
        {
            var result = ApiHandlerWapper.TryCommonApi(accessToken =>
            {
                var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}", accessToken.AsUrlData(), mediaId.AsUrlData());
                var fileName =  HttpUtility.Get.Download(url, dir);
                return new QyJsonResult() { errcode = ReturnCode_QY.请求成功, errmsg = fileName };

            }, accessTokenOrAppKey);

            return result.errmsg;
        }