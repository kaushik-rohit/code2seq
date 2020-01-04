public static MapBlock fromKeyValueBlock(
            Optional<boolean[]> mapIsNull,
            int[] offsets,
            Block keyBlock,
            Block valueBlock,
            MapType mapType,
            MethodHandle keyBlockNativeEquals,
            MethodHandle keyNativeHashCode,
            MethodHandle keyBlockHashCode)
    {
        validateConstructorArguments(0, offsets.length - 1, mapIsNull.orElse(null), offsets, keyBlock, valueBlock, mapType.getKeyType(), keyBlockNativeEquals, keyNativeHashCode);

        int mapCount = offsets.length - 1;

        return createMapBlockInternal(
                0,
                mapCount,
                mapIsNull,
                offsets,
                keyBlock,
                valueBlock,
                new HashTables(Optional.empty(), keyBlock.getPositionCount() * HASH_MULTIPLIER),
                mapType.getKeyType(),
                keyBlockNativeEquals,
                keyNativeHashCode,
                keyBlockHashCode);
    }