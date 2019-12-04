public static async Task<UploadTemporaryResultJson> UploadAsync(string accessTokenOrAppKey, UploadMediaFileType type, string media, int timeOut = Config.TIME_OUT)
        {
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}", accessToken.AsUrlData(), type.ToString());
                var fileDictionary = new Dictionary<string, string>();
                fileDictionary["media"] = media;
                return await Post.PostFileGetJsonAsync<UploadTemporaryResultJson>(url, null, fileDictionary, null, null, null, timeOut);
            }, accessTokenOrAppKey);

        }