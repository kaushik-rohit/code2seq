public static async Task<BatchGetMaterialResult> BatchGetMaterialAsync(string accessTokenOrAppKey, UploadMediaFileType type, int agentId, int offset, int count, int timeOut = Config.TIME_OUT)
        {
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/material/batchget?access_token={0}",
                accessToken.AsUrlData());

                var data = new
                {
                    type = type.ToString(),
                    agentid = agentId,
                    offset = offset,
                    count = count,
                };

                return await Senparc.Weixin.CommonAPIs.CommonJsonSend.SendAsync<BatchGetMaterialResult>(null, url, data, CommonJsonSendType.POST, timeOut);
            }, accessTokenOrAppKey);

        }