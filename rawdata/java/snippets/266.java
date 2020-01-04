static String getRelativeNameFrom(String itemFullName, String groupFullName) {
        String[] itemFullNameA = itemFullName.isEmpty() ? MemoryReductionUtil.EMPTY_STRING_ARRAY : itemFullName.split("/");
        String[] groupFullNameA = groupFullName.isEmpty() ? MemoryReductionUtil.EMPTY_STRING_ARRAY : groupFullName.split("/");
        for (int i = 0; ; i++) {
            if (i == itemFullNameA.length) {
                if (i == groupFullNameA.length) {
                    // itemFullName and groupFullName are identical
                    return ".";
                } else {
                    // itemFullName is an ancestor of groupFullName; insert ../ for rest of groupFullName
                    StringBuilder b = new StringBuilder();
                    for (int j = 0; j < groupFullNameA.length - itemFullNameA.length; j++) {
                        if (j > 0) {
                            b.append('/');
                        }
                        b.append("..");
                    }
                    return b.toString();
                }
            } else if (i == groupFullNameA.length) {
                // groupFullName is an ancestor of itemFullName; insert rest of itemFullName
                StringBuilder b = new StringBuilder();
                for (int j = i; j < itemFullNameA.length; j++) {
                    if (j > i) {
                        b.append('/');
                    }
                    b.append(itemFullNameA[j]);
                }
                return b.toString();
            } else if (itemFullNameA[i].equals(groupFullNameA[i])) {
                // identical up to this point
                continue;
            } else {
                // first mismatch; insert ../ for rest of groupFullName, then rest of itemFullName
                StringBuilder b = new StringBuilder();
                for (int j = i; j < groupFullNameA.length; j++) {
                    if (j > i) {
                        b.append('/');
                    }
                    b.append("..");
                }
                for (int j = i; j < itemFullNameA.length; j++) {
                    b.append('/').append(itemFullNameA[j]);
                }
                return b.toString();
            }
        }
    }