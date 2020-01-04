public final ListProductsPagedResponse listProducts(String parent) {
    ListProductsRequest request = ListProductsRequest.newBuilder().setParent(parent).build();
    return listProducts(request);
  }