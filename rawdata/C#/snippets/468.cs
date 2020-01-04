public static async Task<UploadForeverResultJson> AddMaterialAsync(string accessTokenOrAppKey, UploadMediaFileType type, int agentId, string media, int timeOut = Config.TIME_OUT)
        {
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/material/add_material?agentid={1}&type={2}&access_token={0}", accessToken.AsUrlData(), agentId, type);
                var fileDictionary = new Dictionary<string, string>();
                fileDictionary["media"] = media;
                return await Post.PostFileGetJsonAsync<UploadForeverResultJson>(url, null, fileDictionary, null, null, null, timeOut);
            }, accessTokenOrAppKey);

        }