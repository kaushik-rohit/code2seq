public static int[] validate3NonNegative(int[] data, String paramName){
        validateNonNegative(data, paramName);
        return validate3(data, paramName);
    }