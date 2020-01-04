public static async Task GetAsync(string accessTokenOrAppKey, string mediaId, Stream stream)
        {
            await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}",
                accessToken.AsUrlData(), mediaId.AsUrlData());
                await HttpUtility.Get.DownloadAsync(url, stream);//todo 异常处理
                return new QyJsonResult() { errcode = ReturnCode_QY.请求成功, errmsg = "ok" };
            }, accessTokenOrAppKey);


        }