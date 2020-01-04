@Override
    public void synchronizeToHost(AllocationPoint point) {

        if (!point.isActualOnHostSide()) {
            CudaContext context = (CudaContext) allocator.getDeviceContext().getContext();

            if (!point.isConstant())
                waitTillFinished(point);

            //  log.info("Synchronization started... " + point.getShape());

            // if this piece of memory is device-dependant, we'll also issue copyback once
            if (point.getAllocationStatus() == AllocationStatus.DEVICE && !point.isActualOnHostSide()) {

                long perfD = PerformanceTracker.getInstance().helperStartTransaction();

                if (nativeOps.memcpyAsync(point.getHostPointer(), point.getDevicePointer(), AllocationUtils.getRequiredMemory(point.getShape()), CudaConstants.cudaMemcpyDeviceToHost, context.getSpecialStream()) == 0)
                    throw new IllegalStateException("MemcpyAsync failed: " + point.getShape());

                commitTransfer(context.getSpecialStream());

                PerformanceTracker.getInstance().helperRegisterTransaction(point.getDeviceId(), perfD, point.getNumberOfBytes(), MemcpyDirection.DEVICE_TO_HOST);
            } // else log.info("Not [DEVICE] memory, skipping...");


            // updating host read timer
            point.tickHostRead();
            //log.info("After sync... isActualOnHostSide: {}", point.isActualOnHostSide());
        } // else log.info("Point is actual on host side! " + point.getShape());
    }