public static ServiceClientHandle DangerousCreate(System.IntPtr unsafeHandle, bool ownsHandle)
        {
            ServiceClientHandle safeHandle = new ServiceClientHandle(ownsHandle);
            safeHandle.SetHandle(unsafeHandle);
            return safeHandle;
        }