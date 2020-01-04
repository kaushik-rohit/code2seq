public static char order(DataBuffer buffer) {
        int length = Shape.shapeInfoLength(Shape.rank(buffer));
        return (char) buffer.getInt(length - 1);
    }