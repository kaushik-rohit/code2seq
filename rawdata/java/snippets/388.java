@Override
    public Table<AllocationStatus, Integer, Long> getAllocationStatistics() {
        Table<AllocationStatus, Integer, Long> table = HashBasedTable.create();
        table.put(AllocationStatus.HOST, 0, zeroUseCounter.get());
        for (Integer deviceId : configuration.getAvailableDevices()) {
            table.put(AllocationStatus.DEVICE, deviceId, getAllocatedDeviceMemory(deviceId));
        }
        return table;
    }