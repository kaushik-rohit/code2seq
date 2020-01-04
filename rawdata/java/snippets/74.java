public final ClassifyTextResponse classifyText(Document document) {

    ClassifyTextRequest request = ClassifyTextRequest.newBuilder().setDocument(document).build();
    return classifyText(request);
  }