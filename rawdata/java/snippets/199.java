public long getPreciseFreeMemory(int deviceId) {
        // we refresh free memory on device
        val extFree = NativeOpsHolder.getInstance().getDeviceNativeOps().getDeviceFreeMemory(deviceId);
        //freePerDevice.get(deviceId).set(extFree);

        return extFree;
    }