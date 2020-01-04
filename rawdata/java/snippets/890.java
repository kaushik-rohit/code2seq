public final Finding getFinding(FindingName name) {

    GetFindingRequest request =
        GetFindingRequest.newBuilder().setName(name == null ? null : name.toString()).build();
    return getFinding(request);
  }