private String resolveTemplate(AnnotationValue<Client> clientAnnotation, String templateString) {
        String path = clientAnnotation.get("path", String.class).orElse(null);
        if (StringUtils.isNotEmpty(path)) {
            return path + templateString;
        } else {
            String value = clientAnnotation.getValue(String.class).orElse(null);
            if (StringUtils.isNotEmpty(value)) {
                if (value.startsWith("/")) {
                    return value + templateString;
                }
            }
            return templateString;
        }
    }