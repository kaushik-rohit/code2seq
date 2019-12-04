public static object ResolveItem(this IHttpRequest httpReq,
			string itemKey, Func<IHttpRequest, object> resolveFn)
		{
			object cachedItem;
			if (httpReq.Items.TryGetValue(itemKey, out cachedItem))
				return cachedItem;

			var item = resolveFn(httpReq);
			httpReq.Items[itemKey] = item;

			return item;
		}