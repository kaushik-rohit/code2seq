private void writeBeanDefinitionsToMetaInf() {
        try {
            classWriterOutputVisitor.finish();
        } catch (Exception e) {
            String message = e.getMessage();
            error("Error occurred writing META-INF files: %s", message != null ? message : e);
        }
    }