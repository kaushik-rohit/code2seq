[Action("api/product_rating/search", HttpMethods.POST)]
		public IActionResult Ratings(Guid id) {
			var json = Request.Get<string>("json");
			var request = AjaxTableSearchRequest.FromJson(json);
			var handlers = new ProductRatingTableHandler().WithExtraHandlers();
			var response = request.BuildResponse(handlers);
			return new JsonResult(response);
		}