public final Tenant getTenant(TenantName name) {

    GetTenantRequest request =
        GetTenantRequest.newBuilder().setName(name == null ? null : name.toString()).build();
    return getTenant(request);
  }