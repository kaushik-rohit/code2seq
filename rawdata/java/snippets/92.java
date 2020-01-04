public static CodeBlock join(Iterable<CodeBlock> codeBlocks, String separator) {
    return StreamSupport.stream(codeBlocks.spliterator(), false).collect(joining(separator));
  }