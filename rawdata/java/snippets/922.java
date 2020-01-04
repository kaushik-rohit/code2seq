protected GridPointers pointerizeOp(Op op, int... dimensions) {
        GridPointers pointers = new GridPointers(op, dimensions);

        AtomicAllocator allocator = AtomicAllocator.getInstance();

        //        CudaContext context = AtomicAllocator.getInstance().getFlowController().prepareAction(op.z(), op.x(), op.y());
        // FIXME: do not leave it as is
        CudaContext context = (CudaContext) allocator.getDeviceContext().getContext();

        pointers.setX(allocator.getPointer(op.x(), context));
        pointers.setXShapeInfo(allocator.getPointer(op.x().shapeInfoDataBuffer(), context));
        pointers.setZ(allocator.getPointer(op.z(), context));
        pointers.setZShapeInfo(allocator.getPointer(op.z().shapeInfoDataBuffer(), context));
        pointers.setZLength(op.z().length());

        if (op.y() != null) {
            pointers.setY(allocator.getPointer(op.y(), context));
            pointers.setYShapeInfo(allocator.getPointer(op.y().shapeInfoDataBuffer(), context));
        }

        if (dimensions != null && dimensions.length > 0) {
            DataBuffer dimensionBuffer = Nd4j.getConstantHandler().getConstantBuffer(dimensions, DataType.INT);
            pointers.setDimensions(allocator.getPointer(dimensionBuffer, context));
            pointers.setDimensionsLength(dimensions.length);
        }


        // we build TADs
        if (dimensions != null && dimensions.length > 0) {
            Pair<DataBuffer, DataBuffer> tadBuffers = tadManager.getTADOnlyShapeInfo(op.x(), dimensions);

            Pointer devTadShapeInfo = AtomicAllocator.getInstance().getPointer(tadBuffers.getFirst(), context);
            Pointer devTadOffsets = tadBuffers.getSecond() == null ? null
                    : AtomicAllocator.getInstance().getPointer(tadBuffers.getSecond(), context);

            // we don't really care, if tadOffsets will be nulls
            pointers.setTadShape(devTadShapeInfo);
            pointers.setTadOffsets(devTadOffsets);
        }


        return pointers;
    }