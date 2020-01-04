private static <T> void _logResult(T result, int level, int indentSize, StringBuilder info) {
        if(result instanceof Map) {
            level += 1;
            int finalLevel = level;
            ((Map)result).forEach((k, v) -> {
                info.append("\n");
                info.append(getTabBasedOnLevel(finalLevel, indentSize))
                        .append(k.toString())
                        .append(":");
                _logResult(v, finalLevel, indentSize, info);
            });
        } else if(result instanceof List) {
            int finalLevel = level;
            ((List)result).forEach(element -> _logResult(element, finalLevel, indentSize, info));
        } else if(result instanceof String) {
            info.append(" ").append(result);
        } else if(result != null) {
            try {
                logger.warn(getTabBasedOnLevel(level, indentSize) + "{}", result);
            } catch (Exception e) {
                logger.error("Cannot handle this type: {}", result.getClass().getTypeName());
            }
        }
    }